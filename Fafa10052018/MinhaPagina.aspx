<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MinhaPagina.aspx.cs" Inherits="Fafa10052018.MinhaPagina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resources/css/Bootstrap.css" rel="stylesheet" />
    <link href="Resources/css/Beauty.css" rel="stylesheet" />
</head>
<body style="background-image: url('Resources/img/862609.jpg'); background-size: cover;">
    <form id="form1" runat="server">
    <div class="text-center" style="float:left; margin-left:15%">
    
        <br />
        <br />
        <br />
        <br />
        <br />
    
        <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Label"></asp:Label>
    
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" Height="80px" Width="120px" />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Button4" runat="server" CssClass="btn btn-info" OnClick="Button4_Click" Text="Alterar foto" />
        <br />
        <asp:Button ID="Button5" runat="server" CssClass="btn btn-warning" OnClick="Button5_Click" Text="Cancelar" />
        <br />
        <br />
    </div>
    <div class="text-center" style="float:left; margin-left: 13%; color:white;">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Mensagem:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        <p>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Tweetar!!!" />
        </p>
        <p>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Feed:"></asp:Label>
        </p>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <br />
        <br />
        <br />
    </div>
        <div class="text-center" style="float:right; margin-right:15%">
        <br />
        <br />
        <br />
        <br />
            <br />
            <br />
            <br />
        <br />
        <br />
        <br />

        <asp:Button ID="Button2" runat="server" CssClass="btn btn-info" OnClick="Button2_Click" Text="Pesquisar" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" CssClass="btn btn-danger" OnClick="Button3_Click" Text="Sair" />
            </div>
    </form>
    <!--Jquery-->
    <script src="Resources/js/jquery-3.3.1.min.js"></script>
    <!--Javascript do Bootstrap-->
    <script src="Resources/js/bootstrap.js"></script>
</body>
</html>
