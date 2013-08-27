using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Helper
{
    /// <summary>
    /// Modulo de funções uteis
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Realiza um 'Cast' para Lazy
        /// </summary>
        public static Lazy<T> ToLazy<T>(this T objectResult)
        {
            return new Lazy<T>(() => objectResult);
        }
    }
}
