using System;
using SharpDomain.EventSourcing;

namespace SharpDomain.Commanding
{
    public abstract class CommandToEventProcessor<TCommand> :
        CommandProcessorBase<TCommand>,
        ICommandToEventProcessor
        where TCommand : class, IDomainCommand
    {
        public IEventEmitter Events { get; set; }

        protected void Emit<TEvent>(Action<TEvent> setupEvent)
            where TEvent : class, IDomainEvent
        {
            Events.Emit(setupEvent);
        }
        protected void Emit<TEvent>()
            where TEvent : class, IDomainEvent
        {
            Events.Emit(default(Action<TEvent>));
        }
    }
}
