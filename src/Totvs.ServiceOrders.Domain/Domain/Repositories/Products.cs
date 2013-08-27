using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.OrdemServico.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.Domain.Specifications;

namespace Totvs.ServiceOrders.Repositories
{
    /// <summary>
    /// Repositório: Produtos
    /// </summary>
    public class Products : Repository<Product>
    {
        /// <summary>
        /// Obtém os produtos pelo nome
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Product GetByName(string name)
        {
            ProductByName specification = new ProductByName(name);
            return base.Get(specification);
        }

        /// <summary>
        /// Verifica se existe algum produto com o nome especificado
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AnyByName(string name)
        {
            ProductByName specification = new ProductByName(name);
            return base.Any(specification);
        }

        /// <summary>
        /// Adiciona um novo produto na base de dados
        /// </summary>
        /// <param name="product">produto</param>
        public override void Insert(Product product)
        {
            Repository<ProductVersion> productVersions = new Repository<ProductVersion>();
            IList<ProductVersion> versions = product.Versions.Value;
            foreach (ProductVersion version in product.Versions.Value)
                productVersions.Insert(version);
            base.Insert(product);
        }
    }
}
