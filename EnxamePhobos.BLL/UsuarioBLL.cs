using EnxamePhobos.DAL;
using EnxamePhobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.BLL
{
    public class UsuarioBLL
    {
        //variavel
        UsuarioDAL objBLL = new UsuarioDAL();

        //autenticar
        public UsuarioDTO AuteticarUsuario(string nome, string senha)
        {
            UsuarioDTO user = objBLL.Autenticar(nome, senha);

            return user;

        }

        //CRUD
        //Create
        public void CadastrarUsuario(UsuarioDTO objCad)
        {
            objBLL.Cadastrar(objCad);
        }

        //Read
        public List<UsuarioDTO> ListarUsuario()
        {
            return objBLL.Listar();
        }

        //Delete
        public void ExcluirUsuario(int objDel)
        {
            objBLL.Excluir(objDel);
        }

        //Update
        public void EditarUsuario(UsuarioDTO objEdita)
        {
            objBLL.Editar(objEdita);
        }

        //BuscaPorId
        public UsuarioDTO BuscaUsuarioPorId(int objId)
        {
            return objBLL.BuscaPorId(objId);
        }

        //BuscaPorNome
        public UsuarioDTO BuscaUsuarioPorNome(string objNome)
        {
            return objBLL.BuscaPorNome(objNome);
        }

        //CarregaDDL
        public List<TipoUsuarioDTO> CarregaTpUsuarioDDL()
        {
            return objBLL.CarregaDDL();
        }

    }
}
