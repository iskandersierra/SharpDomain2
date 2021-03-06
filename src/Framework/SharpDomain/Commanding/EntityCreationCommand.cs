﻿using System;

namespace SharpDomain.Commanding
{
    public abstract class EntityCreationCommand :
        IEntityCreationCommand,
        IIdentifiedCommand
    {
        public Guid CommandId { get; set; }
    }
}
