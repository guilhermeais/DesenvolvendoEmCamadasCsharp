using Loja.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.DAL;
using System.Data;

namespace Loja.BLL
{
    public class ProdutosBLL
    {
        public void Inserir(Produtoinformation produto)
        {
            // Nome do produto é obrigatório
            if (produto.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório.");
            }

            // O preço do produto não pode ser negativo
            if (produto.Preco < 0)
            {
                throw new Exception("Preço do produto não pode ser negativo.");
            }

            // O estoque também não pode ser negativo
            if (produto.Estoque < 0)
            {
                throw new Exception("Estoque do produto não pode ser negativo.");
            }

            // Se tudo estiver ok, chama a rotina de gravação 
            ProdutoDAL obj = new ProdutoDAL();
            obj.Inserir(produto);
        }
        public void Alterar(Produtoinformation produto)
        {        
            if (produto.Nome.Trim().Length == 0) 
            {
                throw new Exception("O nome do produto é obrigatório.");
            }

            if (produto.Preco < 0)
            {
                throw new Exception("Preço do produto não pode ser negativo.");
            }

            if (produto.Estoque < 0)
            {
                throw new Exception("Estoque do produto não pode ser negativo.");
            }

            ProdutoDAL obj = new ProdutoDAL();
            obj.Alterar(produto);
        }
        public void Excluir(int codigo)
        {
            ProdutoDAL obj = new ProdutoDAL();
            obj.Excluir(codigo);
        }
        public DataTable Listagem(string filtro)
        {
            ProdutoDAL obj = new ProdutoDAL();
            return obj.Listagem(filtro);
        }
    }
}
