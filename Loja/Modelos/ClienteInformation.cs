using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Modelos
{
    public class ClienteInformation
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _telefone;

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        // Isso que fizemos acima, foi definir propriedades para cada campo da Tabela Clientes existente no banco de dados

       /* O arquivo Modelos.dll contém toda a informação que
        implementamos na classe ClienteInformation, e é ele que será usado
        no próximo projeto - Camada de Acesso a Dados ou DAL(Data Access
        Layer).- que será implementado.*/
    }
}
