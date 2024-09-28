using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal
{
    public partial class Jobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJobs();
            }
        }

        private void LoadJobs()
        {
            // Retrieve the CategoryId from the query string
            string categoryId = Request.QueryString["CategoryId"];
            bool hasCategory = !string.IsNullOrEmpty(categoryId) && int.TryParse(categoryId, out _);

            // Define the connection string (ensure it's correctly set in Web.config)
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Base SQL query with JOINs to fetch CompanyName and CategoryName
            string query = @"
                SELECT 
                    J.JobId, 
                    J.Title, 
                    J.Location, 
                    J.JobType, 
                    J.SalaryMin, 
                    J.SalaryMax, 
                    J.Currency, 
                    J.Description,
                    C.Name AS CompanyName,
                    CAT.Name AS CategoryName
                FROM Jobs J
                LEFT JOIN Companies C ON J.CompanyId = C.CompanyId
                LEFT JOIN Categories CAT ON J.CategoryId = CAT.CategoryId
                WHERE (@CategoryId IS NULL OR J.CategoryId = @CategoryId)
                ORDER BY J.CreatedAt DESC";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameter for CategoryId
                    if (hasCategory)
                    {
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CategoryId", DBNull.Value);
                    }

                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        GridViewJobs.DataSource = reader;
                        GridViewJobs.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Display error message (consider logging in production)
                        Response.Write("<script>alert('Error loading jobs: " + ex.Message + "');</script>");
                    }
                }
            }

            // Optionally, display a heading based on category
            if (hasCategory)
            {
                // Fetch the category name
                string categoryName = GetCategoryName(categoryId);
                if (!string.IsNullOrEmpty(categoryName))
                {
                    // Display the category name on the page
                    lblCategoryName.Text = $"Jobs in <strong>{categoryName}</strong>";
                }
                else
                {
                    lblCategoryName.Text = "Jobs in Selected Category";
                }
            }
            else
            {
                lblCategoryName.Text = "All Available Jobs";
            }
        }

        // Helper method to get Category Name
        private string GetCategoryName(string categoryId)
        {
            string categoryName = string.Empty;
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string query = "SELECT Name FROM Categories WHERE CategoryId = @CategoryId";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            categoryName = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (consider logging)
                        Response.Write("<script>alert('Error fetching category name: " + ex.Message + "');</script>");
                    }
                }
            }

            return categoryName;
        }
    }
}
