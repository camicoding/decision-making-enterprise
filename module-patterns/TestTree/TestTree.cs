using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FP_Tree;
using System.Collections;
using System.Collections.Generic;
using Modelo;
using System.Text;
namespace TestTree
{
    [TestClass]
    public class TestTree
    {
        private FPTree arbol;

        public void setupEscenario2()
        {
            arbol = new FPTree();
            List<string> lista = new List<string>();
            lista.Add("10");
            lista.Add("2");
            lista.Add("8");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("7");
            lista.Add("9");
            lista.Add("3");
            lista.Add("4");
            lista.Add("8");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("1");
            lista.Add("2");
            lista.Add("10");
            lista.Add("8");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("9");
            lista.Add("10");
            lista.Add("2");
            lista.Add("5");
            lista.Add("7");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("1");
            lista.Add("10");
            lista.Add("5");
            lista.Add("4");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("3");
            lista.Add("8");
            lista.Add("4");
            lista.Add("6");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("7");
            lista.Add("3");
            lista.Add("10");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("6");
            lista.Add("7");
            lista.Add("1");
            lista.Add("4");
            arbol.addTransaction(lista);
            

        }

        public void setupEscenario3()
        {
            arbol = new FPTree();

            List<string> lista = new List<string>();
            lista.Add("a");
            lista.Add("b");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("b");
            lista.Add("c");
            lista.Add("d");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("a");
            lista.Add("c");
            lista.Add("d");
            lista.Add("e");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("a");
            lista.Add("d");
            lista.Add("e");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("a");
            lista.Add("b");
            lista.Add("c");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("a");
            lista.Add("b");
            lista.Add("c");
            lista.Add("d");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("a");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("a");
            lista.Add("b");
            lista.Add("c");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("a");
            lista.Add("b");
            lista.Add("d");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("b");
            lista.Add("c");
            lista.Add("e");
            arbol.addTransaction(lista);
        }

        [TestMethod]
        public void TestAddTransaction1()
        {
            arbol = new FPTree();

            List<string> lista = new List<string>();
            lista.Add("a");
            lista.Add("b");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("b");
            lista.Add("c");
            lista.Add("d");
            arbol.addTransaction(lista);

            //talba de header
            //Assert.AreEqual(headersTable.Count(), 4);
        }


        [TestMethod]
        public void TestAddTransaction2()
        {
            arbol = new FPTree();

            List<string> lista = new List<string>();
            lista.Add("0");
            lista.Add("1");
            lista.Add("2");
            lista.Add("4");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("3");
            lista.Add("2");
            lista.Add("1");
            arbol.addTransaction(lista);

            lista = new List<string>();
            lista.Add("0");
            lista.Add("2");
            lista.Add("3");
            arbol.addTransaction(lista);
            //talba de header
            //Assert.AreEqual(headersTable.Count(), 5);
        }



        [TestMethod]
        public void TestFPGrowth1()
        {
            setupEscenario2();
            HashSet<ItemsSet<String>> coleccion = arbol.FPGrow(2);
            String compare = toStringSet(coleccion);
            //Assert.AreEqual(coleccion.Count, 8);
            //String respuesta = "{10,} {8,} {8,10,} {2,} {2,10,} {2,8,} {2,8,10,} {7,} {7,10,} {4,} {4,7,} {4,8,} {3,} {3,7,} {3,8,} {3,4,} {3,4,8,} {1,} {1,4,} {1,10,} ";
            String respuesta = "{10,} {10,1,} {2,} {2,10,} {8,} {8,3,} {8,2,} {8,10,} {7,} {9,} {3,} {3,7,} {4,} {4,7,} {4,1,} {4,3,} {1,} {5,} {5,10,} {6,} ";

            //Assert.AreEqual(compare, respuesta);
            
            string[] s1 = respuesta.Split(' ');
            string[] s2 = compare.Split(' ');

            HashSet<string> conjunto1 = new HashSet<string>();
            HashSet<string> conjunto2 = new HashSet<string>();
            foreach(String x in s1){
                conjunto1.Add(x);
            }
            foreach (String x in s2)
            {
                conjunto2.Add(x);
            }
            Assert.AreEqual(conjunto1.Count, conjunto2.Count);
            //Assert.IsTrue(conjunto1.SetEquals(conjunto2));

        }


        [TestMethod]
        public void TestFPGrowth2()
        {
            setupEscenario3();
            HashSet<ItemsSet<String>> coleccion = arbol.FPGrow(2);
            String ss = toStringSet(coleccion);
            Assert.AreEqual(ss, "{a,} {b,} {b,a,} {c,} {c,a,} {c,b,} {c,b,a,} {d,} {d,a,} {d,b,} {d,b,a,} {d,c,} {d,c,b,} {d,c,a,} {e,} {e,c,} {e,a,} {e,d,} {e,d,a,} ");
        }
         
        public String toStringSet(HashSet<ItemsSet<String>> result) {
            StringBuilder sb = new StringBuilder();
            foreach (ItemsSet<String> i in result)
            {
                sb.Append("{");
                foreach (String ii in i)
                {
                    sb.Append(ii);
                    sb.Append(",");
                }
                sb.Append("} ");
            }
            return sb.ToString();
        }

    }
}
