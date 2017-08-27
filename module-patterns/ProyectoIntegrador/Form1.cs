using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FP_Tree;

namespace ProyectoIntegrador
{
    public partial class Form1 : Form
    {
        private Controladora controladora;
        public Form1()
        {
            controladora = new Controladora();
            InitializeComponent();
            comboBox1.Items.Clear();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                comboBox1.Items.Add(day);
            }
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    double d = Double.Parse(doubleInput.Text);
                    if (d < 0 || d > 1)
                    {
                        throw new Exception("out of limits");
                    }
                    else
                    {
                        controladora.importarInformacion(file.FileName, d);
                        this.textBox1.Text = controladora.FPGrow();
                        this.Refresh();
                        MessageBox.Show(new Form() { TopMost = true },"Se ha completado la operacion");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private TreeNode Preorden(Object[] s)
        {
            TreeNode respuesta = new TreeNode(s[0].ToString());
            foreach (Object[] h in (List<Object[]>)s[1])
            {
                respuesta.Nodes.Add(Preorden(h));
            }
            return respuesta;
        }

        private void doubleInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double.Parse(doubleInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Solo se aceptan numeros reales en formato %,% \n" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                controladora.generarInformacionDiaSemana(file.FileName, (DayOfWeek)comboBox1.SelectedItem);

                MessageBox.Show(new Form() { TopMost = true }, "Se ha completado la operacion");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                controladora.generarInformacionFechaCliente(file.FileName);
                MessageBox.Show(new Form() { TopMost = true }, "Se ha completado la operacion");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Object[] s = controladora.Preorden();
            TreeNode root = Preorden(s);
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add(root);
            this.Refresh();
            MessageBox.Show(new Form() { TopMost = true }, "Se ha completado la operacion");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                controladora.generarInformacion(file.FileName, null, null);
                MessageBox.Show(new Form() { TopMost = true }, "Se ha completado la operacion");
            }
        }
    }
}
