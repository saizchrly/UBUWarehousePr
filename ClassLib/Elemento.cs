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
        private List<List<string>> hijos;
        private List<string> padre;
        private List<String> tiposPosibles = new List<string> { "Raiz", "Espacio", "Contenedor", "Articulo" };
        private string id;
      
        /// <summary>
        /// Constructor para el resto de elementos
        /// </summary> 
        /// <param name="tipo"></param> tipo del elemento a crear
        /// <param name="id"></param> id del elemento a crear
        public Elemento(string tipo, string id)
        {
            if (!tiposPosibles.Contains(tipo))
            {
                throw new System.Exception("Tipos incompatibles");
            }
            
            this.tipo = tipo;
            this.id = id;
            // si no tienen simplemente estaran vacias.
            // Tipo=0, id=1
            padre = new List<string>();
            // hijo == Tipo=0, id=1
            hijos = new List<List<string>>();
        }

        /// <summary>
        /// Añadimos los hijos al elemento
        /// </summary>
        /// <param name="TipoHijo"></param>
        /// <param name="IdHijo"></param>
        public void setHijos(string TipoHijo, string IdHijo)
        {
            List<string> hijo = new List<string>();
            hijo.Add(TipoHijo);
            hijo.Add(IdHijo);
            hijos.Add(hijo);
        }

        /// <summary>
        /// Obtenemos los hijos del elemento
        /// </summary>
        /// <returns></returns>
        public List<List<string>> getHijos() => hijos;

        /// <summary>
        /// Metodo que modifica el valor padre.
        /// </summary>
        /// <param name="padre"></param>
        public void setPadre(string tipoPadre, string IdPadre)
        {
            this.padre.Add(tipoPadre);
            this.padre.Add(IdPadre);
        }

        /// <summary>
        /// Obtenemos el padre del objeto
        /// </summary>
        /// <returns></returns>
        public List<string> getPadre() => padre;

        /// <summary>
        /// Getter para el id del elemento
        /// </summary>
        /// <returns></returns> id del elemento
        public string getId() => id;

        /// <summary>
        /// Método que añade un elemento hijo al elemento actual
        /// </summary>
        /// <param name="elementoAñadir" ></param> elemento a añadir
        /// <returns></returns>
        public bool AnadirHijo(Elemento elementoAñadir)
        {
            if (elementoAñadir == null) return false;
            if (elementoAñadir.getTipo().Equals("Raiz")) return false;
            if (elementoAñadir.getPadre() != null) return false;
            switch (this.tipo)
            {
                case "Raiz":
                    List<string> tiposPosibles = new List<string> { "Espacio", "Contenedor", "Articulo" };
                    if (tiposPosibles.Contains(elementoAñadir.getTipo()))
                    {
                        hijos.Add(elementoAñadir);
                        elementoAñadir.padre = this;
                        return true;
                    }
                    break;
                case "Espacio":
                    List<string> tiposPosibles2 = new List<string> { "Contenedor", "Articulo" };
                    if (elementoAñadir.getTipo().Equals("Contenedor"))
                    {
                        hijos.Add(elementoAñadir);
                        elementoAñadir.padre = this;
                        return true;
                    }
                    break;
                case "Contenedor":
                    List<string> tiposPosibles3 = new List<string> { "Contenedor", "Articulo" };
                    if (elementoAñadir.getTipo().Equals("Articulo"))
                    {
                        hijos.Add(elementoAñadir);
                        elementoAñadir.padre = this;
                        return true;
                    }
                    break;
                case "Articulo":
                    return false;
            }
            return false;
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

        public string getTipo() => tipo;

        public static Elemento buscarElemento(Dictionary<string, List<Elemento>> elementos, string idElemento, string tipoElemento = null)
        {
            if (tipoElemento != null)
            {
                if (elementos.ContainsKey(tipoElemento))
                {
                    foreach (Elemento elemento in elementos[tipoElemento])
                    {
                        if (elemento.id.Equals(idElemento))
                        {
                            return elemento;
                        }
                    }
                }
            }
            else
            {
                foreach (List<Elemento> lista in elementos.Values)
                {
                    foreach (Elemento elemento in lista)
                    {
                        if (elemento.id.Equals(idElemento))
                        {
                            return elemento;
                        }
                    }
                }
            }
            return null;
        }


    }
}