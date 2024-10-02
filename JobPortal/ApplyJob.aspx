<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyJob.aspx.cs" Inherits="YourNamespace.ApplyJob" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Apply for Job</title>
    <!-- Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    
    <style>
        /* General Body Styling */
        body {
            font-family: Arial, sans-serif;
            background-color: #f1f1f1;
            margin: 0;
            padding: 0;
        }

        /* Form Container */
        .form-container {
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.1);
            width: 400px;
            margin: 50px auto;
            text-align: center;
        }

        /* Form Header */
        h2 {
            font-size: 24px;
            margin-bottom: 20px;
            color: #333;
            text-transform: uppercase;
            letter-spacing: 2px;
        }

        /* Form Group */
        .form-group {
            margin-bottom: 20px;
            text-align: left;
        }

        /* Labels */
        label {
            font-size: 14px;
            font-weight: bold;
            color: #555;
        }

        /* File Input */
        input[type="file"] {
            font-size: 14px;
            margin: 10px 0;
        }

        /* Button Styling */
        .button {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 12px 24px;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: all 0.3s ease;
            margin: 15px 0;
        }

        /* Medium Button Size */
        .medium {
            font-size: 16px;
            padding: 10px 24px;
        }

        /* Button Hover Effect */
        .button:hover {
            background-color: #45a049;
            transform: scale(1.05);
        }

        /* Hyperlink for Resume Preview */
        .preview-link {
            display: inline-block;
            margin: 20px 0;
            color: #4CAF50;
            text-decoration: none;
            font-weight: bold;
        }

        .preview-link:hover {
            text-decoration: underline;
        }

        /* Error Message */
        .error-message {
            color: red;
            font-size: 14px;
        }

        /* Navbar Custom Styling */
        .navbar {
            background: linear-gradient(45deg, #0072ff, #00c6ff);
        }

        .navbar-brand {
            color: white !important;
            font-weight: bold;
            letter-spacing: 1px;
        }

        .navbar-nav a {
            color: white !important;
            font-size: 16px;
            font-weight: bold;
        }

        .navbar-toggler {
            border-color: white;
        }

        .navbar-toggler-icon {
            background-image: url("data:image/svg+xml;charset=utf8,%3Csvg viewBox='0 0 30 30' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath stroke='rgba%28255, 255, 255, 0.5%29' stroke-width='2' stroke-linecap='round' stroke-miterlimit='10' d='M4 7h22M4 15h22M4 23h22'/%3E%3C/svg%3E");
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">

        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark">
            <a class="navbar-brand" href="#">Job Portal</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="HomePage.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Jobs.aspx">Jobs</a>
                    </li>
                    <li class="nav-item">
                    <asp:PlaceHolder ID="postJobPlaceHolder" runat="server">
                        <li class="nav-item"><a class="nav-link" href="Jobs_Crud.aspx">Post Job</a></li>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="LoginLogoutPlaceholder" runat="server">
                        <li class="nav-item"><a class="nav-link" href="/Login.aspx">Login</a></li>
                        <li class="nav-item"><a class="nav-link" href="/Register.aspx">Register</a></li>
                    </asp:PlaceHolder>
                </ul>
            </div>
        </nav>

        <!-- Job Application Form -->
        <div class="form-container">
            <h2>Apply for Job</h2>

            <!-- Hidden JobId and UserId fields -->
            <asp:HiddenField ID="hiddenJobId" runat="server" />
            <asp:HiddenField ID="hiddenUserId" runat="server" />

            <!-- Resume Upload Section -->
            <div class="form-group">
                <asp:Label ID="lblResume" runat="server" Text="Upload Resume:"></asp:Label><br />
                <asp:FileUpload ID="fileResume" runat="server" /><br />
            </div>

            <!-- Preview Button -->
            <asp:Button ID="btnPreview" runat="server" CssClass="button medium" Text="Preview Resume" OnClick="btnPreview_Click" /><br />

            <!-- Hyperlink to open the PDF -->
            <asp:HyperLink ID="hlViewResume" runat="server" CssClass="preview-link" Text="View Uploaded Resume" Target="_blank" Visible="false"></asp:HyperLink><br />

            <!-- Submit Button -->
            <asp:Button ID="btnSubmit" runat="server" CssClass="button medium" Text="Submit Application" OnClick="btnSubmit_Click" /><br />

            <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>

    </form>

    <!-- Bootstrap JS and dependencies -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
