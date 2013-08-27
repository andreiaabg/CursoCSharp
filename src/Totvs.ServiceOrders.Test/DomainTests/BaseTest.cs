using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Totvs.OrdemServico.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.UI.Util;

namespace Totvs.ServiceOrders.UI.DomainTests
{
    public abstract class BaseTest
    {
        /// <summary>
        /// Configurar o banco de dados em memória
        /// </summary>
        protected static InMemoryDatabase CreateTestInstance(string instanceName = null)
        {
            var stackTrace = new StackTrace(); 
            var stackFrame = stackTrace.GetFrames();

            instanceName = instanceName ?? stackFrame[1].GetMethod().Name;

            //autenticar
            Thread.CurrentPrincipal = new UserPrincipal(new UserIdentity("Test", true, instanceName));
            var database = new InMemoryDatabase(new DateTime(2013, 7, 21, 21, 50, 0), typeof(Entity).Assembly);
            return database;
        }
    }
}
