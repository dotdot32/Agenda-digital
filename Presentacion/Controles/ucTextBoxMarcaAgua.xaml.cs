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
    /// Lógica de interacción para ucTextBoxMarcaAgua.xaml
    /// </summary>
    public partial class ucTextBoxMarcaAgua : UserControl
    {
        public ucTextBoxMarcaAgua()
        {
            InitializeComponent();
          
        }

        public static DependencyProperty texto = DependencyProperty.Register("Text", typeof(String), typeof(ucTextBoxMarcaAgua), new UIPropertyMetadata(fText));

        public String Text
        {
            get { return (string)GetValue(texto); }
            set { SetValue(texto, value); }
        }

        private static void fText(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            ucTextBoxMarcaAgua boton = (ucTextBoxMarcaAgua)dpo;
            String x = (String)e.NewValue;
            
            boton.txtBox.Text = x;
            boton.Marca = false;
        }

        //--------------------------------------------------------------------------------------

        private static DependencyProperty marca = DependencyProperty.Register("Marca", typeof(Boolean), typeof(ucTextBoxMarcaAgua), new UIPropertyMetadata(fMarca));

        private Boolean Marca
        {
            get { return (Boolean)GetValue(marca); }
            set { SetValue(marca, value); }
        }


        private static void fMarca(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            ucTextBoxMarcaAgua boton = (ucTextBoxMarcaAgua)dpo;
            Boolean x = (Boolean)e.NewValue;

            boton.Marca = x;
        }

        //--------------------------------------------------------------------------------------

        public static DependencyProperty MarcaA = DependencyProperty.Register("MarcaAgua", typeof(String), typeof(ucTextBoxMarcaAgua), new UIPropertyMetadata(fAgua));


        public String MarcaAgua
        {
            get { return (string)GetValue(MarcaA); }
            set { SetValue(MarcaA, value); }
        }


        private static void fAgua(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            ucTextBoxMarcaAgua boton = (ucTextBoxMarcaAgua)dpo;
            String x = (String)e.NewValue;
            boton.MarcaAgua = x;
            if(boton.Marca)
                boton.txtBox.Text = x;
        }

        //--------------------------------------------------------------------------------------

        private void txtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(Marca)
                txtBox.Text = "";
        }

        //---------------------------------------------------------------------------------------

        private void txtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBox.Text != "")
            {
                Marca = false;
                Text = txtBox.Text;
            }
            else
            {
                Text = "";
                txtBox.Text = MarcaAgua;
                Marca = true;
            }

        }

        //----------------------------------------------------------------------------------

        private void txtBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (Text == "" || Text==null)
            {
                Marca = true;
                txtBox.Text = MarcaAgua;
            }
            else
            {
                Marca = false;
            }
        }

        //--------------------------------------------------------------------------------------
    }
}
