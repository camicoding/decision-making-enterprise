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
    public partial class VentanaAnalizar : Form
    {
        public String sucursal;

        public VentanaAnalizar(string sucursal)
        {
            this.sucursal = sucursal;
            InitializeComponent();
            if (!sucursal.Equals("Todas")) Text += " Sucursal " + sucursal;
            else Text += " Todas las Sucursales";
            comboMes.Visible = false; comboBi.Visible = false; comboTri.Visible = false;
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void radMensual_CheckedChanged(object sender, EventArgs e)
        {
            if (radMensual.Checked)
            {
                comboMes.SelectedIndex = -1;   comboMes.Visible = true;
            }
            else
                comboMes.Visible = false;
        }

        private void radBimestral_CheckedChanged(object sender, EventArgs e)
        {
            if (radBimestral.Checked)
            {
                comboBi.SelectedIndex = -1; comboBi.Visible = true;
            }
            else
                comboBi.Visible = false; 
        }

        private void radTrimestral_CheckedChanged(object sender, EventArgs e)
        {
            if (radTrimestral.Checked)
            {
                comboTri.SelectedIndex = -1; comboTri.Visible = true;
            }
            else
                comboTri.Visible = false; 
        }

        private void butCompare_Click(object sender, EventArgs e)
        {
            string periodo = ""; 
            if (radMensual.Checked)
            {
                if (comboMes.SelectedIndex == -1)
                    MessageBox.Show("Debe seleccionar el periodo que desea analizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    periodo = comboMes.Items[comboMes.SelectedIndex].ToString();
            }
            else if (radBimestral.Checked)
            {
                if (comboBi.SelectedIndex == -1)
                    MessageBox.Show("Debe seleccionar el periodo que desea analizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    periodo = comboBi.Items[comboBi.SelectedIndex].ToString();
            }
            else if (radTrimestral.Checked)
            {
                if (comboTri.SelectedIndex == -1)
                    MessageBox.Show("Debe seleccionar el periodo que desea analizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    periodo = comboTri.Items[comboTri.SelectedIndex].ToString();
            }
            else if (!radMensual.Checked && !radBimestral.Checked && !radTrimestral.Checked)
                MessageBox.Show("Primero debe seleccionar el tipo de periodo que desea analizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!periodo.Equals(""))
                graficarAnalisis(periodo);
        }

        private void graficarAnalisis(string periodo)
        {
            radMensual.Checked = false; radBimestral.Checked = false; radTrimestral.Checked = false;
            comboMes.SelectedIndex = -1; comboMes.Visible = false; 
            comboBi.SelectedIndex = -1; comboBi.Visible = false;
            comboTri.SelectedIndex = -1;  comboTri.Visible = false;
            //MessageBox.Show("El periodo escogido fue: " + periodo, "Bien", MessageBoxButtons.OK, MessageBoxIcon.Question);

            GraficarAnalisis ga = new GraficarAnalisis(sucursal, periodo); ga.Show();
        }
    }
}
