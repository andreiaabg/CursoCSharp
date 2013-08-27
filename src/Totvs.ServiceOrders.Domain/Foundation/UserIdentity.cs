using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.OrdemServico.Domain.Foundation
{
    /// <summary>
    /// Identidade do Usuário do Sistema
    /// </summary>
    public class UserIdentity : IIdentity
    {
        /// <summary>
        /// Identidade do Usuário do Sistema
        /// </summary>
        public UserIdentity(string authenticationType, bool isAuthenticated, string name)
        {
            AuthenticationType = authenticationType;
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
