using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FP_Tree;
using System.Collections.Generic;
using System.Text;

namespace ControlodaroraTest
{
    [TestClass]
    public class UnitTest1
    {
        /*
         * Para este test se utilizara el ejemplo de wikipedia de reglas de asociacion
         * ID	Leche	Pan	Mantequilla	Cerveza
         *  1	1	    1	0	        0
         *  2	0	    1	1	        0
         *  3	0	    0	0	        1
         *  4	1	    1	1	        0
         *  5	0	    1	0	        0
         *  
         * 
         * de acuerdo con este ejemplo:
         * Item         Conteo
         * Leche        2
         * Pan          4
         * Mantequilla  2
         * Cerveza      1
         * 
         * Si el soporte minimo es del 20%, entonces todas son validas
         * Para nuestros propositos, Leche ira antes que Mantequilla
         * Si la confianza minima es del 50%, entonces
         * */
        [TestMethod]
        public void TestMethod1()
        {
            Controladora controladora = new Controladora();
            controladora.Tree = new FPTree();
            List<String> uno = new List<string>();
            uno.Add("Pan");
            uno.Add("Leche");
            controladora.Tree.addTransaction(uno);

            List<String> dos = new List<string>();
            dos.Add("Pan");
            dos.Add("Mantequilla");
            controladora.Tree.addTransaction(dos);

            List<String> tres = new List<string>();
            tres.Add("Cerveza");
            controladora.Tree.addTransaction(tres);

            List<String> cuatro = new List<string>();
            cuatro.Add("Pan");
            cuatro.Add("Leche");
            cuatro.Add("Mantequilla");
            controladora.Tree.addTransaction(cuatro);

            List<String> cinco = new List<string>();
            cinco.Add("Pan");
            controladora.Tree.addTransaction(cinco);

            HashSet<Dependencia> set = controladora.FunctionalDependeciesWithFPGrow(1);

            StringBuilder sb = new StringBuilder();
            foreach(Dependencia d in set)
            {
                sb.Append('{');
                foreach(String s in d.Implicante)
                {
                    sb.Append(s);
                    sb.Append(',');
                }
                sb.Append('-');
                foreach(String s in d.Implicados)
                {
                    sb.Append(s);
                    sb.Append(',');
                }
                sb.Append('}');
            }

            Assert.AreEqual(sb.ToString(), "");


        }
    }
}
