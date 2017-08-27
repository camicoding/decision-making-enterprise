using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FP_Tree;
using Modelo;

namespace FP_Tree
{
    public class Controladora
    {
        private int epsilon;
        private FPTree tree;

        public FPTree Tree
        {
            get { return tree; }
            set { tree = value; }
        }
        /*
         * formato:
         * <numero de transacciones>
         * I1,I2,I3...IN
         * 
         * ejemplo:
         * 5
         * a,b,c,d,e,f,g,h,i,j
         * a,b,c
         * d,e,f
         * g,h,i
         * j,a,b
         * c,d,e
         * 
         * */
        public void importarInformacion(String ruta = "datos.txt", double soporte = 0.2)
        {

            tree = new FPTree();
            SortedSet<Item> dic = new SortedSet<Item>(new comparadorPorOcurrencia());
            //INICIO PRIMERA LECTURA
            StreamReader lector = new StreamReader(ruta);
            int numTransacciones = Convert.ToInt32(lector.ReadLine());
            this.epsilon = (int)(soporte * numTransacciones);
            Dictionary<String, int> dictionary = new Dictionary<String, int>();
            for (int i = 0; i < numTransacciones; i++)
            {
                String[] itemsLector = lector.ReadLine().Split(',');

                for (int j = 0; j < itemsLector.Length; j++)
                {
                    if (dictionary.ContainsKey(itemsLector[j]))
                    {
                        dictionary[itemsLector[j]] = dictionary[itemsLector[j]] + 1;
                    }
                    else
                    {
                        dictionary.Add(itemsLector[j], 1);
                    }

                }
            }
            lector.Close();
            //FIN PRIMERA LECTURA
            foreach (KeyValuePair<string, int> entry in dictionary)
            {
                if (entry.Value > epsilon)
                {
                    dic.Add(new Item(entry.Key, entry.Value));
                }
            }
            //Borra el diccionario
            dictionary = null;
            //INICIO SEGUNDA LECTURA
            lector = new StreamReader(ruta);
            lector.ReadLine();
            for (int i = 0; i < numTransacciones; i++)
            {
                String[] itemsLector = lector.ReadLine().Split(',');
                List<string> t = new List<string>();
                //TODO esto se puede mejorar
                foreach (Item ii in dic)
                {
                    if (itemsLector.Contains(ii.Key))
                    {
                        t.Add(ii.Key);
                    }
                }
                //FIN TODO
                tree.addTransaction(t);
            }
            lector.Close();
        }

        public Object[] Preorden()
        {
            if (tree == null)
            {
                throw new Exception("tree is null");
            }
            return tree.Preorden();
        }

        public HashSet<Dependencia> FunctionalDependeciesWithFPGrow(double confianza = 0.2) 
        {
            if (confianza < 0 || confianza > 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (tree == null)
            {
                throw new Exception("tree is null");
            }
            HashSet<ItemsSet<String>> result = tree.FPGrow(epsilon);
            HashSet<Dependencia> posiblesDependencias = new HashSet<Dependencia>();
            foreach (ItemsSet<String> i in result)
            {
                if (i.Count > 1)
                {
                    posiblesDependencias.UnionWith(generarDependencias(i));
                }
            }

            HashSet<Dependencia> dependencias = tree.TestDependenciasV2(posiblesDependencias, confianza);
            HashSet<Dependencia> dependenciasNombre = new HashSet<Dependencia>();

            Dictionary<string, string> dic = new Dictionary<string, string>();
            StreamReader lector = new StreamReader("productos.txt");
            string linea = lector.ReadLine();
            while (linea != null)
            {
                string[] array = linea.Split('|');
                dic.Add(array[0], array[1].Substring(1, array[1].Length - 1));
                linea = lector.ReadLine();
            }

            foreach (Dependencia d in dependencias)
            {
                ItemsSet<string> implicantes = d.Implicante;
                ItemsSet<String> implicantesNombre = new ItemsSet<string>();
                foreach (string i in implicantes)
                {
                    string value = "";
                    dic.TryGetValue(i, out value);
                    implicantesNombre.Add(value);
                }

                ItemsSet<string> implicadosNombre = new ItemsSet<string>();
                ItemsSet<string> implicados = d.Implicados;
                foreach (string idos in implicados)
                {
                    string value = "";
                    dic.TryGetValue(idos, out value);
                    implicadosNombre.Add(value);
                }
                Dependencia depen = new Dependencia(implicantesNombre, implicadosNombre);
                dependenciasNombre.Add(depen);
            }



            //return dependencias;

            //StringBuilder sb = new StringBuilder();
            //using (StreamWriter writer = new StreamWriter(ruta))
            //{
            //    foreach (Dependencia d in dependencias)
            //    {
            //        foreach (String s in d.Implicante)
            //        {
            //            sb.Append(s);
            //            sb.Append(itemSeparator);
            //        }
            //        sb.Remove(sb.Length - 1, 1);
            //        sb.Append(dependencySeparator);
            //        foreach (String s in d.Implicados)
            //        {
            //            sb.Append(s);
            //            sb.Append(itemSeparator);
            //        }
            //        sb.Remove(sb.Length - 1, 1);
            //        writer.WriteLine(sb.ToString());
            //        sb.Clear();
            //    }
            //}
            return dependenciasNombre;

        }

        private IEnumerable<Dependencia> generarDependencias(ItemsSet<string> items)
        {
            List<Dependencia> respuesta = new List<Dependencia>();
            IEnumerable<IEnumerable<String>> partes = GetPowerSet<String>(items.ToList());
            foreach (IEnumerable<String> i in partes)
            {
                foreach (IEnumerable<String> j in partes)
                {
                    if (i.Any() && j.Any() && !i.Intersect(j).Any())
                    {
                        respuesta.Add(new Dependencia(i, j));
                    }
                }
            }
            return respuesta;
        }


        /**
         * http://rosettacode.org/wiki/Power_Set#C.23
         * */
        public IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                       from i in Enumerable.Range(0, list.Count)
                       where (m & (1 << i)) != 0
                       select list[i];
        }

        public string FPGrow()
        {
            if (tree == null)
            {
                throw new Exception("tree is null");
            }
            HashSet<ItemsSet<String>> result = tree.FPGrow(epsilon);

            //empezamos la trad
            HashSet<String> array = new HashSet<String>();
            foreach (ItemsSet<String> i in result)
            {
                foreach (String ii in i)
                {
                    array.Add(ii);
                }
            }

            Dictionary<String, String> dic = new Dictionary<string, string>();

            StreamReader lector = new StreamReader("productos.txt");
            string linea = lector.ReadLine();
            while (linea != null && array.Count != 0)
            {
                string[] producto = linea.Split('|');
                if (array.Contains(producto[0]))
                {
                    dic.Add(producto[0], producto[1].Substring(1, producto[1].Length - 1));
                    array.Remove(producto[0]);
                }

                linea = lector.ReadLine();
            }



            String s = result.ToString();
            String sb = "";

            foreach (ItemsSet<String> i in result)
            {
                sb += "{";
                foreach (String ii in i)
                {
                    string valor = "";
                    dic.TryGetValue(ii, out valor);
                    sb += valor;
                    sb += ", ";
                }
                sb = sb.Substring(0, sb.Length - 2);
                sb += "}";
                sb += Environment.NewLine;
            }

            //termina la trad
            return sb.ToString();
        }

        //public void generarInformacion(string ruta, DateTime inicio = default(DateTime), DateTime fin = default(DateTime))
        public void generarInformacion(string[] rutas, DateTime inicio, DateTime fin)
        {

            //if (inicio==null)
            //{
            //    inicio = new DateTime(2013, 6, 14);
            //}

            //if (fin == null)
            //{
            //    fin = new DateTime(2013, 6, 14);
            //}


            //Variables locales
            
            StringBuilder sb = new StringBuilder();
            /*
            foreach (String ruta in rutas)
            {
                sb.AppendLine(ruta);
            }
            */
            int count = 0;
            String[] elementos;
            //metodos
            foreach (String ruta in rutas)
            {
                StreamReader lector = new StreamReader(ruta);
                String linea = lector.ReadLine();
                while (linea != null)
                {
                    elementos = linea.Split('|');
                    String[] date = elementos[0].Split('-');
                    DateTime fecha = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                    while (inicio <= fecha && fecha <= fin)
                    {
                        String cliente = elementos[2];
                        while (elementos[2].Equals(cliente) && inicio <= fecha && fecha <= fin)
                        {
                            sb.Append(elementos[3]);
                            sb.Append(",");
                            linea = lector.ReadLine();
                            if (linea == null)
                            {
                                break;
                            }
                            elementos = linea.Split('|');
                            date = elementos[0].Split('-');
                            fecha = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.AppendLine();
                        count++;
                        if (linea == null)
                        {
                            break;
                        }
                    }
                    linea = lector.ReadLine();
                }
                lector.Close();
            }
            
            sb.Insert(0, count.ToString() + Environment.NewLine);
            
            StreamWriter escritor = new StreamWriter(rutas[0] + ".test");
            
            escritor.Write(sb.ToString());
            escritor.Close();
        }


        
        public void generarInformacionV2(string[] rutas, DateTime inicio, DateTime fin)
        {
            //Variables locales
            int count = 0;
            String[] elementos;
            StreamWriter sw = new StreamWriter(rutas[0] + ".temp");
            //metodos
            foreach (String ruta in rutas)
            {
                StreamReader lector = new StreamReader(ruta);
                String linea = lector.ReadLine();
                while (linea != null)
                {
                    elementos = linea.Split('|');
                    String[] date = elementos[0].Split('-');
                    DateTime fecha = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                    while (inicio <= fecha && fecha <= fin)
                    {
                        String cliente = elementos[2];
                        while (elementos[2].Equals(cliente) && inicio <= fecha && fecha <= fin)
                        {
                            sw.Write(elementos[3]);
                            sw.Write(",");
                            linea = lector.ReadLine();
                            if (linea == null)
                            {
                                break;
                            }
                            elementos = linea.Split('|');
                            date = elementos[0].Split('-');
                            fecha = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                        }
                        sw.WriteLine();
                        count++;
                        if (linea == null)
                        {
                            break;
                        }
                    }
                }
                lector.Close();
            }
            
            //sb.Insert(0, count.ToString() + Environment.NewLine);
            
            StreamWriter escritor = new StreamWriter(rutas[0] + ".test");
            escritor.WriteLine(count.ToString());
            StreamReader lectura = new StreamReader(rutas[0] + ".temp");
            String l = lectura.ReadLine();
            while (l != null)
            {
                
                escritor.WriteLine(l.Substring(0,l.Length - 1));
                l = lectura.ReadLine();
            }

            lectura.Close();
            File.Delete(rutas[0] + ".temp");
            escritor.Close();
        }


        

        /*
        //ESTE ES EL METODO QUE RESUELVE EL README
        public void generarInformacion(string ruta)
        {
            StreamReader lector = new StreamReader(ruta);
            String linea = lector.ReadLine();
            String[] elementos;
            Int32 i = 0;
            Dictionary<String, HashSet<String>> diccionario = new Dictionary<string, HashSet<string>>();
            while (linea != null)
            {
                elementos = linea.Split('|');
                if (elementos[0].Equals("2013-06-14"))
                {
                    if (!diccionario.ContainsKey(elementos[2]))
                    {
                        diccionario.Add(elementos[2], new HashSet<string>());
                        i++;
                    }
                    diccionario[elementos[2]].Add(elementos[3]);

                }
                linea = lector.ReadLine();
            }
            lector.Close();
            StreamWriter escritor = new StreamWriter(ruta + ".test");
            escritor.WriteLine(i + "");
            StringBuilder sb = new StringBuilder(); ;
            foreach (HashSet<String> strings in diccionario.Values)
            {
                sb.Clear();
                foreach (String s in strings)
                {
                    sb.Append(s);
                    sb.Append(',');
                }
                sb.Remove(sb.Length - 1, 1);
                escritor.WriteLine(sb.ToString());

            }

            escritor.Close();
        }
        */





















        //inicio de metodos adicionales

        public void generarInformacionFechaCliente(string ruta)
        {
            StreamReader lector = new StreamReader(ruta);
            String linea = lector.ReadLine();
            String[] elementos;
            Int32 i = 0;
            Dictionary<String, HashSet<String>> diccionario = new Dictionary<string, HashSet<string>>();
            while (linea != null)
            {
                elementos = linea.Split('|');

                if (!diccionario.ContainsKey(elementos[0] + '|' + elementos[2]))
                {
                    diccionario.Add(elementos[0] + '|' + elementos[2], new HashSet<string>());
                    i++;
                }
                diccionario[elementos[0] + '|' + elementos[2]].Add(elementos[3]);


                linea = lector.ReadLine();
            }
            lector.Close();
            StreamWriter escritor = new StreamWriter(ruta + ".test");
            escritor.WriteLine(i + "");
            StringBuilder sb = new StringBuilder(); ;
            foreach (HashSet<String> strings in diccionario.Values)
            {
                sb.Clear();
                foreach (String s in strings)
                {
                    sb.Append(s);
                    sb.Append(',');
                }
                sb.Remove(sb.Length - 1, 1);
                escritor.WriteLine(sb.ToString());

            }

            escritor.Close();
        }



        public void generarInformacionDiaSemana(string ruta, DayOfWeek day)
        {
            StreamReader lector = new StreamReader(ruta);
            String linea = lector.ReadLine();
            String[] elementos;
            Int32 i = 0;
            Dictionary<String, HashSet<String>> diccionario = new Dictionary<string, HashSet<string>>();
            while (linea != null)
            {
                elementos = linea.Split('|');
                String[] date = elementos[0].Split('-');
                if (new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])).DayOfWeek == day)
                {
                    if (!diccionario.ContainsKey(elementos[0] + '|' + elementos[2]))
                    {
                        diccionario.Add(elementos[0] + '|' + elementos[2], new HashSet<string>());
                        i++;
                    }
                    diccionario[elementos[0] + '|' + elementos[2]].Add(elementos[3]);
                }

                linea = lector.ReadLine();
            }
            lector.Close();
            StreamWriter escritor = new StreamWriter(ruta + ".test");
            escritor.WriteLine(i + "");
            StringBuilder sb = new StringBuilder(); ;
            foreach (HashSet<String> strings in diccionario.Values)
            {
                sb.Clear();
                foreach (String s in strings)
                {
                    sb.Append(s);
                    sb.Append(',');
                }
                sb.Remove(sb.Length - 1, 1);
                escritor.WriteLine(sb.ToString());

            }

            escritor.Close();
        }

        //public string leerDependecias()
        //{
        //    string retorno = "";

        //    StreamReader lector = new StreamReader("dependencias.txt");
        //    string linea = lector.ReadLine();
        //    while (linea != null)
        //    {
        //        string[] dependencia = linea.Split('-');
        //        retorno += dependencia[0] + " ---> " + dependencia[1]+ "\n";
        //        linea = lector.ReadLine();
        //    }

        //    return retorno;
        //}

        public void generarInformacion(string p, DateTime? inicial, DateTime? final)
        {
            throw new NotImplementedException();
        }
    }
}


