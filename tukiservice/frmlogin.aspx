<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmlogin.aspx.cs" Inherits="tukiservice.frmlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        #form1 {
            max-width: 400px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 8px;
            color: #333;
        }

        .form-group input {
            width: 100%;
            padding: 10px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        #btnLogin {
            background-color: #4caf50;
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        #btnLogin:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            <label for="txtUsuario">Username:</label>
            <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtPassword">Password:</label>
            <asp:TextBox runat="server" ID="txtPassword"  CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
        </div>
    </form>
</body>
</html>
