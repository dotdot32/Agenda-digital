using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AgendaDigital.negocios.Clases;

namespace AgendaDigital.presentacion.Paginas
{
    /// <summary>
    /// Interaction logic for pgnGrupos.xaml
    /// </summary>
    public partial class pgnGrupos : Page
    {
        Button btnGuardar;
        Button btnEditar;
        Button btneliminar;
        bool editar = false;
        public pgnGrupos()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(clIdioma.LanguageDictionary());
            cmbGrupos.ItemsSource = clMantenimiento.buscarGrupos();
            this.btnGuardar = clBotones.guardar;
            this.btnEditar = clBotones.editar;
            this.btneliminar = clBotones.eliminar;
            clBotones.activarBotones(true, true, false, true,false);
            btnGuardar.Click += new RoutedEventHandler(btnGuardar_Click);
            btnEditar.Click += new RoutedEventHandler(btnEditar_Click);
            btneliminar.Click += new RoutedEventHandler(btneliminar_Click);
        }

        void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            clMantenimiento.eliminarGrupos(cmbGrupos.Text);
            clBotones.activarBotones(false, false, false, false, false);
            this.NavigationService.Navigate(null);
        }

        void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            
            cmbGrupos.IsEnabled = true;
            cmbGrupos.Visibility = Visibility.Visible;
            txtlista.Visibility = Visibility.Visible;
            clBotones.activarBotones(true, false, true, true, false);
            editar = true;
        }

        void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (editar)
            {
                if (cmbEstado.Text == "Activo")
                    clMantenimiento.editarGrupos(txtnombreGrupo.Text, cmbGrupos.Text, true);
                else
                    clMantenimiento.editarGrupos(txtnombreGrupo.Text, cmbGrupos.Text, false);
            }
            else
            {

                if (txtnombreGrupo.Text != "")
                    negocios.Clases.clGrupo.registrarGrupos(txtnombreGrupo.Text, cmbEstado.Text);
                else
                    MessageBox.Show(clIdioma.pgn.FindResource("Debe ingresar un nombre para el Grupo").ToString());
                clBotones.activarBotones(false, false, false, false, false);
                
            }
            this.NavigationService.Navigate(null);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            btnGuardar.Click -= btnGuardar_Click;
            btneliminar.Click -= btneliminar_Click;
            btnEditar.Click -= btnEditar_Click;
        }
    }
}
