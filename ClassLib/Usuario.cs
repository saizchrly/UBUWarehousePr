using System.Collections.Generic;
using UBULibPr;

namespace ClassLib
{
    /// <summary>
    /// Clase la creacion y gestion de los usuarios
    /// </summary>
    public class Usuario
    {
        private string EmailUsuario;
        private string privilegios;
        private string contrasenaActual;
        private List<string> listaContrasenasAntiguas;
        private int idUsuario;
        private List<Elemento> elementosR;
        private string tipoUsuario;

        /// <summary>
        /// Constructor de la clase Usuario
        /// WIP; privilegios a bool
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="contrasena">Contrasena del usuario</param>
        /// <param name="idUsuario">ID del usuario creado por la BBDD
        /// <param name="privilegios">Privilegios del usuario, si al construir el objeto no se hace referencia a este parametro
        /// <param name="tipoUsuario"> Tipo del usuario
        /// se dará un privilegio de "Usuario" por defecto</param>
        public Usuario(string email, string contrasena, int idUsuario, string privilegios = "Usuario", string tipoUsuario)
        {
            EmailUsuario = email;
            contrasenaActual = Utilidades.Encriptar(contrasena);
            listaContrasenasAntiguas = new List<string>();
            this.idUsuario = idUsuario;
            elementosR = new List<Elemento>();
            this.tipoUsuario = tipoUsuario;
            //añadir la lista de Elemento que contiene el usuario
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

        private bool añadirElemento(string padre, string tipo)
        {

        }
        /// <summary>
        /// TODO:Método para buscar un elemento a partir de su id
        /// </summary> Recorrer el árbol de elementos hasta encontrar el que tenga el id buscado
        /// <param name="id"></param> id del elemento que queremos encontrar
        /// <returns></returns> Elemento encontrado, null si no existe
        private Elemento buscarElemento(string id)
        {

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


        public string getEmUsuario() => idUsuario;

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
        public void cambiarContrasena (string contrasenaNueva)
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
                }
                else throw new System.Exception("La contrasena no puede ser igual a una de las 10 anteriores");
            }
            else throw new System.Exception("La contrasena no cumple con los requisitos minimos");
        }
    }
}
