using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ClassLib;
using System.Collections.Generic;
using UBULibPr;
using System.Drawing;
using OpenQA.Selenium.DevTools.V128.DOM;

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
        public void validarContrasenaTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.IsTrue(usuario.validarContrasena("123"));
            Assert.IsFalse(usuario.validarContrasena("1234"));
        }

        [TestMethod()]
        public void raicesCreadasTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.AreEqual("noPago", usuario.getTipoUsuario());
            Assert.AreEqual(1, usuario.raicesCreadas());
            usuario.añadirElemento("Raiz");
            Assert.AreEqual(1, usuario.raicesCreadas());
            usuario.setTipoUsuario("Pago");
            usuario.añadirElemento("Raiz");
            Assert.AreEqual(2, usuario.raicesCreadas());
            usuario.añadirElemento("Raiz");
            Assert.AreEqual(3, usuario.raicesCreadas());
            usuario.añadirElemento("Raiz");
            Assert.AreEqual(3, usuario.raicesCreadas());
        }

        [TestMethod()]
        public void espaciosCreadosTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.AreEqual(0, usuario.espaciosCreados());
        }

        [TestMethod()]
        public void contCreadosTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.AreEqual(0, usuario.contCreados());
        }

        [TestMethod()]
        public void artCreadosTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.AreEqual(0, usuario.artCreados());
        }

        [TestMethod()]
        public void numElemTotalTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Assert.AreEqual(1, usuario.numElemTotal());
        }

        [TestMethod()]
        public void getElementosTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Dictionary<string, List<Elemento>> elementos = new Dictionary<string, List<Elemento>>();
            elementos.Add("Raiz", new List<Elemento> { new Elemento("Raiz", "0_R1") });
            elementos.Add("Espacio", new List<Elemento>());
            elementos.Add("Contenedor", new List<Elemento>());
            elementos.Add("Articulo", new List<Elemento>());

            usuario.setElementos(elementos);
            Dictionary<string, List<Elemento>> elementosUsuario = usuario.getElementos();

            Assert.AreEqual(elementos.Count, elementosUsuario.Count);
            foreach (var key in elementos.Keys)
            {
                CollectionAssert.AreEqual(elementos[key], elementosUsuario[key]);
            }
        }

        [TestMethod()]
        public void setElementosTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            Dictionary<string, List<Elemento>> elementos = new Dictionary<string, List<Elemento>>();
            elementos.Add("Raiz", new List<Elemento> { new Elemento("Raiz", "0_R1") });
            elementos.Add("Espacio", new List<Elemento> { new Elemento("Espacio", "0_E1") });
            elementos.Add("Contenedor", new List<Elemento>());
            elementos.Add("Articulo", new List<Elemento>());
            usuario.setElementos(elementos);
            Dictionary<string, List<Elemento>> elementosUsuario = usuario.getElementos();

            Assert.AreEqual(elementos.Count, elementosUsuario.Count);
            foreach (var key in elementos.Keys)
            {
                CollectionAssert.AreEqual(elementos[key], elementosUsuario[key]);
            }
        }

        [TestMethod()]
        public void añadirElementoTest()
        {
            Usuario usuario = new Usuario("correo", "123", "Pago");
            Dictionary<string, List<Elemento>> elementos = new Dictionary<string, List<Elemento>>();
            Assert.AreEqual(1, usuario.raicesCreadas());
            usuario.añadirElemento("Raiz");
            Assert.AreEqual(2, usuario.raicesCreadas());
            Assert.AreEqual(0, usuario.espaciosCreados());
            elementos = usuario.getElementos();

            Assert.IsTrue(usuario.añadirElemento("Espacio", elementos["Raiz"][0]));
            Assert.AreEqual(1, usuario.espaciosCreados());
            elementos = usuario.getElementos();

            //no debería dejar
            Assert.IsFalse(usuario.añadirElemento("Espacio", elementos["Espacio"][0]));
            Assert.AreEqual(1, usuario.espaciosCreados());

        }

        [TestMethod()]
        public void eliminarElementoTest()
        {
            Usuario usuario = new Usuario("correo", "123", "Pago");
            Assert.AreEqual(1, usuario.raicesCreadas());
            usuario.añadirElemento("Espacio", usuario.getElementos()["Raiz"][0]);
            Assert.AreEqual(1, usuario.espaciosCreados());

            // no deja eliminar la raiz
            Assert.IsFalse(usuario.eliminarElemento("0_R1"));
            Assert.AreEqual(1, usuario.raicesCreadas());

            Assert.IsTrue(usuario.eliminarElemento("0_E1"));
            Assert.AreEqual(0, usuario.espaciosCreados());

        }

        [TestMethod()]
        public void moverElementoTest()
        {
            Usuario usuario = new Usuario("correo", "123", "Pago");
            Assert.AreEqual(1, usuario.raicesCreadas());
            usuario.añadirElemento("Raiz");
            usuario.añadirElemento("Espacio", usuario.getElementos()["Raiz"][0]);
            usuario.añadirElemento("Contenedor", usuario.getElementos()["Raiz"][0]);
            Assert.AreEqual(2, usuario.raicesCreadas());
            Assert.AreEqual(1, usuario.espaciosCreados());

            //Las Raices y los espacios no se pueden mover
            Assert.IsFalse(usuario.moverElemento("0_E1", "0_R2"));
            Assert.IsFalse(usuario.moverElemento("0_R1", "0_R1"));
            Assert.IsFalse(usuario.moverElemento("0_R1", "0_E1"));
            Assert.IsFalse(usuario.moverElemento("0_R1", "0_R2"));

            Assert.IsTrue(usuario.moverElemento("0_C1", "0_E1"));
        }

        [TestMethod()]
        public void mostrarElementosTest()
        {
            Usuario usuario = new Usuario("correo", "123", "Pago");

            string resultado = usuario.mostrarElementos();
            string esperado = "0_R1\n";
            Assert.AreEqual(esperado, resultado);

            usuario.añadirElemento("Espacio", usuario.getElementos()["Raiz"][0]);
            resultado = usuario.mostrarElementos();
            esperado = "0_R1\n    └── 0_E1\n";
            Assert.AreEqual(esperado, resultado);

            usuario.añadirElemento("Contenedor", usuario.getElementos()["Raiz"][0]);
            resultado = usuario.mostrarElementos();
            esperado = "0_R1\n    ├── 0_E1\n    └── 0_C1\n";
            Assert.AreEqual(esperado, resultado);

            usuario.añadirElemento("Articulo", usuario.getElementos()["Contenedor"][0]);
            resultado = usuario.mostrarElementos();
            esperado = "0_R1\n    ├── 0_E1\n    └── 0_C1\n    └──     └── 0_A1\n";
            Assert.AreEqual(esperado, resultado);

            usuario.añadirElemento("Articulo", usuario.getElementos()["Contenedor"][0]);
            resultado = usuario.mostrarElementos();
            esperado = "0_R1\n    ├── 0_E1\n    └── 0_C1\n    └──     ├── 0_A1\n    └──     └── 0_A2\n";
            Assert.AreEqual(esperado, resultado);

            usuario.añadirElemento("Articulo", usuario.getElementos()["Espacio"][0]);
            resultado = usuario.mostrarElementos();
            esperado = "0_R1\n    ├── 0_E1\n    ├──     └── 0_A3\n    └── 0_C1\n    └──     ├── 0_A1\n    └──     └── 0_A2\n";
            Assert.AreEqual(esperado, resultado);


        }

        [TestMethod()]
        public void getNombreTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            usuario.setNombre("Juan");
            Assert.AreEqual("Juan", usuario.getNombre());
        }

        [TestMethod()]
        public void getPaisTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            usuario.setPais("España");
            Assert.AreEqual("España", usuario.getPais());
        }

        [TestMethod()]
        public void getTelefonoTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            usuario.setTelefono("123456789");
            Assert.AreEqual("123456789", usuario.getTelefono());
        }

        [TestMethod()]
        public void setNombreTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            usuario.setNombre("Juan");
            Assert.AreEqual("Juan", usuario.getNombre());
        }

        [TestMethod()]
        public void setPaisTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            usuario.setPais("España");
            Assert.AreEqual("España", usuario.getPais());
        }

        [TestMethod()]
        public void setTelefonoTest()
        {
            Usuario usuario = new Usuario("correo", "123");
            usuario.setTelefono("123456789");
            Assert.AreEqual("123456789", usuario.getTelefono());
        }
    }
}
