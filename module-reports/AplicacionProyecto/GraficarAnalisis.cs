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
    public partial class GraficarAnalisis : Form
    {
        public String sucursal, periodo;

        public GraficarAnalisis(string sucursal, string p)
        {
            this.sucursal = sucursal; this.periodo = p; 
            InitializeComponent();
            ajustarTitulo();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            rellenarInfo();
        }

        public void ajustarTitulo(){
            if (sucursal.Equals("Todas")) richTextBox1.Text = "Todas las Sucursales"; //+ "\n" + periodo;
            //{
            else if (sucursal.Equals("101")) richTextBox1.Text = "Sucursal 101";
            else if (sucursal.Equals("102")) richTextBox1.Text = "Sucursal 102";
            else if (sucursal.Equals("103")) richTextBox1.Text = "Sucursal 103";
            else if (sucursal.Equals("104")) richTextBox1.Text = "Sucursal 104";
            else if (sucursal.Equals("105")) richTextBox1.Text = "Sucursal 105";
            else if (sucursal.Equals("106")) richTextBox1.Text = "Sucursal 106";
            else if (sucursal.Equals("107")) richTextBox1.Text = "Sucursal 107";
            else if (sucursal.Equals("108")) richTextBox1.Text = "Sucursal 108";
            else if (sucursal.Equals("109")) richTextBox1.Text = "Sucursal 109";
            else if (sucursal.Equals("110")) richTextBox1.Text = "Sucursal 110";
            else if (sucursal.Equals("111")) richTextBox1.Text = "Sucursal 111";
           // }
            richTextBox1.Text = richTextBox1.Text + "\n"+periodo;
            //richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        public void rellenarInfo()
        {
            try
            {
                string name = "";
                if (sucursal.Equals("Todas")) name = "Report" + sucursal + "#" + periodo + ".txt";
                else    name = "ReportSuc" + sucursal + "#" + periodo + ".txt";

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
                        listaAntec.Add(s[0], (int.Parse(s[1].Trim())));///antecedentes));
                    }
                }

                int contConsec = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaConsec = new Dictionary<string, int>();
                for (int x = 0; x < contConsec; x++)
                {
                    string rc = lector.ReadLine();
                    if (x < 6)
                    {
                        string[] s = Regex.Split(rc, " && ");
                        listaConsec.Add(s[0], (int.Parse(s[1].Trim())));// / consecuentes));
                    }
                }

                int distribuciones = int.Parse(lector.ReadLine().Trim()); Dictionary<string, int> listaDistribuciones = new Dictionary<string, int>();
                for (int x = 0; x < distribuciones; x++)
                {
                    string rc = lector.ReadLine();   string[] s = Regex.Split(rc, " && ");
                    if (int.Parse(s[0]) > 1)
                        listaDistribuciones.Add(s[0]+" Elementos", int.Parse(s[1].Trim()));
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

                rtbConfianzudas.Text = "";
                foreach (KeyValuePair<string, decimal> k in listaConf)
                    rtbConfianzudas.Text += "Regla: " + k.Key + " Confianza: 0." + k.Value+"\n";

                rtbEstranax.Text = "";
                foreach (KeyValuePair<string, decimal> k in listaEstranas)
                    rtbEstranax.Text += "Regla: " + k.Key + " Confianza: 0." + k.Value + "\n";

                foreach (KeyValuePair<string, int> pair in listaAntec){
                    agregarPunto(0,pair.Key, pair.Value);
                    //richTextBox1.Text += pair.Value+";";
                }

                 foreach (KeyValuePair<string, int> pair in listaConsec)
                    agregarPunto(1,pair.Key, pair.Value);

                 foreach (KeyValuePair<string, int> pair in listaDistribuciones)
                     agregarPunto(2, pair.Key, pair.Value);
            }
            catch (Exception e)
            {
                //richTextBox1.Text = e.ToString();
                richTextBox1.Text = "No existe la combinacion escogida: La sucursal "+sucursal+" y el periodo "+periodo;
                richTextBox1.Font = new Font("Matura MT Script Capitals", 25);
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label6.Visible = false;
                tabControl1.Visible = false;
            }
        }
        
        public void agregarPunto(int a,String x, Decimal y)
        {
            if(a==0)     chAntecedentes.Series["Antecedentes"].Points.AddXY(x, y);
            else if (a == 1) chConsecuentes.Series["Consecuentes"].Points.AddXY(x, y);
            else if (a == 2) chDistribucion.Series["Distribuciones"].Points.AddXY(x, y);
        }

    }
}
