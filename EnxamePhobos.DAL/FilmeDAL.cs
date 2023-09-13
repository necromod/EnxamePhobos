using EnxamePhobos.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;//
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.DAL
{
    public class FilmeDAL : Conexao
    {
        //CRUD - Create
        public void CadastrarFilme(FilmeDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Filme(TituloFilme,ProdutoraFilme,UrlImgFilme,GeneroFilme_Id,ClassificacaoFilme_Id) VALUES(@TituloFilme,@ProdutoraFilme,@UrlImgFilme,@GeneroFilme_Id,@ClassificacaoFilme_Id)", conn);
                cmd.Parameters.AddWithValue("@TituloFilme", objCad.TituloFilme);
                cmd.Parameters.AddWithValue("@ProdutoraFilme", objCad.ProdutoraFilme);
                cmd.Parameters.AddWithValue("@UrlImgFilme", objCad.UrlImgFilme);
                cmd.Parameters.AddWithValue("@GeneroFilme_Id", objCad.GeneroFilme_Id);
                cmd.Parameters.AddWithValue("@ClassificacaoFilme_Id", objCad.ClassificacaoFilme_Id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //CRUD - Read
        public List<FilmeDTO> ListarFilme()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilme, TituloFilme, ProdutoraFilme, UrlImgFilme, DescricaoGenero, DescricaoClassificacao FROM Filme INNER JOIN Genero ON GeneroFilme_Id = IdGenero INNER JOIN Classificacao ON ClassificacaoFilme_Id = IdClassificacao;", conn);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>();
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.IdFilme = Convert.ToInt32(dr["IdFilme"]);
                    obj.TituloFilme = dr["TituloFilme"].ToString();
                    obj.ProdutoraFilme = dr["ProdutoraFilme"].ToString();
                    obj.UrlImgFilme = dr["UrlImgFilme"].ToString();
                    obj.GeneroFilme_Id = dr["DescricaoGenero"].ToString();
                    obj.ClassificacaoFilme_Id = dr["DescricaoClassificacao"].ToString();
                    Lista.Add(obj);

                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //CRUD - Update
        public void EditarFilme(FilmeDTO objEdit)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Filme SET TituloFilme = @TituloFilme ,ProdutoraFilme = @ProdutoraFilme,UrlImgFilme = @UrlImgFilme, GeneroFilme_Id =@GeneroFilme_Id,ClassificacaoFilme_Id = @ClassificacaoFilme_Id WHERE IdFilme = @IdFilme;", conn);
                cmd.Parameters.AddWithValue("@TituloFilme", objEdit.TituloFilme);
                cmd.Parameters.AddWithValue("@ProdutoraFilme", objEdit.ProdutoraFilme);
                cmd.Parameters.AddWithValue("@UrlImgFilme", objEdit.UrlImgFilme);
                cmd.Parameters.AddWithValue("@GeneroFilme_Id", objEdit.GeneroFilme_Id);
                cmd.Parameters.AddWithValue("@ClassificacaoFilme_Id", objEdit.ClassificacaoFilme_Id);
                cmd.Parameters.AddWithValue("@IdFilme", objEdit.IdFilme);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //CRUD - Delete
        public void ExcluirFilme(int objDel)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Filme WHERE IdFilme = @IdFilme;", conn);
                cmd.Parameters.AddWithValue("@IdFilme", objDel);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Filtrar por Genero
        public List<FilmeDTO> FiltrarFilme(string objFilter)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilme, TituloFilme, ProdutoraFilme, UrlImgFilme, DescricaoGenero, DescricaoClassificacao FROM Filme INNER JOIN Genero ON GeneroFilme_Id = IdGenero INNER JOIN Classificacao ON ClassificacaoFilme_Id = IdClassificacao WHERE DescricaoGenero = @DescricaoGenero;", conn);
                cmd.Parameters.AddWithValue("DescricaoGenero", objFilter);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>();
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.IdFilme = Convert.ToInt32(dr["IdFilme"]);
                    obj.TituloFilme = dr["TituloFilme"].ToString();
                    obj.ProdutoraFilme = dr["ProdutoraFilme"].ToString();
                    obj.UrlImgFilme = dr["UrlImgFilme"].ToString();
                    obj.GeneroFilme_Id = dr["DescricaoGenero"].ToString();
                    obj.ClassificacaoFilme_Id = dr["DescricaoClassificacao"].ToString();
                    Lista.Add(obj);

                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Carrega DDL
        public List<GeneroDTO> CarregaDDL()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Genero;", conn);
                dr = cmd.ExecuteReader();
                List<GeneroDTO> Lista = new List<GeneroDTO>();
                while (dr.Read())
                {
                    GeneroDTO obj = new GeneroDTO();
                    obj.IdGenero = Convert.ToInt32(dr["IdGenero"]);
                    obj.DescricaoGenero = dr["DescricaoGenero"].ToString();
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Search by name
        //public FilmeDTO SearchByName(string objSearch)
        //{
        //    try
        //    {
        //        Conectar();
        //        cmd = new SqlCommand("SELECT IdFilme, TituloFilme, ProdutoraFilme, UrlImgFilme, DescricaoGenero, DescricaoClassificacao FROM Filme INNER JOIN Genero ON GeneroFilme_Id = IdGenero INNER JOIN Classificacao ON ClassificacaoFilme_Id = IdClassificacao WHERE TituloFilme = @TituloFilme;", conn);
        //        cmd.Parameters.AddWithValue("@TituloFilme", objSearch);
        //        dr = cmd.ExecuteReader();
        //        FilmeDTO obj = null;
        //        if (dr.Read())
        //        {
        //            obj = new FilmeDTO();
        //            obj.IdFilme = Convert.ToInt32(dr["IdFilme"]);
        //            obj.TituloFilme = dr["TituloFilme"].ToString();
        //            obj.ProdutoraFilme = dr["ProdutoraFilme"].ToString();
        //            obj.UrlImgFilme = dr["UrlImgFilme"].ToString();
        //            obj.GeneroFilme_Id = dr["DescricaoGenero"].ToString();
        //            obj.ClassificacaoFilme_Id = dr["DescricaoClassificacao"].ToString();
        //        }
        //        return obj;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        Desconectar();
        //    }
        //}


        //Search by name real
        public FilmeDTO SearchByName(string objSearch)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Filme WHERE TituloFilme = @TituloFilme;", conn);
                cmd.Parameters.AddWithValue("@TituloFilme", objSearch);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {
                    obj = new FilmeDTO();
                    obj.IdFilme = Convert.ToInt32(dr["IdFilme"]);
                    obj.TituloFilme = dr["TituloFilme"].ToString();
                    obj.ProdutoraFilme = dr["ProdutoraFilme"].ToString();
                    obj.UrlImgFilme = dr["UrlImgFilme"].ToString();
                    obj.GeneroFilme_Id = dr["GeneroFilme_Id"].ToString();
                    obj.ClassificacaoFilme_Id = dr["ClassificacaoFilme_Id"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Search by id
        public FilmeDTO SearchById(int objId)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Filme WHERE IdFilme = @IdFilme;", conn);
                cmd.Parameters.AddWithValue("@IdFilme", objId);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {
                    obj = new FilmeDTO();
                    obj.IdFilme = Convert.ToInt32(dr["IdFilme"]);
                    obj.TituloFilme = dr["TituloFilme"].ToString();
                    obj.ProdutoraFilme = dr["ProdutoraFilme"].ToString();
                    obj.UrlImgFilme = dr["UrlImgFilme"].ToString();
                    obj.GeneroFilme_Id = dr["GeneroFilme_Id"].ToString();
                    obj.ClassificacaoFilme_Id = dr["ClassificacaoFilme_Id"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

    }
}
