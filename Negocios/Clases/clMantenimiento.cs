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
using AgendaDigital.datos;



using AgendaDigital.datos.Modelo;

namespace AgendaDigital.negocios.Clases
{
    public class clMantenimiento
    {
        public static Boolean iniciarsesion(string nombre,string pass)
        {
            using (AgendaDigital.datos.Modelo.AgendaDigitalEntities context = new AgendaDigital.datos.Modelo.AgendaDigitalEntities())
            {
                try
                {
                    tbUsuarios u = context.tbUsuarios.FirstOrDefault(p => p.nombre == nombre && p.password == pass);
                    if (u != null)
                    {
                        clContacto.idUsuario = u.idUsuario;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña no valido");
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error. " + ex.Message.ToString(),"Mensaje:",MessageBoxButton.OK);
                    return false;
                }
            }
        }
        public static void agregarUsuario(string nombre,string pass)
        {
            using (AgendaDigitalEntities context= new AgendaDigitalEntities())
            {
                try
                {
                    tbUsuarios u = context.tbUsuarios.FirstOrDefault(p => p.nombre == nombre);
                    if (u==null)
                    {
                        u = new tbUsuarios();
                        u.nombre = nombre;
                        u.password = pass;
                        context.tbUsuarios.AddObject(u);
                        context.SaveChanges();
                        context.Connection.Close();
                        MessageBox.Show(clIdioma.pgn.FindResource("El usuario se registro correctamente").ToString());
                    }

                    else
                    {
                        MessageBox.Show(clIdioma.pgn.FindResource("El nombre de usuario")+" "+nombre+" "+clIdioma.pgn.FindResource("ya se encuentra registrado"));
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al registrar el Usuario.") + ex.Message.ToString(), clIdioma.pgn.FindResource("Mensaje:").ToString(),MessageBoxButton.OK);
                }
                
            }
        }
        public static void agregarGrupos(string nombre,Boolean estado)
        {
            using (AgendaDigital.datos.Modelo.AgendaDigitalEntities context = new AgendaDigital.datos.Modelo.AgendaDigitalEntities())
            {
                try
                {
                    tbGrupo g = context.tbGrupo.FirstOrDefault(t=>t.nombre==nombre);
                    if (g == null)
                    {
                        g = new tbGrupo();
                        g.nombre = nombre;
                        g.estado = estado;
                        context.tbGrupo.AddObject(g);
                        context.SaveChanges();
                        context.Connection.Close();
                        MessageBox.Show(clIdioma.pgn.FindResource("El grupo se agrego correctamente").ToString());
                    }
                    else
                    {
                        MessageBox.Show(clIdioma.pgn.FindResource("El nombre del grupo")+" "+nombre+" "+clIdioma.pgn.FindResource("ya se encuentra registrado"));
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. " + ex.Message.ToString(),clIdioma.pgn.FindResource("Mensaje:").ToString(),MessageBoxButton.OK);
                }
            }
        }
        public static void eliminarGrupos(string nombre)
        {
            using (AgendaDigital.datos.Modelo.AgendaDigitalEntities context = new AgendaDigital.datos.Modelo.AgendaDigitalEntities())
            {
                try
                {
                    tbGrupo g = context.tbGrupo.FirstOrDefault(p=>p.nombre==nombre);
                    if (g != null)
                    {
                        tbContactos c = context.tbContactos.FirstOrDefault(p => p.idGrupo == g.idGrupo);
                        //if (c == null)
                        {
                            context.DeleteObject(g);
                            //g.estado = false;
                            context.SaveChanges();
                            context.Connection.Close();
                            MessageBox.Show(clIdioma.pgn.FindResource("El grupo ha sido eliminado").ToString());
                        }
                       /* else
                        {
                            MessageBox.Show(clIdioma.pgn.FindResource("Puede que el grupo este asociado a un contacto, no podra eliminarse").ToString());
                        }*/

                    }
                    else
                    {
                        MessageBox.Show(clIdioma.pgn.FindResource("El grupo ingresado no es valido").ToString());
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al eliminar el Grupo").ToString()+ex.Message.ToString(),"Mensaje:",MessageBoxButton.OK);
                }
            }
        }


        public static List<string> buscarGrupos()
        {
            using (AgendaDigital.datos.Modelo.AgendaDigitalEntities context = new AgendaDigital.datos.Modelo.AgendaDigitalEntities())
            {
                try
                {
                    List<string> b = (from grupo in context.tbGrupo select grupo.nombre).ToList();
                    context.Connection.Close();
                    return b;
                }catch(Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al buscar los grupos.")+ex.Message.ToString(),"Mensaje:",MessageBoxButton.OK);
                }
            }
            return null;
        }

        public static int getIdGrupo(string nombre)
        {
            using (AgendaDigital.datos.Modelo.AgendaDigitalEntities context = new AgendaDigital.datos.Modelo.AgendaDigitalEntities())
            {
                tbGrupo x=null;
                try
                {
                    x = context.tbGrupo.FirstOrDefault(a => a.nombre == nombre);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. " + ex.Message);
                }
                context.Connection.Close();

                if (x != null)
                    return x.idGrupo;
                else
                    return -1;
            }
        }


        public static List<string> buscarGruposActivos()
        {
            using (AgendaDigital.datos.Modelo.AgendaDigitalEntities context = new AgendaDigital.datos.Modelo.AgendaDigitalEntities())
            {
                try
                {
                    List<string> b = (from grupo in context.tbGrupo where grupo.estado==true select grupo.nombre).ToList();
                    context.Connection.Close();
                    return b;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al buscar los grupos.") + ex.Message.ToString(), "Mensaje:", MessageBoxButton.OK);
                }
            }
            return null;
        }

        public static void editarGrupos(string nombre,string nombreEditar,Boolean estado)
        {
            using (AgendaDigital.datos.Modelo.AgendaDigitalEntities context = new AgendaDigital.datos.Modelo.AgendaDigitalEntities())
            {
                try
                {
                    tbGrupo g = context.tbGrupo.FirstOrDefault(p=>p.nombre == nombreEditar);
                    g.nombre = nombre;
                    g.estado = estado;
                    context.SaveChanges();
                    context.Connection.Close();
                    MessageBox.Show(clIdioma.pgn.FindResource("El grupo:")+" "+nombreEditar+clIdioma.pgn.FindResource("ha sido editado correctamente"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(clIdioma.pgn.FindResource("Error al editar el Grupo.")+ex.Message.ToString(),clIdioma.pgn.FindResource("Mensaje:").ToString(),MessageBoxButton.OK);
                }
            }
        }
    }

}
