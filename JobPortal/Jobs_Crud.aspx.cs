using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace JobPortal
{
    public partial class Jobs_Crud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Companies();
                Load_Users();
                Show_Data();
            }
        }

        protected void Load_Companies()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "SELECT CompanyId, Name FROM Companies";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                ddlCompanyId.DataSource = cmd.ExecuteReader();
                ddlCompanyId.DataTextField = "Name";
                ddlCompanyId.DataValueField = "CompanyId";
                ddlCompanyId.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading companies: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        protected void Load_Users()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "SELECT UserId, Username FROM Users WHERE Role = 'employer'";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                ddlPostedBy.DataSource = cmd.ExecuteReader();
                ddlPostedBy.DataTextField = "Username";
                ddlPostedBy.DataValueField = "UserId";
                ddlPostedBy.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading users: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        protected void Show_Data()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "SELECT * FROM Jobs";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                gvJobs.DataSource = cmd.ExecuteReader();
                gvJobs.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "INSERT INTO Jobs (Title, Description, Location, CompanyId, JobType, SalaryMin, SalaryMax, Currency, PostedBy) VALUES (@Title, @Description, @Location, @CompanyId, @JobType, @SalaryMin, @SalaryMax, @Currency, @PostedBy)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Title", tbTitle.Text);
            cmd.Parameters.AddWithValue("@Description", tbDescription.Text);
            cmd.Parameters.AddWithValue("@Location", tbLocation.Text);
            cmd.Parameters.AddWithValue("@CompanyId", ddlCompanyId.SelectedValue);
            cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
            cmd.Parameters.AddWithValue("@SalaryMin", tbSalaryMin.Text);
            cmd.Parameters.AddWithValue("@SalaryMax", tbSalaryMax.Text);
            cmd.Parameters.AddWithValue("@Currency", tbCurrency.Text);
            cmd.Parameters.AddWithValue("@PostedBy", ddlPostedBy.SelectedValue);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Job saved successfully!";
                Show_Data();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "UPDATE Jobs SET Title = @Title, Description = @Description, Location = @Location, CompanyId = @CompanyId, JobType = @JobType, SalaryMin = @SalaryMin, SalaryMax = @SalaryMax, Currency = @Currency, PostedBy = @PostedBy WHERE JobId = @JobId";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@JobId", hfJobId.Value);
            cmd.Parameters.AddWithValue("@Title", tbTitle.Text);
            cmd.Parameters.AddWithValue("@Description", tbDescription.Text);
            cmd.Parameters.AddWithValue("@Location", tbLocation.Text);
            cmd.Parameters.AddWithValue("@CompanyId", ddlCompanyId.SelectedValue);
            cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
            cmd.Parameters.AddWithValue("@SalaryMin", tbSalaryMin.Text);
            cmd.Parameters.AddWithValue("@SalaryMax", tbSalaryMax.Text);
            cmd.Parameters.AddWithValue("@Currency", tbCurrency.Text);
            cmd.Parameters.AddWithValue("@PostedBy", ddlPostedBy.SelectedValue);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Job updated successfully!";
                Show_Data();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        protected void gvJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvJobs.SelectedRow;
            string companyId = row.Cells[4].Text;
            string postedById = row.Cells[9].Text;

            hfJobId.Value = row.Cells[0].Text;
            tbTitle.Text = row.Cells[1].Text;
            tbDescription.Text = row.Cells[2].Text;
            tbLocation.Text = row.Cells[3].Text;
            ddlJobType.SelectedValue = row.Cells[5].Text;
            tbSalaryMin.Text = row.Cells[6].Text;
            tbSalaryMax.Text = row.Cells[7].Text;
            tbCurrency.Text = row.Cells[8].Text;

            if (ddlCompanyId.Items.FindByValue(companyId) != null)
            {
                ddlCompanyId.SelectedValue = companyId;
            }
            else
            {
                lblMessage.Text = "Invalid CompanyId selected.";
            }

            if (ddlPostedBy.Items.FindByValue(postedById) != null)
            {
                ddlPostedBy.SelectedValue = postedById;
            }
            else
            {
                lblMessage.Text = "Invalid PostedById selected.";
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfJobId.Value))
            {
                lblMessage.Text = "Please select a job to delete.";
                return;
            }

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "DELETE FROM Jobs WHERE JobId = @JobId";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@JobId", hfJobId.Value);

            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Job deleted successfully!";
                    Show_Data(); // Refresh the GridView
                }
                else
                {
                    lblMessage.Text = "Job not found.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        protected void ddlCompanyId_SelectedIndexChanged(object sender, EventArgs e)
        {

            Show_Data();
        }


        protected void ddlPostedBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            Show_Data();
        }

    }
}
