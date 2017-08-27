using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;





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
         * param: transaccion, IEnumerable (lista) de string que se recorre en la transaccion, no tiene repetidos
         * param: c, conteo de veces que aparece esta transaccion, default=1
         */
        public void addTransaction(IEnumerable<String> transaction, int c = 1)
        {
            FPNode location = root;
            foreach (String item in transaction)
            {
                if (location.Hijos.ContainsKey(item))
                {
                    location = location.Hijos[item];
                    location.Conteo += c;
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
                    location.Conteo += c;
                }

            }
        }


        public Object[] Preorden()
        {
            return root.Preorden();
        }


        public HashSet<ItemsSet<String>> FPGrow(int epsilon, List<String> previos = null)
        {
            //si previos es default
            if (previos == null)
            {
                //instancia a previos
                previos = new List<string>();
            }

            //crea el conjuto de respuesta
            HashSet<ItemsSet<String>> respuesta = new HashSet<ItemsSet<string>>();
            //para cada item en el arbol
            foreach (KeyValuePair<string, FPNode> entry in headersTable)
            {
                //obtiene su nodo inicial
                FPNode node = entry.Value;
                //crea un nuevo set de items
                ItemsSet<String> items = new ItemsSet<string>();
                //agrega los los items previos que se han hecho y an llevado a esta instancia de arbol
                items.UnionWith(previos);
                //agrega el nodo que se esta evaluando
                items.Add(node.Contenido);
                //agrega a la respueta el set de items
                respuesta.Add(items);
                //crea una copia de los previos
                List<String> nueva = Extenciones.Clone<String>(previos);
                //agrega el actual
                nueva.Add(node.Contenido);
                //genera el arbol condicional para el item actual
                FPTree conditional = GetConditional(node, epsilon);
                //llama recursivamente sobre el arbol condicional y une las respuestas
                respuesta.UnionWith(conditional.FPGrow(epsilon, nueva));
            }
            return respuesta;
        }

        private FPTree GetConditional(FPNode node, int epsilon)
        {
            //inicia el arbol con todos los caminos
            FPTree conditional = getCaminos(node);
            //inicia una variable que cuenta todo
            return Podar(conditional, node, epsilon);





            /*
            //empieza a filtrar
            //hace una copia de la headersTable ya que no se puede modificar y recorrer al mismo tiempo
            //para cada item en el subArbol
            foreach (FPNode entrada in Extenciones.CloneNode<FPNode>(conditional.headersTable.Values.ToList()))
            {
                //cuenta cuantos items hay
                int suma = 0;
                FPNode n = entrada;
                while (n != null)
                {
                    suma += n.Conteo;
                    n = n.Siguiente;
                }

                
                //si es menor que el epsilon
                if (suma < epsilon)
                {
                    //lo remueve
                    conditional.headersTable.Remove(entrada.Contenido);
                    n = entrada;
                    while (n != null)
                    {
                        n.Padre.Hijos.Remove(entrada.Contenido);
                        sumar(n.Padre, n.Hijos);
                        n = n.Siguiente;
                    }
                }
            }
             * */

        }

        private FPTree Podar(FPTree conditional, FPNode node, int epsilon)
        {
            HashSet<String> conteo = new HashSet<String>(); ;
            foreach (KeyValuePair<String, FPNode> entry in conditional.headersTable)
            {
                Int32 i = 0;
                FPNode n = entry.Value;
                while (n != null)
                {
                    i += n.Conteo;
                    n = n.Siguiente;
                }
                if (i >= epsilon)
                {
                    conteo.Add(entry.Key);
                }
            }

            //instancia un nuevo arbol
            FPTree respuesta = new FPTree();
            //optiene el nodo adecuado
            node = conditional.headersTable[node.Contenido];
            //va a recorrer sus caminos y meterlos al arbol
            while (node != null)
            {
                //optiene el padre
                FPNode temp = node.Padre;
                //instancia la transaccion
                LinkedList<String> transaccion = new LinkedList<string>();
                //mete los valores previos al nodo en la transaccion, si es adecuado
                while (temp.Contenido != null)
                {
                    if (conteo.Contains<String>(temp.Contenido))
                    {
                        transaccion.AddFirst(temp.Contenido);
                    }
                    temp = temp.Padre;
                }
                //si la transaccion no esta vacia
                if (transaccion.First != null)
                {
                    //mete la transaccion con su conteo respectivo
                    respuesta.addTransaction(transaccion, node.Conteo);
                }
                //pasa al siguiente camino
                node = node.Siguiente;
            }
            return respuesta;
        }

        //optiene el subarbol con los caminos respectivos sin filtrar
        private FPTree getCaminos(FPNode node)
        {
            //instancia un nuevo arbol
            FPTree caminos = new FPTree();
            //va a recorrer sus caminos y meterlos al arbol
            while (node != null)
            {
                //optiene el padre
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                FPNode temp = node;
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio
                //OJO: se cambio

                //utiliza una linkedList ya que el metodo addFirst es O(1)
                //instancia la transaccion
                LinkedList<String> transaccion = new LinkedList<string>();
                //mete los valores previos al nodo en la transaccion
                while (temp.Contenido != null)
                {
                    transaccion.AddFirst(temp.Contenido);
                    temp = temp.Padre;
                }
                //si la transaccion no esta vacia
                if (transaccion.First != null)
                {
                    //mete la transaccion con su conteo respectivo
                    caminos.addTransaction(transaccion, node.Conteo);
                }
                //pasa al siguiente camino
                node = node.Siguiente;
            }
            return caminos;
        }
        [Obsolete("Se puede hacer mejor", true)]
        private void sumar(FPNode fPNode, Dictionary<string, FPNode> dictionary)
        {
            foreach (KeyValuePair<string, FPNode> entrada in dictionary)
            {
                if (fPNode.Hijos.ContainsKey(entrada.Key))
                {
                    fPNode.Hijos[entrada.Key].Conteo += entrada.Value.Conteo;
                    sumar(fPNode.Hijos[entrada.Key], entrada.Value.Hijos);
                }
                else
                {
                    fPNode.Hijos.Add(entrada.Key, entrada.Value);
                    entrada.Value.Padre = fPNode;
                }
            }
        }


         [Obsolete("No funciona", true)]
        public HashSet<Dependencia> TestDependencias(HashSet<Dependencia> posiblesDependencias, double confianza= 0.2)
        {
            HashSet<Dependencia> respuesta = new HashSet<Dependencia>();
            Dictionary<String, Int32> conteo = new Dictionary<string, int>();
            foreach (FPNode node in headersTable.Values)
            {
                FPNode n = node;
                int i = 0;
                while (n != null)
                {
                    i += node.Conteo;
                    n = n.Siguiente;
                }
                conteo.Add(node.Contenido, i);
            }

            List<String> lista = conteo.ToList().OrderBy(c => c.Value).Select(c => c.Key).ToList();
            int total = conteo.Sum(c => c.Value);
            conteo = null;
            Dictionary<ItemsSet<String>, int> soportes = new Dictionary<ItemsSet<string>, int>();
            foreach (Dependencia dependencia in posiblesDependencias)
            {
                ItemsSet<String> dividendo = new ItemsSet<string>();
                dividendo.UnionWith(dependencia.Implicante.Union(dependencia.Implicados));
                if (!soportes.ContainsKey(dividendo))
                {
                    AgregarSoporte(lista, dividendo, soportes);
                }

                ItemsSet<String> divisor = new ItemsSet<string>();
                divisor.UnionWith(dependencia.Implicante);
                if (!soportes.ContainsKey(divisor))
                {
                    AgregarSoporte(lista, divisor, soportes);
                }
                if ((soportes[dividendo] + 0.0) / (soportes[divisor] + 0.0) >= confianza)
                {
                    respuesta.Add(dependencia);
                }
            }
            return respuesta;
        }
         [Obsolete("No funciona", true)]
        private void AgregarSoporte(List<String> lista, ItemsSet<String> set, Dictionary<ItemsSet<String>, int> soportes )
        {
            String start = "";
            foreach (String s in lista)
            {
                if (set.Contains(s))
                {
                    start = s;
                    break;
                }
            }
            FPNode nodo = headersTable[start];
            int soporteSet = 0;
            while (nodo != null)
            {
                FPNode temp = nodo;
                ItemsSet<String> copy = new ItemsSet<string>();
                copy.Union(set);
                while (temp.Contenido != null)
                {
                    copy.Remove(temp.Contenido);
                    temp = temp.Padre;
                }
                if (!copy.Any())
                {
                    soporteSet += nodo.Conteo;
                }
                nodo = nodo.Siguiente;
            }

            soportes.Add(set, soporteSet);
        }

         public HashSet<Dependencia> TestDependenciasV2(HashSet<Dependencia> posiblesDependencias, double confianza = 0.2)
         {
             Dictionary<ItemsSet<String>, double> memorization = new Dictionary<ItemsSet<String>, double>();
             HashSet<Dependencia> respuesta = new HashSet<Dependencia>();
             foreach (Dependencia posible in posiblesDependencias)
             {
                 double denonimador = 0;
                 if(memorization.ContainsKey(posible.Implicante))
                 {
                     denonimador = memorization[posible.Implicante];
                 }
                 else{
                     foreach (FPNode node in root.Hijos.Values)
                     {
                         denonimador += GetConteo(posible.Implicante, node);
                     }
                     memorization.Add(posible.Implicante, denonimador);
                 }

                 ItemsSet<String> numeradorSet = new ItemsSet<string>(posible.Implicados.Union(posible.Implicante));
                 double numerador = 0;
                 if (memorization.ContainsKey(numeradorSet))
                 {
                     numerador = memorization[numeradorSet];
                 }
                 else
                 {
                     foreach (FPNode node in root.Hijos.Values)
                     {
                         numerador += GetConteo(numeradorSet, node);
                     }
                     memorization.Add(numeradorSet, numerador);
                 }
                 
                 
                 if ((numerador / denonimador) >= confianza)
                 {
                     respuesta.Add(posible);
                 }
             }
             return respuesta;
         }

         private int GetConteo(HashSet<string> itemsSet, FPNode node)
         {
             HashSet<string> copy = new HashSet<string>(itemsSet);
             copy.Remove(node.Contenido);
             if (copy.Any())
             {
                 int conteo = 0;
                 foreach (FPNode n in node.Hijos.Values)
                 {
                     conteo += GetConteo(copy, n);
                 }
                 return conteo;
             }
             else
             {
                 return node.Conteo;
             }
         }

         

         public int getN()
         {
             int count = 0;
             foreach (FPNode node in headersTable.Values)
             {
                 FPNode temp = node;
                 while (temp != null)
                 {
                     count += temp.Conteo;   
                     temp = temp.Siguiente;
                 }
             }
             return count;
         }
    }
}
