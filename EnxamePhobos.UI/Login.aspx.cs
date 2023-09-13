using EnxamePhobos.BLL;
using EnxamePhobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnxamePhobos.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "SEJA BEM VINDO!!! ";
            lblMessage.Font.Size = 50;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //instanciar os objetos DTO BLL
                UsuarioDTO usuario = new UsuarioDTO();
                UsuarioBLL objBLL = new UsuarioBLL();

                //pegar os dados fornecidos pelo usuario
                string objNome = txtNome.Text;
                string objSenha = txtSenha.Text;

                //chamar o metodo na BLL
                usuario = objBLL.AuteticarUsuario(objNome, objSenha);


                //checar o tipo de usuario
                if (usuario != null)
                {

                    lblMessage.Text = $"Bem Vindo {usuario.NomeUsuario}";
                }

            }
            catch (Exception)
            {

                lblMessage.Text = $"Usuario {txtNome.Text} não cadastrado!!! ";
            }
        }
    }
}