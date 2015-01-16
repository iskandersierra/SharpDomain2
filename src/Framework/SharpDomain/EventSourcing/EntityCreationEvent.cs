using System;

namespace SharpDomain.EventSourcing
{
    public class EntityCreationEvent :
        IEntityCreationEvent,
        IIdentifiedEvent,
        IVersionedEvent,
        ICommandRelatedEvent
    {
        public Guid EntityId { get; set; }
        public Guid EventId { get; set; }
        public int EventVersion { get; set; }
        public Guid CommandId { get; set; }
    }
}