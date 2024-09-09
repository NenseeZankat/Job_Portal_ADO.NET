<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Skills_Crud.aspx.cs" Inherits="JobPortal.Skills_Crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 123px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GDVSkill" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        </div>
        <div>

            <br />

        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbName" runat="server" Text="Name "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbCategory" runat="server" Text="Category "></asp:Label>
                </td>
                <td id="tbCategory">
                    <asp:TextBox ID="tbCategory" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div>
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
