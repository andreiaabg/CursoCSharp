using System;

namespace Totvs.ServiceOrders.Domain.Entities
{
    /// <summary>
    /// Versão do Produto
    /// 
    /// --Agregação de Produto
    /// </summary>
    public class ProductVersion : Entity
    {
        /// <summary>
        /// Versão do Produto
        /// </summary>
        /// <param name="product">Produto</param>
        /// <param name="version">Versão</param>
        public ProductVersion(Product product, Version version)
        {
            Version = version;
            Product = product;
        }

        /// <summary>
        /// Id: Código da Versão
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// Id: Código do Produto
        /// </summary>
        public Product Product { get; set; }
    }
}
