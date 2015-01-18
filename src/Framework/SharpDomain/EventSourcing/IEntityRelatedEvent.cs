using System;

namespace SharpDomain.EventSourcing
{
    public interface IEntityEvent : IDomainEvent
    {
        Guid EntityId { get; set; }
    }
}