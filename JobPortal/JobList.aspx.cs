using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace JobPortal
{
    public partial class JobList : System.Web.UI.Page
    {
        protected string CategoryName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Make sure you get CategoryId from the query string
                int categoryId;
                if (int.TryParse(Request.QueryString["CategoryId"], out categoryId))
                {
                    // Load jobs by category
                    LoadJobsByCategory(categoryId);
                }
            }
        }

        private void LoadJobsByCategory(int categoryId)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT JobId, Title, Location,
                                    	(SELECT Name FROM Companies WHERE CompanyId = Jobs.CompanyId) AS CompanyName
                             	FROM Jobs
                             	WHERE CategoryId = @CategoryId";  // Make sure to filter by CategoryId

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Check if any job is returned and bind it to the Repeater
                if (dt.Rows.Count > 0)
                {
                    JobRepeater.DataSource = dt;
                    JobRepeater.DataBind();
                }

                // Optionally, you can set the category name if needed
                // Retrieve category name if required
                string categoryQuery = @"SELECT Name FROM Categories WHERE CategoryId = @CategoryId";
                SqlCommand categoryCmd = new SqlCommand(categoryQuery, conn);
                categoryCmd.Parameters.AddWithValue("@CategoryId", categoryId);
                conn.Open();
                CategoryName = (string)categoryCmd.ExecuteScalar();
                conn.Close();
            }
        }
    }
}

