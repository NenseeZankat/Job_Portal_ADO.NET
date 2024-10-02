<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="JobPortal.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Job Portal</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f5f5f5;
        }

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

        .hero-section {
            background: linear-gradient(135deg, #6dd5ed, #2193b0);
            height: 500px;
            color: white;
            text-align: center;
            padding: 150px 0;
            box-shadow: inset 0 0 150px rgba(0, 0, 0, 0.2);
        }

        .hero-section h1 {
            font-size: 48px;
            font-weight: bold;
            margin-bottom: 20px;
            letter-spacing: 2px;
        }

        .hero-section p {
            font-size: 18px;
        }

        .search-bar {
            margin-top: 30px;
        }

        .search-bar input, .search-bar button {
            height: 55px;
            border-radius: 0;
            border: none;
        }

        .search-bar button {
            background-color: #0072ff;
            color: white;
            font-weight: bold;
        }

        .search-bar input:focus {
            box-shadow: 0 0 10px rgba(0, 114, 255, 0.5);
        }

        .job-categories, .featured-jobs {
            padding: 60px 0;
        }

        .job-categories h2 {
            margin-bottom: 30px;
            font-weight: bold;
        }

        .job-categories .card {
            border: none;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }

        .job-categories .card:hover {
            transform: translateY(-10px);
        }

        .job-categories .card-body {
            background: linear-gradient(135deg, #f093fb, #f5576c);
            color: white;
            padding: 30px 20px;
            text-align: center;
            border-radius: 8px;
        }

        .featured-jobs h2 {
            font-weight: bold;
            margin-bottom: 30px;
        }

        .featured-jobs .card {
            border: none;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }

        .featured-jobs .card:hover {
            transform: translateY(-10px);
        }

        .featured-jobs .card-body {
            padding: 25px;
            border-radius: 8px;
            background: white;
        }

        .featured-jobs .btn {
            background-color: #0072ff;
            color: white;
            font-weight: bold;
            border-radius: 20px;
            padding: 10px 20px;
        }

        .footer {
            background-color: #0072ff;
            color: white;
            padding: 20px 0;
            text-align: center;
            margin-top: 40px;
        }

        .footer p {
            margin: 0;
            font-weight: bold;
            letter-spacing: 1px;
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

        <!-- Hero Section -->
        <div class="hero-section">
            <h1>Find Your Perfect Job</h1>
            <p>Discover thousands of job opportunities from top companies.</p>
            
            <div class="container search-bar">
                <div class="row justify-content-center">
                    <div class="col-md-8">
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="Job Title, Keywords or Company" />
                            <input type="text" class="form-control" placeholder="Location" />
                            <div class="input-group-append">
                                <button class="btn" type="button">Search Jobs</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Job Categories -->
        <div class="container job-categories">
            <h2 class="text-center">Job Categories</h2>
            <div class="row text-center">
                <asp:Repeater ID="CategoryRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3">
                            <a href="JobList.aspx?CategoryId=<%# Eval("CategoryId") %>" style="text-decoration: none;">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("CategoryName") %></h5>
                                        <p class="card-text"><%# Eval("JobCount") %>+ Jobs</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>


        <!-- Featured Jobs -->
        <div class="container featured-jobs">
            <h2 class="text-center">Featured Jobs</h2>
            <div class="row">
                <asp:Repeater ID="FeaturedJobsRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Title") %></h5>
                                    <p class="card-text"><%# Eval("CompanyName") %> - <%# Eval("Location") %></p>
                                    <a href="ApplyJob.aspx?JobId=<%# Eval("JobId") %>" class="btn">Apply</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <!-- Footer -->
        <footer class="footer">
            <p>© 2024 Job Portal. All rights reserved.</p>
        </footer>

        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
