using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using BCrypt.Net;

namespace JobPortal
{
    public partial class Register : Page
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
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            // Fetch the values from the controls
            string username = Username.Text.Trim();
            string email = Email.Text.Trim();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(Password.Text.Trim());
            string role = Role.SelectedValue;
            string firstName = FirstName.Text.Trim();
            string lastName = LastName.Text.Trim();
            string phone = Phone.Text.Trim();
            string location = Location.Text.Trim();

            // Connection string from web.config
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (Username, Email, PasswordHash, Role, FirstName, LastName, Phone, Location) " +
                                 "VALUES (@Username, @Email, @PasswordHash, @Role, @FirstName, @LastName, @Phone, @Location)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Add parameters to avoid SQL Injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Location", location);

                        cmd.ExecuteNonQuery();


                    }
                    sql = "SELECT UserId,PasswordHash, Role FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            string Role = reader["Role"].ToString();
                            string Userid = reader["UserId"].ToString();
                            Session["Username"] = username;
                            Session["Role"] = Role;
                            Session["Userid"] = Userid;
                        }
                    }
                }

             

                // Redirect to the Login page
                Response.Redirect("HomePage.aspx");
            }
            catch (Exception ex)
            {
                // Handle the error
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}
