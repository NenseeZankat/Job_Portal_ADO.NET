<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="JobPortal.Register" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>User Registration Form</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #4cb3d4; /* Adjusted to match the blue in your image */
        }

        /* Navbar */
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

        .container {
            width: 50%;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: block;
            font-weight: bold;
        }
        input[type="text"], 
        input[type="email"], 
        input[type="password"], 
        input[type="tel"], 
        select {
            width: 100%;
            padding: 8px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            padding: 10px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <!-- Single form tag wrapping both navbar and registration form -->
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
                     <!-- Placeholder for login/logout links -->
                     <asp:PlaceHolder ID="LoginLogoutPlaceholder" runat="server">
                         <li class="nav-item"><a class="nav-link" href="/Login.aspx">Login</a></li>
                         <li class="nav-item"><a class="nav-link" href="/Register.aspx">Register</a></li>
                     </asp:PlaceHolder>
                 </ul>
             </div>
         </nav>

        <!-- Registration Form -->
        <div class="container">
            <h2>User Registration</h2>
            <div class="form-group">
                <label for="Username">Username</label>
                <asp:TextBox ID="Username" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Email">Email</label>
                <asp:TextBox ID="Email" runat="server" TextMode="Email" MaxLength="100" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Password">Password</label>
                <asp:TextBox ID="Password" runat="server" TextMode="Password" MaxLength="255" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Role">Role</label>
                <asp:DropDownList ID="Role" runat="server" CssClass="form-control">
                    <asp:ListItem Value="job_seeker" Text="Job Seeker"></asp:ListItem>
                    <asp:ListItem Value="employer" Text="Employer"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="FirstName">First Name</label>
                <asp:TextBox ID="FirstName" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="LastName">Last Name</label>
                <asp:TextBox ID="LastName" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Phone">Phone</label>
                <asp:TextBox ID="Phone" runat="server" TextMode="Number" MaxLength="20" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Location">Location</label>
                <asp:TextBox ID="Location" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" CssClass="btn btn-success" />
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
