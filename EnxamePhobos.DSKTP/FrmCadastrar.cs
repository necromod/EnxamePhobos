using EnxamePhobos.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnxamePhobos.DSKTP
{
    public partial class FrmCadastrar : Form
    {
        public FrmCadastrar()
        {
            InitializeComponent();
        }

        //Instanciando objetos
        UsuarioBLL objBLL = new UsuarioBLL();

        //Load 
        private void FrmCadastrar_Load(object sender, EventArgs e)
        {
            CarregaCbo1();

        }

        private void CarregaCbo1()
        {
            cbo1.ValueMember = "IdTipoUsuario";
            cbo1.DisplayMember = "DescricaoTipoUsuario";
            cbo1.DataSource = objBLL.CarregaTpUsuarioDDL().ToList();
        }


        //fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
