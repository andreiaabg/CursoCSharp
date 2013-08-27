using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Foundation
{
    /// <summary>
    /// Tipos de Autenticações
    /// </summary>
    public enum AuthenticateType
    {
        /// <summary>
        /// Nenhuma (Não autenticado)
        /// </summary>
        None,
        
        /// <summary>
        /// Autenticação pelo cadastro
        /// </summary>
        Database
    }
}
