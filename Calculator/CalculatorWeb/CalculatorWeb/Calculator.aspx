<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="CalculatorWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Calculadora</title>
    <style>
        form {
            width: 450px;
            height: 450px;
        }
    </style>

    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="textBoxesContainer">
            <asp:TextBox ID="TextBox1" runat="server" Width="100%" Height="45%"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" Width="100%" Height="55%"></asp:TextBox>
        </div>
    </form>

    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
</body>
</html>
