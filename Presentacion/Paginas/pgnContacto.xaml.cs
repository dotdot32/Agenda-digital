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
using AgendaDigital.presentacion.ventanas;
using AgendaDigital.presentacion.Controles;
using System.IO;

namespace AgendaDigital.presentacion.Paginas
{
    /// <summary>
    /// Lógica de interacción para pgnContacto.xaml
    /// </summary>
    public partial class pgnContacto : Page
    {
        int id;
        string foto;
        public pgnContacto(Object contacto)
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(clIdioma.LanguageDictionary());
            clBotones.guardar.Click += new RoutedEventHandler(guardar_Click);
            grdContacto.DataContext = contacto;
            grdContacto.IsHitTestVisible = true;
            cbGrupo.ItemsSource = clMantenimiento.buscarGruposActivos();
            clBotones.activarBotones(true, false, false, true,false);
        }

        

        public pgnContacto(Object contacto,int fav, List<clTelefono> listTel,List<clCorreo> listCorreo, List<clDireccion> listDir, int id, string grupo)
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(clIdioma.LanguageDictionary());
            activarControles(false);
            grdContacto.DataContext = contacto;
            grdContacto.IsHitTestVisible = true;
            cbFavorito.SelectedIndex = fav;
            info.agregarTelefonos(listTel);
            info.agregarCorreos(listCorreo);
            info.agregarDir(listDir);
            clBotones.editar.Click += new RoutedEventHandler(editar_Click);
            clBotones.eliminar.Click += new RoutedEventHandler(eliminar_Click);
            clBotones.activarBotones(false, true, true, true,true);
            this.id = id;
            clBotones.correo.Click += new RoutedEventHandler(correo_Click);


            cbGrupo.ItemsSource = clMantenimiento.buscarGruposActivos();
            cbGrupo.Text = grupo;

            try
            {
                BitmapImage imag = new BitmapImage();
                imag.BeginInit();
                imag.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\fotos\\" + id + ".jpg", UriKind.RelativeOrAbsolute);
                imag.EndInit();
                ftPerfil.Source = imag;
            }
            catch(Exception){}
        }

        void correo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new pgnCorreo(id));
            clBotones.correo.Click -= correo_Click;
        }

        void eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (clContacto.eliminar(id))
            {
                clBotones.guardar.Click -= eliminar_Click;
                clBotones.activarBotones(false, false, false, false,false);
                this.NavigationService.Navigate(null);
            }

        }

        void editar_Click(object sender, RoutedEventArgs e)
        {
            activarControles(true);
            clBotones.activarBotones(true, false, true, true,false);
            clBotones.guardar.Click += new RoutedEventHandler(actualizar_Click);
        }

        void actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (clContacto.actualizar(grdContacto, cbFavorito.SelectedIndex, listToTel(info.listTel), listToCorreo(info.listCorreo), listToDir(info.listDirec), clMantenimiento.getIdGrupo(cbGrupo.Text)))
            {
                clBotones.activarBotones(false, true, true, true,false);
                activarControles(false);
                clBotones.guardar.Click -= actualizar_Click;
                if(foto!="")
                    moverFoto(foto);
                NavigationService.Navigate(null);
            }
        }

        void guardar_Click(object sender, RoutedEventArgs e)
        {
            int x=clContacto.registrar(grdContacto, cbFavorito.SelectedIndex, listToTel(info.listTel), listToCorreo(info.listCorreo), listToDir(info.listDirec),clMantenimiento.getIdGrupo(cbGrupo.Text));
            if (-1 != x)
            {
                activarControles(false);
                clBotones.activarBotones(false, false, false, false,false);
                id = x;
                if (foto != "")
                    moverFoto(foto);
                this.NavigationService.Navigate(null);
                clBotones.guardar.Click -= guardar_Click;

            }
        }

        List<clTelefono> listToTel(List<ucCont> list)
        {
            List<clTelefono> tel=new List<clTelefono>();
            for (int i = 0; i < list.Count; i++)
                tel.Add(new clTelefono(list.ElementAt(i).tb.Text, list.ElementAt(i).cb.SelectedIndex) { id=list.ElementAt(i).id});
            return tel;
        }

        List<clDireccion> listToDir(List<ucCont> list)
        {
            List<clDireccion> dir = new List<clDireccion>();
            for (int i = 0; i < list.Count; i++)
                dir.Add(new clDireccion(list.ElementAt(i).tb.Text, list.ElementAt(i).cb.SelectedIndex) { id = list.ElementAt(i).id });
            return dir;
        }
        
        List<clCorreo> listToCorreo(List<ucCont> list)
        {
            List<clCorreo> correo = new List<clCorreo>();
            for (int i = 0; i < list.Count; i++)
                correo.Add(new clCorreo(list.ElementAt(i).tb.Text, list.ElementAt(i).cb.SelectedIndex) { id = list.ElementAt(i).id });
            return correo;
        }

        void activarControles(Boolean x)
        {
            cmbTipo.IsEnabled = x;
            nombreTextBox.txtBox.IsReadOnly = !x;
            apellidosTextBox.txtBox.IsReadOnly = !x;
            empresaTextBox.txtBox.IsReadOnly = !x;
            ftPerfil.IsEnabled = x;
            info.grd.IsEnabled = x;
           // info.IsEnabled= x;
            cbGrupo.IsEnabled = x;
            cbFavorito.IsEnabled = x;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            clBotones.guardar.Click -= actualizar_Click;
            clBotones.guardar.Click -= guardar_Click;
            clBotones.editar.Click -= editar_Click;
            clBotones.eliminar.Click -= eliminar_Click;
            clBotones.correo.Click -= correo_Click;
        }

        private void ftPerfil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            cwImagen x = new cwImagen();
            x.Closed += new EventHandler(x_Closed);
            x.ShowDialog();
            
        }

        void x_Closed(object sender, EventArgs e)
        {
            try
            {
                cwImagen x = (cwImagen)sender;
                BitmapImage imag = new BitmapImage();
                imag.BeginInit();
                imag.UriSource = new Uri(x.url, UriKind.RelativeOrAbsolute);
                imag.EndInit();
                ftPerfil.Source = imag;
                foto = x.url;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. " + ex.Message);
            }
        }

        void moverFoto(String x)
        {
            try
            {
                string sourceFile = @x;
                string destinationFile = Directory.GetCurrentDirectory() + "\\fotos\\" + id + ".jpg";
                System.IO.File.Copy(sourceFile, destinationFile);
            }
            catch(Exception){}
        }
    }
}
