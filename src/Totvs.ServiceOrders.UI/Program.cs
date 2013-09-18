using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Totvs.ServiceOrders.Domain.Repositories;
using Totvs.ServiceOrders.Infra.SqlServer;
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
            Configuration.ConnectionString("DataSource=(local);user=rm;pwd=rm");
            Configuration.Mapping();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDI());
        }


    }
}
