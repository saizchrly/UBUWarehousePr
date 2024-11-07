using ClassLib;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WHDatabase;

namespace WWW
{
    public partial class Inicio : System.Web.UI.Page
    {
        /// <summary>
        /// Menú principal del usuario.
        /// Una vez se haya iniciado su sesión, podrá ver y editar su información personal.
        /// También podrá ver una lista de los elementos que posee.
        /// </summary>
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
                    Response.Redirect("InicioSesion.aspx"); //Si la sesión no ha sido iniciada, volver al login
                }
            }
            u = (Usuario)Session["User"];
            if (u != null)
            {
                lblUsuario.Text = u.getEmailUsuario(); //Mostrar información del usuario
                lblnElementos.Text = "Posee un total de " + u.numElemTotal() + " elementos.";
                lblNombre.Text = "Nombre: " + u.getNombre();
                lblPais.Text = "Pais: " + u.getPais();
                lblTelefono.Text = "Telefono: " + u.getTelefono();
            }
        }
        /// <summary>
        /// Botón que permitirá al usuario cerrar sesión y volver a la página de login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioSesion.aspx");
        }
        /// <summary>
        /// Botón que permitirá al usuario acceder a la página de cambiar contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbCambiarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioPassword.aspx");
        }
        /// <summary>
        /// Botón que permite al usuario añadir elementos raíz hasta llegar al límite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    Session["User"] = u;
                    data = (WHdb)Application["Data"];;
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
        

        /// <summary>
        /// Botón que permitirá al usuario editar su nombre.
        /// Al pulsar aparecerá una textbox y un botón de confirmación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNombre_Click(object sender, EventArgs e)
        {
            tbNombre.Visible = true;
            btnCNombre.Visible = true;
        }

        /// <summary>
        /// Botón de confirmación de edición del nombre.
        /// Al pulsar, el nombre del usuario pasará a ser lo que haya introducido en una textbox, 
        /// siempre y cuando no esté vacía.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Botón de edición del país del usuario.
        /// Funciona exactamente igual que el del nombre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPais_Click(object sender, EventArgs e)
        {
            tbPais.Visible = true;
            btnCPais.Visible = true;
        }

        /// <summary>
        /// Botón de confirmación de edición del país del usuario
        /// El campo se podrá dejar vacío.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCPais_Click(object sender, EventArgs e)
        {
            if (u != null)
            {
                u.setPais(tbPais.Text);
                Session["User"] = u;
                Response.Redirect(Request.RawUrl);
            }
        }

        /// <summary>
        /// Botón de edición del teléfono del usuario.
        /// Mismo funcionamiento que los anteriores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTelefono_Click(object sender, EventArgs e)
        {
            tbTelefono.Visible = true;
            btnCTelefono.Visible = true;
        }

        /// <summary>
        /// Botón de confirmación del teléfono del usuario.
        /// En este caso, solo se permitirán introducir números
        /// y el símbolo + para el prefijo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCTelefono_Click(object sender, EventArgs e)
        {
            if (u != null)
            {
                string caracteresPermitidos = " 0123456789+";
                if (tbTelefono.Text.Intersect(caracteresPermitidos).Count() > 0)
                {
                    u.setTelefono(tbTelefono.Text);
                    Session["User"] = u;
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    lblError.Text = "El teléfono solo puede tener números o el + del prefijo";
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.DarkRed;
                    string script = "setTimeout(function() { window.location = Inicio.aspx'; }, 3000);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true);
                }

            }
        }
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (u != null)
            {
                if (u.raicesCreadas() > 0)
                {
                    int c = u.raicesCreadas();
                    bool flag = false;
                    while (!flag)
                    {
                        string id = $"{u.getIdUsuario()}_R{c}";
                        if (u.eliminarElemento(id)) flag = true;
                    }
                }
                else
                {
                    lblError.Text = "No hay elementos para eliminar";
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.DarkRed;
                    string script = "setTimeout(function() { window.location = Inicio.aspx'; }, 3000);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true);
                }
            }
        }
    }
}