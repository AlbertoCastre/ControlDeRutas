using Control_De_Rutas.Context;
using Control_De_Rutas.Entities;
using Control_De_Rutas.Services;
using Control_De_Rutas.Vistas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Control_De_Rutas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        UsuarioServices usuarioservices = new UsuarioServices();

        private void btn_LogIn_Click(object sender, RoutedEventArgs e)//boton login para comprobar
        {
            string Username = txt_UserName.Text;
            string Password = txt_Passwordbox.Password;           

            var response = usuarioservices.Login(Username, Password);//pasando parametros
            if(response != null) 
            {
                
                if (response.Roles.Nombre == "CEO")
                {
                    MenuCEO menuceo = new MenuCEO();
                    menuceo.Show();
                    Close();
                }
                else if(response.Roles.Nombre == "analista")
                {
                    MenuCEO menuceo = new MenuCEO();
                    menuceo.btnAddCliente.IsEnabled = false;
                    menuceo.btnAddPaquete.IsEnabled = false;
                    menuceo.btnEnvios.IsEnabled = false;                    
                    menuceo.Show();
                    Close();
                }
                
            }
            else
            {
                MessageBox.Show("No existe ese usuario");
            }
        }
        private void btn_MoveToSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            Close();
        }             


    }
}
