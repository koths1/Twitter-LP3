<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Fafa10052018.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Twitter:Login</title>
    <link href="Resources/css/Bootstrap.css" rel="stylesheet" />
    <link href="Resources/css/Beauty.css" rel="stylesheet" />
</head>
<body style="background-image: url('Resources/img/862656.jpg'); background-size: cover;">
   <div class="py-5 text-center">
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" ForeColor="White" CssClass="align-content-center" Text="Bem vindo ao Twiteido" Font-Strikeout="False"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Nome:" ForeColor="White"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Senha:" ForeColor="White"></asp:Label>        
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" OnClick="Button1_Click" Text="Entrar" />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" CssClass="btn btn-info" runat="server" OnClick="Button2_Click" Text="Não tem uma conta? Cadastre-se!!!" />
    </form>
   </div>
    <!--Jquery-->
    <script src="Resources/js/jquery-3.3.1.min.js"></script>
    <!--Javascript do Bootstrap-->
    <script src="Resources/js/bootstrap.js"></script>
</body>
</html>
