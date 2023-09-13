<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="EnxamePhobos.UI.adm.ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="geral">
        <h1>Enxame Phobos</h1>
        <div class="topo">
            <%--formulario--%>
       
                <ul class="formulario">
                    <li>
                        <asp:TextBox ID="txtId" runat="server" placeholder="Id:" AutoCompleteType="Disabled"></asp:TextBox>
                    </li>
                    <li>
                        <asp:TextBox ID="txtNome" runat="server" placeholder="Nome:" AutoCompleteType="Disabled"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
                    </li>

                    <li>
                        <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha:" AutoCompleteType="Disabled" MaxLength="6"></asp:TextBox>
                           <br />
                        <asp:Label ID="lblSenha" runat="server" Text=""></asp:Label>
                    </li>

                    <li>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email:" AutoCompleteType="Disabled"></asp:TextBox>
                           <br />
                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </li>

                    <li>
                        <asp:TextBox ID="txtData" runat="server" placeholder="Data de Nascimento:" AutoCompleteType="Disabled" onkeypress="$(this).mask('00/00/0000')"></asp:TextBox>
                           <br />
                        <asp:Label ID="lblData" runat="server" Text=""></asp:Label>
                    </li>
                    <li>
                        <asp:DropDownList
                            ID="ddl1"
                            runat="server"
                            AutoPostBack="false"
                            DataValueField="IdTipoUsuario"
                            DataTextField="DescricaoTipoUsuario">
                        </asp:DropDownList>
                   
                        <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click"/>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"/>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja realmente eliminar este registro??'))return false" />
                    </li>

                  <%-- search by name--%>
                    <li>
                        <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by Name:" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </li>

                </ul>

          

            <div class="gridView">
                <%--gridView--%>
                <asp:GridView
                    ID="gv1"
                    runat="server"
                    AutoGenerateColumns="false"
                    OnSelectedIndexChanged="gv1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Opção" />
                        <asp:BoundField DataField="IdUsuario" HeaderText="Código" />
                        <asp:BoundField DataField="NomeUsuario" HeaderText="Nome" />
                        <asp:BoundField DataField="SenhaUsuario" HeaderText="Senha" />
                        <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
                        <asp:BoundField DataField="DataNascUsuario" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="UsuarioTp" HeaderText="Permissão" />
                    </Columns>
                   <%-- <SelectedRowStyle BackColor="#d4d4d4" />--%>
                </asp:GridView>

            </div>


        </div>

    </div>
</asp:Content>
