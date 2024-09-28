using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.Configuration;

namespace YourNamespace
{
    public partial class ApplyJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get JobId from URL query string
                string jobId = Request.QueryString["JobId"];
                //lblJobId.Text = "Job ID: " + jobId;

                // Get UserId from session
                int userId = Convert.ToInt32(Session["UserId"]);
                //lblUserId.Text = "User ID: " + userId;
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (fileResume.HasFile && Path.GetExtension(fileResume.FileName).ToLower() == ".pdf")
            {
                try
                {
                    // Save the resume to the server temporarily for preview
                    int userId = Convert.ToInt32(Session["UserId"]);
                    string resumeUrl = SaveResumeForPreview(userId);

                    // Display the uploaded resume's link
                    hlViewResume.NavigateUrl = resumeUrl;
                    hlViewResume.Visible = true;
                    lblMessage.Text = "Resume preview is ready.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error during preview: " + ex.Message;
                }
            }
            else
            {
                lblMessage.Text = "Please upload a PDF resume for preview.";
            }
        }

        // Save uploaded resume file to server for preview and return file path
        private string SaveResumeForPreview(int userId)
        {
            string folderPath = Server.MapPath("~/Resumes/");
            string fileName = $"{userId}_preview_{Path.GetFileName(fileResume.PostedFile.FileName)}";
            string filePath = folderPath + fileName;

            // Ensure directory exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Save file to server
            fileResume.SaveAs(filePath);

            return ResolveUrl("~/Resumes/" + fileName); // Return relative path for hyperlink
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (fileResume.HasFile && Path.GetExtension(fileResume.FileName).ToLower() == ".pdf")
            {
                try
                {
                    // Save Resume to server permanently
                    int userId = Convert.ToInt32(Session["UserId"]);
                    string resumeUrl = SaveResumeToServer(userId);

                    // Add resume entry to Resumes table
                    int resumeId = AddResumeToDatabase(userId, resumeUrl);

                    // Add application entry to Applications table
                    AddApplicationToDatabase(resumeId);

                    lblMessage.Text = "Application submitted successfully!";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblMessage.Text = "Please upload a PDF resume.";
            }
        }

        // Save uploaded resume file to server permanently and return file path
        private string SaveResumeToServer(int userId)
        {
            string folderPath = Server.MapPath("~/Resumes/");
            string fileName = $"{userId}_{Path.GetFileName(fileResume.PostedFile.FileName)}";
            string filePath = folderPath + fileName;

            // Ensure directory exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Save file to server
            fileResume.SaveAs(filePath);

            return ResolveUrl("~/Resumes/" + fileName); // Return relative path for permanent saving
        }

        // Add resume to Resumes table and return ResumeId
        private int AddResumeToDatabase(int userId, string resumeUrl)
        {
            string connString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO Resumes (UserId, ResumeUrl, CreatedAt, UpdatedAt) " +
                               "OUTPUT INSERTED.ResumeId " +
                               "VALUES (@UserId, @ResumeUrl, GETDATE(), GETDATE())";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ResumeUrl", resumeUrl);
                    return (int)cmd.ExecuteScalar(); // Get ResumeId of newly inserted row
                }
            }
        }

        // Add application to Applications table
        private void AddApplicationToDatabase(int resumeId)
        {
            string connString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                int jobId = Convert.ToInt32(Request.QueryString["JobId"]);
                int userId = Convert.ToInt32(Session["UserId"]);
                string coverLetter = "";

                string query = "INSERT INTO Applications (JobId, UserId, ResumeId, CoverLetter, Status, AppliedAt, UpdatedAt) " +
                               "VALUES (@JobId, @UserId, @ResumeId, @CoverLetter, 'applied', GETDATE(), GETDATE())";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JobId", jobId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ResumeId", resumeId);
                    cmd.Parameters.AddWithValue("@CoverLetter", coverLetter);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
