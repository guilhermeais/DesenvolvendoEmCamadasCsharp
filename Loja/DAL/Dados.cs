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

                return "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " 
                    + "C:\\Desenvolvendo-em-Camadas-com-C-Sharp\\Loja\\database\\LOJA.mdf; Integrated Security= True";

            }
        }
    }
}
