using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.OrdemServico.Dominio.Excecoes
{
    public class ProdutoJaExiste : Exception
    {
        public ProdutoJaExiste(string nome)
            : base(string.Format("O produto com nome {0} já esta cadastrado.", nome))
        {

        }
    }

}
