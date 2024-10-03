using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBULibPr;

namespace ClassLib
{
    public class Log
    {
        public static void escribirLog(string usuario, string Accion)
        {
            DateTime fecha = DateTime.Now;
            string texto =" Fecha: " + fecha + " Accion: " + Accion;
            Utilidades.EscribirEnArchivo(usuario + ".log", texto);
        } 
    }
}
