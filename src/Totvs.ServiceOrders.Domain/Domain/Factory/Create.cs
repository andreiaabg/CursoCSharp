using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Exceptions;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.Helper;
using Totvs.ServiceOrders.Repositories;
using Totvs.ServiceOrders.Domain.Exceptions;

namespace Totvs.ServiceOrders.Factory
{
    /// <summary>
    /// Factories: Produtos
    /// </summary>
    public static class Create
    {
        /// <summary>
        /// Cria um Produto
        /// </summary>
        public static Product Product(string name, 
            params string[] versionsCodes)
        {
            using (Products products = new Products())
            {
                Check.IsFalse(products.AnyByName(name), new ProductAlreadyExists(name));

                IList<ProductVersion> productVersions = new List<ProductVersion>();
                Product product = new Product(name, productVersions);
                foreach (string versionCode in versionsCodes)
                {
                    Version version = Version.Parse(versionCode);
                    ProductVersion productVersion = new ProductVersion(product, version);
                    productVersions.Add(productVersion);
                }
                return product;
            }
        }

        /// <summary>
        /// Cria um chamado
        /// </summary>
        public static Ticket Ticket(Requestor requestor,
            string productName,
            string versionCode,
            string indidentDescription)
        {
            using (Products products = new Products())
            {
                Product product = products.GetByName(productName);
                Check.IsNull(product, new ProductNotFoundException(productName));
                ProductVersion productVersion = product.GetVersionByCode(versionCode);

                Incident incidente = new Incident(indidentDescription);
                Ticket ticket = new Ticket(requestor,
                    productVersion,
                    incidente);
                return ticket;
            }
        }

    }
}
