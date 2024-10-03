using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLib.Tests
{
    [TestClass]
    public class LogTests
    {
        [TestMethod]
        public void EscribirLog_CreaArchivoSiNoExiste()
        {
            string usuario = "testuser";
            string accion = "Test action";
            string rutaArchivo = usuario + ".log";

            Log.escribirLog(usuario, accion);

            Assert.IsTrue(File.Exists(rutaArchivo));

            File.Delete(rutaArchivo);
        }

        [TestMethod]
        public void EscribirLog_AgregaTextoConFechaYAccion()
        {
            string usuario = "testuser";
            string accion = "Test action";
            string rutaArchivo = usuario + ".log";

            Log.escribirLog(usuario, accion);

            string[] lineas = File.ReadAllLines(rutaArchivo);
            Assert.AreEqual(1, lineas.Length);
            StringAssert.Contains(lineas[0], "Fecha:");
            StringAssert.Contains(lineas[0], "Accion: " + accion);

            File.Delete(rutaArchivo);
        }
    }
}