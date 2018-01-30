using System;
using System.Windows.Forms;
using TIUtilities.Logic;

namespace Sandbox
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SingleInstance.Application.Run(new Form1());

        }
    }
}
