using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Tests
{
    [TestClass()]
    public class ElementoTests
    {
        [TestMethod()]
        public void ElementoTest()
        {
            string tipo = "Raiz";
            string id = "1";

            Elemento elemento = new Elemento(tipo, id);

            Assert.AreEqual(tipo, elemento.getTipo());
            Assert.AreEqual(id, elemento.getId());
        }

        [TestMethod()]
        public void setHijosTest()
        {
            Elemento elemento = new Elemento("Raiz", "1");
            List<List<string>> hijos = new List<List<string>>
            {
                new List<string> { "Espacio", "2" },
                new List<string> { "Contenedor", "3" }
            };

            elemento.setHijos(hijos);

            CollectionAssert.AreEqual(hijos, elemento.getHijos());
        }

        [TestMethod()]
        public void nuevoHijoTest()
        {
            Elemento elemento = new Elemento("Raiz", "1");
            string tipoHijo = "Espacio";
            string idHijo = "2";
            List<List<string>> expectedHijos = new List<List<string>>
            {
                new List<string> { tipoHijo, idHijo }
            };

            elemento.nuevoHijo(tipoHijo, idHijo);

            Assert.AreEqual(expectedHijos[0][0], elemento.getHijos()[0][0]);
            Assert.AreEqual(expectedHijos[0][1], elemento.getHijos()[0][1]);
        }

        [TestMethod()]
        public void getHijosTest()
        {
            Elemento elemento = new Elemento("Raiz", "1");
            List<List<string>> hijos = new List<List<string>>
            {
                new List<string> { "Espacio", "2" },
                new List<string> { "Contenedor", "3" }
            };
            elemento.setHijos(hijos);

            List<List<string>> actualHijos = elemento.getHijos();

            CollectionAssert.AreEqual(hijos, actualHijos);
        }

        [TestMethod()]
        public void setPadreTest()
        {
            // Arrange
            Elemento elemento = new Elemento("Espacio", "2");
            string tipoPadre = "Raiz";
            string idPadre = "1";
            List<string> expectedPadre = new List<string> { tipoPadre, idPadre };

            elemento.setPadre(tipoPadre, idPadre);

            CollectionAssert.AreEqual(expectedPadre, elemento.getPadre());
        }

        [TestMethod()]
        public void getPadreTest()
        {
            Elemento elemento = new Elemento("Espacio", "2");
            string tipoPadre = "Raiz";
            string idPadre = "1";
            elemento.setPadre(tipoPadre, idPadre);
            List<string> expectedPadre = new List<string> { tipoPadre, idPadre };

            List<string> actualPadre = elemento.getPadre();

            CollectionAssert.AreEqual(expectedPadre, actualPadre);
        }

        [TestMethod()]
        public void getIdTest()
        {
            string tipo = "Raiz";
            string id = "1";
            Elemento elemento = new Elemento(tipo, id);

            string actualId = elemento.getId();

            Assert.AreEqual(id, actualId);
        }

        [TestMethod()]
        public void AnadirHijoTest()
        {
            Elemento elemento = new Elemento("Raiz", "1");
            Elemento hijo = new Elemento("Espacio", "2");

            bool result = elemento.AnadirHijo(hijo);

            Assert.IsTrue(result);
            List<string> hijoElemento = elemento.getHijos()[0];
            Assert.AreEqual(hijo.getTipo(), hijoElemento[0]);
            Assert.AreEqual(hijo.getId(), hijoElemento[1]);

        }

        [TestMethod()]
        public void getTipoTest()
        {
            string tipo = "Raiz";
            string id = "1";
            Elemento elemento = new Elemento(tipo, id);

            string actualTipo = elemento.getTipo();

            Assert.AreEqual(tipo, actualTipo);
        }

        [TestMethod()]
        public void buscarElementoTest()
        {
            Dictionary<string, List<Elemento>> elementos = new Dictionary<string, List<Elemento>>
            {
                { "Raiz", new List<Elemento> { new Elemento("Raiz", "1") } },
                { "Espacio", new List<Elemento> { new Elemento("Espacio", "2") } },
                { "Contenedor", new List<Elemento> { new Elemento("Contenedor", "3") } },
                { "Articulo", new List<Elemento> { new Elemento("Articulo", "4") } }
            };
            string idElemento = "2";
            string tipoElemento = "Espacio";
            Elemento expectedElemento = elementos[tipoElemento][0];

            Elemento actualElemento = Elemento.buscarElemento(elementos, idElemento, tipoElemento);

            Assert.AreEqual(expectedElemento, actualElemento);
        }
    }
}