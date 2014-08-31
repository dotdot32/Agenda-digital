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

namespace AgendaDigital.presentacion.Controles
{
    /// <summary>
    /// Lógica de interacción para ucPassMarcaAgua.xaml
    /// </summary>
    public partial class ucPassMarcaAgua : UserControl
    {
        public ucPassMarcaAgua()
        {
            InitializeComponent();
            Password = "";
        }

        public static DependencyProperty password = DependencyProperty.Register("Password", typeof(String), typeof(ucPassMarcaAgua), new UIPropertyMetadata(fPass));

        public String Password
        {
            get { return (string)GetValue(password); }
            set { SetValue(password, value); }
        }

        private static void fPass(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            ucPassMarcaAgua boton = (ucPassMarcaAgua)dpo;
            String x = (String)e.NewValue;

            boton.pass.Password = x;
            boton.Marca = false;
        }
        //--------------------------------------------------------------------------------------------------------------------

        private static DependencyProperty marca = DependencyProperty.Register("Marca", typeof(Boolean), typeof(ucPassMarcaAgua), new UIPropertyMetadata(fMarca));

        private Boolean Marca
        {
            get { return (Boolean)GetValue(marca); }
            set { SetValue(marca, value); }
        }


        private static void fMarca(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            ucPassMarcaAgua boton = (ucPassMarcaAgua)dpo;
            Boolean x = (Boolean)e.NewValue;

            boton.Marca = x;
        }
        //-----------------------------------------------------------------------------------------------------------------------

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Marca)
                pass.Password = "";
        }

        //-----------------------------------------------------------------------------------------------------------------------
        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pass.Password != "")
            {
                Marca = false;
                Password = pass.Password;
            }
            else
            {
                Password = "";
                pass.Password = "Pass";
                Marca = true;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Password == "")
            {
                Marca = true;
                pass.Password = "Pass";
            }
            else
            {
                Marca = false;
            }
        }

        



    }
}
