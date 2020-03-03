<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication2.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello World</title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<h3>Form Login</h3>
        <asp:Label ID="lblUsername" Text="Username : " runat="server" />
        <asp:TextBox ID="txtUsername" runat="server" />

        <asp:Label ID="lblPassword" Text="Password : " runat="server" />
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />

        <asp:Button ID="btnLogin" OnClick="btnLogin_Click" Text="Login" runat="server" />

        <asp:Literal ID="ltrResult" runat="server" />--%>

        <asp:TextBox ID="num1" runat="server" />
        <asp:DropDownList ID="ddSize" runat="server" />
        <asp:TextBox ID="num2" runat="server" />

        <asp:Button ID="btnCount" OnClick="btnCount_Click" Text="Count" runat="server" />

        <asp:Label ID="lblResult" runat="server" />
    </form>
</body>
</html>
