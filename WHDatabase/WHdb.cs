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
            Usuario u  = new Usuario("prueba1@ubu.es", "prueba1", "Admin")
        }
        public bool GuardaComponente(Componente e)
        {
            throw new NotImplementedException();
        }

        public bool GuardaUsuario(Usuario u)
        {
           if(u.idUsuario < 0)
            {
                u.idUsuario = proximoIDUsuario;
                proximoIDUsuario++;
            }
           tblUsuarios[u.idUsuario] = u;
           return true;
        }

        public Componente LeeComponente(int idElemento)
        {
            throw new NotImplementedException();
        }

        public Usuario? LeeUsuario(string email)
        {
            Usuario utemp;
            foreach (utemp in tblUsuarios.Values()){
                if (utemp.email.Equals(email)) return utemp;
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
