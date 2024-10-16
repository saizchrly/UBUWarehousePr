using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLib;

namespace WHDatabase
{
    public class WHdb : IWHdb
    {
        Dictionary<int, Usuario> tblUsuarios = new Dictionary<int, Usuario>();
        int proximoIDUsuario = 1;

        public WHdb()
        {
            Usuario u = new Usuario("prueba1@ubu.es", "prueba1", "Admin")
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

        public Elemento LeeComponente(int idElemento)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool ValidaUsuario(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
