using EnxamePhobos.BLL;
using EnxamePhobos.DTO;
using EnxamePhobos.UI.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI.adm
{
    public partial class ManageFilme : System.Web.UI.Page
    {
        //instanciando objetos
        FilmeDTO filmeDTO = new FilmeDTO();
        FilmeBLL filmeBLL = new FilmeBLL();

        //loadPage
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularGV1();
                PopularDDL1();
                txtId.Enabled = false;
            }
        }

        //PopularDGV
        public void PopularGV1()
        {
            //populado o dgv1
            gv1.DataSource = filmeBLL.ListarFilmeBLL();

            //imprimindo na tela
            gv1.DataBind();
        }

        //Popular DDL1
        public void PopularDDL1()
        {
            //populado o dgv1
            ddl1.DataSource = filmeBLL.CarregaDDLBLL();

            //imprimindo na tela
            ddl1.DataBind();
        }


        //Limpar
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar.ClearControl(this);
            PopularGV1();
            txtSearch.Focus();
        }

        //validate
        public bool ValidatePage()
        {
            bool validator;
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                lblTitulo.Text = "Digite o Título do Filme !!";
                txtTitulo.Text = string.Empty;
                txtTitulo.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(txtProdutora.Text))
            {
                lblProdutora.Text = "Digite o nome da Produtora !!";
                txtProdutora.Text = string.Empty;
                txtProdutora.Focus();
                validator = false;
            }
            else if (!fUp1.HasFile)
            {
                lblfUp1.Text = "Escolha uma imagem !!";
                fUp1.Focus();
                validator = false;
            }
            else if (string.IsNullOrEmpty(rbl1.Text))
            {
                lblClassificacao_Id.Text = "Selecione uma opção !!";
                rbl1.Focus();
                validator = false;
            }
            else
            {
                validator = true;
            }
            return validator;

        }

        //carregaDados
        public FilmeDTO CarregaDados(string nome)
        {
            filmeDTO = filmeBLL.SearchByNameBLL(nome);
            if (filmeDTO != null)
            {
                txtId.Text = filmeDTO.IdFilme.ToString();
                txtTitulo.Text = filmeDTO.TituloFilme.ToString();
                txtProdutora.Text = filmeDTO.ProdutoraFilme.ToString();
                lblfUp1.Text = filmeDTO.UrlImgFilme.ToString();
                rbl1.SelectedValue = filmeDTO.ClassificacaoFilme_Id.ToString();
                ddl1.SelectedValue = filmeDTO.GeneroFilme_Id.ToString();
            }
            txtSearch.Text = string.Empty;
            txtSearch.Focus();
            return filmeDTO;
        }

        //FiltrarDados
        public void FiltraDados()
        {
            string objFilter = ddl1.SelectedItem.Text;
            gv1.DataSource = filmeBLL.FiltrarFilmeBLL(objFilter);
            gv1.DataBind();
        }

        //Delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            filmeDTO.IdFilme = int.Parse(txtId.Text);
            filmeBLL.ExcluirFilmeBLL(filmeDTO.IdFilme);
            Limpar.ClearControl(this);
            PopularGV1();
            txtSearch.Focus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string nome = txtSearch.Text.Trim();
            CarregaDados(nome);
        }

        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nome = (gv1.SelectedRow.Cells[2].Text);
            CarregaDados(nome);
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            FiltraDados();
        }

        protected void btnRecord_Click(object sender, EventArgs e)
        {
            //preenchendo objeto

            filmeDTO.TituloFilme = txtTitulo.Text.Trim();
            filmeDTO.ProdutoraFilme = txtProdutora.Text.Trim();

            //imagem
            if (fUp1.HasFile)
            {
                string str = fUp1.FileName;
                fUp1.PostedFile.SaveAs(Server.MapPath("~/resources/img/") + str);
                string caminhoImg = "~/resources/img/" + str.ToString();
                filmeDTO.UrlImgFilme = caminhoImg;

            }
            else
            {
                lblMessage.Text = "Escolha uma imagem !!";
            }

            //radio button - classificacao
            filmeDTO.ClassificacaoFilme_Id = rbl1.SelectedValue;

            //ddl - genero
            filmeDTO.GeneroFilme_Id = ddl1.SelectedValue;

            //definicao da operacao do crud (insert / update)
            if (string.IsNullOrEmpty(txtId.Text))
            {
                //cadastrar / insert
                filmeBLL.CadastrarFilmeBLL(filmeDTO);
                PopularGV1();
                Limpar.ClearControl(this);
                lblMessage.Text = $"Filme {filmeDTO.TituloFilme} cadastrado com sucesso !!";

            }
            else
            {
                //editar / update

                filmeDTO.IdFilme = int.Parse(txtId.Text);
                filmeBLL.EditarFilmeBLL(filmeDTO);
                PopularGV1();
                Limpar.ClearControl(this);
                lblMessage.Text = $"Filme {filmeDTO.TituloFilme} editado com sucesso !!";


            }



        }
    }
}