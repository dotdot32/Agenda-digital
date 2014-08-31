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
    /// Interaction logic for pgnCorreo.xaml
    /// </summary>
    public partial class pgnCorreo : Page
    {
        int id;
        
        public pgnCorreo(int id)
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(clIdioma.LanguageDictionary());
            clBotones.activarBotones(false, false, false, true, false);
            this.id = id;
            ucCorreo.Text = clCorreo.nombreDestino(id);
            ucCorreo.IsReadOnly = true;
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            
            List<string> list=clCorreo.listaCorreo(id);
            if (list.Count == 0)
            {
                MessageBox.Show(clIdioma.pgn.FindResource("Error. El contacto no ningun correo asociado").ToString());
            }
            else
            {
                if (clCorreo.enviarCorreo(list, ucAsunto.Text, txtCuerpo.Text))
                {
                    NavigationService.Navigate(null);
                    clBotones.activarBotones(false, false, false, false, false);
                }
            }
        }

        

    }
}
