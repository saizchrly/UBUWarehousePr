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
{
    public partial class WebForm1 : System.Web.UI.Page
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
            if (inicioOk) Server.Transfer("Inicio.aspx", false);
            else
            {
                lblError.Text = "Usuario y/o contraseña incorrecto.";
                lblError.Visible = true;
            }
        }

    }
}