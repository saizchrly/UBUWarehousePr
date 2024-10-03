using Microsoft.VisualStudio.TestTools.UnitTesting;
using UBULibPr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBULibPr.Tests
{
    [TestClass()]
    public class UtilidadesTests
    {
        [TestMethod()]
        public void EncriptarTest()
        {
            Utilidades utilidades = new Utilidades();
            string cadena1 = "HolaContraseña";
            string cadena2 = "holacontraseña";
            string cadena3 = "HolaContraseña";
            string cadena4 = "";
            Assert.AreEqual(utilidades.Encriptar(cadena1), utilidades.Encriptar(cadena3));
            Assert.AreNotEqual(utilidades.Encriptar(cadena1), utilidades.Encriptar(cadena2));
            Assert.AreNotEqual(utilidades.Encriptar(cadena1), utilidades.Encriptar(cadena4));
            Assert.AreNotEqual(utilidades.Encriptar(cadena2), utilidades.Encriptar(cadena4));
        }

        [TestMethod()]
        /*[DataRow("a", 1)]
         * [DataRow("2", 2)]
         * [DataRow("A", 3)]
         * public void CompruebaContrasenaTest(string cadena, int resultado)
         *      Utilidades utilidades = new Utilidades();
         *      Assert.AreEqual(utilidades.CompruebaContrasena(cadena), resultado);
         *      o tambien se puede hacer de la siguiente forma
         *      Assert.IsTrue(utilidades.CompruebaContrasena(cadena) == resultado);
         */
        public void CompruebaContrasenaTest()
        {
            Utilidades utilidades = new Utilidades();
            string cadena1 = "sololetrasminusculas";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena1), 2);

            string cadena2 = "SOLOLETRASMAYUSCULAS";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena2), 2);

            string cadena3 = "SoloLetrasMinusculasYMayusculas";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena3), 3);

            string cadena4 = "01";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena4), 1);

            string cadena5 = "SoloLetrasMinusculasYMayusculas1234567890";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena5), 4);

            string cadena6 = "";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena6), 0);

            string cadena7 = "SoloLetrasMinusculasYMayusculas1234567890!";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena7), 5);

            string cadena8 = "@";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena8), 1);

            string cadena9 = "           ";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena9), 0);

            string cadena10 = "Esto es una contraseña de 8 caracteres ?";
            Assert.AreEqual(utilidades.CompruebaContrasena(cadena10), 0);
        }

        [TestMethod]
        public void EscribirEnArchivo_CreaArchivoSiNoExiste()
        {
            string rutaArchivo = "testfile.log";
            string texto = "Texto de prueba";

            Utilidades.EscribirEnArchivo(rutaArchivo, texto);

            Assert.IsTrue(File.Exists(rutaArchivo));

            File.Delete(rutaArchivo);
        }

        [TestMethod]
        public void EscribirEnArchivo_AgregaTextoAlFinal()
        {
            string rutaArchivo = "testfile.log";
            string texto1 = "Primera línea";
            string texto2 = "Segunda línea";

            Utilidades.EscribirEnArchivo(rutaArchivo, texto1);
            Utilidades.EscribirEnArchivo(rutaArchivo, texto2);

            string[] lineas = File.ReadAllLines(rutaArchivo);
            Assert.AreEqual(2, lineas.Length);
            Assert.AreEqual(texto1, lineas[0]);
            Assert.AreEqual(texto2, lineas[1]);

            File.Delete(rutaArchivo);
        }
    }
}