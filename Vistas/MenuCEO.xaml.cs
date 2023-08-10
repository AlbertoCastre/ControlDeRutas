using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Control_De_Rutas.Vistas
{
    /// <summary>
    /// Lógica de interacción para MenuCEO.xaml
    /// </summary>
    public partial class MenuCEO : Window
    {
        public MenuCEO()
        {
            InitializeComponent();
        }

        private void btnGeneBita_Click(object sender, RoutedEventArgs e)
        {

            GeneradorDeBitacoras generadorBita = new();
            generadorBita.Show();
            Close();
        }

        private void btnRastreo_Click(object sender, RoutedEventArgs e)
        {
            RastreodePaquete rastreo = new();
            rastreo.Show();
            Close();
        }

        private void btnAddCliente_Click(object sender, RoutedEventArgs e)
        {
            ClienteOpc clienteopc = new ClienteOpc();
            clienteopc.Show();
            Close();
        }
        private void btnAddPaquete_Click(object sender, RoutedEventArgs e)
        {
            PaqueteOpc paquete = new();
            paquete.Show();
            Close();
        }
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            Close();
        }

        private void btnEnvios_Click(object sender, RoutedEventArgs e)
        {
            EnvioOpc envio = new EnvioOpc();
            envio.Show();
            Close();
        }
    }
}
