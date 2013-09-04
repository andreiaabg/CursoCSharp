using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Services;

namespace Totvs.ServiceOrders.UI.DomainTests
{
    [TestClass]
    public class SecurityTest
    {
        /// <summary>
        /// Quando:
        ///     Passar um usuário e senha válido
        /// Devo:
        ///     Ter como identificador da Thread um 'UserIdentity' válido
        /// </summary>
        public void _()
        {
            var authentication = new Authentication();
            authentication.Login("mestre", "totvs");
            Assert.IsTrue(Thread.CurrentPrincipal is UserIdentity, "Não definiu um UserIdentity válido");
            Assert.IsTrue((Thread.CurrentPrincipal as UserIdentity).IsAuthenticated);
            Assert.AreEqual("mestre", (Thread.CurrentPrincipal as UserIdentity).Name);
        }

    }
}
