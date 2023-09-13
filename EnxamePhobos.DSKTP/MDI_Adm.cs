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
    public partial class MDI_Adm : Form
    {
        public MDI_Adm()
        {
            InitializeComponent();
            lblSession.Text = $"Seja bem vindo {Session.nomeUsuario.ToUpper()} ao sistema Enxame Phobos ! início de sua sessão: {DateTime.Now.ToString("t")}";
        }

        //sair
        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Session.nomeUsuario.ToUpper()} sua sessão será finalizada", "Atenção", MessageBoxButtons.OK);
            Application.Exit();
        }
        //sair
        private void Sair_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Session.nomeUsuario.ToUpper()} sua sessão será finalizada", "Atenção", MessageBoxButtons.OK);
            Application.Exit();
        }


        //calculadora
        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }
        //calculadora
        private void Calculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }


        //notepad
        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }
        //notepad
        private void Notepad_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        //word
        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        //word
        private void Word_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        //cadastrar
        private void create_Click(object sender, EventArgs e)
        {
            FrmCadastrar obj = new FrmCadastrar();
            obj.ShowDialog();
        }
    }
}
