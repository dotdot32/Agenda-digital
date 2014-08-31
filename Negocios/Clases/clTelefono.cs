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
   
    public class clTelefono
    {
        public int id { get; set; }
        public string telefono;
        public int tipo;
        public clTelefono(string telefono, int tipo)
        {
            this.telefono = telefono;
            this.tipo = tipo;
        }
        public void registrar(tbContactos cont)
        {
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    tbTelefono x = new tbTelefono();
                    x.telefono = telefono;
                    x.tipo = tipo;
                    x.idContactos = cont.idContactos;
                    context.tbTelefono.AddObject(x);
                    context.SaveChanges();
                    context.Connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al registrar el telefono:")+" "+telefono+" ."+ ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }
            }
        }

        public static void elininar(int id)
        {
            tbTelefono x;
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    x = context.tbTelefono.First(a => a.idTelefono == id);
                    string tel = x.telefono;
                    context.tbTelefono.DeleteObject(x);
                    context.SaveChanges();
                    context.Connection.Close();
                    MessageBox.Show(clIdioma.pgn.FindResource("El telefono:").ToString()+" " + tel + " "+clIdioma.pgn.FindResource("se elimino correctamente"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al eliminar el Telefono.")+" " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }

            }
        }

    }
}
