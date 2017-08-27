using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Tree
{
    public class FPTree
    {
        private Dictionary<String, FPNode> headersTable;
        private FPNode root;

        public FPTree()
        {
            headersTable = new Dictionary<string, FPNode>();
            root = new FPNode(null, null, null);
        }

        /*
         * Se asume que una transaccion no tiene items repetidos
         */
        public void addTransaction(List<String> transaction)
        {
            FPNode location = root;
            foreach (String item in transaction)
            {
                if (location.Hijos.ContainsKey(item))
                {
                    location = location.Hijos[item];
                    location.Conteo++;
                }
                else
                {
                    FPNode temp = null;
                    if (headersTable.ContainsKey(item))
                    {
                        temp = new FPNode(item, headersTable[item], location);
                    }
                    else
                    {
                        temp = new FPNode(item, null, location);
                    }
                    location.Hijos[item] = temp;
                    headersTable[item] = temp;
                    location = temp;
                    location.Conteo++;
                }

            }
        }
    }
}
