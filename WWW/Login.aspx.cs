using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WHDatabase;
using ClassLib;
using System.Diagnostics.Eventing.Reader;

namespace WWW
{
    public partial class Login : System.Web.UI.Page
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
            usActual = null;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool inicioOk = false;
            usActual = data.LeeUsuario(tbxUsuario.Text);
            if (usActual != null)
            {
                    inicioOk = usActual.validarContrasena(tbxPassword.Text);
            }
            if(inicioOk) Server.Transfer("NewPage.aspx", false);
            else
            {
                lblError.Text = "Usuario y/o contraseña incorrecto.";
                lblError.Visible = false;
            }
        }
    }
}