using System;

namespace SharpDomain.Commanding
{
    public abstract class EntityCommand :
        IEntityCommand,
        IIdentifiedCommand
    {
        public Guid CommandId { get; set; }
        public Guid EntityId { get; set; }
    }
}