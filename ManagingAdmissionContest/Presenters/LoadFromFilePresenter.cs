using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagingAdmissionContest.Entities;
using ManagingAdmissionContest.Models;

namespace ManagingAdmissionContest.Presenters
{
   internal class LoadFromFilePresenter
    {
       public LoadFromFilePresenter()
       {
           //Generally you should do this in combo with injection. Inject the model.
           model = new ApplicantModel();
       }

       internal void Show()
       {
           //I did not clean up this code, just moved it.
           OpenFileDialog fd = new OpenFileDialog();
           fd.Filter = "txt files (*.txt)|*.txt";
           Stream myStream = null;
           if (fd.ShowDialog() == DialogResult.OK)
           {
               try
               {
                   if ((myStream = fd.OpenFile()) != null)
                   {
                       using (StreamReader sr = new StreamReader(myStream))
                       {
                           String line = sr.ReadLine();
                           char[] delimiterChars = { ',' };
                           string[] words = line.Split(delimiterChars);
                           Console.Write(words.Length);
                           if (words.Length == 7)
                           {
                               Applicant app = new Applicant(words[0], words[1], words[2], Double.Parse(words[3]), Double.Parse(words[4]), Double.Parse(words[5]), Double.Parse(words[6]), 0.0);
                               model.InsertRecord(app);
                               MessageBox.Show("Success!");
                           }
                           else MessageBox.Show("Bad file format");
                       }
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
               }
           }
       }

       private ApplicantModel model;
    }
}
