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
    /// Lógica de interacción para ucInfo.xaml
    /// </summary>
    /// 
    public partial class ucInfo : UserControl
    {
        public ucInfo()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(clIdioma.LanguageDictionary());
            listTel=new List<ucCont>();
            listCorreo = new List<ucCont>();
            listDirec = new List<ucCont>();

            listTel.Add(tel);
            listCorreo.Add(correo);
            listDirec.Add(dir);

            tel.btnMas.Click += new RoutedEventHandler(btnMas_MouseLeftButtonUp);
            tel.btnMenos.Click += new RoutedEventHandler(btnMenos_MouseLeftButtonUp);

            correo.btnMas.Click += new RoutedEventHandler(correo_btnMas_MouseLeftButtonUp);
            correo.btnMenos.Click += new RoutedEventHandler(correo_btnMenos_MouseLeftButtonUp);

            dir.btnMas.Click += new RoutedEventHandler(dir_btnMas_MouseLeftButtonUp);
            dir.btnMenos.Click += new RoutedEventHandler(dir_btnMenos_MouseLeftButtonUp);

            ordena();
        }

        void btnMas_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void correo_btnMas_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ucCont x = nuevo();
            x.Correo = true;
            listCorreo.Add(x);
            x.btnMas.Click += new RoutedEventHandler(correo_btnMas_MouseLeftButtonUp);
            x.btnMenos.Click += new RoutedEventHandler(correo_btnMenos_MouseLeftButtonUp);
            ordena();
        }

        void dir_btnMas_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ucCont x = nuevo();
            x.Dirección = true;
            listDirec.Add(x);
            x.btnMas.Click += new RoutedEventHandler(dir_btnMas_MouseLeftButtonUp);
            x.btnMenos.Click += new RoutedEventHandler(dir_btnMenos_MouseLeftButtonUp);
            ordena();
        }

        void dir_btnMenos_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            int id = fMenos(sender, listDirec);
            if (id != -1)
                clDireccion.elininar(id);
            ordena();
        }

        void correo_btnMenos_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            int id=fMenos(sender, listCorreo);
            if (id != -1)
                clCorreo.elininar(id);
            ordena();
        }

        void btnMenos_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            int id=fMenos(sender, listTel);
            if (id != -1)
                clTelefono.elininar(id);
            ordena();
        }

        void btnMas_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ucCont x = nuevo();
            x.Telefono = true;
            listTel.Add(x);
            x.btnMas.Click += new RoutedEventHandler(btnMas_MouseLeftButtonUp);
            x.btnMenos.Click += new RoutedEventHandler(btnMenos_MouseLeftButtonUp);
            ordena();
        }
        public List<ucCont> listTel;
        public List<ucCont> listCorreo;
        public List<ucCont> listDirec;

        private void ordena()
        {
            int v=10;
            for (int i=0;i<listTel.Count;i++)
            {
                v+=40;
                listTel.ElementAt(i).Margin=new Thickness(8, v, 8, 0);
            }
            v += 40;
            lbCorreo.Margin=new Thickness(8, v, 8, 0);
            
            for (int i = 0; i < listCorreo.Count; i++)
            {
                v += 40;
                listCorreo.ElementAt(i).Margin = new Thickness(8, v, 8, 0);
            }
            v += 40;
            lbDir.Margin = new Thickness(8, v, 8, 0);
            for (int i = 0; i < listDirec.Count; i++)
            {
                v += 40;
                listDirec.ElementAt(i).Margin = new Thickness(8, v, 8, 0);
            }

        }


        private ucCont nuevo()
        {
            ucCont x = new ucCont();
            x.Height = 41;
            x.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            grd.Children.Add(x);
            return x;
        }
        private ucCont busca(Button x, List<ucCont> list)
        {
            for (int i = 0; i < list.Count; i++)
                if (list.ElementAt(i).btnMenos == x)
                    return list.ElementAt(i);
            return null;
        }

        private int fMenos(object sender, List<ucCont> list)
        {
            ucCont x =busca((Button)sender,list);
            list.Remove(x);
            grd.Children.Remove(x);
            ordena();

            return x.id;

        }
        public void agregarTelefonos(List<clTelefono> list)
        {

            if (list.Count != 0)
            {
                listTel.Remove(tel);
                grd.Children.Remove(tel);
                //listTel = new List<ucCont>();
                for (int i = 0; i < list.Count; i++)
                {
                    ucCont x = nuevo();
                    x.Telefono = true;
                    x.cb.SelectedIndex = list.ElementAt(i).tipo;
                    x.tb.Text = list.ElementAt(i).telefono;
                    x.id = list.ElementAt(i).id;
                    listTel.Add(x);
                    x.btnMas.Click += new RoutedEventHandler(btnMas_MouseLeftButtonUp);
                    x.btnMenos.Click += new RoutedEventHandler(btnMenos_MouseLeftButtonUp);

                }
            }
            ordena();
        }
        public void agregarCorreos(List<clCorreo> list)
        {

            if (list.Count != 0)
            {
                //listCorreo = new List<ucCont>();
                listCorreo.Remove(correo);
                grd.Children.Remove(correo);
                for (int i = 0; i < list.Count; i++)
                {
                    ucCont x = nuevo();
                    x.Correo = true;
                    x.cb.SelectedIndex = list.ElementAt(i).tipo;
                    x.tb.Text = list.ElementAt(i).correo;
                    x.id = list.ElementAt(i).id;
                    listCorreo.Add(x);
                    x.btnMas.Click += new RoutedEventHandler(correo_btnMas_MouseLeftButtonUp);
                    x.btnMenos.Click += new RoutedEventHandler(correo_btnMenos_MouseLeftButtonUp);

                }
            }
            ordena();
        }
        public void agregarDir(List<clDireccion> list)
        {
            if (list.Count != 0)
            {
                //listDirec = new List<ucCont>();
                listDirec.Remove(dir);
                grd.Children.Remove(dir);
                for (int i = 0; i < list.Count; i++)
                {
                    ucCont x = nuevo();
                    x.Dirección = true;
                    x.cb.SelectedIndex = list.ElementAt(i).tipo;
                    x.tb.Text = list.ElementAt(i).direccion;
                    x.id = list.ElementAt(i).id;
                    listDirec.Add(x);
                    x.btnMas.Click += new RoutedEventHandler(dir_btnMas_MouseLeftButtonUp);
                    x.btnMenos.Click += new RoutedEventHandler(dir_btnMenos_MouseLeftButtonUp);
                }
            }
            ordena();
        }
    }
}
