using System.Reflection;

namespace SharpDomain.Models
{
    public class PropertyValue
    {
        public PropertyValue(string propertyName, PropertyInfo property, SoftwareDefinitionElement element)
        {
            PropertyName = propertyName;
            Property = property;
            Element = element;
        }

        public string PropertyName { get; private set; }

        public PropertyInfo Property { get; private set; }

        public SoftwareDefinitionElement Element { get; private set; }
    }
}