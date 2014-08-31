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

namespace AgendaDigital.presentacion.Controles
{
    /// <summary>
    /// Lógica de interacción para ucCont.xaml
    /// </summary>
    public partial class ucCont : UserControl
    {
        public int id;
        public ucCont()
        {
            InitializeComponent();
            id = -1;
        }

        public static DependencyProperty tel = DependencyProperty.Register("Telefono", typeof(Boolean), typeof(ucCont), new UIPropertyMetadata(fTel));

        public Boolean Telefono
        {
            get { return (Boolean)GetValue(tel); }
            set { SetValue(tel, value); }
        }


        private static void fTel(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            ucCont boton = (ucCont)dpo;
            Boolean x = (Boolean)e.NewValue;

            boton.Telefono = x;

            boton.cb.Items.Add(clIdioma.pgn.FindResource("Móvil").ToString());
            boton.cb.Items.Add(clIdioma.pgn.FindResource("Casa").ToString());
            boton.cb.Items.Add(clIdioma.pgn.FindResource("Trabajo").ToString());
            boton.cb.Items.Add(clIdioma.pgn.FindResource("Otros").ToString());
//            boton.cb.Items.Add("Móvil");
            //boton.cb.Items.Add("Casa");
            //boton.cb.Items.Add("Trabajo");
            //boton.cb.Items.Add("Otro");
        }

        //-------------------------------------------------------------------------------------------
        public static DependencyProperty correo = DependencyProperty.Register("Correo", typeof(Boolean), typeof(ucCont), new UIPropertyMetadata(fCorreo));

        public Boolean Correo
        {
            get { return (Boolean)GetValue(correo); }
            set { SetValue(correo, value); }
        }


        private static void fCorreo(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            ucCont boton = (ucCont)dpo;
            Boolean x = (Boolean)e.NewValue;

            boton.Correo = x;

            boton.cb.Items.Add("Personal");
            boton.cb.Items.Add(clIdioma.pgn.FindResource("Trabajo").ToString());
            boton.cb.Items.Add(clIdioma.pgn.FindResource("Otros").ToString());
            //boton.cb.Items.Add("Personal");
            //boton.cb.Items.Add("Trabajo");
            //boton.cb.Items.Add("Otro");
        }

        //-------------------------------------------------------------------------------------------
        public static DependencyProperty Dir = DependencyProperty.Register("Dirección", typeof(Boolean), typeof(ucCont), new UIPropertyMetadata(fDir));

        public Boolean Dirección
        {
            get { return (Boolean)GetValue(Dir); }
            set { SetValue(Dir, value); }
        }


        private static void fDir(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
        {
            ucCont boton = (ucCont)dpo;
            Boolean x = (Boolean)e.NewValue;

            boton.Dirección = x;
            boton.cb.Items.Add(clIdioma.pgn.FindResource("Casa").ToString());
            boton.cb.Items.Add(clIdioma.pgn.FindResource("Trabajo").ToString());
            boton.cb.Items.Add(clIdioma.pgn.FindResource("Otros").ToString());
            //boton.cb.Items.Add("Casa");
            //boton.cb.Items.Add("Trabajo");
            //boton.cb.Items.Add("Otra");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // No cargue datos en tiempo de diseño.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Cargue los datos aquí y asigne el resultado a CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }
    }
}
