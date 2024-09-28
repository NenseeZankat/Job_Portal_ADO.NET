<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jobsdisplay.aspx.cs" Inherits="JobPortal.Jobsdisplay" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Job Listings</title>
    <style>
        .jobs-table {
            width: 100%;
            border-collapse: collapse;
        }
        .jobs-table th, .jobs-table td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }
        .jobs-table th {
            background-color: #4CAF50;
            color: white;
        }
        .jobs-table tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        .jobs-table tr:hover {
            background-color: #ddd;
        }
        .apply-btn {
            background-color: #4CAF50;
            color: white;
            padding: 5px 10px;
            border: none;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Available Jobs</h2>
            <asp:GridView ID="gvJobs" runat="server" AutoGenerateColumns="False" CssClass="jobs-table" 
                DataKeyNames="JobId">
                <Columns>
                    <asp:BoundField DataField="JobId" HeaderText="Job ID" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Job Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="CompanyId" HeaderText="Company" />
                    <asp:BoundField DataField="JobType" HeaderText="Job Type" />
                    <asp:BoundField DataField="SalaryMin" HeaderText="Salary Min" />
                    <asp:BoundField DataField="SalaryMax" HeaderText="Salary Max" />
                    <asp:BoundField DataField="Currency" HeaderText="Currency" />
                    <asp:BoundField DataField="PostedBy" HeaderText="Posted By" />
                    
                    <asp:TemplateField HeaderText="Apply">
                        <ItemTemplate>
                            <asp:Button ID="btnApply" runat="server" CommandName="ApplyJob" CommandArgument='<%# Eval("JobId") %>' Text="Apply" CssClass="apply-btn" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>