using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            //get all properties
            PropertyInfo[] properties = type.GetProperties();
            //get all properties with custom attributes
            PropertyInfo[] propWithCustomAttributes = properties
                .Where(p => Attribute.IsDefined(p, typeof(MyValidationAttribute), inherit: true))
                .ToArray();

            foreach (PropertyInfo property in propWithCustomAttributes)
            {
                var validationAttributes = property
                    .GetCustomAttributes(typeof(MyValidationAttribute), inherit: true)
                    .Cast<MyValidationAttribute>();

                foreach (var attribute in  validationAttributes)
                {
                    object value = property.GetValue(obj);
                    if (attribute.IsValid(value) == false)
                    {
                        return false;
                    }
                }
            }
           
            return true;
        }
    }
}
