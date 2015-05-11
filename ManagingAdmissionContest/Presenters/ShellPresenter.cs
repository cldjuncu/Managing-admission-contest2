using System.Windows.Forms;

namespace ManagingAdmissionContest.Presenters
{
    internal class ShellPresenter
    {
        internal ShellPresenter()
        {
            View.Controls.Add(new NavigationPresenter().View);
        }

        internal Form View
        {
            get
            {
                if (shell == null)
                {
                    shell = new Shell();
                }
                return shell;
            }
        }

        private Form shell;
    }
}
