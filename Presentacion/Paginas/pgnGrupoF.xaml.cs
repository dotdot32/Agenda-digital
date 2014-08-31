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
    /// Lógica de interacción para pgnGrupoF.xaml
    /// </summary>
    public partial class pgnGrupoF : Page
    {
        public pgnGrupoF()
        {
            InitializeComponent();
            List<string> list= clMantenimiento.buscarGruposActivos();

            for (int i = 0; i < list.Count; i++)
            {
                cbGrupo.Items.Add(list.ElementAt(i));
            }
                cbGrupo.Items.Add("-");
            clBotones.activarBotones(true, false, false, true, false);
            clBotones.guardar.Click += new RoutedEventHandler(guardar_Click);
        }

        void guardar_Click(object sender, RoutedEventArgs e)
        {
            if (cbGrupo.Text != "-")
            {
                clContacto.idGrupo = clMantenimiento.getIdGrupo(cbGrupo.Text);
            }
            else
            {
                clContacto.idGrupo = -1;
            }
            this.NavigationService.Navigate(null);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            clBotones.guardar.Click -= guardar_Click;
        }
    }
}
