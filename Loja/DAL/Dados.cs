using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DAL
{
    public class Dados
    {
        public static string StringDeConexao
        {
            get
            {
                return "Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFileName=" 
                    + @"C:\Users\guilh\OneDrive\Documentos\GitHub\Desenvolvendo-em-Camadas-com-C-Sharp\Loja\databaseLOJA.mdf;Integrated Security=True";

            }
        }
    }
}
