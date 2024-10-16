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
        private int idUsuario;
        private List<Elemento> elementosR;
        private string tipoUsuario;
        private int raicesCreadas;
        private int espaciosCreados;
        private int contCreados;
        private int artCreados;

        /// <summary>
        /// Constructor de la clase Usuario
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="contrasena">Contrasena del usuario</param>
        /// <param name="tipoUsuario"> Tipo del usuario, los consideramos como "Pago", "noPago" o "Admin"
        /// <param name="privilegios"> Si True es administrador, si False no lo es
        public Usuario(string email, string contrasena, string tipoUsuario = "noPago", bool privilegios = false)
        {
            EmailUsuario = email;
            contrasenaActual = Utilidades.Encriptar(contrasena);
            listaContrasenasAntiguas = new List<string>();
            //se actualiiza en la BD
            this.idUsuario = 0 ;
            elementosR = new List<Elemento>();
            this.tipoUsuario = tipoUsuario;
            raicesCreadas = 0;
            espaciosCreados = 0;
            contCreados = 0;
            artCreados = 0;    
            this.privilegios = privilegios;
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
        public bool CambiarEmail(string emailNuevo)
        {
            string emailAntiguo = EmailUsuario;
            if (emailNuevo != null && emailNuevo != EmailUsuario)
            {
                setEmailUsuario(emailNuevo);
                Log.escribirLog(emailAntiguo, "Cambio de email a: " + emailNuevo);
                Log.escribirLog(emailNuevo, "Cambio de email desde: " + emailAntiguo);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo para cambiar la contrasena del usuario, comprobando que cumple con los requisitos minimos
        /// y que no es igual a ninguna de las 10 anteriores
        /// </summary>
        /// <param name="contrasenaNueva">Contrasena nueva a introducir</param>
        public bool cambiarContrasena (string contrasenaNueva)
        {
            // Comprobamos que la contrasena cumple con los requisitos minimos
            if (contrasenaNueva != null && Utilidades.CompruebaContrasena(contrasenaNueva) == 5 && contrasenaNueva != contrasenaActual)
            {
                // Comprobamos que la contrasena no sea igual a una de las 10 anteriores
                if (!comprobarContrasenaAntigua(contrasenaNueva) )
                {
                    setContrasenaActual(contrasenaNueva);
                    guardarContrasenaAntigua();
                    Log.escribirLog(EmailUsuario, "Cambio de contraseña");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

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

        /// <summary>
        /// Método que añade un elemento al árbol de elementos del usuario
        /// </summary>
        /// <param name="idpadre"></param> padre del nuevo elemento
        /// <param name="tipo"></param> tipo del nuevo elemento
        /// <returns></returns> bool - true si se ha podido crear el elemento, false si no
        public bool añadirElemento(string idpadre, string tipo)
        {
            Elemento padre = buscarElemento(idpadre);
            string id = generarIdElemento(tipo);
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
    }
}
