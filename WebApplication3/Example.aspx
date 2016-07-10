<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example.aspx.cs" Inherits="WebApplication3.Example" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #Button1 {
            margin: 10px 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>(請勿輸入整數以外的字元，避免程式爆炸)
            <br />
            <asp:Button ID="Button1" runat="server" Text="請按我" OnClick="Button1_Click" />
            <br />
            顯示訊息：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>