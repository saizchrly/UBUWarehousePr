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
                lblMostrarElem.Text = u.mostrarElementos();
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

        /*protected void btnRaiz_Click(object sender, EventArgs e)
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
        */

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
            if (u != null)
            {
                u.setPais(tbPais.Text);
                Session["User"] = u;
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnTelefono_Click(object sender, EventArgs e)
        {
            tbTelefono.Visible = true;
            btnCTelefono.Visible = true;
        }

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
            /*
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
            */
        }
    }
}