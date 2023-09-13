<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EnxamePhobos.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <ul>
              <li>
                  <asp:TextBox ID="txtNome" placeholder="Nome: " MaxLength="150" Width="40%" runat="server"/>
              </li>
               <li>
                  <asp:TextBox ID="txtSenha" placeholder="Senha: " MaxLength="6" Width="40%" runat="server"/>
              </li>
              <li>
                  <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
                  <asp:Button ID="btnLimpar" runat="server" Text="Limpar" />
              </li>
              <li>
                  <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
              </li>
          </ul>
        </div>
    </form>
</body>
</html>
