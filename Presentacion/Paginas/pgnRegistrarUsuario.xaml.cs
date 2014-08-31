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

using AgendaDigital.presentacion.Paginas;
using AgendaDigital.negocios.Clases;

namespace AgendaDigital.presentacion.Paginas
{
    /// <summary>
    /// Interaction logic for pgnRegistrarUsuario.xaml
    /// </summary>
    public partial class pgnRegistrarUsuario : Page
    {
        Button btnGuardar;
        public pgnRegistrarUsuario()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(clIdioma.LanguageDictionary());
            this.btnGuardar = clBotones.guardar;
            btnGuardar.Click += new RoutedEventHandler(btnGuardar_Click);
            clBotones.activarBotones(true, false, false, true, false);
        }

        void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtnombre.Text == "" || ucPass.Password=="" || ucPass1.Password=="")
            {
                txterror.Visibility = Visibility.Visible;
                imgError.Visibility = Visibility.Visible;
            }
            else
            {
                if (ucPass1.Password == ucPass.Password)
                {
                    txterror.Visibility = Visibility.Hidden;
                    imgError.Visibility = Visibility.Hidden;
                    txtnombre.IsEnabled = false;
                    ucPass.IsEnabled = false;
                    ucPass1.IsEnabled = false;
                    negocios.Clases.clUsuario.registrarUsuario(txtnombre.Text, ucPass.Password);
                }
                else
                {
                    txterror.Visibility = Visibility.Visible;
                    imgError.Visibility = Visibility.Visible;
                }
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            btnGuardar.Click -= btnGuardar_Click;
        }
    }
}
