<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resumes.aspx.cs" Inherits="JobPortal.Resumes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resumes Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />

            <asp:HiddenField ID="hfResumeId" runat="server" />

            User ID: <asp:TextBox ID="tbUserId" runat="server" /><br />
            Resume URL: <asp:TextBox ID="tbResumeUrl" runat="server" /><br />

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /><br />

            <asp:GridView ID="gvResumes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvResumes_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ResumeId" HeaderText="Resume ID" ReadOnly="True" />
                    <asp:BoundField DataField="UserId" HeaderText="User ID" />
                    <asp:BoundField DataField="ResumeUrl" HeaderText="Resume URL" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
