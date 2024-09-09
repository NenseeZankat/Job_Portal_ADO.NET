<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jobs_Crud.aspx.cs" Inherits="JobPortal.Jobs_Crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jobs CRUD</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Jobs CRUD Operations</h2>

           
            <asp:HiddenField ID="hfJobId" runat="server" />
 
            Job Title: 
            <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox><br /><br />

           
            Description: 
            <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox><br /><br />

           
            Location: 
            <asp:TextBox ID="tbLocation" runat="server"></asp:TextBox><br /><br />

            Company: 
            <asp:DropDownList 
                ID="ddlCompanyId" 
                runat="server" 
                AutoPostBack="true" 
                OnSelectedIndexChanged="ddlCompanyId_SelectedIndexChanged">
            </asp:DropDownList><br /><br />

            
            Job Type: 
            <asp:DropDownList ID="ddlJobType" runat="server">
                <asp:ListItem Value="full-time">Full-Time</asp:ListItem>
                <asp:ListItem Value="part-time">Part-Time</asp:ListItem>
                <asp:ListItem Value="contract">Contract</asp:ListItem>
            </asp:DropDownList><br /><br />

            
            Salary Min: 
            <asp:TextBox ID="tbSalaryMin" runat="server"></asp:TextBox><br /><br />

            
            Salary Max: 
            <asp:TextBox ID="tbSalaryMax" runat="server"></asp:TextBox><br /><br />

           
            Currency: 
            <asp:TextBox ID="tbCurrency" runat="server"></asp:TextBox><br /><br />

          
            Posted By (User): 
            <asp:DropDownList ID="ddlPostedBy" runat="server"></asp:DropDownList><br /><br />

           
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /><br /><br />

           
            <asp:GridView 
                ID="gvJobs" 
                runat="server" 
                AutoGenerateColumns="False" 
                OnSelectedIndexChanged="gvJobs_SelectedIndexChanged"
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
                    <asp:CommandField ShowSelectButton="True" HeaderText="Select" />
                </Columns>
            </asp:GridView>

            
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
