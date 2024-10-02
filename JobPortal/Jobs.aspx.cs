
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
