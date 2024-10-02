<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobList.aspx.cs" Inherits="JobPortal.JobList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Job Listings</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Ensures full height layout for the entire page */
        html, body {
            height: 100%;
            margin: 0;
            display: flex;
            flex-direction: column;
        }

        /* Content container that expands to push footer down */
        .content {
            flex: 1; /* This allows the content to grow and push footer down */
            display: flex;
            flex-direction: column;
            justify-content: flex-start;
        }

        /* Footer styling */
        .footer {
            background-color: #0072ff;
            color: white;
            padding: 5px 0;
            text-align: center;
            margin: 35% 0;
        }

        /* Navbar styling */
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

        /* Job card styling */
        .job-card {
            border: 1px solid #ccc;
            padding: 20px;
            border-radius: 8px;
            margin: 15px 0;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }

        .job-card:hover {
            transform: translateY(-10px);
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark">
            <a class="navbar-brand" href="#">Job Portal</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item"><a class="nav-link" href="HomePage.aspx">Home</a></li>
                    <li class="nav-item"><a class="nav-link" href="Jobs.aspx">Jobs</a></li>
                    
                    <!-- Post Job PlaceHolder for Employer -->
                    <asp:PlaceHolder ID="postJobPlaceHolder" runat="server">
                        <li class="nav-item"><a class="nav-link" href="Jobs_Crud.aspx">Post Job</a></li>
                    </asp:PlaceHolder>
                    
                    <!-- Login/Logout PlaceHolder -->
                    <asp:PlaceHolder ID="LoginLogoutPlaceholder" runat="server">
                        <li class="nav-item"><a class="nav-link" href="/Login.aspx">Login</a></li>
                        <li class="nav-item"><a class="nav-link" href="/Register.aspx">Register</a></li>
                    </asp:PlaceHolder>
                </ul>
            </div>
        </nav>

        <!-- Content -->
        <div class="content">
            <div class="container mt-5">
                <h2>Jobs in <%: CategoryName %></h2>
                <asp:Repeater ID="JobRepeater" runat="server">
                    <ItemTemplate>
                        <div class="job-card">
                            <h4><%# Eval("Title") %></h4>
                            <p>Location: <%# Eval("Location") %></p>
                            <p>Company: <%# Eval("CompanyName") %></p>
                            <a href="ApplyJob.aspx?JobId=<%# Eval("JobId") %>" class="btn btn-primary">Apply</a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <!-- Footer -->
        <footer class="footer">
            <p>© 2024 Job Portal. All rights reserved.</p>
        </footer>

        <!-- Scripts -->
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
