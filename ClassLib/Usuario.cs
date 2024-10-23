﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UBULibPr;

namespace ClassLib
{
    /// <summary>
    /// Clase la creacion y gestion de los usuarios
    /// </summary>
    public class Usuario
    {
        private string EmailUsuario;
        private bool privilegios;
        private string contrasenaActual;
        private List<string> listaContrasenasAntiguas;
        private int idUsuario = 0;
        private string tipoUsuario;
        // string es el Tipo del elemento y El value es la lista de elementos de ese tipo
        private Dictionary<string, List<Elemento>> elementos;

        /// <summary>
        /// Constructor de la clase Usuario
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="contrasena">Contrasena del usuario</param>
        /// <param name="tipoUsuario"> Tipo del usuario, los consideramos como "Pago", "noPago" o "Admin"
        /// <param name="privilegios"> Si True es administrador, si False no lo es
        public Usuario(string email, string contrasena, string tipoUsuario = "noPago", bool privilegios = false, int idUsuario = 0)
        {
            EmailUsuario = email;
            contrasenaActual = Utilidades.Encriptar(contrasena);
            listaContrasenasAntiguas = new List<string>();
            listaContrasenasAntiguas.Add(contrasenaActual);
            //se actualiiza en la BD
            this.idUsuario = idUsuario;
            this.tipoUsuario = tipoUsuario;
            this.privilegios = privilegios;
            elementos = new Dictionary<string, List<Elemento>>(); 
            añadirElemento("Raiz");

            Log.escribirLog(EmailUsuario, "Creacion de usuario");
        }

        /// <summary>
        /// Setter de los privilegios del usuario
        /// </summary>
        /// <param name="privilegios"></param>
        public void setPrivilegios(bool privilegios) => this.privilegios = privilegios;

        /// <summary>
        /// Getter de los privilejos del usuario
        /// </summary>
        /// <returns></returns>
        public bool getPrivilegios() => privilegios;

        /// <summary>
        /// Metodo para Implementar el id de usuario
        /// </summary>
        /// <param name="id"></param>
        public void setIdUsuario(int id) => this.idUsuario = id;

        /// <summary>
        /// Funcion para modificar el tipo de usuario
        /// </summary>
        /// <param name="tipo"></param>
        public void setTipoUsuario(string tipo) => this.tipoUsuario = tipo;

        /// <summary>
        /// Funcion para obtener el tip de usuario
        /// </summary>
        /// <returns></returns>
        public string getTipoUsuario() => tipoUsuario;

        /// <summary>
        /// Metodo para obtener el id de usuario
        /// </summary>
        /// <returns>Id de usuario</returns>
        public int getIdUsuario() => idUsuario;

        /// <summary>
        /// Metodo para introducir el nombre de usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario a introducir</param>
        public void setEmailUsuario(string Email) => this.EmailUsuario = Email;

        /// <summary>
        /// Metodo para obtener el nombre de usuario
        /// </summary>
        /// <returns>Nombre de usuario</returns>
        public string getEmailUsuario() => EmailUsuario;

        /// <summary>
        /// Metodo para introducir la contrasena actual, nunca se guardara en texto plano
        /// </summary>
        /// <param name="contrasenaActual">Contrasena actual a introducir</param>
        private void setContrasenaActual(string contrasenaNueva)
        {
            contrasenaActual = Utilidades.Encriptar(contrasenaNueva);
        }

        /// <summary>
        /// Metodo para guardar las ultimas 10 contraseñas, en caso de que haya 10 se eliminara la más antigua
        /// </summary>
        private void guardarContrasenaAntigua()
        {
            while (listaContrasenasAntiguas.Count >= 10)
            {
                listaContrasenasAntiguas.RemoveAt(0);
            }
            listaContrasenasAntiguas.Add(contrasenaActual);
        }

        /// <summary>

        /// Metodo para cambiar el email del usuario
        /// </summary>
        /// <param name="emailNuevo">Email nuevo a introducir</param>
        public bool cambiarEmail(string emailNuevo)
        {
            string emailAntiguo = EmailUsuario;
            List<string> noSirve = new List<string> { null, "", " ", emailAntiguo };
            if (!noSirve.Contains(emailNuevo))
            {
                setEmailUsuario(emailNuevo);
                Log.escribirLog(emailAntiguo, "Cambio de email a: " + emailNuevo);
                Log.escribirLog(emailNuevo, "Cambio de email desde: " + emailAntiguo);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Metodo para comprobar si la contrasena nueva es igual a alguna de las 10 anteriores
        /// </summary>
        /// <param name="contrasena">Contrasena a comprobar</param>
        /// <returns>True si la contrasena es igual a alguna de las 10 anteriores, false en caso contrario</returns>
        private bool comprobarContrasenaAntigua(string contrasena)
        {
            return listaContrasenasAntiguas.Contains(Utilidades.Encriptar(contrasena));
        }

        /// <summary>
        /// Metodo para cambiar la contrasena del usuario, comprobando que cumple con los requisitos minimos
        /// y que no es igual a ninguna de las 10 anteriores
        /// </summary>
        /// <param name="contrasenaNueva">Contrasena nueva a introducir</param>
        public bool cambiarContrasena(string contrasenaNueva)
        {
            // Comprobamos que la contrasena cumple con los requisitos minimos
            if (contrasenaNueva != null && Utilidades.CompruebaContrasena(contrasenaNueva) == 5 && contrasenaNueva != contrasenaActual)
            {
                // Comprobamos que la contrasena no sea igual a una de las 10 anteriores
                if (!comprobarContrasenaAntigua(contrasenaNueva))

                {
                    setContrasenaActual(contrasenaNueva);
                    guardarContrasenaAntigua();
                    Log.escribirLog(EmailUsuario, "Cambio de contraseña");
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Valida la contraseña introducidada por el usuario
        /// </summary>
        /// <returns></returns>
        public bool validarContrasena(string contrasena)
        {
            return Utilidades.Encriptar(contrasena).Equals(contrasenaActual);
        }


        public int raicesCreadas() => elementos["Raiz"].Count();

        public int espaciosCreados() => elementos["Espacio"].Count();

        public int contCreados() => elementos["Contenedor"].Count();

        public int artCreados() => elementos["Articulo"].Count();

        public int numElemTotal()
        {
            int total = 0;
            foreach (List<Elemento> lista in elementos.Values)
            {
                total += lista.Count();
            }
            return total;
        }
        
        public Dictionary<string, List<Elemento>> getElementos() => elementos;
        
        public void setElementos(Dictionary<string, List<Elemento>> elementos) => this.elementos = elementos;


        /// <summary>
        /// Método que genera el correspondiente id para un nuevo elemento
        /// El formato será idUsuario_TipoNúmero de elementos de ese tipo creados por el usuario
        /// </summary>
        /// <param name="tipo"></param> tipo del elemento a crear
        /// <returns></returns>
        private string generarIdElemento(string tipo)
        {
            string id = $"{idUsuario}_";
            if (idUsuario == 0) return null;

            switch (tipo)
            {
                case "Raiz":
                    id += $"R{raicesCreadas + 1}";
                    break;
                case "Espacio":
                    id += $"E{espaciosCreados + 1}";
                    break;
                case "Contenedor":
                    id += $"C{contCreados + 1}";
                    break;
                case "Articulo":
                    id += $"A{artCreados + 1}";
                    break;
                default:
                    return null;
            }
            return id;
        }

        private Elemento crearUnElemento(string tipo)
        {

            if (tipo == "Raiz")
            {
                int limite = 10000;
                if (tipoUsuario == "Pago") limite = 3;
                else if (tipoUsuario == "noPago") limite = 1;
                int numeroRaices = elementos["Raiz"].Count();
                if (numeroRaices < limite)
                {
                    Elemento e = new Elemento(tipo, generarIdElemento(tipo));
                    return e;
                }
                return null;
            }
            if (tipo == "Espacio")
            {   
                numElem++;
                espaciosCreados++;
                Elemento e = new Elemento(tipo, generarIdElemento(tipo));
                return e;
                
            }
            if (tipo == "Contenedor")
            {
                numElem++;
                contCreados++;
                Elemento e = new Elemento(tipo, generarIdElemento(tipo));
                return e;
            }
            if (tipo == "Articulo")
            {
                numElem++;
                artCreados++;
                Elemento e = new Elemento(tipo, generarIdElemento(tipo));
                return e;
            }
            return null;
        }


        /// <summary>
        /// Método que añade un elemento a uno de los elementos del usuario
        /// </summary>
        /// <param name="idpadre"></param> padre del nuevo elemento
        /// <param name="tipo"></param> tipo del nuevo elemento
        /// <returns>bool - true si se ha podido crear el elemento, false si no</returns> 
        public bool añadirElemento(string tipoElementoAñadir, Elemento elementoBuscar = null)
        {
            Elemento elementoAñadir = crearUnElemento(tipoElementoAñadir);
            if (elementoAñadir == null) return false;
            if (elementoAñadir.getTipo().Equals("Raiz"))
            {
                elementosLista.Add(elementoAñadir);
                return true;
            }
            if (elementoBuscar.AnadirHijo(elementoAñadir)) return true;
            return false;
        }



        /// <summary>
        /// Elimina un elemento del árbol de elementos del usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool eliminarElemento(string id)
        {
            Elemento e = Elemento.buscarElemento(id, elementosLista);
            if (e == null) throw new System.Exception("El elemento no existe");

            if (e.getTipo().Equals("Raiz")) throw new System.Exception("No se puede eliminar la raiz");

            Elemento padre = e.getPadre();
            if (padre != null)
            {
                if (padre.Eliminar(e))
                {
                    elementosLista.Remove(e);
                    Log.escribirLog(EmailUsuario, "Eliminacion de elemento " + id);

                    return true;
                }
            }
            return false;

        }


        /// <summary>
        /// Metodo para mover un elemento de un padre a otro
        /// </summary>
        /// <param name="idMovido"></param>
        /// <param name="idNuevoPadre"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool moverElemento(string idMovido, string idNuevoPadre)
        {
            Elemento e = Elemento.buscarElemento(idMovido, elementosLista); //Buscamos elemento a mover
            if (e == null) throw new System.Exception("El elemento a mover no existe");

            Elemento nuevoPadre = Elemento.buscarElemento(idNuevoPadre, elementosLista); //Buscamos nuevo padre
            if (nuevoPadre == null) throw new System.Exception("El nuevo elemento padre no existe");

            Elemento padreAntiguo = e.getPadre(); //Obtenemos padre del elemento a mover
            List<Elemento> listahijos = nuevoPadre.obtenerHijos();
            listahijos.Add(e);

            eliminarElemento(idMovido);

            return true;
        }        
    }
}
