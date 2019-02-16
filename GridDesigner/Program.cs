using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridDesigner
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
            Application.Run(new GridDesigner());
        }
        ///
        /// Open source GridDesigner
        /// Copyright 2018 - Release 2019
        /// 
        /// Anhvietcr: fb.com/anhvietcr
        /// Buy a Project: anhvietcr.github.io
        /// 
    }
}
