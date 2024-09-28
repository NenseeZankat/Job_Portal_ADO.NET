using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using BCrypt.Net;

namespace JobPortal
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["Username"] != null)
            {
                // User is logged in, show logout link and hide login/register links
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/LogOut.aspx'>Logout</a></li>"
                ));
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                // User is not logged in, show login/register links
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/Login.aspx'>Login</a></li>" +
                    "<li class='nav-item'><a class='nav-link' href='/Register.aspx'>Register</a></li>"
                ));
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();

            // Connection string from web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Fetch the user's stored hash and role from the database
                    string sql = "SELECT UserId,PasswordHash, Role FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            string role = reader["Role"].ToString();
                            string Userid = reader["UserId"].ToString();

                            // Verify the password using BCrypt
                            if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                            {
                                // Authentication successful, set session variables
                                Session["Username"] = username;
                                Session["Role"] = role;
                                Session["Userid"] = Userid;

                                // Optionally: redirect the user based on their role
                                if (role == "Admin")
                                {
                                    Response.Redirect("HomePage.aspx");
                                }
                                else
                                {
                                    Response.Redirect("HomePage.aspx");
                                }
                            }
                            else
                            {
                                // Password is incorrect
                                ErrorLabel.Text = "Invalid username or password.";
                                ErrorLabel.Visible = true;
                            }
                        }
                        else
                        {
                            // Username does not exist
                            ErrorLabel.Text = "Invalid username or password.";
                            ErrorLabel.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (like database connectivity issues)
                ErrorLabel.Text = "An error occurred: " + ex.Message;
                ErrorLabel.Visible = true;
            }
        }
    }
}
