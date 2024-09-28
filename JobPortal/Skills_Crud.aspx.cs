using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal
{
    public partial class Skills_Crud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Show_Data();
        }

        protected void Show_Data()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;

            try
            {
                using (con)
                {
                    string query = " SELECT * FROM Skills";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    GDVSkill.DataSource = rd;
                    GDVSkill.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;

            try
            {
                using (con)
                {
                    string query = " INSERT INTO Skills (Name, Category ) VALUES ( @Name , @Category)";

                    SqlCommand cmd = new SqlCommand (query, con);
                    cmd.Parameters.AddWithValue("@Name", tbName.Text);
                    cmd.Parameters.AddWithValue("@Category",tbCategory.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Show_Data();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        protected void btupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;
            try
            {
                using(con)
                {
                    string query = "UPDATE Skills SET Name = @Name, Category = @Category WHERE SkillId = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", tbName.Text);
                    cmd.Parameters.AddWithValue("@Category", tbCategory.Text);
                    cmd.Parameters.AddWithValue("@Id", tbid.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Show_Data();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;
            try
            {
                using(con)
                {
                    string query = "DELETE FROM Skills where SkillId=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", tbid.Text);
                    cmd.ExecuteNonQuery();
                    query = " DELETE FROM User_Skills where SkillId = @Id";
                    cmd.Parameters.AddWithValue("@Id", tbid.Text);
                    cmd.ExecuteNonQuery();
                    Show_Data();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}