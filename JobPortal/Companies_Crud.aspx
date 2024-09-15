<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Companies_Crud.aspx.cs" Inherits="JobPortal.Companies_Crud" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Companies CRUD</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br /><br />
            
           
            <asp:HiddenField ID="hdnCompanyId" runat="server" />
           
      
           
            <asp:Label ID="lblName" runat="server" Text="Company Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br /><br />
            
           
            <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
            <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox><br /><br />
 
            <asp:Label ID="lblIndustry" runat="server" Text="Industry"></asp:Label>
            <asp:TextBox ID="txtIndustry" runat="server"></asp:TextBox><br /><br />

           
            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox><br /><br />
            
           
            <asp:Label ID="lblWebsite" runat="server" Text="Website"></asp:Label>
            <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox><br /><br />

            
            <asp:Label ID="lblLogoUrl" runat="server" Text="Logo URL"></asp:Label>
            <asp:TextBox ID="txtLogoUrl" runat="server"></asp:TextBox><br /><br />

            
            <asp:Button ID="btnAdd" runat="server" Text="Add Company" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Company" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Company" OnClick="btnDelete_Click" />
        </div>

        <br /><br />

        
        <asp:GridView ID="gvCompanies" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCompanies_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="CompanyId" HeaderText="Company ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:BoundField DataField="Industry" HeaderText="Industry" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Website" HeaderText="Website" />
                <asp:BoundField DataField="LogoUrl" HeaderText="Logo URL" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
