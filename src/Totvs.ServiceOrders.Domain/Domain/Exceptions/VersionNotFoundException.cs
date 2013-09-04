using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Domain.Exceptions
{
    public class VersionNotFoundException : Exception
    {
        public VersionNotFoundException(string product, string version)
            : base(string.Format("O produto {0} com a versão {1} não esta cadastrado.", product, version))
        {

        }
    }
}
