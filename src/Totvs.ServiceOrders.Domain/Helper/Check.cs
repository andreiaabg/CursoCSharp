using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Helper
{
    /// <summary>
    /// Verificações
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Checa se a condição é verdadeira e sobe uma exceção
        /// em caso contrário
        /// </summary>
        public static void IsFalse(bool condition, Exception exception)
        {
            if (condition)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Retorna exceção se o objeto não for nulo
        /// </summary>
        public static void IsNotNull(object objeto, Exception excecao)
        {
            if (objeto != null)
            {
                throw excecao;
            }
        }

        /// <summary>
        /// Retorna exceção se o objeto for nulo
        /// </summary>
        public static void IsNull(object objeto, Exception excecao)
        {
            if (objeto == null)
            {
                throw excecao;
            }
        }
    }
}
