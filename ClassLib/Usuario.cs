using System.Collections.Generic;
using UBULibPr;

namespace ClassLib
{
    // <summary>
    // Clase la creacion y gestion de los usuarios
    // </summary>
    public class Usuario
    {
        private string EmailUsuario;
        private string privilegios;
        private string contrasenaActual;
        private List<string> listaContrasenasAntiguas;

        // <summary>
        // Constructor de la clase Usuario
        // </summary>
        // <param name="email">Email del usuario</param>
        // <param name="contrasena">Contrasena del usuario</param>
        // <param name="privilegios">Privilegios del usuario, si al construir el objeto no se hace referencia a este parametro
        // se dará un privilegio de "Usuario" por defecto</param>
        public Usuario(string email, string contrasena, string privilegios = "Usuario")
        {
            EmailUsuario = email;
            contrasenaActual = Utilidades.Encriptar(contrasena);
            listaContrasenasAntiguas = new List<string>();
            //añadir la lista de Elemento que contiene el usuario
        }

        // <summary>
        // Metodo para introducir el nombre de usuario
        // </summary>
        // <param name="nombreUsuario">Nombre de usuario a introducir</param>
        public void setEmailUsuario(string Email) => this.EmailUsuario = Email;

        // <summary>
        // Metodo para obtener el nombre de usuario
        // </summary>
        // <returns>Nombre de usuario</returns>
        public string getEmailUsuario() => EmailUsuario;

        // <summary>
        // Metodo para introducir la contrasena actual, nunca se guardara en texto plano
        // </summary>
        // <param name="contrasenaActual">Contrasena actual a introducir</param>
        private void setContrasenaActual(string contrasenaNueva)
        {
            contrasenaActual = Utilidades.Encriptar(contrasenaNueva);
        }

        // <summary>
        // Metodo para guardar las ultimas 10 contraseñas, en caso de que haya 10 se eliminara la más antigua
        // </summary>
        private void guardarContrasenaAntigua()
        {
            if (listaContrasenasAntiguas.Count == 10)
            {
                listaContrasenasAntiguas.RemoveAt(0);
            }
            listaContrasenasAntiguas.Add(contrasenaActual);
        }

        // <summary>
        // Metodo para comprobar si la contrasena nueva es igual a alguna de las 10 anteriores
        // </summary>
        // <param name="contrasena">Contrasena a comprobar</param>
        // <returns>True si la contrasena es igual a alguna de las 10 anteriores, false en caso contrario</returns>
        private bool comprobarContrasenaAntigua(string contrasena)
        {
            return listaContrasenasAntiguas.Contains(Utilidades.Encriptar(contrasena));
        }

        // <summary>
        // Metodo para cambiar el email del usuario
        // </summary>
        // <param name="emailNuevo">Email nuevo a introducir</param>
        public void CambiarEmail(string emailNuevo)
        {
            if (emailNuevo != null && emailNuevo != EmailUsuario)
                setEmailUsuario(emailNuevo);
            else throw new System.Exception("El email no puede ser nulo o igual al anterior");
        }

        // <summary>
        // Metodo para cambiar la contrasena del usuario, comprobando que cumple con los requisitos minimos
        // y que no es igual a ninguna de las 10 anteriores
        // </summary>
        // <param name="contrasenaNueva">Contrasena nueva a introducir</param>
        public void cambiarContrasena (string contrasenaNueva)
        {
            // Comprobamos que la contrasena cumple con los requisitos minimos
            if (contrasenaNueva != null && Utilidades.CompruebaContrasena(contrasenaNueva) == 5)
            {
                // Comprobamos que la contrasena no sea igual a una de las 10 anteriores
                if (!comprobarContrasenaAntigua(contrasenaNueva) )
                {
                    setContrasenaActual(contrasenaNueva);
                    guardarContrasenaAntigua();
                }
                else throw new System.Exception("La contrasena no puede ser igual a una de las 10 anteriores");
            }
            else throw new System.Exception("La contrasena no cumple con los requisitos minimos");
        }
    }
}
