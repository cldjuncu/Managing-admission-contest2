using System;
using System.Windows.Forms;
using ManagingAdmissionContest.Contracts;
using ManagingAdmissionContest.Entities;
using ManagingAdmissionContest.Presenters;

namespace ManagingAdmissionContest.Views
{
    public partial class FormularView : Form
    {
        public FormularView()
        {
            InitializeComponent();
        }

        public string ApplicantName
        {
            get { return textBox2.Text; }
        }
        public string ApplicantFirstname
        {
            get { return textBox1.Text; }
        }
        public string No
        {
            get { return textBox3.Text; }
        }

        public string NotaBac
        {
            get { return textBox4.Text; }
        }

        public string NotaMate
        {
            get { return textBox6.Text; }
        }

        public string NotaInfo
        {
            get { return textBox5.Text; }
        }

        public string NotaTest
        {
            get { return textBox7.Text; }
        }

        internal FormularPresenter Presenter { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.Submit();
        }
    }
}
