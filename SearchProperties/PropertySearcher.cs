using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GaiApp.Attributes;
using GaiApp.Models;

namespace GaiApp.SearchProperties
{
    public static class PropertySearcher
    {

        public static IList<PropertyInfo> GetSearchProperties(Type ownerType)
        {
            List<PropertyInfo> list = new List<PropertyInfo>();

            foreach(var p in ownerType.GetProperties())
            {
                if(p.GetCustomAttribute(typeof(SearchObjectAttribute)) != null)
                {
                    list.AddRange(GetSearchProperties(p.PropertyType));
                }

                if(p.GetCustomAttribute(typeof(SearchPropertyAttribute)) != null)
                {
                    list.Add(p);
                }
            }

            return list;
        }

        public static object GetNestedEntity(object owner, Type entityType)
        {
            object result = null;

            foreach (var p in owner.GetType().GetProperties())
            {
                if(p.PropertyType == entityType)
                {
                    return p.GetValue(owner);                
                }
                else if (p.GetCustomAttribute(typeof(SearchObjectAttribute)) != null)
                {
                    result = GetNestedEntity(p.GetValue(owner), entityType);

                    if (result != null)
                        return result;
                }
            }

            return result;
        }
    }
}
