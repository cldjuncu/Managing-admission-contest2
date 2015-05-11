using System;
using System.Windows.Forms;
using ManagingAdmissionContest.Presenters;

namespace ManagingAdmissionContest
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
            var context = new ApplicationContext();
            var presenter = new ShellPresenter();
            context.MainForm = presenter.View;
            Application.Run(context);
        }
    }
}
