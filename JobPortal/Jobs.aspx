<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="JobPortal.Jobs" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Job Listings</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            min-height: 100vh;
            margin: 0;
        }

        form {
            width: 100%;
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
            border: none;
            box-shadow: none;
        }

        .job-listing {
            width: 100%;
/*            border-spacing: 20px;*/
        }

        .job-card {
/*            border: 1px solid #e0e0e0;*/
/*            border-radius: 10px;*/
            padding: 20px;
            margin: 20px;
            background-color: #ffffff;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
            text-align: left;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
        }

        .job-card:hover {
            transform: translateY(-10px);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
        }

        .job-card h2 {
            color: #333;
            font-size: 1.5rem;
            margin-bottom: 10px;
        }

        .job-card p {
            color: #666;
            margin: 5px 0;
            font-size: 1rem;
        }

        .apply-btn {
            display: inline-block;
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            text-decoration: none;
/*            border-radius: 5px;*/
            transition: background-color 0.3s ease;
            align-self: flex-start;
            margin-top: 20px;
        }

        .apply-btn:hover {
            background-color: #0056b3;
        }

        .job-info {
            display: flex;
            justify-content: space-between;
        }

        .job-info p {
            margin-right: 20px;
        }

        @media (max-width: 768px) {
            .job-card {
                padding: 15px;
            }

            .apply-btn {
                width: 100%;
                text-align: center;
            }

            .job-info {
                flex-direction: column;
                align-items: flex-start;
            }
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
                    <li class="nav-item"><a class="nav-link" href="Jobs_Crud.aspx">Post Job</a></li>
                    <asp:PlaceHolder ID="LoginLogoutPlaceholder" runat="server">
                        <li class="nav-item"><a class="nav-link" href="/Login.aspx">Login</a></li>
                        <li class="nav-item"><a class="nav-link" href="/Register.aspx">Register</a></li>
                    </asp:PlaceHolder>
                </ul>
            </div>
        </nav>

        <!-- Job Listings -->
        <asp:GridView ID="GridViewJobs" runat="server" AutoGenerateColumns="False" CssClass="job-listing">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="job-card">
                            <h2><%# Eval("Title") %></h2>
                            <div class="job-info">
                                <p><strong>Location:</strong> <%# Eval("Location") %></p>
                                <p><strong>Job Type:</strong> <%# Eval("JobType") %></p>
                                <p><strong>Salary:</strong> <%# Eval("SalaryMin") %> - <%# Eval("SalaryMax") %> <%# Eval("Currency") %></p>
                            </div>
                            <p><strong>Description:</strong> <%# Eval("Description") %></p>
                            <a href="ApplyJob.aspx?jobId=<%# Eval("JobId") %>" class="apply-btn">Apply</a>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
