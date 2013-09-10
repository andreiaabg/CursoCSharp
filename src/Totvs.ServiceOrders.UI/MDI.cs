using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Totvs.ServiceOrders.UI;

namespace Totvs.ServiceOrders.WinUI
{
    /// <summary>
    /// MDI
    /// </summary>
    public partial class MDI : Form
    {
        /// <summary>
        /// MDI
        /// </summary>
        public MDI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Efetua o Login
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            using (var login = new FormLogin())
            {
                login.ShowDialog();
            }
            Visible = Thread.CurrentPrincipal.Identity.IsAuthenticated;
            base.OnLoad(e);
        }

        /// <summary>
        /// Fecha o formulário em caso de Login sem sucesso.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!Thread.CurrentPrincipal.Identity.IsAuthenticated)
                Close();
        }
    }
}
