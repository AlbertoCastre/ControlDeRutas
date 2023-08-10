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
    /// Lógica de interacción para Registros.xaml
    /// </summary>
    public partial class Registros : Window
    {
        public Registros()
        {
            InitializeComponent();
            GetCPS();//para los combobox
            GetTypePaquetes();
            GetEstadoPaquetes();
        }
        ClienteServices clienteservices = new ClienteServices();
        PaqueteServices paqueteservices = new PaqueteServices();
        EnvioServices envioServices = new EnvioServices();


        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(txtNombreCliente.Text=="" || txtApellidoCliente.Text =="" || txtCorreoCliente.Text == "" || txtTelefonoCliente.Text == "" || cbCodigoPostal.Items.Count == 0)
            {
                MessageBox.Show("Es necesario que se rellenen todos los campos");
            }
            else
            {
                Cliente cliente = new Cliente();
                cliente.NombreCliente = txtNombreCliente.Text;//traemos los datos
                cliente.ApellidoCliente = txtApellidoCliente.Text;
                cliente.CorreoCliente = txtCorreoCliente.Text;
                cliente.TelefonoCliente = txtTelefonoCliente.Text;
                cliente.FkCodigoPostal = int.Parse(cbCodigoPostal.SelectedValue.ToString());
                clienteservices.AddCliente(cliente);
                MessageBox.Show("Se agregaron los datos correctamente");
            }            
        }
        public void GetCPS()
        {
            cbCodigoPostal.ItemsSource = clienteservices.GetCPS();
            cbCodigoPostal.DisplayMemberPath = "Codigo_Postal";
            cbCodigoPostal.SelectedValuePath = "PkIdDirrecion";
        }

        private void BtnAddPaquete_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdCliente.Text == "")
            {
                MessageBox.Show("Es necesario la Id de cliente");

            }
            else if (txtOrigen.Text == "" || txtDestino.Text == "" || txtPeso.Text == "" || txtDescripcion.Text == "" || txtObservaciones.Text == "" )
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
            }
        }
        public void GetTypePaquetes()
        {
            cbTipoPaquete.ItemsSource = paqueteservices.GetTypePaquetes();
            cbTipoPaquete.DisplayMemberPath = "NombreTipoPaquete";
            cbTipoPaquete.SelectedValuePath = "FkIdTipoPaquete";
        }
        public void GetEstadoPaquetes()
        {
            cbEstadoPaquete.ItemsSource = paqueteservices.GetEstadoPaquetes();
            cbEstadoPaquete.DisplayMemberPath = "NombreEstado";
            cbEstadoPaquete.SelectedValuePath = "FkIdEstado";
        }

        private void BtnEnvio_Click(object sender, RoutedEventArgs e)
        {
            if(txtNumPaquete.Text == "")
            {
                MessageBox.Show("Es necesario el codigo de paquete");
            }
            else if(txtHora.Text =="" ||  txtFecha.Text =="")
            {
                MessageBox.Show("Escriba la fecha y hora");
            }
            else
            {
                int IdPaquete = int.Parse(txtNumPaquete.Text);
                Envio envio = new Envio();
                envio.Fecha = txtFecha.Text;
                envio.Hora = txtHora.Text;
                
                
                envioServices.AddEnvio(envio);
                MessageBox.Show("El envio se registro");
            }
        }      

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdCliente.Text != "")
            {
                int Id = int.Parse(txtIdCliente.Text);
                var response = clienteservices.SearchCliente(Id);
                txtNombreCliente.Text = response.NombreCliente.ToString();
                txtApellidoCliente.Text = response.ApellidoCliente.ToString();
                txtCorreoCliente.Text = response.CorreoCliente.ToString();
                txtTelefonoCliente.Text = response.TelefonoCliente.ToString();
                txtFkCliente.Text = response.NombreCliente.ToString();                
            }     
            else
            {
                MessageBox.Show("Asegurese de introducir datos");
            }
        }
    }

}
