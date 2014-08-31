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
using AgendaDigital.presentacion.Paginas;

namespace AgendaDigital.presentacion.Controles
{
    /// <summary>
    /// Lógica de interacción para ucAbc.xaml
    /// </summary>
    public partial class ucAbc : UserControl
    {
        public ucAbc()
        {
            InitializeComponent();
            
            for (int i=-13  ; i < 14; i++)
            {
                TextBlock x = new TextBlock();
                x.Width = 27;
                x.Height = 25;
                x.FontSize = 16;
                x.Cursor = Cursors.Hand;
                x.Foreground = new SolidColorBrush(Colors.White);
                x.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                x.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                x.Margin = new Thickness((i*60), 0, 0, 0);
                int c='A'+i+13;
                if(c==91)
                    c='#';
                x.Text = ""+(char)c;
                x.MouseUp += new MouseButtonEventHandler(x_MouseUp);
                x.MouseEnter += new MouseEventHandler(x_MouseEnter);
                grd.Children.Add(x);
            }
      
        }

        void x_MouseEnter(object sender, MouseEventArgs e)
        {
            if (grdData.Visibility == Visibility.Visible)
            {
                TextBlock x = (TextBlock)sender;
                grdData.Margin = x.Margin;
                clContacto.consultar(x.Text, dtgrd);
            }
        }

        void x_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdData.Visibility = Visibility.Visible;
            x_MouseEnter(sender, null);
        }

        private void grdData_MouseLeave(object sender, MouseEventArgs e)
        {
            grdData.Visibility = Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (clIdioma.pgn != null)
            {
                nombreColumn.Header = clIdioma.pgn.FindResource("Nombre");
                apellidosColumn.Header = clIdioma.pgn.FindResource("Apellidos");
                consultarColums.Header = clIdioma.pgn.FindResource("Consultar");
            }

            // No cargue datos en tiempo de diseño.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Cargue los datos aquí y asigne el resultado a CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            clContacto x = clContacto.buttonToContacto(sender);
            clBotones.frm.Navigate(new pgnContacto(x.contacto,x.fav,x.listTel, x.listCorreo, x.listDir, x.id, x.grupo));
            
        }
    }
}
