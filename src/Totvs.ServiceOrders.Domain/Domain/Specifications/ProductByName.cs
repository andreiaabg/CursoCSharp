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
    /// Especificação
    /// </summary>
    public class ProductByName : Specification<Product>
    {
        public string ProductName { get; set; }


        public ProductByName(string name)
        {
            ProductName = name;
            SatisfiedBy = product => product.Name == name;
        }
    }
}
