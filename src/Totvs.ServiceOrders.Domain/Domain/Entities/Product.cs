using System;
using System.Collections.Generic;
using System.Linq;
using Totvs.ServiceOrders.Helper;

namespace Totvs.ServiceOrders.Domain.Entities
{
    /// <summary>
    /// Entidade: Produto
    /// -- Identificar
    /// </summary>
    public class Product : Entity
    {
        /// <summary>
        /// Id: Nome
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Produto
        /// </summary>
        /// <param name="name">Nome do Produto</param>
        internal Product(string name, IList<ProductVersion> productVersions)
        {
            this.Name = name;
            this.Versions = productVersions.ToLazy();
        }
        
        /// <summary>
        /// Produto
        /// </summary>
        internal Product() 
        { 
        } 

        /// <summary>
        /// Todas as versões
        /// </summary>
        public Lazy<IList<ProductVersion>> Versions { get; internal set; }

        /// <summary>
        /// Obtem a versão existente do produto pelo código
        /// </summary>
        public ProductVersion GetVersionByCode(string code)
        {
            return Versions.Value.FirstOrDefault((productVersion) => productVersion.Version.ToString().Equals(code));
        }
    }
}
