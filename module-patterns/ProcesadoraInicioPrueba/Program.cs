using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FP_Tree;

namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 ft = new Class1();

            ft.importarInformacion();

            List<String> list = ft.transacciones;
            foreach(String a in list)
            {
                Console.WriteLine(a);
            }

            Console.ReadLine();
        }
    }
}
