using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FP_Tree;
using Modelo;

namespace vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Controladora controladora;
        public MainWindow()
        {
            controladora = new Controladora();
            InitializeComponent();
        }

        private void txtSoporte_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Double.Parse(txtSoporte.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Solo se aceptan numeros reales en formato %,% \n" + ex.Message);
            }
        }

        private void butCargar_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            Nullable<bool> result = file.ShowDialog();

            DateTime inicial = CalendarioInicial.SelectedDate.GetValueOrDefault();
            DateTime final = CalendarioFinal.SelectedDate.GetValueOrDefault();

            // Process open file dialog box results 
            if (result == true)
            {

                controladora.generarInformacion(file.FileNames, inicial, final);
                MessageBox.Show("Se ha completado la operacion");
            }
        }

        private void butFpGrowth_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            Nullable<bool> result = file.ShowDialog();
            if (result == true)
            {
                try
                {
                    double d = Double.Parse(txtSoporte.Text);
                    if (d < 0 || d > 1)
                    {
                        throw new Exception("out of limits");
                    }
                    else
                    {
                        controladora.importarInformacion(file.FileName, d);
                        this.txtResultado.Text = controladora.FPGrow();
                        
                       // this.Refresh();
                        MessageBox.Show(this, "Se ha completado la operacion");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private TreeViewItem Preorden(Object[] s)
        {
            return null;
        }

        private void butFechaCliente_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            Nullable<bool> result = file.ShowDialog();
            if (result == true)
            {
                controladora.generarInformacionFechaCliente(file.FileName);
                MessageBox.Show("Se ha completado la operacion");
            }
        }

        private void butCalcular_Click(object sender, RoutedEventArgs e)
        {

            string mostrarDependencias = "";
            HashSet<Dependencia> dependencias = controladora.FunctionalDependeciesWithFPGrow(Double.Parse(txtConfianza.Text));

            foreach(Dependencia d in dependencias)
            {
                string aux = "";
                ItemsSet<string> implicantes = d.Implicante;
                foreach(string i in implicantes)
                {
                    aux += i +",";
                }
                aux = aux.Substring(0, aux.Length - 1);
                aux += " ---> ";
                ItemsSet<string> implicados = d.Implicados;
                foreach (string idos in implicados)
                {
                    aux += idos + ",";
                }
                aux = aux.Substring(0, aux.Length - 1);
                mostrarDependencias += aux + "\n";
            }
            txtDependencias.Text = mostrarDependencias;
        }


    }
}
