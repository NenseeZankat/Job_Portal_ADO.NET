<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jobs_Crud.aspx.cs" Inherits="JobPortal.Jobs_Crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Jobs CRUD</title>
    <!-- Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Existing body styles */
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding-top: 70px; /* Adjusted for navbar height */
        }

        /* Navbar styles from HomePage.aspx */
        .navbar {
            background: linear-gradient(45deg, #0072ff, #00c6ff);
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }

        .navbar-brand {
            color: white !important;
            font-weight: bold;
            letter-spacing: 1px;
        }

        .navbar-nav a {
            color: white !important;
        }

        /* Adjusted form styles */
        .scrollable-form {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.1);
            max-width: 1000px;
            margin: 20px auto;
        }

        h2 {
            color: #4A3C8C;
            text-align: center;
            margin-bottom: 20px;
        }

        label {
            font-weight: bold;
            color: #333;
            margin-bottom: 5px;
            display: block;
        }

        input[type="text"], select, textarea {
            display: block;
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
            font-size: 16px;
            transition: border-color 0.3s;
            margin-bottom: 15px;
            box-sizing: border-box;
        }

        input[type="text"]:hover, select:hover, textarea:hover {
            border-color: #4A3C8C;
        }

        input[type="text"]:focus, select:focus, textarea:focus {
            border-color: #4A3C8C;
            outline: none;
        }

        .btn {
            padding: 10px 20px;
            background-color: #4A3C8C;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s;
            width: 50%;
            margin-bottom: 10px;
        }

        .btn:hover {
            background-color: #3e3277;
        }

        .grid-container {
            margin-top: 20px;
            max-height: 300px;
            overflow-y: auto;
            border: 1px solid #ddd;
            border-radius: 5px;
            width: 100%;
        }

        .grid-container th, .grid-container td {
            text-align: left;
            padding: 10px;
        }

        .grid-container tr:hover {
            background-color: #e7e7ff;
        }

        .grid-container th {
            background-color: #4A3C8C;
            color: white;
        }

        .grid-container {
            margin-bottom: 20px;
            border-collapse: collapse;
            width: 100%;
        }

        .grid-container th, .grid-container td {
            border-bottom: 1px solid #ddd;
        }

        .label-error {
            color: red;
            text-align: center;
        }

        /* Additional styles to ensure compatibility */
        .container {
            max-width: 1200px;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
            <a class="navbar-brand" href="#">Job Portal</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavCrud" aria-controls="navbarNavCrud" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavCrud">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item"><a class="nav-link" href="HomePage.aspx">Home</a></li>
                    <li class="nav-item"><a class="nav-link" href="Jobs.aspx">Jobs</a></li>
                    <li class="nav-item active"><a class="nav-link" href="Jobs_Crud.aspx">Post Job</a></li>
                    <asp:PlaceHolder ID="LoginLogoutPlaceholder" runat="server">
                        <li class="nav-item"><a class="nav-link" href="/Login.aspx">Login</a></li>
                        <li class="nav-item"><a class="nav-link" href="/Register.aspx">Register</a></li>
                    </asp:PlaceHolder>
                </ul>
            </div>
        </nav>

        <!-- Main Content -->
        <div class="container">
            <div class="scrollable-form">
                <h2>Jobs CRUD Operations</h2>

                <asp:HiddenField ID="hfJobId" runat="server" />

                <label for="tbTitle">Job Title:</label>
                <asp:TextBox ID="tbTitle" runat="server" CssClass="form-control"></asp:TextBox>

                <label for="tbDescription">Description:</label>
                <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>

                <label for="tbLocation">Location:</label>
                <asp:TextBox ID="tbLocation" runat="server" CssClass="form-control"></asp:TextBox>

                <label for="ddlCompanyId">Company:</label>
                <asp:DropDownList
                    ID="ddlCompanyId"
                    runat="server"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlCompanyId_SelectedIndexChanged"
                    CssClass="form-control">
                </asp:DropDownList>

                <label for="ddlJobType">Job Type:</label>
                <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control">
                    <asp:ListItem Value="full-time">Full-Time</asp:ListItem>
                    <asp:ListItem Value="part-time">Part-Time</asp:ListItem>
                    <asp:ListItem Value="contract">Contract</asp:ListItem>
                </asp:DropDownList>

                <label for="tbSalaryMin">Salary Min:</label>
                <asp:TextBox ID="tbSalaryMin" runat="server" CssClass="form-control"></asp:TextBox>

                <label for="tbSalaryMax">Salary Max:</label>
                <asp:TextBox ID="tbSalaryMax" runat="server" CssClass="form-control"></asp:TextBox>

                <label for="tbCurrency">Currency:</label>
                <asp:TextBox ID="tbCurrency" runat="server" CssClass="form-control"></asp:TextBox>

                <label for="ddlPostedBy">Posted By (User):</label>
                <asp:DropDownList ID="ddlPostedBy" runat="server" CssClass="form-control"></asp:DropDownList>

                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />

                <div class="grid-container">
                    <asp:GridView
                        ID="gvJobs"
                        runat="server"
                        AutoGenerateColumns="False"
                        OnSelectedIndexChanged="gvJobs_SelectedIndexChanged"
                        DataKeyNames="JobId"
                        CssClass="table table-bordered">
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
                </div>

                <asp:Label ID="lblMessage" runat="server" CssClass="label-error"></asp:Label>
            </div>
        </div>

        <!-- Optional JavaScript -->
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
