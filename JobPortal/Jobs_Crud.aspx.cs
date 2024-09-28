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
                Load_Categories(); 
            }
        }
        protected void Load_Categories()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "SELECT CategoryId, Name FROM Categories";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                ddlCategoryId.DataSource = cmd.ExecuteReader();
                ddlCategoryId.DataTextField = "Name";
                ddlCategoryId.DataValueField = "CategoryId";
                ddlCategoryId.DataBind();

                // Optionally, add a default item
                ddlCategoryId.Items.Insert(0, new ListItem("-- Select Category --", "0"));
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading categories: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        // Existing methods: Load_Companies, Load_Users, Show_Data, etc.
    


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
            //   string query = "SELECT * FROM Jobs";
            string query = @"
        SELECT 
            J.JobId, 
            J.Title, 
            J.Description, 
            J.Location, 
            C.CompanyId, 
            C.Name AS CompanyName, 
            CAT.CategoryId, 
            CAT.Name AS CategoryName, 
            J.JobType, 
            J.SalaryMin, 
            J.SalaryMax, 
            J.Currency, 
            U.UserId, 
            U.Username AS PostedBy 
        FROM Jobs J
        LEFT JOIN Companies C ON J.CompanyId = C.CompanyId
        LEFT JOIN Categories CAT ON J.CategoryId = CAT.CategoryId
        LEFT JOIN Users U ON J.PostedBy = U.UserId";
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
            string query = "INSERT INTO Jobs (Title, Description, Location, CompanyId, CategoryId, JobType, SalaryMin, SalaryMax, Currency, PostedBy) VALUES (@Title, @Description, @Location, @CompanyId, @CategoryId, @JobType, @SalaryMin, @SalaryMax, @Currency, @PostedBy)";
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
            cmd.Parameters.AddWithValue("@CategoryId", ddlCategoryId.SelectedValue != "0" ? (object)ddlCategoryId.SelectedValue : DBNull.Value);
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
            string query = "UPDATE Jobs SET Title = @Title, Description = @Description, Location = @Location, CompanyId = @CompanyId, CategoryId = @CategoryId, JobType = @JobType, SalaryMin = @SalaryMin, SalaryMax = @SalaryMax, Currency = @Currency, PostedBy = @PostedBy WHERE JobId = @JobId";
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
            cmd.Parameters.AddWithValue("@CategoryId", ddlCategoryId.SelectedValue != "0" ? (object)ddlCategoryId.SelectedValue : DBNull.Value);
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

            // Retrieve hidden IDs from the last few cells
            string companyId = row.Cells[11].Text;    // CompanyId (Hidden)
            string categoryId = row.Cells[12].Text;   // CategoryId (Hidden)
            string userId = row.Cells[13].Text;        // UserId (Hidden)

            // Set the HiddenField with JobId
            hfJobId.Value = row.Cells[0].Text;

            // Populate the form fields with selected row data
            tbTitle.Text = row.Cells[1].Text;
            tbDescription.Text = row.Cells[2].Text;
            tbLocation.Text = row.Cells[3].Text;

            // Set the selected values for Company and Category dropdowns
            if (ddlCompanyId.Items.FindByValue(companyId) != null)
            {
                ddlCompanyId.SelectedValue = companyId;
            }
            else
            {
                lblMessage.Text = "Invalid CompanyId selected.";
            }

            if (ddlCategoryId.Items.FindByValue(categoryId) != null)
            {
                ddlCategoryId.SelectedValue = categoryId;
            }
            else
            {
                lblMessage.Text = "Invalid CategoryId selected.";
            }

            // Set the Job Type dropdown
            ddlJobType.SelectedValue = row.Cells[6].Text;

            // Populate salary fields
            tbSalaryMin.Text = row.Cells[7].Text;
            tbSalaryMax.Text = row.Cells[8].Text;
            tbCurrency.Text = row.Cells[9].Text;

            // Set the Posted By dropdown
            if (ddlPostedBy.Items.FindByValue(userId) != null)
            {
                ddlPostedBy.SelectedValue = userId;
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
