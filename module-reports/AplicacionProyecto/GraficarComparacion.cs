using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AplicacionProyecto
{
    public partial class GraficarComparacion : Form
    {
        public String sucursal, periodo1, periodo2;

        public GraficarComparacion(string sucursal, string p1, string p2)
        {
            this.sucursal = sucursal; this.periodo1 = p1; this.periodo2 = p2;
            InitializeComponent();
            Text += " Sucursal "+sucursal;
            ajustarTitulo();
            rellenarInfo1(); rellenarInfo2(); rellenarInfoComp();
        }

        public void ajustarTitulo()
        {
            richTextBox20.Text = ""; richTextBox21.Text = "";
            if (sucursal.Equals("Todas")) { richTextBox20.Text = "Todas las Sucursales"; richTextBox21.Text = "Todas las Sucursales"; }//+ "\n" + periodo;}
            //{
            else if (sucursal.Equals("101")) { richTextBox20.Text = "Sucursal 101"; richTextBox21.Text = "Sucursal 101"; }
            else if (sucursal.Equals("102")) { richTextBox20.Text = "Sucursal 102"; richTextBox21.Text = "Sucursal 102"; }
            else if (sucursal.Equals("103")) { richTextBox20.Text = "Sucursal 103"; richTextBox21.Text = "Sucursal 103"; }
            else if (sucursal.Equals("104")) { richTextBox20.Text = "Sucursal 104"; richTextBox21.Text = "Sucursal 104"; }
            else if (sucursal.Equals("105")) { richTextBox20.Text = "Sucursal 105"; richTextBox21.Text = "Sucursal 105"; }
            else if (sucursal.Equals("106")) { richTextBox20.Text = "Sucursal 106"; richTextBox21.Text = "Sucursal 106"; }
            else if (sucursal.Equals("107")) { richTextBox20.Text = "Sucursal 107"; richTextBox21.Text = "Sucursal 107"; }
            else if (sucursal.Equals("108")) { richTextBox20.Text = "Sucursal 108"; richTextBox21.Text = "Sucursal 108"; }
            else if (sucursal.Equals("109")) { richTextBox20.Text = "Sucursal 109"; richTextBox21.Text = "Sucursal 109"; }
            else if (sucursal.Equals("110")) { richTextBox20.Text = "Sucursal 110"; richTextBox21.Text = "Sucursal 110"; }
            else if (sucursal.Equals("111")) { richTextBox20.Text = "Sucursal 111"; richTextBox21.Text = "Sucursal 111"; }
            // }
            richTextBox20.Text = richTextBox20.Text + "\n" + periodo1; richTextBox21.Text = richTextBox21.Text + "\n" + periodo2;
            richTextBox20.SelectionAlignment = HorizontalAlignment.Center; richTextBox21.SelectionAlignment = HorizontalAlignment.Center; richTextBox22.SelectionAlignment = HorizontalAlignment.Center;
        }

        public void rellenarInfo1() {
            try
            {
                string name = "";
                if (sucursal.Equals("Todas"))  name = "Report" + sucursal + "#" + periodo1 + ".txt"; 
                else    name = "ReportSuc" + sucursal + "#" + periodo1 + ".txt";

                StreamReader lector = new StreamReader("Reportes/"+name);
                int reglas = int.Parse(lector.ReadLine().Trim()); int antecedentes = int.Parse(lector.ReadLine().Trim()); int consecuentes = int.Parse(lector.ReadLine().Trim());

                int confianzudas = int.Parse(lector.ReadLine().Trim()); Dictionary<string, decimal> listaConf = new Dictionary<string, decimal>();
                for (int x = 0; x < confianzudas; x++)
                {
                    string rc = lector.ReadLine(); string[] s = Regex.Split(rc, " && ");
                    listaConf.Add(s[0], decimal.Parse(s[1].Trim()));
                }

                int contAntec = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaAntec = new Dictionary<string, int>();
                for (int x = 0; x < contAntec; x++)
                {
                    string rc = lector.ReadLine();
                    if (x < 6)
                    {
                        string[] s = Regex.Split(rc, " && ");
                        listaAntec.Add(s[0], (int.Parse(s[1].Trim()) ));
                    }
                }

                int contConsec = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaConsec = new Dictionary<string, int>();
                for (int x = 0; x < contConsec; x++)
                {
                    string rc = lector.ReadLine();
                    if (x < 6)
                    {
                        string[] s = Regex.Split(rc, " && ");
                        listaConsec.Add(s[0], (int.Parse(s[1].Trim()) ));
                    }
                }

                int distribuciones = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaDistribuciones = new Dictionary<string, int>();
                for (int x = 0; x < distribuciones; x++)
                {
                    string rc = lector.ReadLine(); string[] s = Regex.Split(rc, " && ");
                    if (int.Parse(s[0]) > 1)
                        listaDistribuciones.Add(s[0] + " Elementos", int.Parse(s[1].Trim()));
                    else
                        listaDistribuciones.Add(s[0] + " Elemento", int.Parse(s[1].Trim()));
                }


                int estranax = int.Parse(lector.ReadLine().Trim()); Dictionary<string, decimal> listaEstranas = new Dictionary<string, decimal>();
                for (int x = 0; x < estranax; x++)
                {
                    string rc = lector.ReadLine(); string[] s = Regex.Split(rc, " && ");
                    listaEstranas.Add(s[0], decimal.Parse(s[1].Trim()));
                }

                label4.Text = reglas + ""; label5.Text = consecuentes + ""; label6.Text = antecedentes + "";

                rtbConfianzudas1.Text = "";
                foreach (KeyValuePair<string, decimal> k in listaConf)
                    rtbConfianzudas1.Text += "Regla: " + k.Key + " Confianza: 0." + k.Value + "\n";

                rtbEstranax1.Text = "";
                foreach (KeyValuePair<string, decimal> k in listaEstranas)
                    rtbEstranax1.Text += "Regla: " + k.Key + " Confianza: 0." + k.Value + "\n";

                foreach (KeyValuePair<string, int> pair in listaAntec)
                {
                    agregarPunto(0, pair.Key, pair.Value);
                    //richTextBox1.Text += pair.Value+";";
                }

                foreach (KeyValuePair<string, int> pair in listaConsec)
                    agregarPunto(1, pair.Key, pair.Value);

                foreach (KeyValuePair<string, int> pair in listaDistribuciones)
                    agregarPunto(2, pair.Key, pair.Value);

            }
            catch (Exception e)
            {
                //richTextBox1.Text = e.ToString();
                richTextBox20.Text = "No existe la combinacion escogida: La sucursal "+sucursal+" y el periodo "+periodo1;
                richTextBox20.Font = new Font("Matura MT Script Capitals", 24);
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label6.Visible = false;
                tabControl1.Visible = false;
            }
        }

        public void rellenarInfo2()
        {
            try
            {
                string name = ""; 
                if (sucursal.Equals("Todas"))   name = "Report" + sucursal + "#" + periodo2 + ".txt";
                else        name = "ReportSuc" + sucursal + "#" + periodo2 + ".txt";

                StreamReader lector = new StreamReader("Reportes/"+name);
                int reglas = int.Parse(lector.ReadLine().Trim()); int antecedentes = int.Parse(lector.ReadLine().Trim()); int consecuentes = int.Parse(lector.ReadLine().Trim());

                int confianzudas = int.Parse(lector.ReadLine().Trim()); Dictionary<string, decimal> listaConf = new Dictionary<string, decimal>();
                for (int x = 0; x < confianzudas; x++)
                {
                    string rc = lector.ReadLine(); string[] s = Regex.Split(rc, " && ");
                    listaConf.Add(s[0], decimal.Parse(s[1].Trim()));
                }

                int contAntec = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaAntec = new Dictionary<string, int>();
                for (int x = 0; x < contAntec; x++)
                {
                    string rc = lector.ReadLine();
                    if (x < 6)
                    {
                        string[] s = Regex.Split(rc, " && ");
                        listaAntec.Add(s[0], (int.Parse(s[1].Trim()) ));
                    }
                }

                int contConsec = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaConsec = new Dictionary<string, int>();
                for (int x = 0; x < contConsec; x++)
                {
                    string rc = lector.ReadLine();
                    if (x < 6)
                    {
                        string[] s = Regex.Split(rc, " && ");
                        listaConsec.Add(s[0], (int.Parse(s[1].Trim()) ));
                    }
                }

                int distribuciones = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaDistribuciones = new Dictionary<string, int>();
                for (int x = 0; x < distribuciones; x++)
                {
                    string rc = lector.ReadLine(); string[] s = Regex.Split(rc, " && ");
                    if (int.Parse(s[0]) > 1)
                        listaDistribuciones.Add(s[0] + " Elementos", int.Parse(s[1].Trim()));
                    else
                        listaDistribuciones.Add(s[0] + " Elemento", int.Parse(s[1].Trim()));
                }


                int estranax = int.Parse(lector.ReadLine().Trim()); Dictionary<string, decimal> listaEstranas = new Dictionary<string, decimal>();
                for (int x = 0; x < estranax; x++)
                {
                    string rc = lector.ReadLine(); string[] s = Regex.Split(rc, " && ");
                    listaEstranas.Add(s[0], decimal.Parse(s[1].Trim()));
                }

                label11.Text = reglas + ""; label9.Text = consecuentes + ""; label8.Text = antecedentes + "";

                rtbConfianzudas2.Text = "";
                foreach (KeyValuePair<string, decimal> k in listaConf)
                    rtbConfianzudas2.Text += "Regla: " + k.Key + " Confianza: 0." + k.Value + "\n";

                rtbEstranax2.Text = "";
                foreach (KeyValuePair<string, decimal> k in listaEstranas)
                    rtbEstranax2.Text += "Regla: " + k.Key + " Confianza: 0." + k.Value + "\n";

                foreach (KeyValuePair<string, int> pair in listaAntec)
                {
                    agregarPunto(3, pair.Key, pair.Value);
                    //richTextBox1.Text += pair.Value+";";
                }

                foreach (KeyValuePair<string, int> pair in listaConsec)
                    agregarPunto(4, pair.Key, pair.Value);

                foreach (KeyValuePair<string, int> pair in listaDistribuciones)
                    agregarPunto(5, pair.Key, pair.Value);

            }
            catch (Exception e)
            {
                //richTextBox1.Text = e.ToString();
                richTextBox21.Text = "No existe la combinacion escogida: La sucursal "+sucursal+" y el periodo "+periodo2;
                richTextBox21.Font = new Font("Matura MT Script Capitals", 24);
                label7.Visible = false; label8.Visible = false; label9.Visible = false; label10.Visible = false; label11.Visible = false; label12.Visible = false;
                tabControl2.Visible = false;
            }
        }

        public void rellenarInfoComp() {
            try
            {
                string name = "";
                if (sucursal.Equals("Todas"))  name = "Report" + sucursal + "Comp" +periodo1+"&&"+periodo2+ ".txt";
                else name = "ReportSuc" + sucursal + "Comp" + periodo1 + "&&" + periodo2 +".txt";

                StreamReader lector = new StreamReader("Reportes/"+name);
                int reglas = int.Parse(lector.ReadLine().Trim()); int antecedentes = int.Parse(lector.ReadLine().Trim()); int consecuentes = int.Parse(lector.ReadLine().Trim());

                if (reglas > 0)
                {
                    int confianzudas = int.Parse(lector.ReadLine().Trim()); Dictionary<string, decimal> listaConf = new Dictionary<string, decimal>();
                    for (int x = 0; x < confianzudas; x++)
                    {
                        string rc = lector.ReadLine(); string[] s = Regex.Split(rc, " && ");
                        listaConf.Add(s[0], decimal.Parse(s[1].Trim()));
                    }

                    int contAntec = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaAntec = new Dictionary<string, int>();
                    for (int x = 0; x < contAntec; x++)
                    {
                        string rc = lector.ReadLine();
                        if (x < 6)
                        {
                            string[] s = Regex.Split(rc, " && ");
                            listaAntec.Add(s[0], (int.Parse(s[1].Trim()) ));
                        }
                    }

                    int contConsec = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaConsec = new Dictionary<string, int>();
                    for (int x = 0; x < contConsec; x++)
                    {
                        string rc = lector.ReadLine();
                        if (x < 6)
                        {
                            string[] s = Regex.Split(rc, " && ");
                            listaConsec.Add(s[0], (int.Parse(s[1].Trim()) ));
                        }
                    }

                    int distribuciones = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaDistribuciones = new Dictionary<string, int>();
                    for (int x = 0; x < distribuciones; x++)
                    {
                        string rc = lector.ReadLine(); string[] s = Regex.Split(rc, " && ");
                        if (int.Parse(s[0]) > 1)
                            listaDistribuciones.Add(s[0] + " Elementos", int.Parse(s[1].Trim()));
                        else
                            listaDistribuciones.Add(s[0] + " Elemento", int.Parse(s[1].Trim()));
                    }


                    int estranax = int.Parse(lector.ReadLine().Trim()); Dictionary<string, decimal> listaEstranas = new Dictionary<string, decimal>();
                    for (int x = 0; x < estranax; x++)
                    {
                        string rc = lector.ReadLine(); string[] s = Regex.Split(rc, " && ");
                        listaEstranas.Add(s[0], decimal.Parse(s[1].Trim()));
                    }

                    label17.Text = reglas + ""; label15.Text = consecuentes + ""; label14.Text = antecedentes + "";

                    rtbConfianzudas3.Text = "";
                    foreach (KeyValuePair<string, decimal> k in listaConf)
                        rtbConfianzudas3.Text += "Regla: " + k.Key + " Confianza: 0." + k.Value + "\n";

                    rtbEstranax3.Text = "";
                    foreach (KeyValuePair<string, decimal> k in listaEstranas)
                        rtbEstranax3.Text += "Regla: " + k.Key + " Confianza: 0." + k.Value + "\n";

                    foreach (KeyValuePair<string, int> pair in listaAntec)
                    {
                        agregarPunto(6, pair.Key, pair.Value);
                        //richTextBox1.Text += pair.Value+";";
                    }

                    foreach (KeyValuePair<string, int> pair in listaConsec)
                        agregarPunto(7, pair.Key, pair.Value);

                    foreach (KeyValuePair<string, int> pair in listaDistribuciones)
                        agregarPunto(8, pair.Key, pair.Value);
                }
                else
                {
                    richTextBox22.Text = "No Tienen Reglas en Comun";
                    richTextBox22.Font = new Font("Matura MT Script Capitals", 29);
                    label13.Visible = false; label14.Visible = false; label15.Visible = false; label16.Visible = false; label17.Visible = false; label18.Visible = false;
                    tabControl3.Visible = false;
                }
            }
            catch (Exception e)
            {
                //richTextBox22.Text = e.ToString();
                //richTextBox22.Text = "Para la Sucursal "+sucursal+", al Comparar los Periodos: "+periodo1+" y "+periodo2+" no hay Reglas en comun";
                richTextBox22.Text = "No Existen Reglas en Comun";
                richTextBox22.Font = new Font("Matura MT Script Capitals", 29);
                label13.Visible = false; label14.Visible = false; label15.Visible = false; label16.Visible = false; label17.Visible = false; label18.Visible = false;
                tabControl3.Visible = false;
            }
        }
        
        public void agregarPunto(int a, String x, Decimal y)
        {
            if (a == 0) chAntecedentes1.Series["Antecedentes"].Points.AddXY(x, y);
            else if (a == 1) chConsecuentes1.Series["Consecuentes"].Points.AddXY(x, y);
            else if (a == 2) chDistribucion1.Series["Distribuciones"].Points.AddXY(x, y);

            else if (a == 3) chAntecedentes2.Series["Antecedentes"].Points.AddXY(x, y);
            else if (a == 4) chConsecuentes2.Series["Consecuentes"].Points.AddXY(x, y);
            else if (a == 5) chDistribucion2.Series["Distribuciones"].Points.AddXY(x, y);

            else if (a == 6) chAntecedentes3.Series["Antecedentes"].Points.AddXY(x, y);
            else if (a == 7) chConsecuentes3.Series["Consecuentes"].Points.AddXY(x, y);
            else if (a == 8) chDistribucion3.Series["Distribuciones"].Points.AddXY(x, y);
        }
    }
}
