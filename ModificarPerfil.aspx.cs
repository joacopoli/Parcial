using Parcial_Policaro.BIZ;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration; 

namespace Parcial_Policaro
{
    public partial class ModificarPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                int userId = (int)Session["UserId"];
               string connectionString = ConfigurationManager.ConnectionStrings["SQLCLASE"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT nombre, apellido FROM Usuarios WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNombre.Text = reader["nombre"].ToString();
                        txtApellido.Text = reader["apellido"].ToString();
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensaje.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                lblMensaje.Text = "Nombre y Apellido son obligatorios.";
                return;
            }

            if (!string.IsNullOrEmpty(txtPassword.Text) || !string.IsNullOrEmpty(txtPassword2.Text))
            {
                if (txtPassword.Text != txtPassword2.Text)
                {
                    lblMensaje.Text = "Las contraseñas no coinciden.";
                    return;
                }
            }

            int userId = (int)Session["UserId"];
            string connectionString = ConfigurationManager.ConnectionStrings["SQLCLASE"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Usuarios SET nombre = @nombre, apellido = @apellido";
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    sql += ", PasswordHash = @PasswordHash";
                }
                sql += " WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    string hash = DatosLogin.Manager.ComputeHash(txtPassword.Text);
                    cmd.Parameters.AddWithValue("@PasswordHash", hash);
                }
                cmd.Parameters.AddWithValue("@Id", userId);

                cmd.ExecuteNonQuery();
            }
            lblMensaje.ForeColor = System.Drawing.Color.Green;
            lblMensaje.Text = "Cambios guardados correctamente.";
        }
    }
}