using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal
{
    public partial class JobList : System.Web.UI.Page
    {
        protected string CategoryName;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in or not
            if (Session["Role"] != null)
            {
                string role = Session["Role"].ToString();

                if (role == "job_seeker")
                {
                    // If the user is a job seeker, do not show the 'Post Job' link
                    postJobPlaceHolder.Visible = false;
                }
                else if (role == "employer")
                {
                    // If the user is an employer, show the 'Post Job' link
                    postJobPlaceHolder.Visible = true;
                }

                // Modify Login/Logout PlaceHolder for logged-in users
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/Logout.aspx'>Logout</a></li>"
                ));
            }
            else
            {
                // User is not logged in, show Login and Register links
                LoginLogoutPlaceholder.Controls.Clear();
                LoginLogoutPlaceholder.Controls.Add(new LiteralControl(
                    "<li class='nav-item'><a class='nav-link' href='/Login.aspx'>Login</a></li>" +
                    "<li class='nav-item'><a class='nav-link' href='/Register.aspx'>Register</a></li>"
                ));

                // Hide the post job link since no user is logged in
                postJobPlaceHolder.Visible = false;
            }

            // Load Jobs by category logic
            LoadJobsByCategory();
        }

        private void LoadJobsByCategory()
        {
            // Assuming CategoryID is passed via query string
            string categoryId = Request.QueryString["CategoryId"];
            CategoryName = "Technology"; // Just a placeholder value for the sake of example

            // Bind job listings to the repeater
            JobRepeater.DataSource = GetJobsByCategoryId(categoryId);
            JobRepeater.DataBind();
        }

        private DataTable GetJobsByCategoryId(string categoryId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Location");
            dt.Columns.Add("CompanyName");
            dt.Columns.Add("JobId");

            // Example job listings
            dt.Rows.Add("Software Engineer", "New York", "Tech Corp", "1");
            dt.Rows.Add("Web Developer", "San Francisco", "WebWorks", "2");

            return dt;
        }
    }
}
