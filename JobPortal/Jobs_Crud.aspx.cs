using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
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

                if (Session["Username"] != null)
                {
                    // User is logged in
                    LoginLogoutPlaceholder.Controls.Clear();
                    LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                        "<li class='nav-item'><a class='nav-link' href='/LogOut.aspx'>Logout</a></li>"
                    ));
                }
                else
                {
                    // User is not logged in
                    LoginLogoutPlaceholder.Controls.Clear();
                    LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                        "<li class='nav-item'><a class='nav-link' href='/Login.aspx'>Login</a></li>" +
                        "<li class='nav-item'><a class='nav-link' href='/Register.aspx'>Register</a></li>"
                    ));
                }

                if (Session["Role"] != null && Session["Role"].ToString() == "job_seeker")
                {
                    postJobPlaceHolder.Controls.Clear();
                    postJobPlaceHolder.Controls.Add(new LiteralControl(
                        "<li class=\"nav-item\"><a class=\"nav-link\" href=\"Jobs_Crud.aspx\">Post Job</a></li>"
                    ));
                }
                else
                {
                    postJobPlaceHolder.Controls.Clear();
                }
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
            if (Session["UserId"] == null)
            {
                lblMessage.Text = "You must be logged in to view jobs.";
                return;
            }

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "SELECT * FROM Jobs WHERE PostedBy = @PostedBy";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@PostedBy", Session["UserId"]); // Fetch only jobs posted by the logged-in user

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

            if (Session["UserId"] == null)
            {
                lblMessage.Text = "You must be logged in to post a job.";
                return;
            }

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "INSERT INTO Jobs (Title, Description, Location, CompanyId, JobType, SalaryMin, SalaryMax, Currency, PostedBy) " +
                           "VALUES (@Title, @Description, @Location, @CompanyId, @JobType, @SalaryMin, @SalaryMax, @Currency, @PostedBy)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Title", tbTitle.Text);
            cmd.Parameters.AddWithValue("@Description", tbDescription.Text);
            cmd.Parameters.AddWithValue("@Location", tbLocation.Text);
            cmd.Parameters.AddWithValue("@CompanyId", ddlCompanyId.SelectedValue);
            cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
            cmd.Parameters.AddWithValue("@SalaryMin", tbSalaryMin.Text);
            cmd.Parameters.AddWithValue("@SalaryMax", tbSalaryMax.Text);
            cmd.Parameters.AddWithValue("@Currency", tbCurrency.Text);
            cmd.Parameters.AddWithValue("@PostedBy", Session["UserId"]); // Use the logged-in user ID

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Job posted successfully!";
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

            if (Session["Username"] != null)
            {
                // User is logged in
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/LogOut.aspx'>Logout</a></li>"
                ));
            }
            else
            {
                // User is not logged in
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/Login.aspx'>Login</a></li>" +
                    "<li class='nav-item'><a class='nav-link' href='/Register.aspx'>Register</a></li>"
                ));
            }
            Page_Load(sender, e);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                lblMessage.Text = "You must be logged in to update jobs.";
                return;
            }

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "UPDATE Jobs SET Title = @Title, Description = @Description, Location = @Location, CompanyId = @CompanyId, " +
                           "JobType = @JobType, SalaryMin = @SalaryMin, SalaryMax = @SalaryMax, Currency = @Currency " +
                           "WHERE JobId = @JobId AND PostedBy = @PostedBy"; // Ensure the job is being updated by the right user
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
            cmd.Parameters.AddWithValue("@PostedBy", Session["UserId"]); // Ensure the job is updated by the same user who posted it

            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Job updated successfully!";
                    Show_Data();
                }
                else
                {
                    lblMessage.Text = "No job found with the specified ID or you are not authorized to update this job.";
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
            if (Session["Username"] != null)
            {
                // User is logged in
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/LogOut.aspx'>Logout</a></li>"
                ));
            }
            else
            {
                // User is not logged in
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/Login.aspx'>Login</a></li>" +
                    "<li class='nav-item'><a class='nav-link' href='/Register.aspx'>Register</a></li>"
                ));
            }
            Page_Load(sender, e);
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
            if (Session["Username"] != null)
            {
                // User is logged in
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/LogOut.aspx'>Logout</a></li>"
                ));
            }
            else
            {
                // User is not logged in
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/Login.aspx'>Login</a></li>" +
                    "<li class='nav-item'><a class='nav-link' href='/Register.aspx'>Register</a></li>"
                ));
            }
            Page_Load(sender, e);
        }
        protected void ddlCompanyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic to handle the selection change, for example, you might want to reload jobs based on the selected company
            Show_Data();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "job_seeker")
            {
                postJobPlaceHolder.Controls.Clear();
                postJobPlaceHolder.Controls.Add(new LiteralControl(
                    "<li class=\"nav-item\"><a class=\"nav-link\" href=\"Jobs_Crud.aspx\">Post Job</a></li>"
                ));
            }
            else
            {
                postJobPlaceHolder.Controls.Clear();
            }

            if (string.IsNullOrEmpty(hfJobId.Value))
            {
                lblMessage.Text = "Please select a job to delete.";
                return; // Avoid calling Page_Load unnecessarily
            }

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "DELETE FROM Jobs WHERE JobId = @JobId AND PostedBy = @PostedBy"; // Ensure the job is deleted by the right user
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@JobId", hfJobId.Value);
            cmd.Parameters.AddWithValue("@PostedBy", Session["UserId"]); // Ensure the job is deleted by the same user who posted it

            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Job deleted successfully, redirect to home page
                    Response.Redirect("/HomePage.aspx");
                }
                else
                {
                    lblMessage.Text = "No job found with the specified ID or you are not authorized to delete this job.";
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

    }
}
