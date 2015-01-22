using System.Collections.Generic;
using System.Linq;

namespace SharpDomain.Models
{
    public abstract class SoftwareDefinitionElement
    {
        public SoftwareDefinition Root { get; protected set; }

        public SoftwareDefinitionElement ParentElement { get; protected set; }

        private IEnumerable<PropertyValue> containedElements;
        public IEnumerable<PropertyValue> ContainedElements
        {
            get
            {
                //return containedElements ?? (containedElements = GetContainedElements().ToArray());
                return GetContainedElements();
            }
        }

        private IEnumerable<PropertyValue> referencedElements;
        public IEnumerable<PropertyValue> ReferencedElements
        {
            get
            {
                //return referencedElements ?? (referencedElements = GetReferencedElements().ToArray());
                return GetReferencedElements();
            }
        }

        protected virtual IEnumerable<PropertyValue> GetContainedElements()
        {
            return Enumerable.Empty<PropertyValue>();
        }

        protected virtual IEnumerable<PropertyValue> GetReferencedElements()
        {
            return Enumerable.Empty<PropertyValue>();
        }

        protected internal virtual void Init(InitContext c, SoftwareDefinitionElement parent)
        {
            Root = c.Root;
            ParentElement = parent;

            foreach (var containedElement in GetContainedElements())
            {
                containedElement.Element.Init(c, this);
            }
        }
    }
}