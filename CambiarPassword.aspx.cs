using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parcial_Policaro.BIZ; 

namespace Parcial_Policaro
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected string token;

        protected void Page_Load(object sender, EventArgs e)
        {
            token = Request.QueryString["token"];
            if (string.IsNullOrEmpty(token) || !DatosLogin.Manager.ValidarToken(token))
            {
                panelCambio.Visible = false;
                ltMensaje.Text = "<span style='color:red;'>El enlace no es válido o expiró.</span>";
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            string pass1 = txtPassword1.Text;
            string pass2 = txtPassword2.Text;

            if (string.IsNullOrWhiteSpace(pass1) || pass1 != pass2)
            {
                ltMensaje.Text = "<span style='color:red;'>Las contraseñas no coinciden.</span>";
                return;
            }

            bool ok = DatosLogin.Manager.RecuperarPassword(token, pass1);
            if (ok)
            {
                panelCambio.Visible = false;
                ltMensaje.Text = "<span style='color:green;'>¡Contraseña cambiada exitosamente!</span>";
            }
            else
            {
                ltMensaje.Text = "<span style='color:red;'>Error al cambiar la contraseña. Intente de nuevo.</span>";
            }
        }
    }
}