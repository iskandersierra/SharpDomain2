using System;

namespace SharpDomain.EventSourcing
{
    public interface IIdentifiedEvent : IDomainEvent
    {
        Guid EventId { get; set; }
    }
}