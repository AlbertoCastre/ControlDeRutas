using Control_De_Rutas.Entities;
using Control_De_Rutas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ubiety.Dns.Core;

namespace Control_De_Rutas.Vistas
{
    /// <summary>
    /// Lógica de interacción para ClienteOpc.xaml
    /// </summary>
    public partial class ClienteOpc : Window
    {
        public ClienteOpc()
        {
            InitializeComponent();
            GetCPS();
        }
        ClienteServices clienteservices = new ClienteServices();
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreCliente.Text == "" || txtApellidoCliente.Text == "" || txtCorreoCliente.Text == "" || txtTelefonoCliente.Text == "" || cbCodigoPostal.Items.Count == 0)
            {
                MessageBox.Show("Es necesario que se rellenen todos los campos");
            }
            else
            {
                Cliente cliente = new Cliente();
                //traemos los datos
                cliente.NombreCliente = txtNombreCliente.Text;
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

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdCliente.Text != "")
            {
                int Id = int.Parse(txtIdCliente.Text);
                var response = clienteservices.SearchCliente(Id);
                if (response != null)
                {
                    txtNombreCliente.Text = response.NombreCliente.ToString();
                    txtApellidoCliente.Text = response.ApellidoCliente.ToString();
                    txtCorreoCliente.Text = response.CorreoCliente.ToString();
                    txtTelefonoCliente.Text = response.TelefonoCliente.ToString();
                }
                else
                {
                    MessageBox.Show("No existe ese cliente");
                }
                
                
            }
            else
            {
                MessageBox.Show("Asegurese de introducir datos");
            }

        }

        private void btnUpdateCliente_Click(object sender, RoutedEventArgs e)
        {
            if(txtIdCliente.Text != "")
            {
                int id = int.Parse(txtIdCliente.Text);//guardamos el valor de la Pk del usuario seleccionado
                Cliente cliente = new Cliente();
                cliente.PkIdCliente = id;
                cliente.NombreCliente = txtNombreCliente.Text;//traemos los datos actulizados            
                cliente.ApellidoCliente = txtApellidoCliente.Text;
                cliente.CorreoCliente = txtCorreoCliente.Text;
                cliente.TelefonoCliente = txtTelefonoCliente.Text;
                cliente.FkCodigoPostal = int.Parse(cbCodigoPostal.SelectedValue.ToString());
                clienteservices.UpdateCliente(cliente);
                MessageBox.Show("Se actulizaron los datos");
                txtNombreCliente.Clear();
                txtApellidoCliente.Clear();
                txtCorreoCliente.Clear();
                txtTelefonoCliente.Clear();
            }
            else
            {
                MessageBox.Show("Para actualizar es necesario el ID del cliente");
            }
            
        }

        private void btnDeleteCliente_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("No se puede borrar esta vacio");
            }
            else
            {
                Cliente cliente = new Cliente();
                int Id = int.Parse(txtIdCliente.Text);//comprobamos que exista un valor de PkUser para borrar
                clienteservices.DeleteCliente(Id);
                MessageBox.Show("Se borraron los datos");
                txtNombreCliente.Clear();
                txtApellidoCliente.Clear();
                txtCorreoCliente.Clear();
                txtTelefonoCliente.Clear();
            }
        }

        private void btnHomeBack_Click(object sender, RoutedEventArgs e)
        {
            MenuCEO menu = new MenuCEO();
            menu.Show();
            Close();
        }

    
    }
    
}

