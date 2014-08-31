using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaDigital.negocios.Clases
{
    public class clUsuario
    {
        public static string nombre;
        public static string contraseña;
        public static void registrarUsuario(string nom, string contra)
        {
            nombre = nom;
            contraseña = contra;
            clMantenimiento.agregarUsuario(nombre, contraseña);
        }
    }
    public class clGrupo
    {
        public static string nombre;
        public static Boolean estado;
        public static void registrarGrupos(string nom, string est)
        {
            nombre = nom;
            if (est == "Activo")
                estado = true;
            else
                estado = false;
            clMantenimiento.agregarGrupos(nombre, estado);
        }
    }

}
