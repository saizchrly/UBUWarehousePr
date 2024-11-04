using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WHDatabase;

namespace WWW
{
    public partial class CambioPassword : System.Web.UI.Page
    {
        private WHdb data;
        private Usuario u;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data = (WHdb)Application["Data"];
                u = (Usuario)Session["User"];
                if (data == null || u == null)
                {
                    Response.Redirect("WebForm1.aspx");
                }
                lblUsuario.Text = u.getEmailUsuario();
            }
        }

        protected void lbInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}