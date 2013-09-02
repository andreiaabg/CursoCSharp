using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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


    }
}
