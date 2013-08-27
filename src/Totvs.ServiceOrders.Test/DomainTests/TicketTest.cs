using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.Factory;
using Totvs.ServiceOrders.Repositories;
using Totvs.ServiceOrders.UI.Util;

namespace Totvs.ServiceOrders.UI.DomainTests
{
    [TestClass]
    public class TicketTest : BaseTest
    {

        /// <summary>
        /// Quando: 
        ///     Ao Criar um Chamado
        /// Devemos:
        ///     Garantir que um identificador válido foi Gerado
        /// </summary>
        [TestMethod]
        public void CreateTicket()
        {
            //enviroment
            const string productName = "Classis";
            const string productversion = "11.90";
            const string requestorName = "andreia.goncalves";
            const string incidentDescriptor = "Não abre a tela de cadastro de aluno";
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
            Assert.AreEqual(1, ticket.Id);
        }
    }
}
