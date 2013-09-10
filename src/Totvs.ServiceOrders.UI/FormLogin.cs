using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Totvs.ServiceOrders.Domain.Services;

namespace Totvs.ServiceOrders.UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var authentication = new Authentication();
            authentication.Login(textBoxUser.Text, textBoxPassword.Text);
            var identity = Thread.CurrentPrincipal.Identity;

            try
            {

                if (!identity.IsAuthenticated)
                {
                    MessageBox.Show(string.Format("Usuário {0} não autenticado", identity.Name));
                    return;
                }
            }
            catch (SecurityException securityException)
            {
                MessageBox.Show(securityException.ToString());
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
