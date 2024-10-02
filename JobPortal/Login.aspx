<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JobPortal.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login - Job Portal</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #4cb3d4;
        }

        .login-container {
            margin-top: 100px;
        }

        .login-box {
            background-color: white;
            padding: 30px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        .btn-login {
            background-color: #0072ff;
            color: white;
            font-weight: bold;
            border-radius: 20px;
            padding: 10px 20px;
            width: 100%;
        }

        .btn-login:hover {
            background-color: #0056d2;
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

        <div class="container login-container">
            <div class="row justify-content-center">
                <div class="col-md-4">
                    <div class="login-box">
                        <h3 class="text-center">Login</h3>
                        <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        <div class="form-group">
                            <asp:Label ID="UsernameLabel" runat="server" Text="Username" AssociatedControlID="Username"></asp:Label>
                            <asp:TextBox ID="Username" runat="server" CssClass="form-control" placeholder="Enter your username"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="PasswordLabel" runat="server" Text="Password" AssociatedControlID="Password"></asp:Label>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your password"></asp:TextBox>
                        </div>
                        <div class="form-group text-center">
                            <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-login" Text="Login" OnClick="LoginButton_Click" />
                        </div>
                        <div class="text-center">
                            <p>Don't have an account? <a href="Register.aspx">Register here</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
