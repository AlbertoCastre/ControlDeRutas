using Control_De_Rutas.Entities;
using Control_De_Rutas.Services;
using Microsoft.EntityFrameworkCore;
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
    /// Lógica de interacción para RastreodePaquete.xaml
    /// </summary>
    public partial class RastreodePaquete : Window
    {
        public RastreodePaquete()
        {
            InitializeComponent();
        }
        PaqueteServices paqueteservices = new();
        ClienteServices clienteservices = new();
        EstadoPaqueteServices estadopaqueteservices = new();
        TipoPaqueteServices tipopaqueteservices = new();
        EnvioServices envioservices = new();
        private void BotonSelect_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TextBoxIdPaquete.Text))
            {
                MessageBox.Show("Para rastrear es necesario el ID del paquete");
            }
            else
            {
                int Id = int.Parse(TextBoxIdPaquete.Text);
                var response = paqueteservices.Search(Id);
                if(response != null)
                {
                    TextBoxIdPaquete.Text = response.PkIdPaquete.ToString();
                    TextBoxDescripcion.Text = response.Descripcion.ToString();
                    TextBoxObservaciones.Text = response.Observaciones.ToString();
                    TextBoxPeso.Text = response.Peso.ToString();
                    TextBoxOrigen.Text = response.Origen.ToString();
                    TextBoxDestino.Text = response.Destino.ToString();
                    //Llenar txt de cliente
                    int IdCliente = int.Parse(response.FkCliente.ToString());
                    var responsecli = clienteservices.SearchCliente(IdCliente);
                    if (responsecli == null)
                    {
                        MessageBox.Show("Falta llenar datos de cliente");
                    }
                    TextBoxCliente.Text = responsecli.NombreCliente.ToString();
                    //Llenar txt de Estado
                    int IdEstados = int.Parse(response.FkEstados.ToString());
                    var responseEstado = estadopaqueteservices.SearchEstado(IdEstados);
                    TextBoxEstado.Text = responseEstado.NombreEstado.ToString();
                    //Llenar txt de tipo
                    int IdTipo = int.Parse(response.FkTipoPaquete.ToString());
                    var responseTipo = tipopaqueteservices.SearchTipo(IdTipo);
                    TextBoxTipoPaquete.Text = responseTipo.NombreTipoPaquete.ToString();
                    //Llenar txt de hora y fecha
                    int IdEnvio = int.Parse(TextBoxIdPaquete.Text);
                    var responseEnvio = envioservices.SearchEnvio(IdEnvio);
                    if (responseEnvio == null)
                    {
                        MessageBox.Show("Falta llenar el envio");
                    }
                    else
                    {
                        TextBoxFecha.Text = responseEnvio.Fecha.ToString();
                        TextBoxHora.Text = responseEnvio.Hora.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro ese paquete");
                }                
                
            }
        }

        private void BotonRiniciar_Click(object sender, RoutedEventArgs e)
        {
            TextBoxIdPaquete.Text = string.Empty;
            TextBoxTipoPaquete.Text = string.Empty;
            TextBoxHora.Text = string.Empty;
            TextBoxFecha.Text = string.Empty;
            TextBoxCliente.Text = string.Empty;
            TextBoxEstado.Text = string.Empty;
            TextBoxOrigen.Text = string.Empty;
            TextBoxDestino.Text = string.Empty;
            TextBoxDescripcion.Text = string.Empty;
            TextBoxObservaciones.Text = string.Empty;
            TextBoxPeso.Text = string.Empty;
        }
        private void btnHomeBack_Click(object sender, RoutedEventArgs e)
        {
            MenuCEO menu = new MenuCEO();
            menu.Show();
            Close();
        }
    }

}
