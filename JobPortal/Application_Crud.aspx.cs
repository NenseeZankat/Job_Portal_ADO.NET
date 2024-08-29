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
    public partial class Application_Crud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Show_Data();
            tbAppliedAt.Text = DateTime.Now.ToString();
        }

        protected void Show_Data()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;

            try
            {
                using (con)
                {
                    string query = "SELECT * FROM Applications";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    GDVApplication.DataSource = rd;
                    GDVApplication.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;

            try
            {
                using(con)
                {
                    string query = "INSERT INTO Applications (JobId , UserId, ResumeId, CoverLetter , Status , AppliedAt ,UpdatedAt )"
                         + "Values ( @JobId ,@UserId ,@ResumeId,@CoverLetter , @Status , @AppliedAt ,@UpdatedAt)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@JobId",ddlJobId.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@UserId", ddlUserId.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@ResumeId", GetResumeId(con, ddlUserId.SelectedItem.Value));
                    cmd.Parameters.AddWithValue("@CoverLetter",tbCoverLetter.Text);
                    cmd.Parameters.AddWithValue("@Status",tbStatus.Text);
                    cmd.Parameters.AddWithValue("@AppliedAt",tbAppliedAt.Text);
                    cmd.Parameters.AddWithValue("@UpdatedAt",tbUpdateAt.Text);
                    cmd.ExecuteNonQuery();
                    Show_Data();

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected int GetResumeId(SqlConnection con,string UserId)
        {
            string query = "SELECT ResumeId from Resumes where UserId = @UserId";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserId", UserId);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new Exception("Failed to retrieve the last inserted user ID.");
                }
            }
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["JPCon"].ConnectionString;
            try
            {
                using(con)
                {
                    string query = "DELETE FROM Applications where ApplicationId = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", tbId.Text);
                    cmd.ExecuteNonQuery();
                    Show_Data();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}