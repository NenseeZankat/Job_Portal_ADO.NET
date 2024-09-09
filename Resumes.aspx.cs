using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace JobPortal
{
    public partial class Resumes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show_Data();
            }
        }

        
        protected void Show_Data()
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                string query = "SELECT * FROM Resumes";
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    gvResumes.DataSource = cmd.ExecuteReader();
                    gvResumes.DataBind();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                string query = "INSERT INTO Resumes (UserId, ResumeUrl) VALUES (@UserId, @ResumeUrl)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserId", tbUserId.Text);
                cmd.Parameters.AddWithValue("@ResumeUrl", tbResumeUrl.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Resume saved successfully!";
                    Show_Data();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

       
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                string query = "UPDATE Resumes SET UserId = @UserId, ResumeUrl = @ResumeUrl WHERE ResumeId = @ResumeId";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ResumeId", hfResumeId.Value); 
                cmd.Parameters.AddWithValue("@UserId", tbUserId.Text);
                cmd.Parameters.AddWithValue("@ResumeUrl", tbResumeUrl.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Resume updated successfully!";
                    Show_Data();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

       
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                string query = "DELETE FROM Resumes WHERE ResumeId = @ResumeId";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ResumeId", hfResumeId.Value);  

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Resume deleted successfully!";
                    Show_Data();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

       
        protected void gvResumes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvResumes.SelectedRow;
            hfResumeId.Value = row.Cells[0].Text;  
            tbUserId.Text = row.Cells[1].Text;     
            tbResumeUrl.Text = row.Cells[2].Text; 
        }
    }
}
