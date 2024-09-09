using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JobPortal
{
    public partial class Companies_Crud : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

       
        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Companies", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();    
                    gvCompanies.DataSource = dt;
                    gvCompanies.DataBind();
                }
            }
        }

       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Companies (Name, Location, Industry, Description, Website, LogoUrl) VALUES (@Name, @Location, @Industry, @Description, @Website, @LogoUrl)", con))
                {
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                    cmd.Parameters.AddWithValue("@Industry", txtIndustry.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text);
                    cmd.Parameters.AddWithValue("@LogoUrl", txtLogoUrl.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close() ;
                    lblMessage.Text = "Company added successfully!";
                    BindGrid();
                    ClearForm();
                }
            }
        }

      
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (hdnCompanyId.Value != "")
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Companies SET Name = @Name, Location = @Location, Industry = @Industry, Description = @Description, Website = @Website, LogoUrl = @LogoUrl WHERE CompanyId = @CompanyId", con))
                    {
                        cmd.Parameters.AddWithValue("@CompanyId", hdnCompanyId.Value);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                        cmd.Parameters.AddWithValue("@Industry", txtIndustry.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@Website", txtWebsite.Text);
                        cmd.Parameters.AddWithValue("@LogoUrl", txtLogoUrl.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    
                        lblMessage.Text = "Company updated successfully!";
                        BindGrid();
                        ClearForm();
                    }
                }
            }
        }

       
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (hdnCompanyId.Value != "")
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Companies WHERE CompanyId = @CompanyId", con))
                    {
                        cmd.Parameters.AddWithValue("@CompanyId", hdnCompanyId.Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "Company deleted successfully!";
                        BindGrid();
                        ClearForm();
                    }
                }
            }
        }

       
        protected void gvCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCompanies.SelectedRow;
            hdnCompanyId.Value = row.Cells[0].Text;
            txtName.Text = row.Cells[1].Text;
            txtLocation.Text = row.Cells[2].Text;
            txtIndustry.Text = row.Cells[3].Text;
            txtDescription.Text = row.Cells[4].Text;
            txtWebsite.Text = row.Cells[5].Text;
            txtLogoUrl.Text = row.Cells[6].Text;
        }

        
        private void ClearForm()
        {
            hdnCompanyId.Value = "";
            txtName.Text = "";
            txtLocation.Text = "";
            txtIndustry.Text = "";
            txtDescription.Text = "";
            txtWebsite.Text = "";
            txtLogoUrl.Text = "";
        }
    }
}
