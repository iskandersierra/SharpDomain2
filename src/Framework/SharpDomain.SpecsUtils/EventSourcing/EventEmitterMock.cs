using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SharpDomain.EventSourcing;

namespace SharpDomain.SpecsUtils.EventSourcing
{
    public class EventEmitterMock : IEventEmitter
    {
        public IReadOnlyList<IDomainEvent> EmittedEvents { get; private set; }
        private IList<IDomainEvent> _Events;

        public EventEmitterMock()
        {
            _Events = new List<IDomainEvent>();
            EmittedEvents = new ReadOnlyCollection<IDomainEvent>(_Events);
        }

        public void Emit<TEvent>(Action<TEvent> setupEvent)
            where TEvent : class, IDomainEvent
        {
            var ev = Activator.CreateInstance<TEvent>();
            if (setupEvent != null)
                setupEvent(ev);
            _Events.Add(ev);
        }
    }
}
