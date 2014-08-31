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
using System.Net.Mail;
using System.Net;

using AgendaDigital.datos.Modelo;


namespace AgendaDigital.negocios.Clases
{
    public class clCorreo
    {
        public int id { get; set; }
        public string correo;
        public int tipo;


        public clCorreo(string correo, int tipo)
        {
            this.correo = correo;
            this.tipo = tipo;
        }

        public void registrar(tbContactos cont)
        {
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    tbCorreo x = new tbCorreo();
                    x.correo = correo;
                    x.tipo = tipo;
                    x.idContactos = cont.idContactos;
                    context.tbCorreo.AddObject(x);
                    context.SaveChanges();
                    context.Connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el correo: " + correo + " ." + ex.Message.ToString(), "Mensaje:", MessageBoxButton.OK);
                }
            }
        }
        //--------------------------------------------------------------
        public static void elininar(int id)
        {
            tbCorreo x;
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    x = context.tbCorreo.First(a => a.idCorreo == id);
                    string coreo = x.correo;
                    context.tbCorreo.DeleteObject(x);
                    context.SaveChanges();
                    context.Connection.Close();
                    MessageBox.Show(clIdioma.pgn.FindResource("El correo:") + " " + coreo + " " + clIdioma.pgn.FindResource("se elimino correctamente"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al registrar el correo").ToString() + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }

            }
        }

        //--------------------------------------------------------------------
        public static List<string> listaCorreo(int id)
        {
            try
            {
                using (AgendaDigitalEntities context = new AgendaDigitalEntities())
                {
                    List<string> lista = (from correo in context.tbCorreo
                                          where correo.idContactos == id
                                          select correo.correo).ToList();

                    context.Connection.Close();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(clIdioma.pgn.FindResource("Error al agregar el destinatario") + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                return null;
            }

        }
        public static string nombreDestino(int id)
        {
            tbContactos contacto;
            try
            {
                using (AgendaDigitalEntities context = new AgendaDigitalEntities())
                {
                    contacto = context.tbContactos.First(a => a.idContactos == id);
                    context.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                return null;
            }
            return contacto.nombre + " " + contacto.apellidos;
        }

        public static Boolean enviarCorreo(List<string> correos, string asunto, string cuerpo)
        {
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential myCreds = new NetworkCredential("unahollows@gmail.com", "Hollows2012");
            cliente.EnableSsl = true;
            cliente.Credentials = myCreds;

            MailMessage msg = new MailMessage();
            for (int i = 0; i < correos.Count; i++)
            {
                msg.To.Add(correos.ElementAt(i));
            }

            msg.From = new MailAddress("unahollows@gmail.com");
            msg.Subject = asunto;
            msg.Body = cuerpo;
            msg.Priority = MailPriority.High;

            try
            {
                cliente.Send(msg);
                MessageBox.Show(clIdioma.pgn.FindResource("Mensaje enviado exitosamente").ToString());
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(clIdioma.pgn.FindResource("Error, no se pudo enviar el mensaje.")+" " + ex.Message);
                return false;
            }
        }
    }
}
