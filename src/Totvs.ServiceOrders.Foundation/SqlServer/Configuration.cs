using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Entities;

namespace Totvs.ServiceOrders.Infra.SqlServer
{
    public static class Configuration
    {
        public static void Mapping()
        {
            var mapperProduct = new DataMapper<Product>()
                    .Table("PRODUTO")
                    .Column(p => p.Name, "NOME");

        }
    }
}
