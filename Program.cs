using System;
using System.Windows.Forms;
using CafeShopManagement.Forms;

namespace CafeShopManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 🔐 Show Login form first
            var loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }
}
