using System.Collections.Generic;

namespace SharpDomain.Models
{
    public class ComponentDependency : SoftwareDefinitionElement
    {
        public SoftwareComponent Component { get; set; }

        public SoftwareComponent ParentComponent
        {
            get
            {
                return ParentElement as SoftwareComponent;
            }
        }

        protected override IEnumerable<PropertyValue> GetReferencedElements()
        {
            return this
                .GetPropertyValue(e => e.Component)
                .Done(base.GetReferencedElements());
        }
    }
}