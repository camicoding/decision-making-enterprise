using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionProyecto
{
    public partial class VentanaComparar : Form
    {
        public String sucursal;

        public VentanaComparar(string sucursal)
        {
            this.sucursal = sucursal;
            InitializeComponent();
            if (!sucursal.Equals("Todas")) Text += " Sucursal " + sucursal;
            else Text += " Todas las Sucursales";
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            comboMes1.Visible = false; comboMes2.Visible = false; comboBi1.Visible = false;
            comboBi2.Visible = false; comboTri1.Visible = false; comboTri2.Visible = false;
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void radMensual_CheckedChanged(object sender, EventArgs e)
        {
            if (radMensual.Checked)
            {
                comboMes1.SelectedIndex = -1; comboMes2.SelectedIndex = -1;
                comboMes1.Visible = true; comboMes2.Visible = true;
            }
            else
            {
                comboMes1.Visible = false; comboMes2.Visible = false;
            }
        }

        private void radBimestral_CheckedChanged(object sender, EventArgs e)
        {
            if (radBimestral.Checked)
            {
                comboBi1.SelectedIndex = -1; comboBi2.SelectedIndex = -1;
                comboBi1.Visible = true; comboBi2.Visible = true;
            }
            else
            {
                comboBi1.Visible = false; comboBi2.Visible = false;
            }
        }

        private void radTrimestral_CheckedChanged(object sender, EventArgs e)
        {
            if (radTrimestral.Checked)
            {
                comboTri1.SelectedIndex = -1; comboTri2.SelectedIndex = -1;
                comboTri1.Visible = true; comboTri2.Visible = true;
            }
            else
            {
                comboTri1.Visible = false; comboTri2.Visible = false;
            }
        }

        private void butCompare_Click(object sender, EventArgs e)
        {
            string periodo1 = "";         string periodo2 = ""; 
            if (radMensual.Checked)
            {
                if (comboMes1.SelectedIndex == -1 || comboMes2.SelectedIndex == -1)
                    MessageBox.Show("Debe seleccionar los 2 periodos que desea comparar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                else if (comboMes1.SelectedIndex == comboMes2.SelectedIndex)
                    MessageBox.Show("Debe seleccionar 2 periodos diferentes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (comboMes1.SelectedIndex > comboMes2.SelectedIndex)
                    MessageBox.Show("El periodo seleccionado en la lista 2 debe ser posterior al seleccionado en la lista 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    periodo1 = comboMes1.Items[comboMes1.SelectedIndex].ToString();
                    periodo2 = comboMes2.Items[comboMes2.SelectedIndex].ToString();
                }
            }
            else if (radBimestral.Checked)
            {
                if (comboBi1.SelectedIndex == -1 || comboBi2.SelectedIndex == -1)
                    MessageBox.Show("Debe seleccionar los 2 periodos que desea comparar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (comboBi1.SelectedIndex == comboBi2.SelectedIndex)
                    MessageBox.Show("Debe seleccionar 2 periodos diferentes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (comboBi1.SelectedIndex > comboBi2.SelectedIndex)
                    MessageBox.Show("El periodo seleccionado en la lista 2 debe ser posterior al seleccionado en la lista 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (haySolapamiento(comboBi1.Items[comboBi1.SelectedIndex].ToString(), comboBi2.Items[comboBi2.SelectedIndex].ToString(), 2))
                    MessageBox.Show("Los periodos seleccionados no deben solaparse, es decir que no pueden tener meses en comun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    periodo1 = comboBi1.Items[comboBi1.SelectedIndex].ToString();
                    periodo2 = comboBi2.Items[comboBi2.SelectedIndex].ToString();
                }
            }
            else if (radTrimestral.Checked)
            {
                if (comboTri1.SelectedIndex == -1 || comboTri2.SelectedIndex == -1)
                    MessageBox.Show("Debe seleccionar los 2 periodos que desea comparar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (comboTri1.SelectedIndex == comboTri2.SelectedIndex)
                    MessageBox.Show("Debe seleccionar 2 periodos diferentes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (comboTri1.SelectedIndex > comboTri2.SelectedIndex)
                    MessageBox.Show("El periodo seleccionado en la lista 2 debe ser posterior al seleccionado en la lista 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //else if (haySolapamiento(comboTri1.Items[comboTri1.SelectedIndex].ToString(), comboTri2.Items[comboTri2.SelectedIndex].ToString(), 3))
                 //   MessageBox.Show("Los periodos seleccionados no deben solaparse, es decir tener meses en comun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    periodo1 = comboTri1.Items[comboTri1.SelectedIndex].ToString();
                    periodo2 = comboTri2.Items[comboTri2.SelectedIndex].ToString();
                }
            }
            else if (!radMensual.Checked && !radBimestral.Checked && !radTrimestral.Checked)
                MessageBox.Show("Primero debe seleccionar el tipo de periodos que desea comparar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!periodo1.Equals("") && !periodo2.Equals(""))
                graficarComparacion(periodo1, periodo2);
        }

        private void graficarComparacion(string periodo1, string periodo2)
        {
            radMensual.Checked = false; radBimestral.Checked = false; radTrimestral.Checked = false;
            comboMes1.SelectedIndex = -1; comboMes2.SelectedIndex = -1; comboMes1.Visible = false; comboMes2.Visible = false;
            comboBi1.SelectedIndex = -1; comboBi2.SelectedIndex = -1; comboBi1.Visible = false; comboBi2.Visible = false;
            comboTri1.SelectedIndex = -1; comboTri2.SelectedIndex = -1; comboTri1.Visible = false; comboTri2.Visible = false;
           // MessageBox.Show("El primer periodo fue: " + periodo1 + " Y el segundo periodo fue: " + periodo2, "Bien", MessageBoxButtons.OK, MessageBoxIcon.Question);

            GraficarComparacion gc = new GraficarComparacion(sucursal, periodo1, periodo2); gc.Show();
        }

        private bool haySolapamiento(string periodo1, string periodo2, int tipo)
        {
            bool b = false;
            if (periodo1.Equals(periodo2))
                b = true;
            else if (tipo == 2)
            {
                if ((periodo1.Equals("Enero-Febrero") && periodo2.Equals("Febrero-Marzo"))
                    || (periodo1.Equals("Febrero-Marzo") && periodo2.Equals("Marzo-Abril"))
                    || (periodo1.Equals("Marzo-Abril") && periodo2.Equals("Abril-Mayo"))
                    || (periodo1.Equals("Abril-Mayo") && periodo2.Equals("Mayo-Junio")))
                             b = true;
            }
            //else
            //{
            //    if ((periodo1.Equals("Enero-Febrero-Marzo") && (periodo2.Equals("Febrero-Marzo-Abril") || periodo2.Equals("Marzo-Abril-Mayo")))
            //        || (periodo1.Equals("Febrero-Marzo-Abril") && (periodo2.Equals("Marzo-Abril-Mayo") || periodo2.Equals("Abril-Mayo-Junio")))
            //        || (periodo1.Equals("Marzo-Abril-Mayo") && periodo2.Equals("Abril-Mayo-Junio")))
            //        b = true;
            //}
            return b;
        }
    }
}
