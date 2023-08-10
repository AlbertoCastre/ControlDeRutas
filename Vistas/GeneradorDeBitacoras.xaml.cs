using Control_De_Rutas.Context;
using Control_De_Rutas.Entities;
using Control_De_Rutas.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace Control_De_Rutas.Vistas
{
    /// <summary>
    /// Lógica de interacción para GeneradorDeBitacoras.xaml
    /// </summary>
    public partial class GeneradorDeBitacoras : Window
    {
        public GeneradorDeBitacoras()
        {
            InitializeComponent();
            PaqueteTable.ItemsSource = paqueteservices.GetPaquetes();                  
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        PaqueteServices paqueteservices = new();
        //private void BtnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    if (txtPkIdPaquete.Text == "")
        //    {
        //        Paquete pack = new();
        //        pack.Descripcion = txtDescripcion.Text;//traemos los datos del txt
        //        pack.Peso = float.Parse(txtPeso.Text);
        //        pack.Observaciones = txtObservaciones.Text;
        //        //pack.TipoPaquete = txtTipoPaquete.Text;
        //        paqueteservices.AddPaquete(pack);
        //        txtDescripcion.Clear();
        //        txtPeso.Clear();
        //        txtObservaciones.Clear();
        //        txtTipoPaquete.Clear();
        //        PaqueteTable.ItemsSource = paqueteservices.GetPaquetes();
        //    }
        //    else//editar
        //    {
        //        int id = int.Parse(txtPkIdPaquete.Text);//modicar por paquete
        //        Paquete pack = new();
        //        pack.Descripcion = txtDescripcion.Text;//traemos los datos del txt
        //        pack.Peso = float.Parse(txtPeso.Text);
        //        pack.Observaciones = txtObservaciones.Text;
        //        //pack.TipoPaquete = txtTipoPaquete.Text;
        //        //pack.FkRol = int.Parse(SelectRol.SelectedValue.ToString());
        //        paqueteservices.UpdatePaquete(pack);//usamos el metodo UpdateUser
        //        //UserTable.ItemsSource = servicespaquete.GetUsuarios();//actulizamos la tabla localmente
        //        MessageBox.Show("Se actulizaron los datos");
        //        txtDescripcion.Clear();
        //        txtPeso.Clear();
        //        txtObservaciones.Clear();
        //        txtTipoPaquete.Clear();
        //        txtPkIdPaquete.Clear();
        //    }
        //}//agregar paquetes nuevos
        //public void DeletePaquete(int Id)
        //{
        //    try
        //    {
        //        using (var _context = new ApplicationDbContext())
        //        {
        //            Paquete res = _context.Paquetes.Find(Id);
        //            if (res != null)
        //            {
        //                _context.Paquetes.Remove(res);
        //                _context.SaveChanges();
        //            }
        //            else
        //            {
        //                MessageBox.Show("No existe ese paquete");
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Ocurrio un error" + ex.Message);
        //    }
        //}//borrar paquete
        //public void SelectEdit(object sender, RoutedEventArgs e)
        //{


        //    Paquete pack = new Paquete();
        //    pack = (sender as FrameworkElement).DataContext as Paquete;//con el formato de la tabla
        //    txtPkIdPaquete.Text = pack.PkIdPaquete.ToString();
        //    txtDescripcion.Text = pack.Descripcion.ToString();
        //    txtObservaciones.Text = pack.Observaciones.ToString();
        //    txtPeso.Text = pack.Peso.ToString();
        //    //txtTipoPaquete.Text = pack.TipoPaquete.ToString();
        //    Envio envio = new Envio();


        //}
        //public void UpdatePaquete(Paquete request)
        //{
        //    try
        //    {
        //        using (var _context = new ApplicationDbContext())
        //        {
        //            Paquete update = _context.Paquetes.Find(request.PkIdPaquete);
        //            update.Descripcion = txtDescripcion.Text;//traemos los datos del txt
        //            update.Peso = float.Parse(txtPeso.Text);
        //            update.Observaciones = txtObservaciones.Text;
        //            //update.TipoPaquete = txtTipoPaquete.Text;
        //            _context.Paquetes.Update(update);

        //            //_context.Entry(update).State = EntityState.Modified;
        //            _context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Sucedio un error " + ex.Message);
        //    }
        //}  
        //private void BtnOtraPagina_Click(object sender, RoutedEventArgs e)
        //{
        //    RastreodePaquete rastreodePaquetes = new RastreodePaquete();
        //    rastreodePaquetes.Show();
        //    Close();
        //}//boton temporal

        private void btn_ExportExcel_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = PaqueteTable; // Asegúrate de que el DataGrid tenga este nombre en tu XAML
            var data = (dataGrid.ItemsSource as System.Collections.IEnumerable).Cast<object>().ToList();

            // Crear un nuevo paquete de Excel
            using (var package = new ExcelPackage())
            {
                // Crear una nueva hoja de trabajo
                var worksheet = package.Workbook.Worksheets.Add("Datos");

                // Escribir los datos en la hoja de trabajo
                for (int row = 0; row < data.Count; row++)
                {
                    var properties = data[row].GetType().GetProperties();
                    for (int col = 0; col < properties.Length; col++)
                    {
                        var value = properties[col].GetValue(data[row]);
                        worksheet.Cells[row + 1, col + 1].Value = value;
                    }
                }
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TablaPaquetes.xlsx");
                // Guardar el archivo Excel en disco
                var file = new FileInfo(filePath);
                package.SaveAs(file);
            }

            MessageBox.Show("Exportación a Excel completada.");
        }

        private void btnHomeBack_Click(object sender, RoutedEventArgs e)
        {
            MenuCEO menu = new MenuCEO();
            menu.Show();
            Close();
        }

        private void btnRecargarTabla_Click(object sender, RoutedEventArgs e)
        {
            PaqueteTable.ItemsSource = paqueteservices.GetPaquetes();
        }
    }
}

