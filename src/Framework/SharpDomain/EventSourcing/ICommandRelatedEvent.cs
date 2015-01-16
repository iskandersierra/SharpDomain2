using System;

namespace SharpDomain.EventSourcing
{
    public interface ICommandRelatedEvent : IDomainEvent
    {
        Guid CommandId { get; set; }
    }
}