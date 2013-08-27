using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Totvs.OrdemServico.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.Factory;

namespace Totvs.ServiceOrders.UI.DomainTests
{
    [TestClass]
    public class ProductTest : BaseTest
    {

        private Lazy<List<Product>> _products;

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(Factory.Create.Product("P001", "1.0"));
            return products;
        }

        /// <summary>
        /// Quando:
        ///     Cadastramos uma Versão do Produto
        /// Devemos:
        ///     Certificar que a versão seja válida
        /// </summary>
        [TestMethod]
        public void ProductVersionValidateTest()
        {
            //enviroment
            const string productName = "Classis";
            const string productVersionCode = "11.90";
            {
                CreateTestInstance();
            }

            //test
            Product product = Create.Product(productName, productVersionCode);
            ProductVersion productVersion = product.GetVersionByCode(productVersionCode);
            Assert.IsNotNull(productVersion);
            Assert.AreEqual(productVersionCode, productVersion.Version.ToString());
            Assert.AreEqual(product, productVersion.Product);
        }
    }
}
