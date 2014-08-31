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
using System.Text.RegularExpressions;

namespace AgendaDigital.negocios.Clases
{
    public class clContacto
    {
        public Object contacto { get; set; }
        public int fav { get; set; }
        public List<clTelefono> listTel { get; set; }
        public List<clCorreo> listCorreo { get; set; }
        public List<clDireccion> listDir { get; set; }
        public string grupo { get; set; }
        public int titulo { get; set; }
        public int id { get; set; }

        public static Boolean favoritos;
        public static int idUsuario;
        public static int idGrupo;

        public static Object nuevo()
        {
            return (Object)new tbContactos();
        }

        public static int registrar(Grid g, int fav, List<clTelefono> listTel, List<clCorreo> listCorreo, List<clDireccion> listDir, int idGrupo)
        {
            int id;
            tbContactos contacto = g.DataContext as tbContactos;
            switch (fav)
            {
                case 0:
                    contacto.favorito = true;
                    break;
                case 1:
                    contacto.favorito = false;
                    break;
            }
            contacto.idUsuario = idUsuario;
            if (idGrupo != -1)
                contacto.idGrupo = idGrupo;
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    context.tbContactos.AddObject(contacto);
                    context.SaveChanges();
                    context.Connection.Close();

                    MessageBox.Show(clIdioma.pgn.FindResource("El Contacto").ToString() + " " + contacto.nombre + " " + clIdioma.pgn.FindResource("se ha registrado con exito").ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                    id = contacto.idContactos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                    id = -1;
                }
            }

            for (int i = 0; i < listTel.Count; i++)
            {
                if (listTel.ElementAt(i).telefono != "")
                    listTel.ElementAt(i).registrar(contacto);
            }

            for (int i = 0; i < listCorreo.Count; i++)
            {
                if (listCorreo.ElementAt(i).correo != "")
                    listCorreo.ElementAt(i).registrar(contacto);
            }

            for (int i = 0; i < listDir.Count; i++)
            {
                if (listDir.ElementAt(i).direccion != "")
                    listDir.ElementAt(i).registrar(contacto);
            }
            return id;
        }


        //-----------------------------------------------------------------------
        public static void consultar(string x, DataGrid dg)
        {
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    Boolean g = clContacto.idGrupo == -1;

                    List<tbContactos> contactos;
                    if (x == "#")
                    {
                        contactos = (from contacto in context.tbContactos
                                     where (contacto.nombre.StartsWith("1") || contacto.nombre.StartsWith("2") || contacto.nombre.StartsWith("3") || contacto.nombre.StartsWith("4") || contacto.nombre.StartsWith("5") || contacto.nombre.StartsWith("6") || contacto.nombre.StartsWith("7") || contacto.nombre.StartsWith("8") || contacto.nombre.StartsWith("9") || contacto.nombre.StartsWith("0")) && contacto.idUsuario == idUsuario && (contacto.favorito == true || !favoritos) && (contacto.idGrupo == clContacto.idGrupo || g)
                                     orderby contacto.nombre ascending
                                     select contacto).ToList();
                    }

                    else
                    {
                        contactos = (from contacto in context.tbContactos
                                     where contacto.nombre.StartsWith(x) && contacto.idUsuario == idUsuario && (contacto.favorito == true || !favoritos) && (contacto.idGrupo == clContacto.idGrupo || g)
                                     orderby contacto.nombre ascending
                                     select contacto).ToList();
                    }
                    context.Connection.Close();
                    dg.ItemsSource = contactos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al filtrar contactos").ToString() + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }
            }
        }
        //---------------------------------------------------------------------------
        public static clContacto buttonToContacto(Object sender)
        {
            tbContactos contacto = ((Button)sender).DataContext as tbContactos;
            int fav;
            if (contacto.favorito == null)
                fav = -1;
            else if ((Boolean)contacto.favorito)
                fav = 0;
            else
                fav = 1;

            List<tbTelefono> lisTel;
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                lisTel = (from tel in context.tbTelefono
                          where tel.idContactos == contacto.idContactos
                          select tel).ToList();
                context.Connection.Close();
            }
            List<clTelefono> tels = new List<clTelefono>();

            for (int i = 0; i < lisTel.Count; i++)
            {
                tels.Add(new clTelefono(lisTel.ElementAt(i).telefono, (int)lisTel.ElementAt(i).tipo) { id = lisTel.ElementAt(i).idTelefono, });
            }

            //----------------------------

            List<tbCorreo> lisCorreo;
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                lisCorreo = (from correo in context.tbCorreo
                             where correo.idContactos == contacto.idContactos
                             select correo).ToList();
                context.Connection.Close();
            }
            List<clCorreo> correos = new List<clCorreo>();

            for (int i = 0; i < lisCorreo.Count; i++)
            {
                correos.Add(new clCorreo(lisCorreo.ElementAt(i).correo, (int)lisCorreo.ElementAt(i).tipo) { id = lisCorreo.ElementAt(i).idCorreo });
            }

            //------------------------------

            List<tbDireccion> lisDir;
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                lisDir = (from dir in context.tbDireccion
                          where dir.idContactos == contacto.idContactos
                          select dir).ToList();
                context.Connection.Close();
            }
            List<clDireccion> dirs = new List<clDireccion>();

            for (int i = 0; i < lisDir.Count; i++)
            {
                dirs.Add(new clDireccion(lisDir.ElementAt(i).direccion, (int)lisDir.ElementAt(i).tipo) { id = lisDir.ElementAt(i).idDireccion });
            }
            //-------------------------

            string nombreGrupo = "";
            if (contacto.idGrupo != null)
                using (AgendaDigitalEntities context = new AgendaDigitalEntities())
                {
                    try
                    {
                        tbGrupo c = context.tbGrupo.First(p => p.idGrupo == contacto.idGrupo);
                        nombreGrupo = c.nombre;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error. " + ex.Message);
                        nombreGrupo = null;
                    }
                }


            //-----------------------
            clContacto x = new clContacto() { contacto = contacto, fav = fav, listTel = tels, listCorreo = correos, listDir = dirs, id = contacto.idContactos, grupo = nombreGrupo };
            return x;
        }
        //-----------------------------------------------------------------------------------
        public static Boolean actualizar(Grid g, int fav, List<clTelefono> listTel, List<clCorreo> listCorreo, List<clDireccion> listDir, int idGrupo)
        {
            Boolean ban;
            tbContactos contacto = g.DataContext as tbContactos;
            switch (fav)
            {
                case -1:
                    contacto.favorito = null;
                    break;
                case 0:
                    contacto.favorito = true;
                    break;
                case 1:
                    contacto.favorito = false;
                    break;
            }
            if(idGrupo != -1)
                contacto.idGrupo = idGrupo;
            try
            {
                using (AgendaDigitalEntities context = new AgendaDigitalEntities())
                {
                    context.tbContactos.Attach(context.tbContactos.Single(a => a.idContactos == contacto.idContactos));
                    context.tbContactos.ApplyCurrentValues(contacto);
                    context.SaveChanges();
                    context.Connection.Close();

                    MessageBox.Show(clIdioma.pgn.FindResource("Los datos del contacto").ToString() + " " + contacto.nombre + " " + clIdioma.pgn.FindResource("se ha actualizado con exito.").ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }
                ban = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                ban = false;
            }

            //----------------------

            for (int i = 0; i < listTel.Count; i++)
            {
                clTelefono item = listTel.ElementAt(i);
                if (item.telefono != "")
                    if (item.id == -1)
                        item.registrar(contacto);
                    else
                    {
                        tbTelefono tel;

                        try
                        {
                            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
                            {
                                tel = context.tbTelefono.First(a => a.idTelefono == item.id);
                                tel.telefono = item.telefono;
                                tel.tipo = item.tipo;
                                context.SaveChanges();
                                context.Connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(clIdioma.pgn.FindResource("Error al actualizar el telefono:").ToString() + " " + item.telefono + ". " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                        }
                    }
            }

            //----------------------

            for (int i = 0; i < listCorreo.Count; i++)
            {
                clCorreo item = listCorreo.ElementAt(i);
                if (item.correo != "")
                    if (item.id == -1)
                        item.registrar(contacto);
                    else
                    {
                        tbCorreo correo;

                        try
                        {
                            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
                            {
                                correo = context.tbCorreo.First(a => a.idCorreo == item.id);
                                correo.correo = item.correo;
                                correo.tipo = item.tipo;
                                context.SaveChanges();
                                context.Connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(clIdioma.pgn.FindResource("Error al actualizar el correo:").ToString() + " " + item.correo + ". " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                        }
                    }
            }

            //------------------------

            for (int i = 0; i < listDir.Count; i++)
            {
                clDireccion item = listDir.ElementAt(i);
                if (item.direccion != "")
                    if (item.id == -1)
                        item.registrar(contacto);
                    else
                    {
                        tbDireccion dir;

                        try
                        {
                            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
                            {
                                dir = context.tbDireccion.First(a => a.idDireccion == item.id);
                                dir.direccion = item.direccion;
                                dir.tipo = item.tipo;
                                context.SaveChanges();
                                context.Connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(clIdioma.pgn.FindResource("Error al actualizar la direccion:").ToString() + " " + item.direccion + ". " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                        }
                    }
            }

            //------------------------

            return ban;

        }
        //-------------------------------------------------------------------------

        public static Boolean eliminar(int id)
        {
            Boolean ban = true;
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    List<tbTelefono> listTel = (from tel in context.tbTelefono
                                                where tel.idContactos == id
                                                select tel).ToList();
                    for (int i = 0; i < listTel.Count; i++)
                    {
                        context.tbTelefono.DeleteObject(listTel.ElementAt(i));
                    }
                    context.SaveChanges();
                    context.Connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al eliminar los telefonos:").ToString() + " " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }
            }
            //---------------
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    List<tbCorreo> listCorreo = (from correo in context.tbCorreo
                                                 where correo.idContactos == id
                                                 select correo).ToList();
                    for (int i = 0; i < listCorreo.Count; i++)
                    {
                        context.tbCorreo.DeleteObject(listCorreo.ElementAt(i));
                    }
                    context.SaveChanges();
                    context.Connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al eliminar los correos:").ToString() + " " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }
            }
            //--------------
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    List<tbDireccion> listDir = (from dir in context.tbDireccion
                                                 where dir.idContactos == id
                                                 select dir).ToList();
                    for (int i = 0; i < listDir.Count; i++)
                    {
                        context.tbDireccion.DeleteObject(listDir.ElementAt(i));
                    }
                    context.SaveChanges();
                    context.Connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al eliminar las direcciones.").ToString() + " " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                }
            }
            //---------------
            using (AgendaDigitalEntities context = new AgendaDigitalEntities())
            {
                try
                {
                    tbContactos cont = context.tbContactos.First(a => a.idContactos == id);
                    context.tbContactos.DeleteObject(cont);
                    context.SaveChanges();
                    context.Connection.Close();
                    MessageBox.Show(clIdioma.pgn.FindResource("El contacto se elimino correctamente").ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al eliminar el contacto.").ToString() + " " + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(), MessageBoxButton.OK);
                    ban = false;
                }
            }
            return ban;
        }
    }
}
