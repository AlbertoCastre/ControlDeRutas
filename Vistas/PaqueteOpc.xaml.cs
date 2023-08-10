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
    /// Lógica de interacción para PaqueteOpc.xaml
    /// </summary>
    public partial class PaqueteOpc : Window
    {
        public PaqueteOpc()
        {
            InitializeComponent();
            GetTypePaquetes();
            GetEstadosPaquetes();
        }
        PaqueteServices paqueteservices = new();
        ClienteServices clienteservices = new();       

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdCliente.Text == "")
            {
                MessageBox.Show("Es necesario la Id de cliente");

            }
            else if (txtOrigen.Text == "" || txtDestino.Text == "" || txtPeso.Text == "" || txtDescripcion.Text == "" || txtObservaciones.Text == "" || cbEstadoPaquete.Items.Count == 0 || cbTipoPaquete.Items.Count == 0)
            {
                MessageBox.Show("Se necesita rellenar todos los campos");
            }
            else
            {
                int IdCliente = int.Parse(txtIdCliente.Text);
                Paquete paquete = new Paquete();
                paquete.FkCliente = int.Parse(txtIdCliente.Text);
                paquete.Origen = txtOrigen.Text;
                paquete.Destino = txtDestino.Text;
                paquete.Peso = float.Parse(txtPeso.Text);
                paquete.Descripcion = txtDescripcion.Text;
                paquete.Observaciones = txtObservaciones.Text;
                paquete.FkTipoPaquete = int.Parse(cbTipoPaquete.SelectedValue.ToString());
                paquete.FkEstados = int.Parse(cbEstadoPaquete.SelectedValue.ToString());
                paqueteservices.AddPaquete(paquete);
                MessageBox.Show("El paquete ha sido guardado");
                txtIdCliente.Clear();
                txtFkCliente.Clear();
                txtOrigen.Clear();
                txtDestino.Clear();
                txtPeso.Clear();
                txtDescripcion.Clear();
                txtDescripcion.Clear();
                txtObservaciones.Clear();
                txtIdPaquete.Clear();
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdPaquete.Text != "")
            {
                int IdPaquete = int.Parse(txtIdPaquete.Text);
                var response = paqueteservices.Search(IdPaquete);
                if(response != null) 
                {
                    txtIdCliente.Text = response.FkCliente.ToString();
                    txtIdPaquete.Text = response.PkIdPaquete.ToString();
                    txtOrigen.Text = response.Origen.ToString();
                    txtDestino.Text = response.Destino.ToString();
                    txtPeso.Text = response.Peso.ToString();
                    txtDescripcion.Text = response.Descripcion.ToString();
                    txtObservaciones.Text = response.Observaciones.ToString();
                    //cbEstadoPaquete.SelectedValue = response.EstadosPaquetes.ToString();
                    //cbTipoPaquete.SelectedValue = response.FkTipoPaquete.ToString();
                    //Conseguir nombre de cliente
                    int IdCliente = int.Parse(response.FkCliente.ToString());
                    var responsecli = clienteservices.SearchCliente(IdCliente);
                    txtFkCliente.Text = responsecli.NombreCliente.ToString();
                }
                else
                {
                    MessageBox.Show("No existe ese paquete");
                }               
            }
            else
            {
                MessageBox.Show("Para buscar se necesita el Id del paquete");
            }

        }

        private void btnUpdateCliente_Click(object sender, RoutedEventArgs e)
        {
            if(txtIdPaquete.Text != "")
            {
                int id = int.Parse(txtIdPaquete.Text);
                Paquete paquete = new Paquete();
                paquete.PkIdPaquete = id;                
                paquete.Origen = txtOrigen.Text;
                paquete.Destino = txtDestino.Text;
                paquete.Peso = float.Parse(txtPeso.Text);
                paquete.Descripcion = txtDescripcion.Text;
                paquete.Observaciones = txtObservaciones.Text;
                paquete.FkTipoPaquete = int.Parse(cbTipoPaquete.SelectedValue.ToString());
                paquete.FkEstados = int.Parse(cbEstadoPaquete.SelectedValue.ToString());
                paqueteservices.UpdatePaquete(paquete);
                MessageBox.Show("Se actualizaron los datos");
                txtIdCliente.Clear();
                txtFkCliente.Clear();
                txtOrigen.Clear();
                txtDestino.Clear();
                txtPeso.Clear();
                txtDescripcion.Clear();
                txtDescripcion.Clear();
                txtObservaciones.Clear();
                txtIdPaquete.Clear();
            }
            else
            {
                MessageBox.Show("Se necesita el ID del paquete");
            }
            
        }

        private void btnDeleteCliente_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtIdPaquete.Text))
            {
                MessageBox.Show("Campo de ID vacio");
            }
            else
            {
                int id = int.Parse(txtIdPaquete.Text);
                paqueteservices.DeletePaquete(id);
                MessageBox.Show("Se eleminaron el paquete");
                txtIdCliente.Clear();
                txtFkCliente.Clear();
                txtOrigen.Clear();
                txtDestino.Clear();
                txtPeso.Clear();
                txtDescripcion.Clear();
                txtDescripcion.Clear();
                txtObservaciones.Clear();
                txtIdPaquete.Clear();
            }
        }

        public void GetTypePaquetes()
        {
            cbTipoPaquete.ItemsSource = paqueteservices.GetTypePaquetes();
            cbTipoPaquete.DisplayMemberPath = "NombreTipoPaquete";
            cbTipoPaquete.SelectedValuePath = "FkIdTipoPaquete";

        }

        public void GetEstadosPaquetes()
        {
            cbEstadoPaquete.ItemsSource = paqueteservices.GetEstadoPaquetes();
            cbEstadoPaquete.DisplayMemberPath = "NombreEstado";
            cbEstadoPaquete.SelectedValuePath = "FkIdEstado";
        }

        private void btnHomeBack_Click(object sender, RoutedEventArgs e)
        {
            MenuCEO menu = new MenuCEO();
            menu.Show();
            Close();        
        }

        private void checkCliente_Checked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("Para validar el usuario introduzca el ID");
            }
            else if (checkCliente.IsChecked == true)
            {
                int idPack = int.Parse(txtIdCliente.Text);
                var responsepack = paqueteservices.Search(idPack);
                if (responsepack != null)
                {
                    int IdCliente = (int)responsepack.FkCliente;
                    var responseclien = clienteservices.SearchCliente(IdCliente);
                    txtFkCliente.Text = responseclien.NombreCliente.ToString();
                }
                else
                {
                    MessageBox.Show("No existe ese cliente");
                }
                
            }
        }
    }
}
