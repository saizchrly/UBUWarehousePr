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
    public class WHdb : IWHdb
    {
        Dictionary<int, Usuario> tblUsuarios = new Dictionary<int, Usuario>();
        int proximoIDUsuario = 1;
        public WHdb()
        {
            Usuario u = new Usuario("prueba1@ubu.es", "prueba1", "Admin");
            GuardaUsuario(u);
        }
        public bool GuardaComponente(string tipoElemento, int idUsuario)
        {
            foreach(Usuario u in tblUsuarios.Values)
            {
                if (u.getIdUsuario().Equals(idUsuario))
                {
                    return u.añadirElemento(tipoElemento);
                }
            }
            return false;

        }

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
                    return Elemento.buscarElemento(u.getElementos(),idElemento);
                }
            }
            return null;
        }


        public Usuario LeeUsuario(string email)
        {
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                if (utemp.getEmailUsuario().Equals(email)) return utemp;
            }
            return null;
        }

        public int NumComponente()
        {
            int total = 0;
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                total += utemp.numElemTotal();
            }
            return total;
        }

        public int NumUsuarios()
        {
            return tblUsuarios.Count;
        }

        public int NumUsuariosActivos()
        {
            int cont = 0;
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                cont ++;
            }
            return cont;
        }

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

        public bool cambiarEmail(string email,string password , string newemail)
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
    }
}
