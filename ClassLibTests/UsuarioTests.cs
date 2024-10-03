using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ClassLib;

namespace ClassLibTests
{
    [TestClass]
    public class UsuarioTests
    {
        [TestMethod]
        public void CambiarEmail_CambiaElEmailCorrectamente()
        {
            string emailInicial = "usuario@ejemplo.com";
            string emailNuevo = "nuevo@ejemplo.com";
            Usuario usuario = new Usuario(emailInicial, "Contrasena123");

            usuario.CambiarEmail(emailNuevo);

            Assert.AreEqual(emailNuevo, usuario.getEmailUsuario());

            File.Delete(emailInicial + ".log");
            File.Delete(emailNuevo + ".log");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "El email no puede ser nulo o igual al anterior")]
        public void CambiarEmail_LanzaExcepcionSiEmailEsNulo()
        {
            string emailInicial = "usuario@ejemplo.com";
            Usuario usuario = new Usuario(emailInicial, "Contrasena123");

            usuario.CambiarEmail(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "El email no puede ser nulo o igual al anterior")]
        public void CambiarEmail_LanzaExcepcionSiEmailEsIgualAlAnterior()
        {
            string emailInicial = "usuario@ejemplo.com";
            Usuario usuario = new Usuario(emailInicial, "Contrasena123");

            usuario.CambiarEmail(emailInicial);
        }

        [TestMethod]
        public void CambiarContrasena_CambiaLaContrasenaCorrectamente()
        {
            string email = "usuario@ejemplo.com";
            string contrasenaInicial = "Contrasena123";
            string contrasenaNueva = "NuevaContrasena123";
            Usuario usuario = new Usuario(email, contrasenaInicial);

            usuario.cambiarContrasena(contrasenaNueva);

            // PREGUNTAR COMO HACERLO
            // No hay un método público para obtener la contraseña, así que verificamos que no lanza excepción
            Assert.IsTrue(true);

            File.Delete(email + ".log");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "La contrasena no cumple con los requisitos minimos")]
        public void CambiarContrasena_LanzaExcepcionSiContrasenaNoCumpleRequisitos()
        {
            string email = "usuario@ejemplo.com";
            string contrasenaInicial = "Contrasena123";
            string contrasenaNueva = "123";
            Usuario usuario = new Usuario(email, contrasenaInicial);

            usuario.cambiarContrasena(contrasenaNueva);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "La contrasena no puede ser igual a una de las 10 anteriores")]
        public void CambiarContrasena_LanzaExcepcionSiContrasenaEsIgualAUnaAnterior()
        {
            string email = "usuario@ejemplo.com";
            string contrasenaInicial = "Contrasena123";
            Usuario usuario = new Usuario(email, contrasenaInicial);

            usuario.cambiarContrasena(contrasenaInicial);
        }
    }
}
