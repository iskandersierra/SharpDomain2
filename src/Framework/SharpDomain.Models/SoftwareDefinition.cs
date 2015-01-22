using System.Collections.Generic;

namespace SharpDomain.Models
{

    public class SoftwareDefinition : SoftwareDefinitionElement
    {
        public SoftwareDefinition()
        {
            Components = new List<SoftwareComponent>();
        }

        public string Name { get; set; }

        public Metadata Metadata { get; set; }

        public List<SoftwareComponent> Components { get; set; }

        public SoftwareDefinition Init()
        {
            var initContext = new InitContext(this);

            Init(initContext, null);

            return this;
        }

        protected override IEnumerable<PropertyValue> GetContainedElements()
        {
            return this
                .GetPropertyValues(d => d.Components)
                .GetPropertyValue(d => d.Metadata)
                .Done();
        }
    }
}
