using EnxamePhobos.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.DAL
{
    public class UsuarioDAL : Conexao
    {
        //autenticacao
        public UsuarioDTO Autenticar(string nome, string senha)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario=@nome AND SenhaUsuario=@senha;", conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@senha", senha);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;//ponteiro
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.NomeUsuario = dr["NomeUsuario"].ToString();
                    obj.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    obj.UsuarioTp = dr["UsuarioTp"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"Usuário não cadastrado ! {ex.Message}");
            }
            finally
            {
                Desconectar();
            }


        }

        //CRUD
        //Create
        public void Cadastrar(UsuarioDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Usuario (NomeUsuario,SenhaUsuario,EmailUsuario,DataNascUsuario,UsuarioTp) VALUES (@Nome,@Senha,@Email,@Data,@UsuarioTp);", conn);
                cmd.Parameters.AddWithValue("@Nome", objCad.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", objCad.EmailUsuario);
                cmd.Parameters.AddWithValue("@Senha", objCad.SenhaUsuario);
                cmd.Parameters.AddWithValue("@Data", objCad.DataNascUsuario);
                cmd.Parameters.AddWithValue("@UsuarioTp", objCad.UsuarioTp);
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

        //Read
        public List<UsuarioDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdUsuario,NomeUsuario,SenhaUsuario,EmailUsuario,DataNascUsuario,DescricaoTipoUsuario FROM Usuario INNER JOIN TipoUsuario ON IdTipoUsuario = UsuarioTp ORDER BY IdUsuario ASC;", conn);
                dr = cmd.ExecuteReader();
                List<UsuarioDTO> lista = new List<UsuarioDTO>();
                while (dr.Read())
                {
                    UsuarioDTO obj = new UsuarioDTO();
                    obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    obj.NomeUsuario = dr["NomeUsuario"].ToString();
                    obj.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    obj.EmailUsuario = dr["EmailUsuario"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    obj.UsuarioTp = dr["DescricaoTipoUsuario"].ToString();
                    lista.Add(obj);
                }
                return lista;
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

        //Delete
        public void Excluir(int objDel)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", objDel);
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

        //Update
        public void Editar(UsuarioDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Usuario SET [NomeUsuario] = @nome,[SenhaUsuario]=@senha,[EmailUsuario]=@email,[DataNascUsuario] = @data,[UsuarioTp] = @usuarioTp WHERE IdUsuario = @id;", conn);
                cmd.Parameters.AddWithValue("@nome", objEdita.NomeUsuario);
                cmd.Parameters.AddWithValue("@senha", objEdita.SenhaUsuario);
                cmd.Parameters.AddWithValue("@email", objEdita.EmailUsuario);
                cmd.Parameters.AddWithValue("@data", objEdita.DataNascUsuario);
                cmd.Parameters.AddWithValue("@usuarioTp", objEdita.UsuarioTp);
                cmd.Parameters.AddWithValue("@id", objEdita.IdUsuario);
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

        //BuscaPorId
        public UsuarioDTO BuscaPorId(int objId)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE IdUsuario = @id;", conn);
                cmd.Parameters.AddWithValue("@id", objId);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    obj.NomeUsuario = dr["NomeUsuario"].ToString();
                    obj.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    obj.EmailUsuario = dr["EmailUsuario"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    obj.UsuarioTp = dr["UsuarioTp"].ToString();
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

        //BuscaPorNome
        public UsuarioDTO BuscaPorNome(string objNome)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario = @nome;", conn);
                cmd.Parameters.AddWithValue("@nome", objNome);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    obj.NomeUsuario = dr["NomeUsuario"].ToString();
                    obj.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    obj.EmailUsuario = dr["EmailUsuario"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    obj.UsuarioTp = dr["UsuarioTp"].ToString();
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

        //CarregaDDL
        public List<TipoUsuarioDTO> CarregaDDL()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TipoUsuario;", conn);
                dr = cmd.ExecuteReader();
                List<TipoUsuarioDTO> lista = new List<TipoUsuarioDTO>();
                while (dr.Read())
                {
                    TipoUsuarioDTO obj = new TipoUsuarioDTO();
                    obj.IdTipoUsuario = Convert.ToInt32(dr["IdTipoUsuario"]);
                    obj.DescricaoTipoUsuario = dr["DescricaoTipoUsuario"].ToString();
                    lista.Add(obj);

                }
                return lista;
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
