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
            // idUsuario_Tipo(R,E,C,A) + Número
            this.id = id;
            // si no tienen simplemente estaran vacias.
            // Tipo=0, id=1
            padre = new List<string>();
            // hijo == Tipo=0, id=1
            hijos = new List<List<string>>();
        }

        public void setHijos(List<List<string>> hijos)
        {
            this.hijos = hijos;
        }

        /// <summary>
        /// Añadimos los hijos al elemento
        /// </summary>
        /// <param name="TipoHijo"></param>
        /// <param name="IdHijo"></param>
        public void nuevoHijo(string TipoHijo, string IdHijo)
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
            List<string> datosElementoAñadir = new List<string> { elementoAñadir.getTipo(), elementoAñadir.getId() };
            switch (this.tipo)
            {
                
                case "Raiz":
                    List<string> tiposPosibles = new List<string> { "Espacio", "Contenedor", "Articulo" };
                    if (tiposPosibles.Contains(elementoAñadir.getTipo()))
                    {
                        hijos.Add(datosElementoAñadir);
                        return true;
                    }
                    break;
                case "Espacio":
                    List<string> tiposPosibles2 = new List<string> { "Contenedor", "Articulo" };
                    if (tiposPosibles2.Contains(elementoAñadir.getTipo()))
                    {
                        hijos.Add(datosElementoAñadir);
                        return true;
                    }
                    break;
                case "Contenedor":
                    List<string> tiposPosibles3 = new List<string> { "Contenedor", "Articulo" };
                    if (tiposPosibles3.Contains(elementoAñadir.getTipo()))
                    {
                        hijos.Add(datosElementoAñadir);
                        return true;
                    }
                    break;
                case "Articulo":
                    return false;
            }
            return false;
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