using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ClassLib;

namespace ClassLib.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        [TestMethod()]
        public void UsuarioTest()
        {
            Usuario usuarioBasico = new Usuario("correo1@gmail.com", "123456");
            Assert.AreEqual("correo1@gmail.com", usuarioBasico.getEmailUsuario());
            Assert.AreEqual("noPago", usuarioBasico.getTipoUsuario());
            Assert.IsFalse(usuarioBasico.getPrivilegios());


            Usuario usuarioAdmin = new Usuario("correoAdmin@gmail.com", "123456", "Admin", true);
            Assert.AreEqual("correoAdmin@gmail.com", usuarioAdmin.getEmailUsuario());
            Assert.AreEqual("Admin", usuarioAdmin.getTipoUsuario());
            Assert.IsTrue(usuarioAdmin.getPrivilegios());

            Usuario usuarioPago = new Usuario("correoPago@gmail.com", "123456", "Pago", false);
            Assert.AreEqual("correoPago@gmail.com", usuarioPago.getEmailUsuario());
            Assert.AreEqual("Pago", usuarioPago.getTipoUsuario());
            Assert.IsFalse(usuarioPago.getPrivilegios());

            Usuario usuarioNoPago = new Usuario("correoNoPago@gmail.com", "123456", "noPago", false);
            Assert.AreEqual("correoNoPago@gmail.com", usuarioNoPago.getEmailUsuario());
            Assert.AreEqual("noPago", usuarioNoPago.getTipoUsuario());
            Assert.IsFalse(usuarioNoPago.getPrivilegios());
        }

        [TestMethod()]
        public void setIdUsuarioTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            usuario.setIdUsuario(1);
            Assert.AreEqual(1, usuario.getIdUsuario());
        }

        [TestMethod()]
        public void setTipoUsuarioTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.AreEqual("noPago", usuario.getTipoUsuario());
            usuario.setTipoUsuario("Admin");
            Assert.AreEqual("Admin", usuario.getTipoUsuario());
            usuario.setTipoUsuario("Pago");
            Assert.AreEqual("Pago", usuario.getTipoUsuario());
            usuario.setTipoUsuario("noPago");
            Assert.AreEqual("noPago", usuario.getTipoUsuario());

        }

        [TestMethod()]
        public void getTipoUsuarioTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.AreEqual("noPago", usuario.getTipoUsuario());
        }

        [TestMethod()]
        public void getIdUsuarioTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            usuario.setIdUsuario(1);
            Assert.AreEqual(1, usuario.getIdUsuario());
        }

        [TestMethod()]
        public void setEmailUsuarioTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            usuario.setEmailUsuario("correoNuevo");
            Assert.AreEqual("correoNuevo", usuario.getEmailUsuario());
        }

        [TestMethod()]
        public void getEmailUsuarioTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.AreEqual("correo", usuario.getEmailUsuario());
        }

        [TestMethod]
        public void CambiarEmailTest()
        {
            string emailInicial = "usuario@ejemplo.com";
            string emailNuevo = "nuevo@ejemplo.com";
            Usuario usuario = new Usuario(emailInicial, "Contrasena123");

            usuario.CambiarEmail(emailNuevo);

            Assert.AreEqual(emailNuevo, usuario.getEmailUsuario());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "El email no puede ser nulo o igual al anterior")]
        public void CambiarEmail_LanzaExcepcionSiEmailEsNulo()
        {
            string emailInicial = "usuario@ejemplo.com";
            Usuario usuario = new Usuario(emailInicial, "Contrasena123");

            usuario.CambiarEmail(null);
            Assert.ThrowsException<Exception>(() => usuario.CambiarEmail(null));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "El email no puede ser nulo o igual al anterior")]
        public void CambiarEmail_LanzaExcepcionSiEmailEsIgualAlAnterior()
        {
            string emailInicial = "usuario@ejemplo.com";
            Usuario usuario = new Usuario(emailInicial, "Contrasena123");

            usuario.CambiarEmail(emailInicial);
            Assert.ThrowsException<Exception>(() => usuario.CambiarEmail(emailInicial));
        }

        [TestMethod]
        public void CambiarContrasena_CambiaLaContrasenaCorrectamente()
        {
            string email = "usuario@ejemplo.com";
            string contrasenaInicial = "Contrasena123";
            string contrasenaNueva = "NuevaContrasena123?";
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
            Assert.ThrowsException<Exception>(() => usuario.cambiarContrasena(contrasenaNueva));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "La contrasena no puede ser igual a una de las 10 anteriores")]
        public void CambiarContrasena_LanzaExcepcionSiContrasenaEsIgualAUnaAnterior()
        {
            string email = "usuario@ejemplo.com";
            string contrasenaInicial = "Contrasena123";
            Usuario usuario = new Usuario(email, contrasenaInicial);

            usuario.cambiarContrasena(contrasenaInicial);
            Assert.ThrowsException<Exception>(() => usuario.cambiarContrasena(contrasenaInicial));
        }
    }
}
