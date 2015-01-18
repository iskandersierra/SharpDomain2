namespace SharpDomain.Commanding
{
    public interface ICommandProcessor
    {
        void Process(IDomainCommand command);
    }

    public interface ICommandProcessor<TCommand> : 
        ICommandProcessor
        where TCommand : class, IDomainCommand
    {
        void Process(TCommand command);
    }
}