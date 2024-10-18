using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ClassLib;
using System.Collections.Generic;
using UBULibPr;

namespace ClassLib.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        [TestMethod()]
        public void UsuarioTest()
        {
            Usuario usuarioBasico = new Usuario("correo1@gmail.com", "123456");
            List<string> listaContrasenas = new List<string> { Utilidades.Encriptar("123456") };
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
        public void getElementosListaTest()
        {
            Elemento raiz = new Elemento("1");
            List<Elemento> elementos = new List<Elemento> { raiz };
            Usuario usuario = new Usuario("correo", "123");
            usuario.setElementosLista(elementos);
            Assert.AreEqual(elementos, usuario.getElementosLista());
        }

        [TestMethod()]
        public void setElementosListaTest()
        {
            Elemento elemento1 = new Elemento("Elemento1");
            Elemento elemento2 = new Elemento("Elemento2");
            List<Elemento> elementos = new List<Elemento> { elemento1, elemento2 };
            Usuario usuario = new Usuario("correo", "123");
            usuario.setElementosLista(elementos);
            Assert.AreEqual(elementos, usuario.getElementosLista());
        }

        [TestMethod()]
        public void setPrivilegiosTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.IsFalse(usuario.getPrivilegios());
            usuario.setPrivilegios(true);
            Assert.IsTrue(usuario.getPrivilegios());
            usuario.setPrivilegios(false);
            Assert.IsFalse(usuario.getPrivilegios());
        }

        [TestMethod()]
        public void getPrivilegiosTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.IsFalse(usuario.getPrivilegios());
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

        [TestMethod]
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

        [TestMethod()]
        public void cambiarEmailTest()
        {
            string emailInicial = "usuario@ejemplo.com";
            string emailNuevo = "nuevo@ejemplo.com";
            Usuario usuario = new Usuario(emailInicial, "Contrasena123");
            Assert.IsTrue(usuario.cambiarEmail(emailNuevo));
            Assert.AreEqual(emailNuevo, usuario.getEmailUsuario());
        }
        [TestMethod()]
        public void cambiarEmailTest_null()
        {
            Usuario usuario = new Usuario("usuario", "Contrasena123");
            Assert.IsFalse(usuario.cambiarEmail(null));

        }
        [TestMethod()]
        public void cambiarEmailTest_vacio()
        {
            Usuario usuario = new Usuario("usuario", "Contrasena123");
            Assert.IsFalse(usuario.cambiarEmail(""));
        }
        [TestMethod()]
        public void cambiarEmailTest_espacios()
        {
            Usuario usuario = new Usuario("usuario", "Contrasena123");
            Assert.IsFalse(usuario.cambiarEmail(" "));
        }
        [TestMethod()]
        public void cambiarEmailTest_igual()
        {
            string emailInicial = "usuario@ejemplo.com";
            Usuario usuario = new Usuario(emailInicial, "Contrasena123");
            Assert.IsFalse(usuario.cambiarEmail(emailInicial));
        }

        [TestMethod()]
        public void cambiarContrasenaTest()
        {
            string email = "usuario@ejemplo.com";
            string contrasenaInicial = "Contrasena123?";
            string contrasenaNueva1 = "NuevaContrasena12?";
            string contrasenaNueva2 = "NuevaContrasena122?";
            string contrasenaNueva3 = "NuevaContrasena123?";
            string contrasenaNueva4 = "NuevaContrasena124?";
            string contrasenaNueva5 = "NuevaContrasena125?";
            string contrasenaNueva6 = "NuevaContrasena126?";
            string contrasenaNueva7 = "NuevaContrasena127?";
            string contrasenaNueva8 = "NuevaContrasena128?";
            string contrasenaNueva9 = "NuevaContrasena193?";
            string contrasenaNueva10 = "NuevaContrasena1023?";
            string contrasenaNuevaNoRequisitos = "1234";
            List<string> ListaContrasenas = new List<string> { contrasenaNueva2, contrasenaNueva3, contrasenaNueva4, contrasenaNueva5, contrasenaNueva6, contrasenaNueva7, contrasenaNueva8, contrasenaNueva9, contrasenaNueva10 };
            Usuario usuario = new Usuario(email, contrasenaInicial);

            Assert.IsTrue(usuario.cambiarContrasena(contrasenaNueva1));

            //No cumple requisitos
            Assert.IsFalse(usuario.cambiarContrasena(contrasenaNuevaNoRequisitos));

            //Igual a una de las anteriores
            Assert.IsFalse(usuario.cambiarContrasena(contrasenaInicial));

            // Metemos 9 contraseñas nuevas, y con la inicial y el primer cambio, serian 11,
            // por lo que deberia dejar poner la inicial de nuevo
            foreach (string contrasena in ListaContrasenas)
            {
                Assert.IsTrue(usuario.cambiarContrasena(contrasena));
            }
            Assert.IsTrue(usuario.cambiarContrasena(contrasenaInicial));
            Assert.IsFalse(usuario.cambiarContrasena(contrasenaNueva8));
        }

        [TestMethod()]
        public void añadirElementoTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            //añadimos raiz
            Elemento elemento1 = new Elemento("1");
            List<Elemento> elementos = new List<Elemento> { elemento1 };
            usuario.setElementosLista(elementos);
            //añadimos espacio
            Elemento elemento2 = new Elemento("2");
            Assert.IsTrue(usuario.añadirElemento("1", "Espacio", "2"));
        }

        [TestMethod()]
        public void buscarElementoTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void eliminarElementoTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void moverElementoTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void getRaicesCreadasTest()
        {
            Usuario usuario = new Usuario("correo", "123");

            Elemento elemento1 = new Elemento("1");
            List<Elemento> elementos = new List<Elemento> { elemento1 };
            usuario.setElementosLista(elementos);
            Assert.AreEqual(1, usuario.getRaicesCreadas());


        }

        [TestMethod()]
        public void getEspaciosCreadosTest()
        {
            Usuario usuario = new Usuario("correo", "123");

            Elemento elemento1 = new Elemento("1");
            List<Elemento> elementos = new List<Elemento> { elemento1 };
            usuario.setElementosLista(elementos);
            Assert.AreEqual(1, usuario.getRaicesCreadas());
            Elemento elemento2 = new Elemento("2");
            Assert.IsTrue(usuario.añadirElemento("1", "Espacio", "2"));
            Assert.AreEqual(1, usuario.getEspaciosCreados());
        }

        [TestMethod()]
        public void getContCreadosTest()
        {
            Usuario usuario = new Usuario("correo", "123");

            Elemento elemento1 = new Elemento("1");
            List<Elemento> elementos = new List<Elemento> { elemento1 };
            usuario.setElementosLista(elementos);
            Assert.AreEqual(1, usuario.getRaicesCreadas());
            Elemento elemento2 = new Elemento("2");
            Assert.IsTrue(usuario.añadirElemento("1", "Espacio", "2"));
            Assert.AreEqual(1, usuario.getEspaciosCreados());
            Elemento elemento3 = new Elemento("3");
            Assert.IsTrue(usuario.añadirElemento("2", "Contenedor", "3"));
            Assert.AreEqual(1, usuario.getContCreados());
        }

        [TestMethod()]
        public void getArtCreadosTest()
        {
            Usuario usuario = new Usuario("correo", "123");

            Elemento elemento1 = new Elemento("1");
            List<Elemento> elementos = new List<Elemento> { elemento1 };
            usuario.setElementosLista(elementos);
            Assert.AreEqual(1, usuario.getRaicesCreadas());
            Elemento elemento2 = new Elemento("2");
            Assert.IsTrue(usuario.añadirElemento("1", "Espacio", "2"));
            Assert.AreEqual(1, usuario.getEspaciosCreados());
            Elemento elemento3 = new Elemento("3");
            Assert.IsTrue(usuario.añadirElemento("2", "Contenedor", "3"));
            Assert.AreEqual(1, usuario.getContCreados());
            Elemento elemento4 = new Elemento("4");
            Assert.IsTrue(usuario.añadirElemento("3", "Articulo", "4"));
            Assert.AreEqual(1, usuario.getArtCreados());
        }

        [TestMethod()]
        public void getNumElemTest()
        {
            Usuario usuario = new Usuario("correo", "123");

            Elemento elemento1 = new Elemento("1");
            List<Elemento> elementos = new List<Elemento> { elemento1 };
            usuario.setElementosLista(elementos);
            Assert.AreEqual(1, usuario.getRaicesCreadas());
            Elemento elemento2 = new Elemento("2");
            Assert.IsTrue(usuario.añadirElemento("1", "Espacio", "2"));
            Assert.AreEqual(1, usuario.getEspaciosCreados());
            Elemento elemento3 = new Elemento("3");
            Assert.IsTrue(usuario.añadirElemento("2", "Contenedor", "3"));
            Assert.AreEqual(1, usuario.getContCreados());
            Elemento elemento4 = new Elemento("4");
            Assert.IsTrue(usuario.añadirElemento("3", "Articulo", "4"));
            Assert.AreEqual(1, usuario.getArtCreados());
            Assert.AreEqual(4, usuario.getNumElem());
        }
    }
}
