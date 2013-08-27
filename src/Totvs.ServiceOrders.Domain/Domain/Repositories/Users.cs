using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.Domain.Specifications;
using Totvs.ServiceOrders.Foundation;

namespace Totvs.ServiceOrders.Domain.Repositories
{
    public class Users : Repository<User>
    {
        /// <summary>
        /// Checa se existe um usuário cadastrado no banco de dados com a senha especificada
        /// </summary>
        public bool Any(string userName, string password)
        {
            var specification = new UserByNameAndPassword(userName, password);
            var user = Get(specification);
            if (user == null)
                return false;
            return user.PasswordIs(password);
        }
    }
}
