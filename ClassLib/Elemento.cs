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
        /// <param name="tipo"></param>
        /// <param name="padre"></param>
        /// <param name="id"></param>
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

        public string obtenerID()
        {
            return id;
        }


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