using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SharpDomain.Models
{
    public static class PropertyValueExtensions
    {
        public static GetPropertyValuesResult<TDef> GetPropertyValues<TDef, TProp>(this TDef self,
            Expression<Func<TDef, IEnumerable<TProp>>> multiValuedProperty)
            where TDef : SoftwareDefinitionElement
            where TProp : SoftwareDefinitionElement
        {
            var result = new GetPropertyValuesResult<TDef>(self);
            return result.GetPropertyValues(multiValuedProperty);
        }
        public static GetPropertyValuesResult<TDef> GetPropertyValue<TDef, TProp>(this TDef self,
            Expression<Func<TDef, TProp>> singleValuedProperty)
            where TDef : SoftwareDefinitionElement
            where TProp : SoftwareDefinitionElement
        {
            var result = new GetPropertyValuesResult<TDef>(self);
            return result.GetPropertyValue(singleValuedProperty);
        }

        public class GetPropertyValuesResult<TDef>
            where TDef : SoftwareDefinitionElement
        {
            private readonly SoftwareDefinitionElement _self;
            private List<PropertyValue> properties = new List<PropertyValue>();

            internal SoftwareDefinitionElement Self
            {
                get { return _self; }
            }

            public GetPropertyValuesResult(SoftwareDefinitionElement self)
            {
                _self = self;
            }

            public GetPropertyValuesResult<TDef> GetPropertyValues<TProp>(
                Expression<Func<TDef, IEnumerable<TProp>>> multiValuedProperty)
                where TProp : SoftwareDefinitionElement
            {
                if (multiValuedProperty == null) throw new ArgumentNullException("multiValuedProperty");
                var prop = GetPropertyInfo(multiValuedProperty);
                var values = prop.GetValue(Self) as IEnumerable<TProp>;
                if (values != null)
                {
                    foreach (var value in values)
                    {
                        properties.Add(new PropertyValue(prop.Name, prop, value));
                    }
                }
                return this;
            }

            public GetPropertyValuesResult<TDef> GetPropertyValue<TProp>(
                Expression<Func<TDef, TProp>> singleValuedProperty)
                where TProp : SoftwareDefinitionElement
            {
                if (singleValuedProperty == null) throw new ArgumentNullException("singleValuedProperty");
                var prop = GetPropertyInfo(singleValuedProperty);
                var value = prop.GetValue(Self) as TProp;
                if (value != null)
                {
                    properties.Add(new PropertyValue(prop.Name, prop, value));
                }
                return this;
            }

            private PropertyInfo GetPropertyInfo(LambdaExpression expression)
            {
                if (expression.Parameters.Count == 1)
                {
                    var memberExpression = expression.Body as MemberExpression;
                    if (memberExpression != null)
                    {
                        if (memberExpression.Expression == expression.Parameters[0])
                        {
                            var property = memberExpression.Member as PropertyInfo;
                            if (property != null)
                                return property;
                        }
                    }
                }
                throw new ArgumentException("Expression body must be of the form element.Property but found: " + expression);
            }

            public IEnumerable<PropertyValue> Done(IEnumerable<PropertyValue> baseProperties = null)
            {
                if (baseProperties == null)
                    return properties;
                else
                    return baseProperties.Concat(properties);
            }
        }
    }
}