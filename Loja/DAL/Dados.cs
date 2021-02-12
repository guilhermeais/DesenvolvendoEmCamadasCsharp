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

                return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Guilherme\\Documents\\GitHub\\CursoCsharp\\DesenvolvendoEmCamadasCsharp\\Loja\\database\\LOJA.mdf;Integrated Security=True;Connect Timeout=30";

            }
        }
    }
}
