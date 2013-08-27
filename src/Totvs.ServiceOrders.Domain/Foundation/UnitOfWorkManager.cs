using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Domain.Foundation
{
    /// <summary>
    /// Gerenciador de Unidades de Trabalho
    /// </summary>
    public static class UnitOfWorkManager
    {
        
        /// <summary>
        /// Obtém a unidade de trabalho do contexto
        /// </summary>
        public static IUnitOfWork GetInstance()
        {
            var userPrincipal = Thread.CurrentPrincipal as UserPrincipal;
            if (userPrincipal == null)
                //não há controle transacional para usuários não autenticados
                return IoC.Resolve<IUnitOfWork>();

            userPrincipal.VoteInUse++;
            if (userPrincipal.UnitOfWork != null)
            {
                return userPrincipal.UnitOfWork;
            }
            var unitOfWork = IoC.Resolve<IUnitOfWork>();
            return userPrincipal.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Libera a unidade de trabalho do contexto
        /// </summary>
        public static void Unregister()
        {
            var userPrincipal = Thread.CurrentPrincipal as UserPrincipal;
            if (userPrincipal == null)
                return;
            userPrincipal.VoteInUse--;
            if (userPrincipal.VoteInUse == 0)
            {
                userPrincipal.UnitOfWork = null;
            }
        }
    }
}
