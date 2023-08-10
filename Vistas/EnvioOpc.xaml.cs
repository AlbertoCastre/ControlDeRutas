using Control_De_Rutas.Entities;
using Control_De_Rutas.Services;
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
    /// Lógica de interacción para EnvioOpc.xaml
    /// </summary>
    public partial class EnvioOpc : Window
    {
        public EnvioOpc()
        {
            InitializeComponent();
        }
        #region Objetos
        PaqueteServices paqueteservices = new();
        ClienteServices clienteservices = new();
        EnvioServices envioservices = new();
        #endregion
        #region Agregar Envio
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumPaquete.Text))
            {
                MessageBox.Show("Ingrese es necesario el código del paquete");
            }
            else if (string.IsNullOrEmpty(txtFecha.Text) || string.IsNullOrEmpty(txtHora.Text))
            {
                MessageBox.Show("Es necesario ingresar la fecha y la hora");
            }
            else if(string.IsNullOrEmpty(txtFkCliente.Text) || string.IsNullOrEmpty(txtClienteNom.Text))
            {
                MessageBox.Show("No se encontro datos de cliente");
            }
            else
            {

                Envio envio = new();
                envio.Fecha = txtFecha.Text;
                envio.Hora = txtHora.Text;
                envio.FkPaquete = int.Parse(txtNumPaquete.Text);
                envio.FkCliente = int.Parse(txtFkCliente.Text);
                envioservices.AddEnvio(envio);
                MessageBox.Show("El envio fue guardado");
                txtIdEnvio.Clear();
                txtHora.Clear();
                txtFecha.Clear();
                txtNumPaquete.Clear();
                txtClienteNom.Clear();
            }
        }
        #endregion
        #region Buscar Envio
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdEnvio.Text))
            {
                MessageBox.Show("Ingrese es necesario el código del paquete");
            }
            else 
            {
                
                int IdEnvio = int.Parse(txtIdEnvio.Text);
                var response = envioservices.SearchEnvio(IdEnvio);
                if (response != null)
                {
                    txtFecha.Text = response.Fecha.ToString();
                    txtHora.Text = response.Hora.ToString();
                    txtFkCliente.Text = response.FkCliente.ToString();
                    txtNumPaquete.Text = response.FkPaquete.ToString();
                    int IdCliente = (int)response.FkCliente;
                    var responseclien = clienteservices.SearchCliente(IdCliente);
                    txtClienteNom.Text = responseclien.NombreCliente.ToString();
                }
                else
                {
                    MessageBox.Show("No existe ese envio");
                }
                   

            }
        }
        #endregion
        #region Actualizar Envio
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(txtIdEnvio.Text != "")
            {
                int id = int.Parse(txtIdEnvio.Text);
                Envio envio = new();
                envio.Fecha = txtFecha.Text;
                envio.Hora = txtHora.Text;
                envioservices.UpdateEnvio(envio);
                MessageBox.Show("Los datos fueron actualizados");
                txtIdEnvio.Clear();
                txtHora.Clear();
                txtFecha.Clear();
                txtNumPaquete.Clear();
                txtClienteNom.Clear();
            }
            else
            {
                MessageBox.Show("Para actualizar es necesario el ID del envio");
            }
            

        }
        #endregion
        #region Eliminar Envio
        private void btnDeleteCliente_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtIdEnvio.Text))
            {
                MessageBox.Show("Campo vacio");
            }
            else
            {
                int id = int.Parse(txtIdEnvio.Text);
                envioservices.DeleteEnvio(id);
                MessageBox.Show("Se eleminaron el paquete");
                txtIdEnvio.Clear();
                txtClienteNom.Clear();
                txtFecha.Clear();
                txtFkCliente.Clear();
                txtHora.Clear();
                txtNumPaquete.Clear();

            }
        }

        #endregion
        #region Check Cliente
        private void checkCliente_Checked(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNumPaquete.Text))
            {
                MessageBox.Show("Para validar el usuario introduzca el ID");
            }
            else if (checkCliente.IsChecked == true)
            {
                int idPack = int.Parse(txtNumPaquete.Text);
                var responsepack = paqueteservices.Search(idPack);
                if (responsepack != null)
                {
                    int IdCliente = (int)responsepack.FkCliente;
                    var responseclien = clienteservices.SearchCliente(IdCliente);
                    txtFkCliente.Text = responseclien.PkIdCliente.ToString();
                    txtClienteNom.Text = responseclien.NombreCliente.ToString();
                }
                else
                {
                    MessageBox.Show("No existe ese paquete");
                }
              
            }
        }
        #endregion
        #region Boton Menu
        private void btnHomeBack_Click(object sender, RoutedEventArgs e)
        {
            MenuCEO menu = new();
            menu.Show();
            Close();
        }
        #endregion

    }
}
