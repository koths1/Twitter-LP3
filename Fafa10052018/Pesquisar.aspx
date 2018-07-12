<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pesquisar.aspx.cs" Inherits="Fafa10052018.Pesquisar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resources/css/Bootstrap.css" rel="stylesheet" />
    <link href="Resources/css/Beauty.css" rel="stylesheet" />
</head>
<body style="background-image: url('Resources/img/862632.jpg'); background-size: cover;">
    <form id="form1" runat="server">
    <div class="py-5 text-center">
        <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Pesquisar pessoas:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Pesquisar!!!" OnClick="Button1_Click" />
    </div>
    <div class="py-5 text-center">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" OnClick="Button2_Click" Text="Voltar" />
    </div>
    </form>
    <!--Jquery-->
    <script src="Resources/js/jquery-3.3.1.min.js"></script>
    <!--Javascript do Bootstrap-->
    <script src="Resources/js/bootstrap.js"></script>
</body>
</html>
