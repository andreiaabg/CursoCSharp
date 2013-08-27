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
    class UserByNameAndPassword : Specification<User>
    {

        /// <summary>
        /// Usuário por None
        /// </summary>
        public UserByNameAndPassword(string userName, string password)
        {
            var userQuery = new User(userName, password);
            SatisfiedBy = user => user.UserName == userQuery.UserName && user.Password == userQuery.Password;
        }
    }
}
