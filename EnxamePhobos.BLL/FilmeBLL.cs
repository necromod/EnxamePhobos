using EnxamePhobos.DAL;
using EnxamePhobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.BLL
{
    public class FilmeBLL
    {
        //objeto global
        FilmeDAL objBLL = new FilmeDAL();

        //CRUD - Create
        public void CadastrarFilmeBLL(FilmeDTO objCad)
        {
            objBLL.CadastrarFilme(objCad);
        }


        //CRUD - Read
        public List<FilmeDTO> ListarFilmeBLL()
        {
            return objBLL.ListarFilme();
        }


        //CRUD - Update
        public void EditarFilmeBLL(FilmeDTO objEdit)
        {
            objBLL.EditarFilme(objEdit);
        }

        //CRUD - Delete
        public void ExcluirFilmeBLL(int objDel)
        {
            objBLL.ExcluirFilme(objDel);
        }

        //Filtrar por Genero
        public List<FilmeDTO> FiltrarFilmeBLL(string objFilter)
        {
            return objBLL.FiltrarFilme(objFilter);
        }


        //Carrega DDL
        public List<GeneroDTO> CarregaDDLBLL()
        {
            return objBLL.CarregaDDL();
        }


        //Search by name
        public FilmeDTO SearchByNameBLL(string objSearch)
        {
            return objBLL.SearchByName(objSearch);
        }



        //Search by id
        public FilmeDTO SearchByIdBLL(int objId)
        {
            return objBLL.SearchById(objId);
        }
    }
}
