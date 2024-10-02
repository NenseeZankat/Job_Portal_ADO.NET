using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.Configuration;

namespace JobPortal
{
    public partial class HomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Manage login/logout link visibility
            ManageLoginLogoutLinks();

            // Load data only on initial page load
            if (!IsPostBack)
            {
                LoadFeaturedJobs();
                BindJobCategories();
            }
        }

        private void ManageLoginLogoutLinks()
        {
            // Display Logout if the user is logged in; otherwise, show Login/Register
            LoginLogoutPlaceholder.Controls.Clear();

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

        private void LoadFeaturedJobs()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Updated SQL Query to include JobId
                string query = @"
            SELECT TOP 3 JobId, Title, Location, 
                   (SELECT Name FROM Companies WHERE CompanyId = Jobs.CompanyId) AS CompanyName
            FROM Jobs
            ORDER BY CreatedAt DESC";  // Fetch the 3 most recent jobs

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind the data to the repeater control
                    if (dt.Rows.Count > 0)
                    {
                        FeaturedJobsRepeater.DataSource = dt;
                        FeaturedJobsRepeater.DataBind();
                    }
                }
            }
        }


        private void BindJobCategories()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // SQL query to fetch categories and job count for each category
            string query = @"
                SELECT c.CategoryId, c.Name AS CategoryName, COUNT(j.JobId) AS JobCount
                FROM Categories c
                LEFT JOIN Jobs j ON c.CategoryId = j.CategoryId
                GROUP BY c.CategoryId, c.Name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable categoriesTable = new DataTable();
                    adapter.Fill(categoriesTable);

                    // Bind the repeater control to category data
                    CategoryRepeater.DataSource = categoriesTable;
                    CategoryRepeater.DataBind();
                }
            }
        }
    }
}
