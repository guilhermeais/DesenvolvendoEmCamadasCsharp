using Loja.DAL;
using Loja.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.BLL
{
    public class UsuariosBLL
    {
        public void Inserir(Usuarioinformation usuario)
        {
            // O nome de usuário é obrigatório
            if (usuario.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do usuário é obrigatório.");
            }
            //Caso esteja tudo ok, chama a rotina de inserção de dados
            UsuariosDAL obj = new UsuariosDAL();
            obj.Inserir(usuario);
        }
        public void Alterar(Usuarioinformation usuario)
        {
            if (usuario.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do usuário é obrigatório.");
            }
            UsuariosDAL obj = new UsuariosDAL();
            obj.Alterar(usuario);
        }
        public void Excluir(int codigo)
        {
            if (codigo < 1)
            {
                throw new Exception("Selecione um usuário para excluí-lo.");
            }
            UsuariosDAL obj = new UsuariosDAL();
            obj.Excluir(codigo);
        }

        public DataTable Listagem(string filtro)
        {
            UsuariosDAL obj = new UsuariosDAL();
            return obj.Listagem(filtro);
        }
        public int IsAdministrador(string usuarioLogado)
        {
            UsuariosDAL obj = new UsuariosDAL();
            return obj.isAdministrador(usuarioLogado);
        }
        public int isUsuarioAutorizado(string usuarioLogado)
        {
            UsuariosDAL obj = new UsuariosDAL();
            return obj.isUsuarioAutorizado(usuarioLogado);
        }

    }
}
