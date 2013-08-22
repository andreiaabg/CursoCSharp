using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.OrdemServico.Dominio.Util
{
    public class Checar
    {
        /// <summary>
        /// Checa se a condição é verdadeira e sobe uma exceção
        /// em caso contrário
        /// </summary>
        public static void Falso(bool condicao, Exception excecao)
        {
            if (condicao)
            {
                throw excecao;
            }
        }

        public static void NaoNulo(object objeto, Exception excecao)
        {
            if (objeto == null)
            {
                throw excecao;
            }
        }
    }
}
