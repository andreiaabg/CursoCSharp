using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Totvs.ServiceOrders.Domain.Repositories;
using Totvs.ServiceOrders.UI.DomainTests;
using Totvs.ServiceOrders.WinUI;

namespace Totvs.ServiceOrders.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateDatabaseMemory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDI());
        }

        private static void CreateDatabaseMemory()
        {
            var principal = Thread.CurrentPrincipal;
            BaseTest.CreateTestInstance();
            using (Users users = new Users())
            {
                var user = new Domain.Entities.User("mestre", "totvs");
                users.Insert(user);
            }
            Thread.CurrentPrincipal = principal;
        }
    }
}
