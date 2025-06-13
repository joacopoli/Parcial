using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

namespace Parcial_Policaro
{
    public partial class recuperar : System.Web.UI.Page
    {
        protected void btnEnviarEnlace_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string email = txtEmailRecup.Text.Trim();

            // 1) Verificar que exista el email en la BD
            if (!UsuarioBIZ.ExistePorEmail(email))
            {
                lblMensajeRecuperar.ForeColor = System.Drawing.Color.Red;
                lblMensajeRecuperar.Text = "No existe una cuenta con ese email.";
                return;
            }

            // 2) Generar token en BD y enviar correo (GenerarTokenRecupero maneja el envío internamente)
            bool okGenerar = UsuarioBIZ.GenerarTokenRecupero(email);
            if (!okGenerar)
            {
                // Si por algún motivo el UPDATE de token falló (email no existe o error de BD),
                // mostramos un mensaje genérico de error.
                lblMensajeRecuperar.ForeColor = System.Drawing.Color.Red;
                lblMensajeRecuperar.Text = "Error al generar el enlace. Intenta más tarde.";
                return;
            }

            // 3) Si llegamos aquí, el email existía y ya se hizo el UPDATE en BD.
            //    El método GenerarTokenRecupero ya intentó enviar el correo (sin propagar excepciones).
            lblMensajeRecuperar.ForeColor = System.Drawing.Color.Green;
            lblMensajeRecuperar.Text = "Chequea tu correo para el enlace de cambio de contraseña.";
        }
    }
}
    }
}