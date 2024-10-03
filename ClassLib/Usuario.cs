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
        private string contrasenaActual;
        private List<string> listaContrasenasAntiguas;

        public Usuario(string email, string contrasena)
        {
            EmailUsuario = email;
            contrasenaActual = Utilidades.Encriptar(contrasena);
            listaContrasenasAntiguas = new List<string>();
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
        public void setContrasenaActual(string contrasenaNueva)
        {
            this.contrasenaActual = Utilidades.Encriptar(contrasenaNueva);
        }

    }
}
