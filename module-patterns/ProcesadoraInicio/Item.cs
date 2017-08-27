using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Tree
{
    public class Item
    {
        private String key;
        private int value;

        public override bool Equals(object o)
        {
            Item i = (Item)o;

            if (i.key.Equals(key))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            return key.GetHashCode();
        }

        

        public Item(String key, int value)
        {
            this.key = key;
            this.value = value;
        }

        public String Key
        {
            get { return key; }
            set { key = value; }
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        
    }
}
