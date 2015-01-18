namespace SharpDomain.Commanding
{
    public abstract class CommandProcessorBase<TCommand> : 
        ICommandProcessor<TCommand> 
        where TCommand : class, IDomainCommand
    {
        public abstract void Process(TCommand command);

        void ICommandProcessor.Process(IDomainCommand command)
        {
            Process((TCommand)command);
        }
    }
}