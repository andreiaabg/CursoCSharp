using System;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Totvs.ServiceOrders.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Repositories;
using Totvs.ServiceOrders.Foundation;

namespace Totvs.ServiceOrders.Domain.Services
{
    /// <summary>
    /// Serviço de Autenticação
    /// </summary>
    public sealed class Authentication
    {

        /// <summary>
        /// Efetua o Login no Sistema
        /// </summary>
        public void Login(string userName, string password)
        {
            using (var users = new Users())
            {
                if (users.Any(userName, password))
                {
                    var userIdentity = new UserIdentity(AuthenticateType.Database, true, userName);
                    var userPrincipal = new UserPrincipal(userIdentity);
                    Thread.CurrentPrincipal = userPrincipal;
                } 
                else 
                {
                    var userIdentity = new UserIdentity(AuthenticateType.None, false, userName);
                    var userPrincipal = new GenericPrincipal(userIdentity, new string[0]);
                    Thread.CurrentPrincipal = userPrincipal;
                }
            }
        }

        /// <summary>
        /// Retorna verdadeiro se existe um usuário autenticado 
        /// </summary>
        /// <returns></returns>
        public static bool IsAutenthicate(bool allowGenericUser = false)
        {
            var userIndetity = Thread.CurrentPrincipal.Identity as UserIdentity;
            return userIndetity != null && (allowGenericUser || userIndetity.IsAuthenticated);
        }

        /// <summary>
        /// Retorna exceção caso o usuário não esteja autenticado no sistema
        /// </summary>
        public static void CheckAuthenticate()
        {
            if (!IsAutenthicate())
            {
                throw new SecurityException("Usuário não autenticado no sistema");
            }
        }
    }
}
