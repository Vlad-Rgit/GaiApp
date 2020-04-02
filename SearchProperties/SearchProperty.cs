using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.SearchProperties
{
    public abstract class SearchProperty
    {
        public PropertyInfo PropertyInfo { get; set; }

        public virtual object GetValue(object owner)
           => PropertyInfo?.GetValue(owner);

        public virtual string GetStringValue(object owner)
           => PropertyInfo?.GetValue(owner).ToString();
    }
}
