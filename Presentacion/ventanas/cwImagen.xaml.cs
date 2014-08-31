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
using System.Windows.Shapes;

namespace AgendaDigital.presentacion.ventanas
{
    /// <summary>
    /// Lógica de interacción para cwImagen.xaml
    /// </summary>
    public partial class cwImagen : Window
    {
        public string url;
        public cwImagen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            url = txtRuta.Text;
            this.Close();
        }
    }
}
