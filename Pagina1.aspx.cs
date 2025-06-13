using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial_Policaro
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["UserId"] == null || Session["Permission"] == null || (int)Session["Permission"] != 0)
                {
                    Response.Redirect("Login.aspx");
                }

                if (!IsPostBack)
                {
                    lblSaludo.Text = "¡Hola " + Session["Email"] + "!";
                }
            }

            protected void btnLogout_Click(object sender, EventArgs e)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
        }
    
}
