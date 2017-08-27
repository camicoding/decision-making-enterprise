using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class ItemsSet<T> : HashSet<T>
    {


        public ItemsSet(IEnumerable<T> enumerable) : base(enumerable)
        {
            
        }

        public ItemsSet(): base() 
        {
        }
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to ItemsSet return false.
            ItemsSet<T> p = obj as ItemsSet<T>;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true SetEquals:
            return base.SetEquals(p);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
