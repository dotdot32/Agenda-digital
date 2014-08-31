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
    public class clBotones
    {
        public static Button guardar;
        public static Frame frm;
        public static Button editar;
        public static Button eliminar;
        public static Button cancelar;
        public static Button correo;


        public static void activarBotones(Boolean guardar, Boolean editar, Boolean eliminar, Boolean cancelar, Boolean correo)
        {
            clBotones.guardar.IsEnabled=guardar;
            clBotones.editar.IsEnabled=editar;
            clBotones.eliminar.IsEnabled=eliminar;
            clBotones.cancelar.IsEnabled = cancelar;
            clBotones.correo.IsEnabled = correo;
        }
    }
}
