using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDomain.Commanding
{
    public interface IDomainCommand
    {
    }

    public interface IIdentifiedCommand : IDomainCommand
    {
        Guid CommandId { get; set; }
    }

    public interface IEntityCreationCommand : IDomainCommand
    {
    }

    public interface IEntityCommand : IDomainCommand
    {
        Guid EntityId { get; set; }
    }

    public abstract class EntityCreationCommand :
        IEntityCreationCommand,
        IIdentifiedCommand
    {
        public Guid CommandId { get; set; }
    }

    public abstract class EntityCommand :
        IEntityCommand,
        IIdentifiedCommand
    {
        public Guid CommandId { get; set; }
        public Guid EntityId { get; set; }
    }
}
