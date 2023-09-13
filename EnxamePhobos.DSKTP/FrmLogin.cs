using EnxamePhobos.BLL;
using EnxamePhobos.DTO;
using EnxamePhobos.UI.utilities;
using System;
using System.Windows.Forms;

namespace EnxamePhobos.DSKTP
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

        }

        //load
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        //fechar
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        //entrar
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //pegar as informacoes do usuario
                string nome = txtUser.Text.Trim();
                string senha = txtPassword.Text.Trim();

                UsuarioDTO obj = new UsuarioDTO();
                UsuarioBLL objBLL = new UsuarioBLL();

                obj = objBLL.AuteticarUsuario(nome, senha);
                if (obj != null)
                {
                    switch (obj.UsuarioTp)
                    {
                        case "1":
                            Session.nomeUsuario = txtUser.Text.Trim();
                            MDI_Adm formuAdm = new MDI_Adm();
                            formuAdm.Show();
                            this.Visible = false;
                            break;
                        case "2":
                            Session.nomeUsuario = txtUser.Text.Trim();
                            MDI_Outros formOutros = new MDI_Outros();
                            formOutros.Show();
                            this.Visible = false;
                            break;

                    }
                }
                else
                {
                    MessageBox.Show($"Usuário {txtUser.Text} não cadastrado !!");
                    Limpar.ClearControl(this);
                    txtUser.Focus();
                }


            }
            catch (Exception)
            {

                MessageBox.Show($"Usuário {txtUser.Text} não cadastrado !!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar.ClearControl(this);
            txtUser.Focus();
        }
    }
}
