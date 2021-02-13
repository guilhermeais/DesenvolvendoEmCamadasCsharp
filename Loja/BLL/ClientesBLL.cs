using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.DAL;
using Loja.Modelos;

// BLL = Camada de Regra de Negocios
namespace Loja.BLL
{
    public class ClientesBLL
    {
        // Regra de Négocios para Inserir dados no BD
        public void Inserir(ClienteInformation cliente)
        {
            // Obriga que o nome tenha algo escrito
            if (cliente.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do clinte é obrigatório");
            }
            // E obriga que o email deve ser em caixa baixa
            cliente.Email = cliente.Email.ToLower();
            // Cria um objeto da camada de acesso ao banco de dados
            ClientesDAL obj = new ClientesDAL();
            // Chama o método da DAL e insere no BD o objeto cliente criado a partir do Modulo que é responspavel por maniupar a tabela clientes
            obj.Inserir(cliente);
        }
        public void Alterar(ClienteInformation cliente)
        {
            if (cliente.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do clinte é obrigatório");
            }
            cliente.Email = cliente.Email.ToLower();

            ClientesDAL obj = new ClientesDAL();

            obj.Alterar(cliente);
        }

        public void Excluir(int codigo)
        {
            if (codigo < 1)
            {
                throw new Exception("Selecione um clinete antes de exclui-lo");
            }

            ClientesDAL obj = new ClientesDAL();
            obj.Excluir(codigo);
        }

        public DataTable Listagem(string filtro)
        {
            ClientesDAL obj = new ClientesDAL();
            
            return obj.Listagem(filtro);
        }

    }
}
