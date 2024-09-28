
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
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string query = "SELECT JobId, Title, Location, JobType, SalaryMin, SalaryMax, Currency, Description FROM Jobs";

            using (con)
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridViewJobs.DataSource = reader;
                GridViewJobs.DataBind();
                con.Close();
            }
        }
    }
}
