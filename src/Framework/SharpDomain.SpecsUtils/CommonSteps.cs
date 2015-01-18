using System;
using NUnit.Framework;
using SharpDomain.Commanding;
using SharpDomain.EventSourcing;
using SharpDomain.SpecsUtils.EventSourcing;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SharpDomain.SpecsUtils
{
    public abstract class CommonSteps
    {
        protected T Get<T>()
        {
            return ScenarioContext.Current.Get<T>();
        }
        protected T Get<T>(string key)
        {
            return ScenarioContext.Current.Get<T>(key);
        }
        protected void Set<T>(T value)
        {
            ScenarioContext.Current.Set<T>(value);
        }
        protected void Set<T>(T value, string key)
        {
            ScenarioContext.Current.Set<T>(value, key);
        }
        protected string OrNull(string value)
        {
            if (value == null || value == "<null>") return null;
            return value;
        }

        protected void RunExceptionControlledStep(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                ScenarioContext.Current.Set(exception);
            }
        }

        protected EventSourced GivenEntity<TEntity>()
            where TEntity : EventSourced, new()
        {
            var eventSourced = new TEntity();
            Set(eventSourced);
            Set<EventSourced>(eventSourced);
            return eventSourced;
        }
        protected TCommandProcessor GivenCommandProcessor<TCommandProcessor>(Action<TCommandProcessor> setupProcessor = null)
            where TCommandProcessor : class, ICommandToEventProcessor, new()
        {
            var eventEmitter = GivenEventEmitter();
            var processor = new TCommandProcessor
            {
                Events = eventEmitter,
            };
            if (setupProcessor != null)
                setupProcessor(processor);
            Set(processor);
            return processor;
        }
        protected IEventEmitter GivenEventEmitter()
        {
            var mock = new EventEmitterMock();
            Set(mock);
            Set<IEventEmitter>(mock);
            return mock;
        }

        protected void WhenCommandProcessed<TCommandProcessor, TCommand>(Table table)
            where TCommandProcessor : class, ICommandProcessor<TCommand> 
            where TCommand : class, IDomainCommand
        {
            var processor = Get<TCommandProcessor>();
            var command = table.CreateInstance<TCommand>();
            processor.Process(command);
        }

        protected void AssertIsExpected<TResult, TExpected>(Table table, Action<TResult, TExpected> assertActions)
        {
            if (assertActions == null) throw new ArgumentNullException("assertActions");
            var expected = table.CreateInstance<TExpected>();
            var entity = Get<TResult>();
            assertActions(entity, expected);
        }
        protected void AssertIsExpected<TResult>(Table table, Action<TResult, TResult> assertActions)
        {
            if (assertActions == null) throw new ArgumentNullException("assertActions");
            AssertIsExpected<TResult, TResult>(table, assertActions);
        }
        protected void AssertIsEmitted<TEvent, TExpected>(int position, Table table, Action<TEvent, TExpected> assertActions)
            where TEvent : class, IDomainEvent
            where TExpected : class, TEvent
        {
            if (assertActions == null) throw new ArgumentNullException("assertActions");

            var emitter = Get<EventEmitterMock>();
            var expected = table.CreateInstance<TExpected>();

            Assert.That(position, Is.LessThan(emitter.EmittedEvents.Count));
            Assert.That(emitter.EmittedEvents[position], Is.InstanceOf<TEvent>());
            var ev = (TEvent)emitter.EmittedEvents[position];

            assertActions(ev, expected);
        }
        protected void AssertIsEmitted<TEvent>(int position, Table table, Action<TEvent, TEvent> assertActions)
            where TEvent : class, IDomainEvent
        {
            if (assertActions == null) throw new ArgumentNullException("assertActions");
            AssertIsEmitted<TEvent, TEvent>(position, table, assertActions);
        }


        protected void ApplyEvent<TEvent>(Table table) where TEvent : class, IDomainEvent
        {
            var ev = table.CreateInstance<TEvent>();
            var entity = ScenarioContext.Current.Get<EventSourced>();
            RunExceptionControlledStep(() =>
                ((IEventSourced)entity).ApplyCommittedEvent(ev)
            );
        }
        protected void WhenAppendEvent<TEvent>(Table table) where TEvent : class, IDomainEvent
        {
            var ev = table.CreateInstance<TEvent>();
            var entity = ScenarioContext.Current.Get<EventSourced>();
            RunExceptionControlledStep(() =>
                entity.AppendEvent(ev)
            );
        }
    }

    [Binding]
    public abstract class CommonExceptionSteps
    {
        [Then(@"an argument out of range exception is raised")]
        public void ThenAnArgumentOutOfRangeExceptionIsRaised()
        {
            AnExceptionIsRaised<ArgumentOutOfRangeException>();
        }

        [Then(@"an argument null exception is raised")]
        public void ThenAnArgumentNullExceptionIsRaised()
        {
            AnExceptionIsRaised<ArgumentNullException>();
        }

        [Then(@"an invalid operation exception is raised")]
        public void ThenAnInvalidOperationExceptionIsRaised()
        {
            AnExceptionIsRaised<InvalidOperationException>();
        }

        private static void AnExceptionIsRaised<TException>() where TException : Exception
        {
            Exception exception;
            Assert.That(ScenarioContext.Current.TryGetValue(out exception), Is.True);
            Assert.That(exception, Is.InstanceOf<TException>());
        }
    }


}
