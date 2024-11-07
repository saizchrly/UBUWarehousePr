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
    /// <summary>
    /// Página que permite al usuario cambiar su contraseña
    /// </summary>
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
                lblUsuario.Text = u.getEmailUsuario(); //Información superior igual que la del menú principal
            }
        }

        /// <summary>
        /// Botón que permite al usuario volver al menú principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        /// <summary>
        /// Botón que permite al usuario cerrar su sesión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        /// <summary>
        /// Botón de confirmación del cambio de contraseña.
        /// El usuario debe introducir su contraseña actual, después, la nueva, y confirmarla.
        /// La nueva contraseña debe cumplir al menos 3 requisitos de seguridad (+8 caracteres, mayúsculas, números, caracteres especiales)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (u != null)
            {
                if (!tbNueva.Text.Equals(tbConfirmar.Text))
                {
                    lblError.Text = "La contraseña no ha sido confirmada correctamente."; 
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true; //Los campos contraseña nueva y confirmar contraseña deben ser iguales
                }
                else if (!u.validarContrasena(tbActual.Text))
                {
                    lblError.Text = "La contraseña introducida no es correcta.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true; //Para poder cambiar la contraseña se debe introducir la actual
                }
                else if (tbActual.Text.Equals(tbNueva.Text))
                {
                    lblError.Text = "La nueva contraseña no puede ser igual a la antigua";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true; //La nueva contraseña no puede ser igual que la actual
                }
                else if (Utilidades.CompruebaContrasena(tbNueva.Text) < 3)
                {
                    lblError.Text = "La nueva contraseña no es lo suficientemente segura.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true; //La contraseña debe cumplir los requisitos de seguridad
                }
                else
                {
                    if (u.cambiarContrasena(tbNueva.Text))
                    {
                        lblError.Text = "Contraseña actualizada con éxito. Redirigiendo a la página de inicio de sesión...";
                        lblError.ForeColor = System.Drawing.Color.DarkGreen;
                        lblError.Visible = true; //Si se cumplen los requisitos, se comunica al usuario y se vuelve al login
                        string script = "setTimeout(function() { window.location = 'WebForm1.aspx'; }, 3000);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true); //
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