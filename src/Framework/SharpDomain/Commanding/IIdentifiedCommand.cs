using System;

namespace SharpDomain.Commanding
{
    public interface IIdentifiedCommand : IDomainCommand
    {
        Guid CommandId { get; set; }
    }
}