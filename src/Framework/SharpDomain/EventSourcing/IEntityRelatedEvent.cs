using System;

namespace SharpDomain.EventSourcing
{
    public interface IEntityRelatedEvent : IDomainEvent
    {
        Guid EntityId { get; set; }
    }
}