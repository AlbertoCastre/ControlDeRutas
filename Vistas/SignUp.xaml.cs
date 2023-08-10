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
    /// Lógica de interacción para SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
            GetRoles();
        }
        UsuarioServices usuarioservices = new UsuarioServices();
        private void btn_CreateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txt_Username.Text) || string.IsNullOrWhiteSpace(txt_Password.Text) || string.IsNullOrWhiteSpace(cbRoles.Text))
                {
                    MessageBox.Show("No pueden haber campos vacios");
                }
                else
                {
                    Usuario user = new Usuario();
                    user.Nombre = txtNombre.Text;
                    user.Username = txt_Username.Text;
                    user.Password = txt_Password.Text;
                    user.FkRol = int.Parse(cbRoles.SelectedValue.ToString());
                    usuarioservices.AddUsuario(user);
                    txt_Username.Clear();
                    txt_Password.Clear();
                    txt_PasswordValid.Clear();
                    txt_UsernameValid.Clear();
                    txtNombre.Clear();
                    MessageBox.Show("Registro exitoso, ya puede iniciar sesión");
                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error"+ex.Message) ;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();   
            mainwindow.Show();
            Close();
        }

        public void GetRoles()
        {
            cbRoles.ItemsSource = usuarioservices.GetRoles();
            cbRoles.DisplayMemberPath = "Nombre";
            cbRoles.SelectedValuePath = "PkIdRol";
        }
    }
}
