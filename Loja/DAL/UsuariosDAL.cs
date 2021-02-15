using Loja.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DAL
{
    public class UsuariosDAL
    {
        public void Inserir(Usuarioinformation usuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Usuarios (nome, administrador) values (@nome, @administrador); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@administrador", usuario.Administrador);

                cn.Open();
                usuario.Codigo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {

                throw new Exception("Erro SQL: " + ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Alterar(Usuarioinformation usuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "update Usuarios set nome=@nome, administrador = @administrador where codigo = @codigo;";
                cmd.Parameters.AddWithValue("@codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@administrador", usuario.Administrador);

                cn.Open();
                cmd.ExecuteNonQuery();
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
                cmd.CommandText = "delete from Usuarios where codigo = " + codigo;
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o usuário " + codigo);
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
            string strSql = "select * from Usuarios";
            if (filtro != "")
            {
                strSql = "select * from Usuarios where nome like '%" + filtro + "%'";
            }
            SqlDataAdapter da = new SqlDataAdapter(strSql, Dados.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
         /*
         Verifica se o usuário logado possui permissão de Uso do Aplicativo
         Regra de Segurança:
         Somente usuários cadastrados podem acessar o Aplicativo.
         */ 
         public int isUsuarioAutorizado(string usuarioLogado)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = Dados.StringDeConexao;
            string strSql = "select 1 from Usuarios where nome = '" + usuarioLogado + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            int output = 0;
            cmd.CommandText = strSql;
            try
            {
                cn.Open();
                output = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            cmd.Dispose();
            cmd = null;
           
            return output;
        }

        // Verifica se o usuário autenticado é Administrador
        public int isAdministrador(string usuarioLogado)
        {
            
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = Dados.StringDeConexao;
                string strSql = "select administrador from Usuarios where nome='" + usuarioLogado + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                int output = 0;
                cmd.CommandText = strSql;
            try
            {
                cn.Open();
                output = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            cmd.Dispose();
            cmd = null;
            return output;
        }
    }
}
