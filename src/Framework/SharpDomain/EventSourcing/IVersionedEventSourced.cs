namespace SharpDomain.EventSourcing
{
    public interface IVersionedEventSourced : IEventSourced
    {
        int CommittedVersion { get; }
        
        int AppendedVersion { get; }
    }
}