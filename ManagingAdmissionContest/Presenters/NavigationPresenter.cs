using ManagingAdmissionContest.Views;

namespace ManagingAdmissionContest.Presenters
{
    internal class NavigationPresenter
    {
        internal NavigationPresenter()
        {
            View.Presenter = this;

            //Generally you should resolve all the presenters here via dependancy injection.
            //Yes that means an itnerface for the presenter etc.
            formularPresenter = new FormularPresenter();
            loadFromFilePresenter = new LoadFromFilePresenter();
            publishPresenter = new PublishPresenter();
        }

        internal NavigationView View
        {
            get
            {
                if (navView == null)
                {
                    navView = new NavigationView();
                }
                return navView;
            }
        }

        internal void OpenFormular()
        {
            formularPresenter.Show();
        }

        internal void OpenPublish()
        {
            publishPresenter.Show();
        }
      
        internal void OpenLoadFromFile()
        {
            loadFromFilePresenter.Show();
        }

        private NavigationView navView;
        private readonly FormularPresenter formularPresenter;
        private readonly PublishPresenter publishPresenter;
        private readonly LoadFromFilePresenter loadFromFilePresenter;
    }
}
