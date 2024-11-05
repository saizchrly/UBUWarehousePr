using ClassLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UBULibPr;
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!u.validarContrasena(tbActual.Text))
            {
                lblError.Text = "La contraseña introducida no es correcta.";
                lblError.Visible = true;
            }
            else if (tbActual.Text.Equals(tbNueva.Text))
            {
                lblError.Text = "La nueva contraseña no puede ser igual a la antigua";
                lblError.Visible = true;
            }
            else if (Utilidades.CompruebaContrasena(tbNueva.Text) < 3)
            {
                lblError.Text = "La nueva contraseña no es lo suficientemente segura";
                lblError.Visible = true;
            }
            else
            {
                u.cambiarContrasena(tbNueva.Text);
                Response.Redirect("WebForm1.aspx");
            }
        }
    }
}