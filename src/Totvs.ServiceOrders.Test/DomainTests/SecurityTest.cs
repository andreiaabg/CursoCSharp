using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Repositories;
using Totvs.ServiceOrders.Domain.Services;

namespace Totvs.ServiceOrders.UI.DomainTests
{
    [TestClass]
    public class SecurityTest : BaseTest
    {
        /// <summary>
        /// Quando:
        ///     Passar um usuário e senha válido
        /// Devo:
        ///     Ter como identificador da Thread um 'UserIdentity' válido
        /// </summary>
        [TestMethod]
        public void _()
        {
            CreateTestInstance();
            using (Users users = new Users())
            {
                var user = new Domain.Entities.User("mestre", "totvs");
                users.Insert(user);
            }


            var authentication = new Authentication();
            authentication.Login("mestre", "totvs");
            Assert.IsTrue(Thread.CurrentPrincipal is UserPrincipal, "Não definiu um UserIdentity válido");
            Assert.IsTrue((Thread.CurrentPrincipal.Identity as UserIdentity).IsAuthenticated);
            Assert.AreEqual("mestre", (Thread.CurrentPrincipal.Identity as UserIdentity).Name);
        }


        [TestMethod]
        public void _2()
        {
            CreateTestInstance();
            using (Users users = new Users())
            {
                var user = new Domain.Entities.User("mestre", "totvs2");
                users.Insert(user);
            }


            var authentication = new Authentication();
            authentication.Login("mestre", "totvs");
            Assert.IsTrue(Thread.CurrentPrincipal is System.Security.Principal.GenericPrincipal, "Não definiu um UserIdentity válido");
            Assert.IsFalse((Thread.CurrentPrincipal.Identity as UserIdentity).IsAuthenticated);
            Assert.AreEqual("mestre", (Thread.CurrentPrincipal.Identity as UserIdentity).Name);
        }
    }
}
