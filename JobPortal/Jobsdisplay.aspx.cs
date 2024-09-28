using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace JobPortal
{
    public partial class Jobsdisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJobs();
            }
        }

        // Load jobs from the database
        private void LoadJobs()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\Job portal ADO.NET\\JobPortal\\App_Data\\DBJobPortal.mdf\";Integrated Security=True";  // Replace with actual connection string
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Jobs";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvJobs.DataSource = dt;
                gvJobs.DataBind();
            }
        }

        // Handle the RowCommand event for applying to a job
        protected void gvJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ApplyJob")
            {
                // Retrieve the job ID from CommandArgument
                int jobId = Convert.ToInt32(e.CommandArgument);

                // Call the ApplyForJob method
                ApplyForJob(jobId);
            }
        }

        // Logic for applying to a job
        private void ApplyForJob(int jobId)
        {
            // Implement your application logic here, e.g., saving the application to the database
            Response.Write("<script>alert('You have successfully applied for Job ID: " + jobId + "');</script>");
        }
    }
}