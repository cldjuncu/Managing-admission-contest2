using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ManagingAdmissionContest.Contracts;
using ManagingAdmissionContest.Entities;
using ManagingAdmissionContest.Views;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using System.IO;

namespace ManagingAdmissionContest
{
    public partial class Shell : Form
    {
        public  Shell()
        {
            InitializeComponent();
        }
    }
}
