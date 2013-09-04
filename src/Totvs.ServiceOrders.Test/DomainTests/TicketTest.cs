using Microsoft.VisualStudio.TestTools.UnitTesting;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.Domain.Exceptions;
using Totvs.ServiceOrders.Factory;
using Totvs.ServiceOrders.Repositories;
using Totvs.ServiceOrders.UI.Util;

namespace Totvs.ServiceOrders.UI.DomainTests
{
    /// <summary>
    /// Testes : Chamado
    /// </summary>
    [TestClass]
    public class TicketTest : BaseTest
    {
        const string productName = "Classis";
        const string productversion = "11.90";
        const string requestorName = "andreia.goncalves";
        const string incidentDescriptor = "Não abre a tela de cadastro de aluno";

        /// <summary>
        /// Quando: 
        ///     Ao Criar um Chamado
        /// Devemos:
        ///     Garantir que um identificador válido foi Gerado
        /// </summary>
        [TestMethod]
        public void When_CreateTicket_ShouldReturnValidTicket()
        {
            //enviroment
            {
                CreateTestInstance();
                using (var products = new Products())
                {
                    var product = Factory.Create.Product(productName, productversion);
                    products.Insert(product);
                }
            }

            //test
            Requestor requestor = new Requestor(requestorName);
            Ticket ticket = Create.Ticket(requestor, productName, productversion, incidentDescriptor);
            Assert.IsNotNull(ticket);
            Assert.AreEqual(ticket.Requestor, requestor);
            Assert.AreEqual(ticket.ProductVersion.Product.Name, productName);
            Assert.AreEqual(ticket.ProductVersion.Version.ToString(), productversion);
            Assert.AreEqual(ticket.Incident.Description, incidentDescriptor);
        }



        /// <summary>
        /// Quando:
        ///     Tentamos criar um chamado de um produto que não exista na base de dados
        /// Devemos:
        ///     Subir a exceção 'ProductNotFound'
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ProductNotFoundException))]
        public void When_CreateTicketWithProductNotRegistered_ShouldProductNotFoundException()
        {
            //enviroment
            {
                CreateTestInstance();
            }

            //test
            Requestor requestor = new Requestor(requestorName);
            Create.Ticket(requestor, productName, productversion, incidentDescriptor);
        }

        /// <summary>
        /// Quando:
        ///     Tentamos criar um chamado de um produto cuja versão não exista na base de dados
        /// Devemos:
        ///     Subir a exceção 'VersionNotFound'
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(VersionNotFoundException))]
        public void When_CreateTicketWithVersionNotRegistered_ShouldVersionNotFoundException()
        {
            const string existVersion = "10.00";
            const string tryOtherVersion = "12.00";

            //enviroment
            {
                CreateTestInstance();
                using (var products = new Products())
                {
                    var product = Create.Product(productName, existVersion);
                    products.Insert(product);
                }
            }

            //test
            Requestor requestor = new Requestor(requestorName);
            Create.Ticket(requestor, productName, tryOtherVersion, incidentDescriptor);
        }



    }
}
