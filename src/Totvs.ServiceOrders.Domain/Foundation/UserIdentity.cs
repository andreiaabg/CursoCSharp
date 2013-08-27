using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Foundation;

namespace Totvs.ServiceOrders.Domain.Foundation
{
    /// <summary>
    /// Identidade do Usuário do Sistema
    /// </summary>
    public class UserIdentity : IIdentity
    {
        /// <summary>
        /// Identidade do Usuário do Sistema
        /// </summary>
        public UserIdentity(AuthenticateType authenticationType, bool isAuthenticated, string name)
        {
            AuthenticationType = Enum.GetName(typeof(AuthenticateType), authenticationType);
            IsAuthenticated = isAuthenticated;
            Name = name;
        }

        /// <summary>
        /// Tipo de Autenticação
        /// </summary>
        public string AuthenticationType { get; private set; }

        /// <summary>
        /// Retorna verdadeiro se autenticado
        /// </summary>
        public bool IsAuthenticated { get; private set; }

        /// <summary>
        /// Nome do Usuário
        /// </summary>
        public string Name { get; private set; }
    }
}
