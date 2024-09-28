<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyJob.aspx.cs" Inherits="YourNamespace.ApplyJob" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Apply for Job</title>
<style>   /* General Body Styling */
body {
    font-family: Arial, sans-serif;
    background-color: #f1f1f1;
    margin: 0;
    padding: 0;
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
}

/* Form Container */
.form-container {
    background-color: #fff;
    padding: 30px;
    border-radius: 10px;
    box-shadow: 0 8px 16px rgba(0, 0, 0, 0.1);
    width: 400px;
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
    </style> 
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
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
</body>
</html>
