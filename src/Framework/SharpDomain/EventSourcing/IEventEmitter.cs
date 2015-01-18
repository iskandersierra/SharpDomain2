using System;

namespace SharpDomain.EventSourcing
{
    public interface IEventEmitter
    {
        void Emit<TEvent>(Action<TEvent> setupEvent) 
            where TEvent : class, IDomainEvent;
    }
}
