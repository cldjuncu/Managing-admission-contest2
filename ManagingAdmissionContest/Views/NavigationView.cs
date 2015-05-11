using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagingAdmissionContest.Contracts;
using ManagingAdmissionContest.Entities;
using ManagingAdmissionContest.Presenters;

namespace ManagingAdmissionContest.Views
{
    internal partial class NavigationView : UserControl
    {
        IApplicantDatabase appDatabase = ApplicantDatabase.InitializeDatabase("applicantDatabase\\applicantTable.txt");
        internal NavigationView()
        {   
            InitializeComponent();
        }

        internal NavigationPresenter Presenter { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.OpenFormular();
        }

        private void publishResults_Click(object sender, EventArgs e)
        {
            Presenter.OpenPublish();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Presenter.OpenLoadFromFile();
        }
    }
}
