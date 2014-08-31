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
    /// Interaction logic for PgnLogin.xaml
    /// </summary>
    public partial class PgnLogin : Page
    {
        public PgnLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clIdioma.idioma = cbIdioma.SelectedIndex;
            Boolean valid = clMantenimiento.iniciarsesion(txtnombre.Text,ucPass.Password);

            if (valid == true)
                NavigationService.Navigate(new PgnPrincipal());
        }
    }
}
