using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace JobPortal
{
    public partial class UserCrud : System.Web.UI.Page
    {
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string con = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;
            SqlConnection connection =  new SqlConnection(con);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;    
            command.CommandText = "Select * from Users";
            SqlDataAdapter adapter = new SqlDataAdapter(command); 
            ds = new DataSet();
            try
            {
                using (connection)
                {
                    connection.Open();
                    adapter.Fill(ds, "Users");
                    connection.Close();
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("No users found........");
                Response.Write(ex.ToString());
            }
           
            gdvusers.DataSource = ds;
            gdvusers.DataBind();
            */
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;
            try
            {
                using(con)
                {
                    string cmd = "select * from Users";
                    SqlCommand sqlCommand = new SqlCommand(cmd, con);
                    con.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    gdvusers.DataSource = reader;
                    gdvusers.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message); 
            }
             


        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;
            conn.Open();
            string query = "INSERT INTO Users (Username, Email,PasswordHash,Role,FirstName,LastName,Phone,Location,ResumeId,CreatedAt,UpdatedAt)"+
                " VALUES(@Username, @Email,@PasswordHash, @Role, @FirstName, @LastName, @Phone, @Location, @ResumeId, @CreatedAt, @UpdatedAt)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", tbusername.Text);
            cmd.Parameters.AddWithValue("@Email", tbemail.Text);
            cmd.Parameters.AddWithValue("@PasswordHash", tbpassword.Text);
            cmd.Parameters.AddWithValue("@Role", ddlrole.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@FirstName", tbfirstname.Text);
            cmd.Parameters.AddWithValue("@LastName", tblastname.Text);
            cmd.Parameters.AddWithValue("@Phone", tbphone.Text);
            cmd.Parameters.AddWithValue("@Location", tblocation.Text);
            cmd.Parameters.AddWithValue("@ResumeId", tbresume.Text);
            cmd.Parameters.AddWithValue("@CreatedAt", tbcdatereate.Text);
            cmd.Parameters.AddWithValue("@UpdatedAt", tbupdatedate.Text);
            cmd.ExecuteNonQuery();
            Page_Load(sender, e);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;
            conn.Open();
            string query = "DELETE FROM Users where UserId=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", tbid.Text);
            cmd.ExecuteNonQuery();
        }

        protected void btupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbfirstname.Text) ||
                string.IsNullOrEmpty(tblastname.Text) ||
                string.IsNullOrEmpty(tbphone.Text) ||
                string.IsNullOrEmpty(tblocation.Text) ||
                string.IsNullOrEmpty(tbresume.Text) ||
                string.IsNullOrEmpty(tbid.Text))
            {
                Response.Write("Please fill in all required fields.");
                return;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;
            try
            {
                using(con)
                {

                    con.Open();
                    string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Location = @Location, ResumeId = @ResumeId WHERE UserId = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", tbfirstname.Text);
                    cmd.Parameters.AddWithValue("@LastName", tblastname.Text);
                    cmd.Parameters.AddWithValue("@Phone", tbphone.Text);
                    cmd.Parameters.AddWithValue("@Location", tblocation.Text);
                    cmd.Parameters.AddWithValue("@ResumeId", tbresume.Text);

                    int userId;
                    if (!int.TryParse(tbid.Text, out userId))
                    {
                        Response.Write("Invalid user ID format.");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message); 
                }
            
        }
    }
}