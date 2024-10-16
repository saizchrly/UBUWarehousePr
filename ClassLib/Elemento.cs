using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<String> tiposPosibles = new List<string>{ "Raiz", "Espacio", "Contenedor", "Articulo" };
        private String id;
        List<Elemento> ubicacion;
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
            if (!tiposPosibles.Contains(tipo) || tipo.Equals("Raiz"))
            {
                return;
            }
            this.tipo = tipo;
            this.padre = padre;
            this.id = id;
            if (tipo.Equals("Articulo")) hijos = null;
            else hijos = new List<Elemento>();
            ubicacion = ObtenerLocalizacion();
        }

        /// <summary>
        /// Método que añade un elemento hijo al elemento actual
        /// </summary>
        /// <param name="tipo"></param> tipo del elemento a añadir
        /// <param name="id"></param> id del elemento a añadir
        /// <returns></returns>
        public Elemento AnadirHijo(string tipo, string id)
        {
            Elemento e;
            if (!tiposPosibles.Contains(tipo)) return null;
            switch (tipo)
            {
                case "Raiz":
                    if (tipo.Equals("Raiz")) return null;
                    e = new Elemento(tipo, this, id);
                    this.hijos.Add(e);
                    return e;
                case "esp":
                    if (tipo.Equals("Raiz")) return null;
                    e = new Elemento(tipo, this, id);
                    this.hijos.Add(e);
                    return e;
                case "cont":
                    if (!tipo.Equals("Articulo")) return null;
                    e = new Elemento(tipo, this, id);
                    this.hijos.Add(e);
                    return e;
                default:
                    return null;
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
        /// Método que elimina un elemento a partir de su id
        /// </summary>
        /// <param name="id"></param> id del elemento a borrar
        /// <returns></returns>
        public Elemento Eliminar(string id)
        {
            if (this.hijos == null) return null;
            foreach (Elemento i in hijos)
            {
                if (i.obtenerID().Equals(id))
                {
                    hijos.Remove(i);
                    return i;
                }
            }
            return null;
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
            while(stack.Count > 0)
            {
                camino.Add(stack.Pop());
            }
            return camino;
        }
    }
}