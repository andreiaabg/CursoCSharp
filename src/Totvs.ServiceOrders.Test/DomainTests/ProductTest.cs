using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Totvs.ServiceOrders.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.Factory;
using Totvs.ServiceOrders.Repositories;

namespace Totvs.ServiceOrders.UI.DomainTests
{
    [TestClass]
    public class ProductTest : BaseTest
    {
        const string productName = "Classis";
        const string productVersionCode = "11.90";

        /// <summary>
        /// Quando:
        ///     Cadastramos uma Versão do Produto
        /// Devemos:
        ///     Certificar que a versão seja válida
        /// </summary>
        [TestMethod]
        public void When_CreateAndInsertNewProduct_ShouldCreateValidProductVersion()
        {
            DateTime now = new DateTime(2013, 7, 21, 12, 0, 0);
            {
                CreateTestInstance().NowFake = now;
            }

            using (Products products = new Products())
            {
                Product product = Create.Product(productName, productVersionCode);
                ProductVersion productVersion = product.GetVersionByCode(productVersionCode);
                Assert.IsNotNull(productVersion);
                products.Insert(product);

                Assert.AreEqual(productVersionCode, productVersion.Version.ToString());
                Assert.AreEqual(product, productVersion.Product);
                Assert.AreEqual("ProductVersionValidateTest", product.CreatedBy);
                Assert.AreEqual(now, product.CreatedAt);
            }
        }
    }
}
