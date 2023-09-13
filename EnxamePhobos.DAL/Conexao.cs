using System;
using System.Data.SqlClient;


namespace EnxamePhobos.DAL
{
    public class Conexao
    {
        //variaveis
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlConnection conn;

        //metodos
        //Conectar
        protected void Conectar()
        {
            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=EnxamePhobosDB;Integrated Security=True");
                conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        //desconectar
        protected void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
