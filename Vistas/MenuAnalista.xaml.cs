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
    /// Lógica de interacción para MenuAnalista.xaml
    /// </summary>
    public partial class MenuAnalista : Window
    {
        public MenuAnalista()
        {
            InitializeComponent();
        }

        private void btnRastreo_Click(object sender, RoutedEventArgs e)
        {
            RastreodePaquete rastreodePaquete = new RastreodePaquete();
            rastreodePaquete.Show();
            Close();
        }
    }
}
