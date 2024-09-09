<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Crud.aspx.cs" Inherits="JobPortal.UserCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gdvusers" runat="server"></asp:GridView>
            <br />
        </div>
        <div>
            <table id="tbluser">
                <tr>
                    <td> <asp:Label ID="lbusername" runat="server" Text="Username"/></td>
                    <td>
                        <asp:TextBox ID="tbusername" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbemail" runat="server" Text="Email"/></td>
                    <td><asp:TextBox ID="tbemail" runat="server" TextMode="Email"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbpassword" runat="server" Text="Password"></asp:Label></td>
                    <td><asp:TextBox ID="tbpassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbrole" runat="server" Text="Role"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlrole" runat="server">
                            <asp:ListItem Text="select type" Value="-1" />
                            <asp:ListItem Text="employer" Value="employer" />
                            <asp:ListItem Text="job_seeker" Value="job_seeker" />
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbfirstname" runat="server" Text="FirstName"/></td>
                    <td><asp:TextBox ID="tbfirstname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblastname" runat="server" Text="LastName"/></td>
                    <td><asp:TextBox ID="tblastname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbphone" runat="server" Text="Phone"/></td>
                    <td><asp:TextBox ID="tbphone" runat="server" TextMode="Phone"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblocation" runat="server" Text="Location"/></td>
                    <td><asp:TextBox ID="tblocation" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbresume" runat="server" Text="ResumeId"/></td>
                    <td>
                        <asp:TextBox ID="tbresume" runat="server" TextMode="Number"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbcreatedate" runat="server" Text="Create Date"/></td>
                    <td><asp:TextBox ID="tbcdatereate" runat="server" TextMode="Date"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbupdatedate" runat="server" Text="Update Date"/></td>
                    <td><asp:TextBox ID="tbupdatedate" runat="server" TextMode="Date"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Skill"/></td>
                    <td>
                        <asp:CheckBoxList ID="cbSkill" runat="server" DataSourceID="SkillData" DataTextField="Name" DataValueField="Name">
                        </asp:CheckBoxList>
                        <asp:SqlDataSource ID="SkillData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [Name], [SkillId] FROM [Skills]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
            
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnadd" runat="server" Text="Save" OnClick="btnadd_Click" />
            <br />
            <br />
&nbsp;&nbsp;
            <asp:Label ID="lbId" runat="server" Text="Id"></asp:Label>
&nbsp;
            <asp:TextBox ID="tbid" runat="server" TextMode="Number"/>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btupdate" runat="server" Text="Update" OnClick="btupdate_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
        </div>
    </form>
</body>
</html>
