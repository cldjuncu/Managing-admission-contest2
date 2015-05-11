using System;
using System.Windows.Forms;
using ManagingAdmissionContest.Entities;
using ManagingAdmissionContest.Models;
using ManagingAdmissionContest.Views;

namespace ManagingAdmissionContest.Presenters
{
    internal class FormularPresenter
    {
        public FormularPresenter()
        {
            //Normally should be done via injection
            Model = new ApplicantModel();
        }

        internal void Show()
        {
            View = new FormularView();
            View.Presenter = this;
            View.ShowDialog();
        }

        internal void Submit()
        {
             decimal myDec;
            if (string.IsNullOrWhiteSpace(View.ApplicantFirstname) ||
                string.IsNullOrWhiteSpace(View.ApplicantName) ||
                string.IsNullOrWhiteSpace(View.No) ||
                string.IsNullOrWhiteSpace(View.NotaBac) ||
                string.IsNullOrWhiteSpace(View.NotaInfo) ||
                string.IsNullOrWhiteSpace(View.NotaMate)
                )
            {
                MessageBox.Show("All fields must be field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(View.NotaBac, out myDec))
            {
                MessageBox.Show("Baccalaureat grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(View.NotaInfo, out myDec))
            {
                MessageBox.Show("Computer Science grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(View.NotaMate, out myDec))
            {
                MessageBox.Show("Mathematics grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             else
            {
                Applicant applicant = new Applicant(View.No, View.ApplicantFirstname, View.NotaInfo, Double.Parse(View.NotaTest), Double.Parse(View.NotaBac), Double.Parse(View.NotaInfo), Double.Parse(View.NotaMate),0.0);
                Model.InsertRecord(applicant);
                View.Close();
                MessageBox.Show("Success!");

            }
            
        }

        private FormularView View;
        private ApplicantModel Model;
    }
}
