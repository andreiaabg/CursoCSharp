using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string nome)
            : base(string.Format("O produto com nome {0} não esta cadastrado.", nome))
        {

        }
    }
}
