<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job_skills_Crud.aspx.cs" Inherits="JobPortal.Job_skills_Crud" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Job Skills Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />

            <asp:GridView ID="gvJobSkills" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvJobSkills_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="JobId" HeaderText="Job ID" />
                    <asp:BoundField DataField="SkillId" HeaderText="Skill ID" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblJobId" runat="server" Text="Job ID:" />
            <asp:TextBox ID="tbJobId" runat="server" />
            <br />
            <asp:Label ID="lblSkillId" runat="server" Text="Skill ID:" />
            <asp:TextBox ID="tbSkillId" runat="server" />
            <br />

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
    </form>
</body>
</html>
