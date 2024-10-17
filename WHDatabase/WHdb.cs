using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        }
        public bool GuardaComponente(Elemento e)
        {
            throw new NotImplementedException();
        }

        public bool GuardaUsuario(Usuario u)
        {
            if (u.getIdUsuario() < 0)
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
                    return u.buscarElemento(idElemento);
                }
            }
            return null;
        }


        public Usuario? LeeUsuario(string email)
        {
            foreach (Usuario utemp in tblUsuarios.Values)
            {
                if (utemp.getEmailUsuario().Equals(email)) return utemp;
            }
            return null;
        }

        public int NumComponente()
        {
            throw new NotImplementedException();
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
                cont += utemp.numElem;
            }
            return cont;
        }

        public bool ValidaUsuario(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
