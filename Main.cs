using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OnvifAssistant
{
    static class CamMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormOnvif());
        }
    }
}
