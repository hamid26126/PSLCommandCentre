using System;
using System.Windows.Forms;
using PSLCommandCentre.Forms;
using PSLCommandCentre.Helpers;

namespace PSLCommandCentre
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}