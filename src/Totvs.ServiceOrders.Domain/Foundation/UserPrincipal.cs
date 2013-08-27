using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Domain.Foundation
{
    /// <summary>
    /// Contexto de Execução do Aplicativo
    /// </summary>
    public class UserPrincipal : IPrincipal
    {
        /// <summary>
        /// Contexto de Execução do Aplicativo
        /// </summary>
        public UserPrincipal(UserIdentity userIndentity)
        {
            Identity = userIndentity;
        }

        /// <summary>
        /// Identidade do Usuário
        /// </summary>
        public IIdentity Identity { get; set; }

        /// <summary>
        /// Retorna Verdadeiro se o Usuário tem acesso ao módulo especificado
        /// </summary>
        public bool IsInRole(string role)
        {
            return true;
        }

        /// <summary>
        /// Unidade de Trabalho do Contexto
        /// </summary>
        internal IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// Quantidade de Utilizadores ativos da unidade de trabalho
        /// </summary>
        internal int VoteInUse { get; set; }
    }
}
