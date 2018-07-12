<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Fafa10052018.Perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resources/css/Bootstrap.css" rel="stylesheet" />
    <link href="Resources/css/Beauty.css" rel="stylesheet" />
</head>
<body style="background-image: url('Resources/img/12886.jpg'); background-size: cover;">
    <form id="form1" runat="server">
    <div class="py-5 text-center" style="color:white">
        

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        

        <br />
        <asp:Image ID="Image1" runat="server" Height="80px" Width="120px" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-info" Text="Botón" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tweets:"></asp:Label>
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" OnClick="Button2_Click" Text="Voltar a pesquisa" />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" CssClass="btn btn-danger" OnClick="Button3_Click" Text="Voltar a tela inicial" />
        <br />
    </div>
    </form>
    <!--Jquery-->
    <script src="Resources/js/jquery-3.3.1.min.js"></script>
    <!--Javascript do Bootstrap-->
    <script src="Resources/js/bootstrap.js"></script>
</body>
</html>
