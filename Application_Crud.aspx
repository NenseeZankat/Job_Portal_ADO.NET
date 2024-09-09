<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Application_Crud.aspx.cs" Inherits="JobPortal.Application_Crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            width: 179px;
        }
        .auto-style4 {
            height: 26px;
            width: 179px;
        }
        .auto-style5 {
            margin-left: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GDVApplication" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <br />
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lbJobid" runat="server" Text="JobId "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlJobId" runat="server" DataSourceID="JobData" DataTextField="Title" DataValueField="JobId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="JobData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [JobId], [Title] FROM [Jobs]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lbUserId" runat="server" Text="UserId"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlUserId" runat="server" DataSourceID="UserDate" DataTextField="Username" DataValueField="UserId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="UserDate" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [UserId], [Username] FROM [Users]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lbCoverLetter" runat="server" Text="Cover Letter "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbCoverLetter" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lbStatus" runat="server" Text="Status "></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbStatus" runat="server">applied</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lbAppliedAt" runat="server" Text="Applied At"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbAppliedAt" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lbUpdateAt" runat="server" Text="Update At"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbUpdateAt" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <br />
                    <br />
                    <asp:Button ID="btSave" runat="server" OnClick="btSave_Click" Text="Save" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lbId" runat="server" Text="                       Id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbId" runat="server" TextMode="Number"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btDelete" runat="server" OnClick="btDelete_Click" Text="Delete" />
                </td>
            </tr>
        </table>
    <p class="auto-style5">
        &nbsp;</p>
    </form>
    </body>
</html>
