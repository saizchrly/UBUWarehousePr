using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UBULibPr
{
    public class Utilidades
    {
        public static string Encriptar(string cadena)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.UTF8.GetBytes(cadena);
            SHA256 mySHA256 = SHA256Managed.Create();
            encryted = mySHA256.ComputeHash(encryted);
            result = System.Text.Encoding.ASCII.GetString(encryted);
            return result;
        }
        public static int CompruebaContrasena(string cadena)
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

        public static int CompruebaIBAN(string iban)
        {
            string caracteres = "ES0123456789";
            List<string> codBancos = new List<string> { "0241","2080","8620","1535","0011","0200","0136","3183","1541","0061","1550","0078","0188","0182","0225","0198","0091","0240","0003","9000","1569","0169","0081","0184","0220","0232","0186","0121","0235","1509","0049","8843","1574",
                                                        "0219","1485","1488","8832","0128","1525","1580","0152","1554","8696","9607","1533","6717","1532","1492","0149","1500","1576","0230","0061","1545","0038","1451","1493","3025","3159","3045","3162","3117","3105","3096","3123","3070",
                                                        "3111","3166","3160","3102","3118","3174","6305","0835","8776","2100","2045","3029","3035","3115","3110","3005","3190","3150","3179","3001","3191","3059","3089","3060","3104","3127","3121","3009","3007","3023","3140","3067","3008",
                                                        "3098","3016","3017","3080","3020","3144","3152","3085","3187","3157","3134","3018","3165","3119","3113","3130","3112","3135","3095","3058","3076","0237","8844","4706","0234","2000","1553","1474","1499","1546","1543","2056","0159",
                                                        "1459","8221","8814","7053","0154","1472","1555","7919","2258","6716","8842","1457","1548","0145","0019","8826","1501","0211","1473","3081","0239","0218","8308","8805","8823","6726","6718","4470","2165","8839","1496","6702","1564",
                                                        "1497","1504","0162","2085","4832","1514","1538","1465","1000","1494","1567","1482","0151","5660","2477","2095","1547","8342","6725","1520","4799","1552","0630","2657","1559","6723","6720","0160","8556","7659","1544","1563","1479",
                                                        "0133","8235","1577","8814","0073","1568","8542","4893","6722","0284","0391","6707","0029","0839","1508","0083","1583","3138","0242","0224","8906","0036","4797","0964","1549","8813","6705","8795","8833","1490","1551","8816","0108","1578","8838","6724","8836","1573","1570","1487","4784","6721","1491","1460","0226","2103","1557","8596","8512","8769","6719","6709","8806","1480","1575","0229","8840","1560" };
            if (iban.Length != 24) return 0;
            if (iban.Intersect(caracteres).Count() > 0) return 1;
            if (iban.ElementAt(0) != 'E' && iban.ElementAt(1) != 'S') return 2;
            string codEnt = (string)codBancos.ElementAt(4);
            for (int i = 5; i < 8; i++)
            {
                codEnt.Append(iban.ElementAt(i));
            }
            if (codBancos.Contains(codEnt) == false) return 3;
            return 4;
        }

        /// <summary>
        /// Escribe un texto en un archivo .txt.
        /// </summary>
        /// <param name="rutaArchivo">La ruta del archivo donde se escribirá el texto.</param>
        /// <param name="texto">El texto a escribir en el archivo.</param>
        public static void EscribirEnArchivo(string rutaArchivo, string texto)
        {
            using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
            {
                escritor.WriteLine(texto);
            }
        }
    }
}