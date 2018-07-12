<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Fafa10052018.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resources/css/Bootstrap.css" rel="stylesheet" />
    <link href="Resources/css/Beauty.css" rel="stylesheet" />
</head>
<body style="background-image: url('Resources/img/862661.jpg'); background-size: cover;">
   <form id="form1" runat="server">
    <div class="py-5 text-center">
    
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Cadastro"></asp:Label>
        <br />
        <br />
        <br />
    
        <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Nome:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Senha:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Confirmar senha:"></asp:Label>        
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Foto:"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
       <br />
        <br />
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" OnClick="Button1_Click" Text="Cadastrar" />
        <br />
       <br />
       <br />
        <br />
        <asp:Button ID="Button2" runat="server" CssClass="btn btn-info" OnClick="Button2_Click" Text="Entrar" />
    </div>
    </form>

    <!--Jquery-->
    <script src="Resources/js/jquery-3.3.1.min.js"></script>
    <!--Javascript do Bootstrap-->
    <script src="Resources/js/bootstrap.js"></script>
</body>
</html>
