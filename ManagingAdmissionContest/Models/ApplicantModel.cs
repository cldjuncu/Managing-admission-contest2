using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagingAdmissionContest.Contracts;
using ManagingAdmissionContest.Entities;

namespace ManagingAdmissionContest.Models
{
    public class ApplicantModel
    {
        public ApplicantModel()
        {
            appDatabase = ApplicantDatabase.InitializeDatabase("applicantTable.txt");
        }

        internal void InsertRecord(Applicant app)
        {
            appDatabase.InsertRecord(app);
        }

        private IApplicantDatabase appDatabase;

        internal List<Applicant> SelectAllRecords()
        {
            return appDatabase.SelectAllRecords();
        }

        internal void TestPopulateDatabase()
        {
            Applicant applicant1 = new Applicant("1910541231783", "Adrian", "Botez", 8, 8.75, 6, 7.75, 0.0);

            Applicant applicant2 = new Applicant("2342184593201", "Victor", "Rachieru", 7, 4.75, 4, 4.5, 0.0);

            Applicant applicant3 = new Applicant("1314541890188", "Marius", "Zavincu", 8, 9.75, 10, 6.75, 0.0);

            appDatabase.InsertRecord(applicant1);
            appDatabase.InsertRecord(applicant2);
            appDatabase.InsertRecord(applicant3);
        }
    }
}
