using System;

namespace SharpDomain.Utils
{
    public class SystemNewGuidGenerator : INewGuidGenerator
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}