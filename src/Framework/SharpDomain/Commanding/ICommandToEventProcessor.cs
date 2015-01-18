using SharpDomain.EventSourcing;

namespace SharpDomain.Commanding
{
    public interface ICommandToEventProcessor : 
        ICommandProcessor
    {
        IEventEmitter Events { get; set; }
    }
}