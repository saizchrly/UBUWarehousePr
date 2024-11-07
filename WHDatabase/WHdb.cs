using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using ClassLib;

namespace WHDatabase
{
    /// <summary>
    /// Clase que modela la base de datos a implementar en la web
    /// </summary>
    public class WHdb : IWHdb
    {
        /// <summary>
        /// Diccionario que contiene los usuarios del sistema junto a su id
        /// </summary>
        Dictionary<int, Usuario> tblUsuarios = new Dictionary<int, Usuario>();

        /// <summary>
        /// Contador que asigna el ID del próximo usuario a crear
        /// </summary>
        int proximoIDUsuario = 1;

        /// <summary>
        /// Constructor que genera la base de datos, guardando un usuario de prueba
        /// </summary>
        public WHdb()
        {
            Usuario u = new Usuario("prueba1@ubu.es", "prueba1", "Pago");
            u.añadirElemento("Espacio", u.getElementos()["Raiz"][0]);
            u.añadirElemento("Contenedor", u.getElementos()["Raiz"][0]);
            u.añadirElemento("Contenedor", u.getElementos()["Espacio"][0]);
            u.añadirElemento("Articulo", u.getElementos()["Contenedor"][0]);
            GuardaUsuario(u);
        }

        /// <summary>
        /// Método que guarda un componente de un tipo en la base de datos de un usuario
        /// </summary>
        /// <param name="tipoElemento"></param> tipo del elemento a guardar
        /// <param name="idUsuario"></param> usuario propietario del elemento
        /// <returns></returns> true si se ha podido guardar, false si no
        public bool GuardaComponente(string tipoElemento, int idUsuario)
        {
            foreach (Usuario u in tblUsuarios.Values)
            {
                if (u.getIdUsuario().Equals(idUsuario))
                {
                    u.añadirElemento(tipoElemento);
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Método que añade un usuario a la base de datos
        /// </summary>
        /// <param name="u"></param> usuario a añadir
        /// <returns></returns> true si se ha añadido, false si no
        public bool GuardaUsuario(Usuario u)
        {
            if (u.getIdUsuario() <= 0)
            {
                u.setIdUsuario(proximoIDUsuario);
                proximoIDUsuario++;
            }
            tblUsuarios[u.getIdUsuario()] = u;
            return true;
        }

        /// <summary>
        /// Método que devuelve un elemento a partir de su ID
        /// </summary>
        /// <param name="idElemento"></param> id del elemento a buscar
        /// <returns></returns> elemento encontrado, null si no existe
        public Elemento LeeComponente(string idElemento)
        {
            Match match = Regex.Match(idElemento, @"^\d+");
            int idUsuario;
            if (match.Success)
            {
                idUsuario = Convert.ToInt32(match.Value);
            }
            else
            {
                return null;
            }
            foreach (Usuario u in tblUsuarios.Values)
            {
                if (u.getIdUsuario().Equals(idUsuario))
                {
                    return Elemento.buscarElemento(u.getElementos(), idElemento);
                }
            }
            return null;
        }

        /// <summary>
        /// Método que devuelve un usuario a partir de su email
        /// </summary>
        /// <param name="email"></param> email del usuario
        /// <returns></returns> usuario encontrado, null si no existe
        public Usuario LeeUsuario(string email)
        {
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                if (utemp.getEmailUsuario().Equals(email)) return utemp;
            }
            return null;
        }

        /// <summary>
        /// Método que devuelve el número total de componentes en el sistema
        /// </summary>
        /// <returns></returns>
        public int NumComponente()
        {
            int total = 0;
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                total += utemp.numElemTotal();
            }
            return total;
        }

        /// <summary>
        /// Método que devuelve el número de usuarios que han sido creados
        /// </summary>
        /// <returns></returns> número de usuarios
        public int NumUsuarios()
        {
            return tblUsuarios.Count;
        }

        /// <summary>
        /// Método que devuelve el número de usuarios activos
        /// </summary>
        /// <returns></returns> contador de usuarios
        public int NumUsuariosActivos()
        {
            int cont = 0;
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                cont++;
            }
            return cont;
        }

        /// <summary>
        /// Método que valida la contraseña de un usuario 
        /// </summary>
        /// <param name="email"></param> email del usuario
        /// <param name="password"></param> contraseña introducida
        /// <returns></returns> true si es correcta, false si no
        public bool ValidaUsuario(string email, string password)
        {
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                if (utemp.getEmailUsuario().Equals(email))
                {
                    if (utemp.validarContrasena(password))
                    {
                        return true;
                    }
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Método que cambi la contraseña de un usuario
        /// </summary>
        /// <param name="email"></param> email del usuario
        /// <param name="password"></param> contraseña del usuario
        /// <param name="newpassword"></param> nueva contraseña
        /// <returns></returns> true si se ha cambiado, false si no
        public bool cambiarContrasena(string email, string password, string newpassword)
        {
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                if (utemp.getEmailUsuario().Equals(email))
                {
                    if (utemp.validarContrasena(password))
                    {
                        utemp.cambiarContrasena(newpassword);
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Método que permite cambiar el email del usuario
        /// </summary>
        /// <param name="email"></param> email del usuario
        /// <param name="password"></param> contraseña del usuario
        /// <param name="newemail"></param> nuevo email del usuario
        /// <returns></returns> true si se ha cambiado correctamente, false si no
        public bool cambiarEmail(string email, string password, string newemail)
        {
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                if (utemp.getEmailUsuario().Equals(email))
                {
                    if (utemp.validarContrasena(password))
                    {
                        utemp.cambiarEmail(newemail);
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Método que permite añadir un usuario a la base de datos
        /// </summary>
        /// <param name="email"></param> email del usuario
        /// <param name="password"></param> contraseña del usuario
        /// <param name="rol"></param> rol del usuario
        /// <returns></returns> true si se ha registrado correctamente, false si no
        public bool registrarUsuario(string email, string password, string rol = "NoPago")
        {
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                if (utemp.getEmailUsuario().Equals(email))
                {
                    return false;
                }
            }
            Usuario u = new Usuario(email, password, rol);
            return GuardaUsuario(u);
        }
    }
}
