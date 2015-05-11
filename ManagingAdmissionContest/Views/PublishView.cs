using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ManagingAdmissionContest.Contracts;
using ManagingAdmissionContest.Entities;
using ManagingAdmissionContest.Presenters;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace ManagingAdmissionContest.Views
{
    public partial class PublishView : Form
    {
        public PublishView()
        {
            InitializeComponent();
        }

        internal string BudgetFinanced
        {
            get { return budgetFinanced.Text; }
        }

        internal string FeePayer
        {
            get { return feePayer.Text; }
        }

        private void budgetFinanced_TextChanged(object sender, EventArgs e)
        {  
            int result;
            if (string.IsNullOrWhiteSpace(budgetFinanced.Text))
                MessageBox.Show("Field cannot be empty");
            
            if (!Int32.TryParse(budgetFinanced.Text, out result))
            {
                MessageBox.Show("Please enter only numbers.");

                if (budgetFinanced.Text.Length >= 1)
                {
                    budgetFinanced.Text = budgetFinanced.Text.Remove(budgetFinanced.Text.Length - 1);
                }
            }
        }


        private void feePayer_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(feePayer.Text))
                MessageBox.Show("Field cannot be empty");
            int result = 0;

            if (!Int32.TryParse(feePayer.Text, out result))
            {
                MessageBox.Show("Please enter only numbers.");

                if (feePayer.Text.Length >= 1)
                {
                    feePayer.Text = feePayer.Text.Remove(feePayer.Text.Length - 1);
                }
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(budgetFinanced.Text) || string.IsNullOrWhiteSpace(feePayer.Text))
            {
                MessageBox.Show("Field cannot be empty");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Presenter.ShowGridDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Presenter.GeneratePdf();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Presenter.GenerateHtml();
            }
          
        }

        internal PublishPresenter Presenter { get; set; }
    }
}