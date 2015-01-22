using System.Collections.Generic;

namespace SharpDomain.Models
{
    public class Package : SoftwareComponent
    {
        public Package()
        {
            Components = new List<SoftwareComponent>();
        }

        public List<SoftwareComponent> Components { get; set; }

        protected override IEnumerable<PropertyValue> GetContainedElements()
        {
            return this
                .GetPropertyValues(d => d.Components)
                .Done(base.GetContainedElements());
        }
    }
}