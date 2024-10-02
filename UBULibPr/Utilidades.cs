using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UBULibPr
{
    public class Utilidades
    {
        public string Encriptar(string cadena)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.UTF8.GetBytes(cadena);
            SHA256 mySHA256 = SHA256Managed.Create();
            encryted = mySHA256.ComputeHash(encryted);
            result = System.Text.Encoding.ASCII.GetString(encryted);
            return result;
        }
        public int CompruebaContrasena(string cadena)
        {
            string caracteresPermitdos = "abcdefghijklmnopqrstuvwxyz";
            string numerosPermitidos = "0123456789";
            string caracteresEspeciales = "!@#$%^&*()_+?¿";
            int puntuacion = 0;

            // Iniciamos los compronbantes
            if (cadena.Contains(" ")) return 0;
            if (cadena.Length > 8) puntuacion++;
            if (cadena.Intersect(caracteresPermitdos).Count() > 0) puntuacion++;
            if (cadena.Intersect(caracteresPermitdos.ToUpper()).Count() > 0) puntuacion++;
            if (cadena.Intersect(numerosPermitidos).Count() > 0) puntuacion++;
            if (cadena.Intersect(caracteresEspeciales).Count() > 0) puntuacion++;

            return puntuacion;
        }


    }
}