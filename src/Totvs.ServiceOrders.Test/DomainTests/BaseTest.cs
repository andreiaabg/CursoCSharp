using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Foundation;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.UI.Util;
using Totvs.ServiceOrders.Domain.Services;
using Totvs.ServiceOrders.Domain.Repositories;
using System.Security.Principal;

namespace Totvs.ServiceOrders.UI.DomainTests
{
    /// <summary>
    /// Testes unitários
    /// </summary>
    public abstract class BaseTest
    {
        /// <summary>
        /// Configurar o banco de dados em memória
        /// </summary>
        public static InMemoryDatabase CreateTestInstance(string instanceName = null)
        {
            var stackTrace = new StackTrace(); 
            var stackFrame = stackTrace.GetFrames();

            instanceName = instanceName ?? stackFrame[1].GetMethod().Name;

            var database = new InMemoryDatabase(DateTime.MinValue, instanceName, typeof(Entity).Assembly);

            //autenticar
            Authentication authenticate = new Authentication();
            authenticate.Login(instanceName, instanceName);

            return database;
        }
    }
}
