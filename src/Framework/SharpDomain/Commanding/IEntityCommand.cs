using System;

namespace SharpDomain.Commanding
{
    public interface IEntityCommand : IDomainCommand
    {
        Guid EntityId { get; set; }
    }
}