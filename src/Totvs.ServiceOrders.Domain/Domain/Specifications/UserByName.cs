using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Entities;

namespace Totvs.ServiceOrders.Domain.Specifications
{
    /// <summary>
    /// Especificação : Usuários
    /// </summary>
    class UserByName : Specification<User>
    {
        /// <summary>
        /// Usuário por None
        /// </summary>
        public UserByName(string userName)
        {
            SatisfiedBy = user => user.UserName == userName;
        }
    }
}
