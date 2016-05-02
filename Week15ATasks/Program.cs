using System;
using System.Windows.Forms;

namespace Week15ATasks
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InputValidator());
        }
    }
}
