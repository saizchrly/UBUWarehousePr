using System;
using System.Collections.Generic;
using System.Data;
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
        private List<Elemento> elementosR;
        private string tipoUsuario;
        private int raicesCreadas;
        private int espaciosCreados;
        private int contCreados;
        private int artCreados;
        public int numElem;

        /// <summary>
        /// Constructor de la clase Usuario
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="contrasena">Contrasena del usuario</param>
        /// <param name="idUsuario">ID del usuario creado por la BBDD
        /// <param name="tipoUsuario"> Tipo del usuario, los consideramos como "Pago", "noPago" o "Admin"
        /// <param name="privilegios"> Si True es administrador, si False no lo es
        public Usuario(string email, string contrasena, string tipoUsuario = "noPago", bool privilegios = false, int idUsuario = 0)
        {
            EmailUsuario = email;
            contrasenaActual = Utilidades.Encriptar(contrasena);
            listaContrasenasAntiguas = new List<string>();
            //se actualiiza en la BD
            this.idUsuario = idUsuario;
            elementosR = new List<Elemento>();
            this.tipoUsuario = tipoUsuario;
            raicesCreadas = 0;
            espaciosCreados = 0;
            contCreados = 0;
            artCreados = 0;
            this.privilegios = privilegios;
            numElem = 0;
            //añadir la lista de Elemento que contiene el usuario
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
        /// Método que añade un elemento raiz. Comprueba que no se ha superado el limite de elementos raiz.
        /// Si no se ha superado, lo crea y lo añade a la lista.
        /// TODO: generar IDs con estructura(idUsuario_tipo_numTipoCreados)
        /// </summary>
        /// <returns></returns>
        private bool añadirRaiz()
        {
            int limite = 10000;
            if (tipoUsuario == "Pago") limite = 3;
            else if (tipoUsuario == "noPago") limite = 1;
            if (elementosR.Count >= limite)
            {
                string id = "raiz" + (elementosR.Count + 1);
                Elemento raiz = new Elemento(id);
                elementosR.Add(raiz);
                numElem++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método que genera el correspondiente id para un nuevo elemento
        /// El formato será idUsuario_TipoNúmero de elementos de ese tipo creados por el usuario
        /// </summary>
        /// <param name="tipo"></param> tipo del elemento a crear
        /// <returns></returns>
        private string generarId(string tipo)
        {
            string id = $"{idUsuario}_";

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


        /// <summary>
        /// Método que añade un elemento al árbol de elementos del usuario
        /// </summary>
        /// <param name="idpadre"></param> padre del nuevo elemento
        /// <param name="tipo"></param> tipo del nuevo elemento
        /// <returns></returns> bool - true si se ha podido crear el elemento, false si no
        private bool añadirElemento(string idpadre, string tipo, string id = null)
        {
            Elemento padre = buscarElemento(idpadre);
            if (id == null) id = generarId(tipo);
            else id = $"{idUsuario}_{id}";
            if (padre == null || id == null) return false;
            switch (tipo)
            {
                case "Raiz":
                    raicesCreadas++;
                    break;
                case "Espacio":
                    espaciosCreados++;
                    break;
                case "Contenedor":
                    contCreados++;
                    break;
                case "Articulo":
                    artCreados++;
                    break;
            }
            numElem++;
            return padre.AnadirHijo(tipo, id);
        }
        /// <summary>
        /// TODO:Método para buscar un elemento a partir de su id
        /// </summary> Recorrer el árbol de elementos hasta encontrar el que tenga el id buscado
        /// <param name="id"></param> id del elemento que queremos encontrar
        /// <returns></returns> Elemento encontrado, null si no existe
        public Elemento buscarElemento(string id)
        {
            foreach (Elemento e in elementosR)
            {
                while (e != null)
                {
                    if (e.obtenerID().Equals(id)) return e;
                    buscarElementoRecursivo(e.obtenerHijos(), id);
                }
            }
            return null;
        }

        /// <summary>
        /// Método auxiliar para buscar un elemento a partir de su id
        /// </summary>
        /// <param name="hijos"></param> hijos del elemento actual
        /// <param name="id"></param>
        /// <returns></returns>
        private Elemento buscarElementoRecursivo(List<Elemento> hijos, string id)
        {
            foreach (Elemento e in hijos)
            {
                if (e == null) return null;
                if (e.obtenerID().Equals(id)) return e;
                buscarElementoRecursivo(e.obtenerHijos(), id);
            }
            return null;
        }

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
            if (listaContrasenasAntiguas.Count == 10)
            {
                listaContrasenasAntiguas.RemoveAt(0);
            }
            listaContrasenasAntiguas.Add(contrasenaActual);
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
        /// Metodo para cambiar el email del usuario
        /// </summary>
        /// <param name="emailNuevo">Email nuevo a introducir</param>
        public void CambiarEmail(string emailNuevo)
        {
            string emailAntiguo = EmailUsuario;
            if (emailNuevo != null && emailNuevo != EmailUsuario)
                setEmailUsuario(emailNuevo);
            else throw new System.Exception("El email no puede ser nulo o igual al anterior");
            Log.escribirLog(emailAntiguo, "Cambio de email a: " + emailNuevo);
            Log.escribirLog(emailNuevo, "Cambio de email desde: " + emailAntiguo);
        }

        /// <summary>
        /// Metodo para cambiar la contrasena del usuario, comprobando que cumple con los requisitos minimos
        /// y que no es igual a ninguna de las 10 anteriores
        /// </summary>
        /// <param name="contrasenaNueva">Contrasena nueva a introducir</param>
        public void cambiarContrasena(string contrasenaNueva)
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
                }
                else throw new System.Exception("La contrasena no puede ser igual a una de las 10 anteriores");
            }
            else throw new System.Exception("La contrasena no cumple con los requisitos minimos");
        }

        public bool eliminarElemento(string id)
        {
            Elemento e = buscarElemento(id);
            if (e == null) throw new System.Exception("El elemento no existe");
            Elemento padre = e.obtenerPadre();
            return padre.Eliminar(e);
        }

        public bool moverElemento(string idMovido, string idNuevoPadre)
        {
            Elemento e = buscarElemento(idMovido); //Buscamos elemento a mover
            if (e == null) throw new System.Exception("El elemento a mover no existe");
            Elemento nuevoPadre = buscarElemento(idNuevoPadre); //Buscamos nuevo padre
            if (nuevoPadre == null) throw new System.Exception("El nuevo elemento padre no existe");
            Elemento padreAntiguo = e.obtenerPadre(); //Obtenemos padre del elemento a mover
            if (!nuevoPadre.AnadirHijo(e.obtenerTipo(), idMovido))
            {
                throw new System.Exception("No se ha podido mover el elemento, tipos incompatibles");
            }
            if (!padreAntiguo.Eliminar(e))
            {
                nuevoPadre.Eliminar(e);
                throw new System.Exception("No se ha podido eliminar el elemento de su padre antiguo");
            }
            return true;
        }


    }
