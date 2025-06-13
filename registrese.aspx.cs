using Parcial_Policaro.BIZ;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial_Policaro
{
    public partial class registrese : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtRegistrarse_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(Txname.Text) ||
                string.IsNullOrWhiteSpace(Txapellido.Text) ||
                string.IsNullOrWhiteSpace(Txemail.Text) ||
                string.IsNullOrWhiteSpace(TxPassword.Text) ||
                string.IsNullOrWhiteSpace(TxPassword2.Text))
            {
                lblMensaje.Text = "Todos los campos son obligatorios";
                lblMensaje.Visible = true;  
            }

            if (TxPassword.Text != TxPassword2.Text)
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                lblMensaje.Visible = true;
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["SQLCLASE"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlCheck = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@Email", Txemail.Text.Trim());

                int count = (int)cmdCheck.ExecuteScalar();
                if (count > 0)
                {
                    lblMensaje.Text = "Ya existe un usuario con ese email.";
                    lblMensaje.Visible = true;
                    return;
                }

                // Insertar usuario
                string hash = DatosLogin.Manager.ComputeHash(TxPassword.Text);
                string sqlInsert = @"INSERT INTO Usuarios (nombre, apellido, Email, PasswordHash, Nivel, Token)
                                     VALUES (@nombre, @apellido, @Email, @PasswordHash, @Nivel, @Token)";
                SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                cmdInsert.Parameters.AddWithValue("@nombre", Txname.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@apellido", Txapellido.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@Email", Txemail.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@PasswordHash", hash);
                cmdInsert.Parameters.AddWithValue("@Nivel", 1);
                cmdInsert.Parameters.AddWithValue("@Token", Guid.NewGuid().ToString());

                cmdInsert.ExecuteNonQuery();
            }

           
            lblMensaje.Text = "Registro exitoso. Ahora puedes iniciar sesión.";
            lblMensaje.Visible = true; 
        }
    }
}