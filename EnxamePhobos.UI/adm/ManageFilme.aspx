<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageFilme.aspx.cs" Inherits="EnxamePhobos.UI.adm.ManageFilme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    <%--formulario--%>
    <div class="manageFilme-container">


        <%--formulario--%>
        <ul class="manageFilme-inner">
            <li>
                <asp:TextBox ID="txtId" runat="server" placeholder="Id:"></asp:TextBox>
            </li>
            <li>
                <asp:TextBox ID="txtTitulo" runat="server" placeholder="Titulo:" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>

            </li>
            <li>
                <asp:TextBox ID="txtProdutora" runat="server" placeholder="Produtora:" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:Label ID="lblProdutora" runat="server" Text=""></asp:Label>

            </li>
            <li>
                <asp:FileUpload ID="fUp1" runat="server" Text="Selecione a Imagem" />
                <asp:Label ID="lblfUp1" runat="server" Text=""></asp:Label>

            </li>

            <li>
                <asp:RadioButtonList ID="rbl1" runat="server">
                    <asp:ListItem Value="1" Text=" Livre" />
                    <asp:ListItem Value="2" Text=" +14" />
                    <asp:ListItem Value="3" Text=" +18" />
                </asp:RadioButtonList>
                <asp:Label ID="lblClassificacao_Id" runat="server" Text=""></asp:Label>

            </li>
            <li>
                <asp:DropDownList
                    ID="ddl1"
                    runat="server"
                    Width="160px"
                    Height="27px"
                    AutoPostBack="false"
                    DataValueField="IdGenero"
                    DataTextField="DescricaoGenero">
                </asp:DropDownList>
                <%--filtro por genero--%>

                <asp:Button ID="btnFiltro" runat="server" Text="Search by filter" CssClass="btnDefault" OnClick="btnFiltro_Click" />
                <asp:Label ID="lblFiltro" runat="server" Text=""></asp:Label>
            </li>
            <li>
                <asp:Button ID="btnRecord" runat="server" Text="Record" CssClass="btnDefault" OnClick="btnRecord_Click" />

                <asp:Button ID="btnLimpar" runat="server" Text="Clear" CssClass="btnDefault" OnClick="btnLimpar_Click" />

                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClientClick="if(!confirm('Deseja mesmo eliminar este registro?'))return false" CssClass="btnDefault" OnClick="btnDelete_Click"/>
            </li>
        </ul>
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by Name:" AutoCompleteType="Disabled"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnDefault" OnClick="btnSearch_Click" />
        <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>





        <%--gridView--%>
        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False"
            OnSelectedIndexChanged="gv1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                <asp:BoundField DataField="IdFilme" HeaderText="Código" />
                <asp:BoundField DataField="TituloFilme" HeaderText="Título" />
                <asp:BoundField DataField="ProdutoraFilme" HeaderText="Produtora" />
                <asp:BoundField DataField="ClassificacaoFilme_Id" HeaderText="Classificação" />
                <asp:BoundField DataField="GeneroFilme_Id" HeaderText="Gênero" />
                <asp:ImageField DataImageUrlField="UrlImgFilme" HeaderText="Image" ControlStyle-Width="150" ControlStyle-Height="150">

                    <ControlStyle Height="150px" Width="150px"></ControlStyle>
                </asp:ImageField>

            </Columns>
        </asp:GridView>
    </div>





</asp:Content>
