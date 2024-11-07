using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics.Eventing.Reader;
using System.Data.SqlClient;
using WHDatabase;
using ClassLib;

namespace WWW
{   /// <summary>
    /// Página de inicio de sesión al sistema. El usuario deberá introducir su email y contraseña.
    /// </summary>
    public partial class InicioSesion : System.Web.UI.Page
    {
        WHdb data = null;
        Usuario usActual = null;
        protected void Page_Load(object sender, EventArgs e)
        {
                data = (WHdb)Application["Data"];
                if (data == null)
                {
                    data = new WHdb();
                    Application["Data"] = data;
                }
                if(!IsPostBack) usActual = null;
        }

        /// <summary>
        /// Al pulsar aceptar, se comprobará que los campos email
        /// y contraseña corresponden con los de un usuario del sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool inicioOk = false;
            usActual = data.LeeUsuario(tbxUsuario.Text);
            if (usActual != null)
            {
                if (usActual.validarContrasena(tbxPassword.Text))
                {
                    Session["User"] = usActual;
                    inicioOk = true;
                }
            }
            if (inicioOk) Server.Transfer("Inicio.aspx", false);
            else
            {
                lblError.Text = "Usuario y/o contraseña incorrecto.";
                lblError.Visible = true;
            }
        }
    }
}