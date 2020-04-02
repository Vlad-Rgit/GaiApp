using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.Models
{
    public abstract class Entity
    {

        public bool IsDeleted { get; set; }

        public virtual void InitilizeDefault()
        {
            foreach(var p in this.GetType().GetProperties())
            {
                if (typeof(Entity).IsAssignableFrom(p.PropertyType))
                {
                    ConstructorInfo constructor = p.PropertyType.GetConstructor(Type.EmptyTypes);
                    Entity entity = (Entity)constructor.Invoke(new object[0]);
                    p.SetValue(this, entity);
                    entity.InitilizeDefault();
                }
            }
        }
    }
}
