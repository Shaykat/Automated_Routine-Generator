using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;


namespace Automated_Routine_Generator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            parse p = new Parsegradebysem();
            Parsegradebysem pgs = new Parsegradebysem();
            pgs.getgradedetails();
            //pgs.insertgradeinfo();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Log_In());
            //Application.Run(new Routine_Criteria());
        }
    }
}
