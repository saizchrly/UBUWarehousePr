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
using System.Threading;

namespace WWW
{
    public partial class CambioPassword : System.Web.UI.Page
    {
        private WHdb data;
        private Usuario u;
        protected void Page_Load(object sender, EventArgs e)
        {
            data = (WHdb)Application["Data"];
            u = (Usuario)Session["User"];
            if (data == null || u == null)
            {
                Response.Redirect("WebForm1.aspx");
            }
            lblUsuario.Text = u.getEmailUsuario();
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
            if (u != null)
            {
                if (!tbNueva.Text.Equals(tbConfirmar.Text))
                {
                    lblError.Text = "La contraseña no ha sido confirmada correctamente.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                }
                else if (!u.validarContrasena(tbActual.Text))
                {
                    lblError.Text = "La contraseña introducida no es correcta.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                }
                else if (tbActual.Text.Equals(tbNueva.Text))
                {
                    lblError.Text = "La nueva contraseña no puede ser igual a la antigua";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                }
                else if (Utilidades.CompruebaContrasena(tbNueva.Text) < 3)
                {
                    lblError.Text = "La nueva contraseña no es lo suficientemente segura.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                }
                else
                {
                    if (u.cambiarContrasena(tbNueva.Text))
                    {
                        lblError.Text = "Contraseña actualizada con éxito. Redirigiendo a la página de inicio de sesión...";
                        lblError.ForeColor = System.Drawing.Color.DarkGreen;
                        lblError.Visible = true;
                        string script = "setTimeout(function() { window.location = 'WebForm1.aspx'; }, 3000);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true);
                    }
                    else
                    {
                        lblError.Text = "Se ha producido un error en la actualización de la contraseña";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Visible = true;
                    }
                }
            }
            else
            {
                lblError.Text = "La sesión del usuario no está iniciada";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
            }
        }
    }
}