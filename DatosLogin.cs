using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace Parcial_Policaro.BIZ
{
    public struct StUser
    {
        public int Id;
        public string nombre;
        public string apellido;
        public string email;
        public string contrasenia;
        public int Nivel;
        public string Token;
    }
    public class DatosLogin
    {
        public static class Manager
        {
            static string conexionstring = ConfigurationManager.ConnectionStrings["SQLCLASE"].ConnectionString;
            public static string ComputeHash(string password)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(password);
                    byte[] hash = sha256.ComputeHash(bytes);
                    StringBuilder result = new StringBuilder();
                    foreach (byte b in hash)
                        result.Append(b.ToString("x2"));  // convierte a hex
                    return result.ToString();
                }
            }

            public static StUser? LoginUser(string email, string contrasenia) //SIGNO ? PARA QUE ME PUEDA DEVOLVER NULL EN CASO DE ERROR
            {
                string hash = ComputeHash(contrasenia);
                string query = @"SELECT Id, nombre, apellido, Email, Nivel, Token 
                     FROM Usuarios
                     WHERE Email = @Email AND PasswordHash = @PasswordHash";

                using (SqlConnection conn = new SqlConnection(conexionstring))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email); 
                    cmd.Parameters.AddWithValue("@PasswordHash", hash);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StUser
                            {
                                Id = (int)reader["Id"],
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                email = reader["Email"].ToString(),
                                Nivel = (int)reader["Nivel"],
                                Token = reader["Token"].ToString()
                            };
                        }
                    }
                }
                return null;
            }

            public static bool Registro(StUser user)
            {
                string hash = ComputeHash(user.contrasenia);
                string query = @"INSERT INTO Usuarios (nombre, apellido, Email, PasswordHash, Nivel)
                     VALUES (@Nombre, @Apellido, @Email, @PasswordHash, @Nivel)";

                using (SqlConnection conn = new SqlConnection(conexionstring))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", user.nombre);
                    cmd.Parameters.AddWithValue("@Apellido", user.apellido);
                    cmd.Parameters.AddWithValue("@Email", user.email);
                    cmd.Parameters.AddWithValue("@PasswordHash", hash);
                    cmd.Parameters.AddWithValue("@Nivel", user.Nivel);
                    conn.Open();
                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }

            public static string GenerarToken(string email)
            {
                string token = Guid.NewGuid().ToString();
                DateTime expiration = DateTime.Now.AddMinutes(20);

                string query = @"UPDATE Usuarios SET Token=@Token, TokenExpiration=@Exp WHERE Email=@Email";

                using (SqlConnection conn = new SqlConnection(conexionstring))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Token", token);
                    cmd.Parameters.AddWithValue("@Exp", expiration);
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        return token;
                }
                return null;
            }

            public static bool ValidarToken(string token)
            {
                string query = @"SELECT Email FROM Usuarios WHERE Token=@Token AND TokenExpiration>@Now";

                using (SqlConnection conn = new SqlConnection(conexionstring))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Token", token);
                    cmd.Parameters.AddWithValue("@Now", DateTime.Now);
                    conn.Open();
                    return cmd.ExecuteScalar() != null;
                }
            }
            public static bool RecuperarPassword(string token, string newPassword)
            {
                string hash = ComputeHash(newPassword);
                string query = @"UPDATE Usuarios 
                             SET PasswordHash=@PasswordHash, Token=NULL, TokenExpiration=NULL 
                             WHERE Token=@Token AND TokenExpiration>@Now";

                using (SqlConnection conn = new SqlConnection(conexionstring))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PasswordHash", hash);
                    cmd.Parameters.AddWithValue("@Token", token);
                    cmd.Parameters.AddWithValue("@Now", DateTime.Now);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

        }
             

     }
}

