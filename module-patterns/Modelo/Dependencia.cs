using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FP_Tree;
using Modelo;

namespace FP_Tree
{
    public class Dependencia
    {
        ItemsSet<String> implicante;

        public ItemsSet<String> Implicante
        {
            get { return implicante; }
            set { implicante = value; }
        }
        ItemsSet<String> implicados;

        public ItemsSet<String> Implicados
        {
            get { return implicados; }
            set { implicados = value; }
        }

        public Dependencia(IEnumerable<string> i, IEnumerable<string> j)
        {
            implicante = new ItemsSet<string>();
            implicados = new ItemsSet<string>();
            implicante.UnionWith(i);
            implicados.UnionWith(j);
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Dependencia return false.
            Dependencia p = obj as Dependencia;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return p.implicante.SetEquals(this.implicante) && p.implicados.SetEquals(this.implicados);
        }

        public override int GetHashCode()
        {
            return implicante.GetHashCode() + implicados.GetHashCode();
        }
            
        
    }
}
