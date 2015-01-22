using System.Collections.Generic;

namespace SharpDomain.Models
{
    public abstract class SoftwareComponent : SoftwareDefinitionElement
    {
        protected SoftwareComponent()
        {
            Dependencies = new List<ComponentDependency>();
        }

        public string Name { get; set; }

        public Metadata Metadata { get; set; }

        public Package ParentPackage
        {
            get { return ParentElement as Package; }
        }

        public List<ComponentDependency> Dependencies { get; set; }
        
        protected override IEnumerable<PropertyValue> GetContainedElements()
        {
            return this
                .GetPropertyValue(e => e.Metadata)
                .GetPropertyValues(e => e.Dependencies)
                .Done(base.GetContainedElements());
        }
    }
}