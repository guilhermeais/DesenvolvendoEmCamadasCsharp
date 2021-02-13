using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Modelos;

// DAL = Camada de Acesso a Dados
namespace Loja.DAL
{
    public class ClientesDAL
    {
        public void Inserir(ClienteInformation cliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandText = "insert into Clientes (nome, email, telefone) values (@nome, @email, @telefone); select @@IDENTITY;";

                cmd.Parameters.AddWithValue("@nome", cliente.Nome);

                cmd.Parameters.AddWithValue("@email", cliente.Email);

                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);

                cn.Open();

                cliente.Codigo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Alterar(ClienteInformation cliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandText = "update Clientes set nome = @nome, email = @email, telefone = @telefone where codigo = @codigo;";

                cmd.Parameters.AddWithValue("@codigo", cliente.Codigo);

                cmd.Parameters.AddWithValue("@nome", cliente.Nome);

                cmd.Parameters.AddWithValue("@email", cliente.Email);

                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);

                cn.Open();

                cmd.ExecuteNonQuery();

                cliente.Codigo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Excluir(int codigo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandText = "delete from Clientes where codigo = " + codigo;

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {

                    throw new Exception("Não foi possível excluir o cliente " + codigo);
                }
            }

            catch (SqlException ex)
            {
                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public DataTable Listagem(string filtro)
        {
            DataTable tabela = new DataTable();

            string strSql = "select * from Clientes";

            if (filtro != "")
            {
                strSql = "select * from Clientes where nome like '%" + filtro + "%'";
            }
            
            SqlDataAdapter da = new SqlDataAdapter(strSql, Dados.StringDeConexao);
            da.Fill(tabela);

            return tabela;
        }
           
    }
}
