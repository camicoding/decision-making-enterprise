using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Tree
{
    class FPNode
    {
        private String contenido;

        public String Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
        private int conteo;

        public int Conteo
        {
            get { return conteo; }
            set { conteo = value; }
        }
        private FPNode siguiente;

        public FPNode Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        private FPNode padre;

        public FPNode Padre
        {
            get { return padre; }
            set { padre = value; }
        }
        private Dictionary<String, FPNode> hijos;

        public Dictionary<String, FPNode> Hijos
        {
            get { return hijos; }
            set { hijos = value; }
        }

        public FPNode(String contenido, FPNode siguiente, FPNode padre)
        {
            this.conteo = 0;
            this.contenido = contenido;
            this.siguiente = siguiente;
            this.padre = padre;
            hijos = new Dictionary<string, FPNode>();
        }
    }
}
