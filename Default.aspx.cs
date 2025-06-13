using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parcial_Policaro.BIZ; 

namespace Parcial_Policaro
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txusuario.Text) || string.IsNullOrWhiteSpace(TxPassword.Text))
                {
                    lt_mensaje.Text = "Debe completar ambos campos para ingresar";
                    lt_mensaje.Visible = true;
                    return;
                }

                StUser? usuario = DatosLogin.Manager.LoginUser(Txusuario.Text, TxPassword.Text);
                if (usuario != null)
                {
                    Session["UserId"] = usuario.Value.Id;
                    Session["Email"] = usuario.Value.email;
                    Session["Permission"] = usuario.Value.Nivel;

                    if (usuario.Value.Nivel == 0)
                    {
                        Response.Redirect("Pagina1.aspx");
                    }
                    else
                    {
                        Response.Redirect("Pagina2.aspx");
                    }
                }
                else
                {
                    lt_mensaje.Text = "Usuario y/o contraseña incorrectos";
                    lt_mensaje.Visible = true;
                    TxPassword.Text = "";
                    Txusuario.Focus();
                }
            }
            catch (Exception ex)
            {
                lt_mensaje.Text = "Ocurrió un error: " + ex.Message;
                lt_mensaje.Visible = true;
            }
        }

    }
}