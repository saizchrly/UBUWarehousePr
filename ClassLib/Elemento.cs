using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    /// <summary>
    /// Clase Elemento que modela los 4 tipos de elementos que puede tener un usuario
    /// </summary>
    public class Elemento
    {
        private string tipo;
        private List<Elemento> hijos;
        private Elemento padre;
        private List<String> tiposPosibles = new List<string> { "Raiz", "Espacio", "Contenedor", "Articulo" };
        private string id;
        /// <summary>
        /// Constructor para crear raíces
        /// </summary>
        /// <param name="id"> id del elemento raíz a crear
        public Elemento(string id)
        {
            tipo = "Raiz";
            hijos = new List<Elemento>();
            this.id = id;
        }
        /// <summary>
        /// Constructor para el resto de elementos
        /// </summary> 
        /// <param name="tipo"></param> tipo del elemento a crear
        /// <param name="padre"></param> padre del elemento a crear
        /// <param name="id"></param> id del elemento a crear
        public Elemento(string tipo, Elemento padre, string id)
        {
            if (!tiposPosibles.Contains(tipo))
            {
                throw new System.Exception("Tipos incompatibles");
            }
            if (tipo.Equals("Raiz"))
            {
                throw new System.Exception("Utilice el otro constructor para crear elementos raíz");
            }
            this.tipo = tipo;
            this.padre = padre;
            this.id = id;
            if (tipo.Equals("Articulo")) hijos = null;
            else hijos = new List<Elemento>();
        }

        /// <summary>
        /// Método que añade un elemento hijo al elemento actual
        /// </summary>
        /// <param name="tipo"></param> tipo del elemento a añadir
        /// <param name="id"></param> id del elemento a añadir
        /// <returns></returns>
        public bool AnadirHijo(string tipo, string id)
        {
            Elemento e;
            if (!tiposPosibles.Contains(tipo)) return false;
            switch (tipo)
            {
                case "Raiz":
                    if (tipo.Equals("Raiz")) return false;
                    e = new Elemento(tipo, this, id);
                    this.hijos.Add(e);
                    return true;
                case "Espacio":
                    if (tipo.Equals("Raiz")) return false;
                    e = new Elemento(tipo, this, id);
                    this.hijos.Add(e);
                    return true;
                case "Contenedor":
                    if (!tipo.Equals("Articulo")) return false;
                    e = new Elemento(tipo, this, id);
                    this.hijos.Add(e);
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Getter para el id del elemento
        /// </summary>
        /// <returns></returns> id del elemento
        public string obtenerID()
        {
            return id;
        }

        /// <summary>
        /// Getter para obtener los hijos del elemento actual
        /// </summary>
        /// <returns></returns> lista de hijos del elemento actual
        public List<Elemento> obtenerHijos()
        {
            return hijos;
        }

        /// <summary>
        /// Método que elimina un elemento pasado por parámetro
        /// </summary>
        /// <param name="id"></param> id del elemento a borrar
        /// <returns></returns>
        public bool Eliminar(Elemento hijo)
        {
            if (this.hijos == null) return false;
            foreach (Elemento i in hijos)
            {
                if (i.Equals(hijo))
                {
                    hijos.Remove(hijo);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Método que devuelve la localización de un elemento
        /// </summary>
        /// <returns></returns> lista de elementos desde la raíz hasta el elemento
        public List<Elemento> ObtenerLocalizacion()
        {
            List<Elemento> camino = new List<Elemento>();
            Stack<Elemento> stack = new Stack<Elemento>();
            Elemento e = this;
            while (!e.padre.Equals(null))
            {
                stack.Push(e);
                e = e.padre;
            }
            while (stack.Count > 0)
            {
                camino.Add(stack.Pop());
            }
            return camino;
        }

        public Elemento obtenerPadre() => padre;

        public string obtenerTipo() => tipo;
    }
}