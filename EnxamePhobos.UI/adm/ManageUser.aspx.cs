using EnxamePhobos.BLL;
using EnxamePhobos.DTO;
using EnxamePhobos.UI.utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.adm
{
    public partial class ManageUser : System.Web.UI.Page
    {
        //instanciando objetos
        UsuarioDTO objModelo = new UsuarioDTO();
        UsuarioBLL objBLL = new UsuarioBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtId.Enabled = false;
                PopularDDL();
                PopularGV1();
            }
        }

        //popular ddl
        public void PopularDDL()
        {
            ddl1.DataSource = objBLL.CarregaTpUsuarioDDL();
            ddl1.DataBind();
        }

        //popular gv1
        public void PopularGV1()
        {
            gv1.DataSource = objBLL.ListarUsuario();
            gv1.DataBind();
        }

        //search
        public void Search(string nome)
        {
            nome = txtSearch.Text.Trim();
            objModelo = new UsuarioDTO();
            objModelo = objBLL.BuscaUsuarioPorNome(nome);
            if (objModelo != null)
            {
                txtId.Text = objModelo.IdUsuario.ToString();
                txtNome.Text = objModelo.NomeUsuario.ToString();
                txtSenha.Text = objModelo.SenhaUsuario.ToString();
                txtEmail.Text = objModelo.EmailUsuario.ToString();
                txtData.Text = objModelo.DataNascUsuario.ToString("dd/MM/yyyy");
                ddl1.SelectedValue = objModelo.UsuarioTp.ToString();
                txtSearch.Text = string.Empty;
                lblMessage.Text = string.Empty;
                btnSearch.Enabled = false;
                txtNome.Focus();
            }
            else
            {
                lblMessage.Text = $"Usuário {txtSearch.Text} não cadastrado !!";
                txtSearch.Text = string.Empty;
                btnSearch.Enabled = true;
                txtSearch.Focus();
                return;
            }

        }

        //validaPage
        public bool ValidaPage()
        {
            //criando variavel de retorno
            bool validator;

            //estrutura de checagem
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                NewMethod();
                lblNome.Text = "Digite o nome do usuário !!";
                txtNome.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                NewMethod();
                lblSenha.Text = "Digite a senha do usuário !!";
                txtSenha.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                NewMethod();
                lblEmail.Text = "Digite o email do usuário !!";
                txtEmail.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtData.Text))
            {
                NewMethod();
                lblData.Text = "Digite a data de nascimento do usuário !!";
                txtData.Focus();
                validator = false;
            }
            else
            {
                validator = true;

            }

            return validator;

        }

        //limpar labels de validacao
        private void NewMethod()
        {
            lblNome.Text = lblSenha.Text = lblEmail.Text = lblData.Text = string.Empty;
        }



        //searchBtn
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblMessage.Text = $"Usuário {txtSearch.Text} não cadastrado !!";
                txtSearch.Text = string.Empty;
                txtSearch.Focus();
                return;
            }

            string nome = txtSearch.Text.Trim();
            Search(nome);

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Limpar.ClearControl(this);
            btnSearch.Enabled = true;
            txtSearch.Focus();
            gv1.SelectedRowStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
        }


        //CRUD - CREATE / UPDATE
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {

                //preenchendo dados
                objModelo = new UsuarioDTO();
                objModelo.NomeUsuario = txtNome.Text.Trim();
                objModelo.SenhaUsuario = txtSenha.Text.Trim();
                objModelo.EmailUsuario = txtEmail.Text.Trim();
                //ajustar a data
                DateTime dt;
                if (DateTime.TryParse(txtData.Text, out dt))
                {
                    objModelo.DataNascUsuario = dt;
                }
                else
                {
                    lblData.Text = $"Data inválida !!";
                    txtData.Text = string.Empty;
                    txtData.Focus();
                    return;
                }


                //ddl
                objModelo.UsuarioTp = ddl1.SelectedValue;

                //verificando operacao
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    //cadastrar
                    objBLL.CadastrarUsuario(objModelo);
                    PopularGV1();
                    Limpar.ClearControl(this);
                    btnSearch.Enabled = true;
                    lblMessage.Text = $"Usuário {objModelo.NomeUsuario} cadastrado com sucesso !!";
                }
                else
                {
                    //editar
                    objModelo.IdUsuario = int.Parse(txtId.Text);
                    objBLL.EditarUsuario(objModelo);
                    PopularGV1();
                    Limpar.ClearControl(this);
                    btnSearch.Enabled = true;
                    lblMessage.Text = $"Usuário {objModelo.NomeUsuario} editado com sucesso !!";
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //passando Id
            objModelo = new UsuarioDTO();
            objModelo.IdUsuario = int.Parse(txtId.Text);
            objBLL.ExcluirUsuario(objModelo.IdUsuario);
            PopularGV1();
            Limpar.ClearControl(this);
            txtSearch.Focus();
        }

        //btn selecionar do gv1
        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //passando a linha selecionada
            int idUser = int.Parse(gv1.SelectedRow.Cells[1].Text);

            objModelo = new UsuarioDTO();
            objModelo = objBLL.BuscaUsuarioPorId(idUser);

            txtId.Text = objModelo.IdUsuario.ToString();
            txtNome.Text = objModelo.NomeUsuario.ToString();
            txtSenha.Text = objModelo.SenhaUsuario.ToString();
            txtEmail.Text = objModelo.EmailUsuario.ToString();
            txtData.Text = objModelo.DataNascUsuario.ToString("dd/MM/yyyy");
            ddl1.SelectedValue = objModelo.UsuarioTp.ToString();
            txtSearch.Text = string.Empty;
            lblMessage.Text = string.Empty;
            btnSearch.Enabled = false;

            PopularGV1();
            gv1.SelectedRowStyle.BackColor = ColorTranslator.FromHtml("#d4d4d4");
        }
    }
}