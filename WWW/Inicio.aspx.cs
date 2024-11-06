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
    public partial class Inicio : System.Web.UI.Page
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
                lblnElementos.Text = "Posee un total de " + u.numElemTotal() + " elementos.";
            }
        }

        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void lbCambiarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioPassword.aspx");
        }

        protected void btnRaiz_Click(object sender, EventArgs e)
        {
            if (u != null)
            {
                if (u.añadirElemento("Raiz"))
                {
                    lblMensaje.Text = "Elemento raíz añadido correctamente.";
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.DarkGreen;
                    lblnElementos.Text = "Posee un total de " + u.numElemTotal() + " elementos.";
                }
                else
                {
                    lblMensaje.Text = "Límite de elementos raíz superado.";
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                    lblnElementos.Text = "Posee un total de " + u.numElemTotal() + " elementos.";
                }
            }
        }
    }
}