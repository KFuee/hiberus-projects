<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="CalculatorWeb.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Calculator</title>

    <style>
        .container {
            max-width: 400px;
            box-shadow: 0px 0px 43px 17px rgba(153,153,153,1);
        }

        #display {
            display: flex;
            flex-direction: column;
            text-align: right;
            height: 70px;
            line-height: 70px;
            padding: 16px 8px;
            font-size: 25px;
        }

        .buttons {
            display: grid;
            border-bottom: 1px solid #999;
            border-left: 1px solid#999;
            grid-template-columns: 1fr 1fr 1fr 1fr;
        }

        .button {
            border: 0.5px solid #999;
            line-height: 100px;
            text-align: center;
            font-size: 25px;
            cursor: pointer;
        }

        .button:hover {
            background-color: #323330;
            color: white;
            transition: 0.5s ease-in-out;
        }

        .equal {
            background-color: rgb(85, 85, 255);
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div id="display">
                <asp:TextBox ID="operation" runat="server" Height="35px" />
                <asp:TextBox ID="result" runat="server" Height="40px" />
            </div>

            <div class="buttons">
                <asp:Button ID="Button1" runat="server" Text="MR" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button2" runat="server" Text="M" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button3" runat="server" Text="C" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button4" runat="server" Text="*" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button5" runat="server" Text="7" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button6" runat="server" Text="8" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button7" runat="server" Text="9" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button8" runat="server" Text="/" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button9" runat="server" Text="4" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button10" runat="server" Text="5" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button11" runat="server" Text="6" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button12" runat="server" Text="-" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button13" runat="server" Text="1" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button14" runat="server" Text="2" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button15" runat="server" Text="3" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button16" runat="server" Text="+" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button17" runat="server" Text="±" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button18" runat="server" Text="0" CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button19" runat="server" Text="." CssClass="button" OnClick="buttonClick" />
                <asp:Button ID="Button20" runat="server" Text="=" CssClass="button equal" OnClick="buttonClick" />
            </div>
        </div>
    </form>
</body>
</html>
