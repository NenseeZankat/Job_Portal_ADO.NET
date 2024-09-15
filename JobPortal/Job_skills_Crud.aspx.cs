using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace JobPortal
{
    public partial class Job_skills_Crud : System.Web.UI.Page
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
                string query = "SELECT * FROM Job_Skills";
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    gvJobSkills.DataSource = rd;
                    gvJobSkills.DataBind();
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
                string query = "INSERT INTO Job_Skills (JobId, SkillId) VALUES (@JobId, @SkillId)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@JobId", tbJobId.Text);
                cmd.Parameters.AddWithValue("@SkillId", tbSkillId.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Job Skill saved successfully!";
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
                string query = "UPDATE Job_Skills SET SkillId = @SkillId WHERE JobId = @JobId";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@JobId", tbJobId.Text);
                cmd.Parameters.AddWithValue("@SkillId", tbSkillId.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Job Skill updated successfully!";
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
                string query = "DELETE FROM Job_Skills WHERE JobId = @JobId AND SkillId = @SkillId";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@JobId", tbJobId.Text);
                cmd.Parameters.AddWithValue("@SkillId", tbSkillId.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Job Skill deleted successfully!";
                    Show_Data();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }


        protected void gvJobSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvJobSkills.SelectedRow;
            tbJobId.Text = row.Cells[1].Text;
            tbSkillId.Text = row.Cells[2].Text;
        }
    }
}
