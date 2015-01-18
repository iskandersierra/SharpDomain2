using System;
using NUnit.Framework;
using SharpDomain.EventSourcing;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Contacts.CommandProcessing
{
    [Binding]
    public class EventSourcedSteps
    {
        [When(@"The event is appended to the entity")]
        public void WhenTheContactCreatedEventIsAppendedToTheContact()
        {
            var entity = ScenarioContext.Current.Get<EventSourced>();
            var e = ScenarioContext.Current.Get<IDomainEvent>();

            entity.AppendEvent(e);
        }
        [When(@"The event is applied to the entity")]
        public void WhenTheContactCreatedEventIsAppliedToTheContact()
        {
            var entity = ScenarioContext.Current.Get<EventSourced>();
            var e = ScenarioContext.Current.Get<IDomainEvent>();

            ((IEventSourced)entity).ApplyCommittedEvent(e);
        }

        public static void AppendEvent<TEvent>(Table table) where TEvent : class, IDomainEvent
        {
            var ev = table.CreateInstance<TEvent>();
            var entity = ScenarioContext.Current.Get<EventSourced>();
            entity.AppendEvent(ev);
        }
    }
}