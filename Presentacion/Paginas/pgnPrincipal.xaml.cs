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
    /// Interaction logic for PgnPrincipal.xaml
    /// </summary>
    public partial class PgnPrincipal : Page
    {
        public PgnPrincipal()
        {
            this.Resources.MergedDictionaries.Add(clIdioma.LanguageDictionary());
            clIdioma.pgn = this;
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(clIdioma.LanguageDictionary());
            clBotones.guardar = btnGuardar;
            clBotones.frm = frmMantenimiento;
            clBotones.editar = btnEditar;
            clBotones.eliminar = btnEliminar;
            clBotones.cancelar = btnCancelar;
            clContacto.favoritos = false;
            clBotones.correo = btnCorreo;
            clBotones.activarBotones(false, false,false, false,false );
            clContacto.idGrupo = -1;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            frmMantenimiento.Navigate(new pgnContacto(clContacto.nuevo()));
        }

        private void btnAgregarU_Click(object sender, RoutedEventArgs e)
        {
            frmMantenimiento.Navigate(new pgnRegistrarUsuario());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmMantenimiento.Navigate(new pgnGrupos());
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frmMantenimiento.Navigate(null);
            clBotones.activarBotones(false, false, false, false,false);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            clContacto.favoritos = !clContacto.favoritos;
            if (clContacto.favoritos)
                btnFavorito.Style = (Style)this.FindResource("favoritoA");
            else
                btnFavorito.Style = (Style)this.FindResource("favorito");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            frmMantenimiento.Navigate(new pgnGrupos());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            frmMantenimiento.Navigate(new pgnGrupoF());
        }

    }
}
