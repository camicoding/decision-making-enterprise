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
    public partial class Aplicacion : Form
    {
        public Aplicacion()
        {
            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void butAnalizar_Click(object sender, EventArgs e)
        {
            if (combo1.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar alguna opcion de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //MessageBox.Show("Bien Hecho con: " + combo1.Items[combo1.SelectedIndex].ToString(), "Bien", MessageBoxButtons.OK, MessageBoxIcon.Question);
                VentanaAnalizar va = new VentanaAnalizar(combo1.Items[combo1.SelectedIndex].ToString()); va.Show();
            }

            combo1.SelectedIndex = -1;
        }

        private void butComparar_Click(object sender, EventArgs e)
        {
            if (combo1.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar alguna opcion de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //MessageBox.Show("Bien Hecho con: " + combo1.Items[combo1.SelectedIndex].ToString(), "Bien", MessageBoxButtons.OK, MessageBoxIcon.Question);
                VentanaComparar vc = new VentanaComparar(combo1.Items[combo1.SelectedIndex].ToString()); vc.Show();
            }

            combo1.SelectedIndex = -1;
        }


    }
}
