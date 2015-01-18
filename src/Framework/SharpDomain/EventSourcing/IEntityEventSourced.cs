using System;

namespace SharpDomain.EventSourcing
{
    public interface IEntityEventSourced : IEventSourced
    {
        Guid EntityId { get; }
    }
}