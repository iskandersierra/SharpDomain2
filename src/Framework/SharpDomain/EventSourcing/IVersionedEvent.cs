namespace SharpDomain.EventSourcing
{
    public interface IVersionedEvent : IDomainEvent
    {
        int EventVersion { get; set; }
    }
}