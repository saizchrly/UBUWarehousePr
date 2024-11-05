using Microsoft.VisualStudio.TestTools.UnitTesting;
using WHDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib;

namespace WHDatabase.Tests
{
    [TestClass()]
    public class WHdbTests
    {
        private WHdb _db;


        [TestMethod()]
        public void WHdbTest()
        {
            _db = new WHdb();
            Assert.IsNotNull(_db);
        }

        [TestMethod()]
        public void GuardaComponenteTest()
        {
            _db = new WHdb();
            Elemento componente = new Elemento("Articulo", "1_A1");
            _db.GuardaComponente("Articulo", 1);
            Assert.AreEqual(2, _db.NumComponente());
            Elemento result = _db.LeeComponente("1_A1");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GuardaUsuarioTest()
        {
            _db = new WHdb();
            var usuario = new Usuario ("Prueba", "1234");
            _db.GuardaUsuario(usuario);
            var result = _db.LeeUsuario("Prueba");
            Assert.AreEqual(usuario, result);
        }

        [TestMethod()]
        public void LeeComponenteTest()
        {
            _db = new WHdb();
            var componente = new Elemento("Articulo", "1_A1");
            _db.GuardaComponente("Articulo" ,1);
            var result = _db.LeeComponente("1_A1");
            Assert.IsNotNull(result);

        }

        [TestMethod()]
        public void LeeUsuarioTest()
        {
            _db = new WHdb();
            var usuario = new Usuario("Prueba", "1234");
            _db.GuardaUsuario(usuario);
            var result = _db.LeeUsuario("Prueba");
            Assert.AreEqual(usuario, result);
        }

        [TestMethod()]
        public void NumComponenteTest()
        {
            _db = new WHdb();
            Assert.AreEqual(1, _db.NumComponente());
            _db.GuardaComponente("Articulo", 1);
            var result = _db.NumComponente();
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void NumUsuariosTest()
        {
            _db = new WHdb();
            var usuario1 = new Usuario("Prueba", "1234");
            var usuario2 = new Usuario("Prueba2", "1234");
            _db.GuardaUsuario(usuario1);
            _db.GuardaUsuario(usuario2);
            var result = _db.NumUsuarios();
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void NumUsuariosActivosTest()
        {
            _db = new WHdb();
            var usuario1 = new Usuario("Prueba", "1234");
            var usuario2 = new Usuario("Prueba2", "1234");
            _db.GuardaUsuario(usuario1);
            _db.GuardaUsuario(usuario2);
            var result = _db.NumUsuarios();
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void ValidaUsuarioTest()
        {
            _db = new WHdb();
            var usuario1 = new Usuario("Prueba", "1234");
            _db.GuardaUsuario(usuario1);
            var result = _db.ValidaUsuario("Prueba", "1234");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void cambiarContrasenaTest()
        {
            _db = new WHdb();
            Usuario usuario =new Usuario("Usuario1", "oldpassword");
            _db.GuardaUsuario(usuario);
            _db.cambiarContrasena("Usuario1", "oldpassword", "NewPassword123?");
            var result = _db.ValidaUsuario("Usuario1", "NewPassword123?");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void cambiarEmailTest()
        {
            _db = new WHdb();
            Usuario usuario = new Usuario("Usuario1", "1234");
            _db.GuardaUsuario(usuario);
            _db.cambiarEmail("Usuario1","1234", "newUser");
            var result = _db.LeeUsuario("newUser");
            Assert.AreEqual("newUser", result.getEmailUsuario());
        }

        [TestMethod()]
        public void registrarUsuarioTest()
        {
            _db = new WHdb();
            var usuario = new Usuario("Prueba", "1234");
            _db.registrarUsuario("Prueba", "1234");
            var result = _db.LeeUsuario("Prueba");
            Assert.AreEqual(usuario.getEmailUsuario(), result.getEmailUsuario());
        }
    }
}