using System.Collections.Generic;

namespace SharpDomain.EventSourcing
{
    public interface IEventSourced
    {
        /// <summary>
        /// This method is used when hidrating an aggregate from an event stream
        /// </summary>
        /// <param name="e"></param>
        void ApplyCommittedEvent(IDomainEvent e);

        /// <summary>
        /// This method is used when appending events to an aggregate
        /// </summary>
        /// <param name="e"></param>
        void AppendEvent(IDomainEvent e);

        /// <summary>
        /// Collection of appended events
        /// </summary>
        IReadOnlyCollection<IDomainEvent> AppendedEvents { get; }
    }
}
