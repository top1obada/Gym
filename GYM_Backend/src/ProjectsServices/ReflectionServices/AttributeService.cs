using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsServices.ReflectionServices
{
    


    public static class clsAttributeService
    {
       
        public static TBase? GetAttributeAsBase<TBase>(PropertyInfo property) where TBase : Attribute
        {
            if (property == null) return null;

            var attr = property.GetCustomAttributes(inherit: true)
                               .FirstOrDefault((a) =>
                               {
                                   return typeof(TBase).IsAssignableFrom(a.GetType());
                               }
                               );

            return attr as TBase; 
        }
    }
}
