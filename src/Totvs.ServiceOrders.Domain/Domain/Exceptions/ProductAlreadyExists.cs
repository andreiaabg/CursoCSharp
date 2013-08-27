using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Exceptions
{
    public class ProductAlreadyExists : Exception
    {
        public ProductAlreadyExists(string nome)
            : base(string.Format("O produto com nome {0} já esta cadastrado.", nome))
        {

        }
    }

}
