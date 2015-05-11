using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagingAdmissionContest.Entities;
using ManagingAdmissionContest.Models;
using ManagingAdmissionContest.Views;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace ManagingAdmissionContest.Presenters
{
    internal class PublishPresenter
    {

        public PublishPresenter()
        {
            Model = new ApplicantModel();
            Model.TestPopulateDatabase();
        }

        internal void Show()
        {
            View = new PublishView();
            View.Presenter = this;
            View.ShowDialog();
        }

        internal void ShowGridDialog()
        {
            //Mayne it would be better to make a form with the gridview on there.
            //So call a presenter that shows this form with supplied model or w.e
            Form fm = new Form();
            DataGridView dg = new DataGridView();
            dg.ColumnCount = 3;
            dg.Columns[0].HeaderText = "Name";
            dg.Columns[1].HeaderText = "Grade";
            dg.Columns[2].HeaderText = "Status";
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            var listApplicantsSortedByGrade = GetSortedList();
            foreach (Applicant applicant in listApplicantsSortedByGrade)
            {
                var index = listApplicantsSortedByGrade.IndexOf(applicant);
                var limitTotalAdmitted = Double.Parse(View.BudgetFinanced) + Double.Parse(View.FeePayer);

                XSolidBrush brush;
                string typeCandidate = "";
                if (index < Double.Parse(View.BudgetFinanced))
                {
                    typeCandidate = "budget-financed";
                    brush = XBrushes.Green;
                }
                else if (index < limitTotalAdmitted)
                {
                    typeCandidate = "fee payer";
                    brush = XBrushes.Black;
                }
                else
                {
                    typeCandidate = "rejected";
                    brush = XBrushes.Red;
                }

                dg.Rows.Add(applicant.Name + " " + applicant.Surname, applicant.AdmissionGrade, typeCandidate);
            }

            fm.Controls.Add(dg);
            fm.ShowDialog();
            View.Hide();
        }

        private List<Applicant> GetSortedList()
        {
            List<Applicant> listApplicants = Model.SelectAllRecords();

            foreach (var applicant in listApplicants)
            {
                var index = listApplicants.IndexOf(applicant);
                var grades = new List<double> {applicant.MathGrade, applicant.InfoGrade, applicant.TestGrade};
                double avgPonderateGrade = applicant.TestGrade/2 + applicant.BacGrade/4 + grades.Max()/4;

                applicant.AdmissionGrade = avgPonderateGrade;
            }

            var listApplicantsSortedByGrade = listApplicants.OrderByDescending(s => s.AdmissionGrade).ToList();

            return listApplicantsSortedByGrade;
        }

        private PublishView View { get; set; }
        private ApplicantModel Model { get; set; }

        internal void GeneratePdf()
        {
            WriteResultsToPdfFile(GetSortedList(), Double.Parse(View.BudgetFinanced), Double.Parse(View.FeePayer));
            View.Hide();
        }


        private void WriteResultsToPdfFile(List<Applicant> listApplicantsSortedByGrade, double limitBudget,
            double limitFeePayer)
        {
            PdfDocument pdf = new PdfDocument();

            PdfPage pdfPage = pdf.AddPage();

            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            XFont fontTitle = new XFont("Verdana", 20, XFontStyle.Regular);

            graph.DrawString("Faculty admission contest",
                fontTitle,
                XBrushes.Black,
                new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point),
                XStringFormats.TopCenter
                );

            int yPoint = 40;

            XFont fontEntries = new XFont("Verdana", 16, XFontStyle.Regular);

            foreach (Applicant applicant in listApplicantsSortedByGrade)
            {
                var index = listApplicantsSortedByGrade.IndexOf(applicant);
                var limitTotalAdmitted = limitBudget + limitFeePayer;

                XSolidBrush brush;
                string typeCandidate = "";
                if (index < limitBudget)
                {
                    typeCandidate = "budget-financed";
                    brush = XBrushes.Green;
                }
                else if (index < limitTotalAdmitted)
                {
                    typeCandidate = "fee payer";
                    brush = XBrushes.Black;
                }
                else
                {
                    typeCandidate = "rejected";
                    brush = XBrushes.Red;
                }

                graph.DrawString(applicant.Surname + " " + applicant.Name, fontEntries, XBrushes.Black,
                    new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                graph.DrawString(applicant.AdmissionGrade.ToString(), fontEntries, XBrushes.Black,
                    new XRect(280, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                graph.DrawString(typeCandidate, fontEntries, brush,
                    new XRect(420, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                yPoint = yPoint + 40;
            }

            pdf.Save("ResultsPDF.pdf");

            Process.Start("ResultsPDF.pdf");
        }

        private void WriteResultsToHTML(List<Applicant> listApplicantsSortedByGrade, double limitBudget,
            double limitFeePayer)
        {
            string path = "results.htm";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("<!DOCTYPE html>");
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<title>Results</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body >");
                sw.WriteLine("<table border = \"1\">");
                sw.WriteLine("<tr>");

                foreach (Applicant applicant in listApplicantsSortedByGrade)
                {
                    var index = listApplicantsSortedByGrade.IndexOf(applicant);
                    var limitTotalAdmitted = limitBudget + limitFeePayer;

                    XSolidBrush brush;
                    string typeCandidate = "";
                    if (index < limitBudget)
                    {
                        typeCandidate = "budget-financed";
                        brush = XBrushes.Green;
                    }
                    else if (index < limitTotalAdmitted)
                    {
                        typeCandidate = "fee payer";
                        brush = XBrushes.Black;
                    }
                    else
                    {
                        typeCandidate = "rejected";
                        brush = XBrushes.Red;
                    }

                    sw.WriteLine("<td>" + applicant.Surname + " " + applicant.Name + "<td>");
                    sw.WriteLine("<td>" + applicant.AdmissionGrade + "</td>");
                    sw.WriteLine("<td>" + typeCandidate + "<td>");
                    sw.WriteLine("</tr>");
                }
                sw.WriteLine("</table>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start("results.htm");
        }

        internal void GenerateHtml()
        {
            WriteResultsToHTML(GetSortedList(), Double.Parse(View.BudgetFinanced), Double.Parse(View.FeePayer));
            View.Hide();
        }
    }
}
