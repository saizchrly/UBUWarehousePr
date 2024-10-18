using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WWW
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Página de inicio de Sesión";
            lblUsuario.Text = "Usuario en formato e-mail";
            btnRegistrarse.Text = "Registrarse";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}