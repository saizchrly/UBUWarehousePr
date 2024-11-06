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
            }
            u = (Usuario)Session["User"];
            if (u != null)
            {
                lblUsuario.Text = u.getEmailUsuario();
                lblnElementos.Text = "Posee un total de " + u.numElemTotal() + " elementos.";
                lblNombre.Text = "Nombre: " + u.getNombre();
                lblPais.Text = "Pais: " + u.getPais();
                lblTelefono.Text = "Telefono: " + u.getTelefono();
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
                    Session["User"] = u;
                    string script = "setTimeout(function() { window.location = Inicio.aspx'; }, 3000);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true);
                }
                else
                {
                    lblMensaje.Text = "Límite de elementos raíz superado.";
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.DarkRed;
                    string script = "setTimeout(function() { window.location = Inicio.aspx'; }, 3000);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true);
                }
            }
        }

        protected void btnNombre_Click(object sender, EventArgs e)
        {
            tbNombre.Visible = true;
            btnCNombre.Visible = true;
        }

        protected void btnCNombre_Click(object sender, EventArgs e)
        {
            if (u != null)
            {
                if (tbNombre.Text.Length != 0)
                {
                    u.setNombre(tbNombre.Text);
                    Session["User"] = u;
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    lblError.Text = "El nombre no puede quedar vacío";
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.DarkRed;
                    string script = "setTimeout(function() { window.location = Inicio.aspx'; }, 3000);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true);
                }
            }
        }

        protected void btnPais_Click(object sender, EventArgs e)
        {
            tbPais.Visible = true;
            btnCPais.Visible = true;
        }

        protected void btnCPais_Click(object sender, EventArgs e)
        {

        }

        protected void btnTelefono_Click(object sender, EventArgs e)
        {

        }

        protected void btnCTelefono_Click(object sender, EventArgs e)
        {

        }
    }
}