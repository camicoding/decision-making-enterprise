using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Tree
{
    public class comparadorPorOcurrencia : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x.Value > y.Value)
            {
                return -1;
            }
            else if (x.Value < y.Value)
            {
                return 1;
            }
            else
            {
                return 1;
            }

        }
    }
}
