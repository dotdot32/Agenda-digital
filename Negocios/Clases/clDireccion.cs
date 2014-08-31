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

using AgendaDigital.datos.Modelo;

namespace AgendaDigital.negocios.Clases
{
    public class clDireccion
    {
        public int id { get; set; }
        public string direccion;
        public int tipo;
        public clDireccion(string dir, int tipo)
        {
            this.direccion = dir;
            this.tipo = tipo;
        }
        public void registrar(tbContactos cont)
        {
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    tbDireccion x = new tbDireccion();
                    x.direccion = direccion;
                    x.tipo = tipo;
                    x.idContactos = cont.idContactos;
                    context.tbDireccion.AddObject(x);
                    context.SaveChanges();
                    context.Connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al registrar la direccion:")+" " + direccion + " ." + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }
            }
        }
        //--------------------------------------------------------------
        public static void elininar(int id)
        {
            tbDireccion x;
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    x = context.tbDireccion.First(a => a.idDireccion == id);
                    string dir = x.direccion;
                    context.tbDireccion.DeleteObject(x);
                    context.SaveChanges();
                    context.Connection.Close();
                    MessageBox.Show(clIdioma.pgn.FindResource("La Direccion:") +" "+ dir +" "+ clIdioma.pgn.FindResource("se elimino correctamente"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al eliminar la direccion.") + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }

            }
        }

        //--------------------------------------------------------------------
    }

}