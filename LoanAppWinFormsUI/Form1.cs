using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanAppWinFormsUI
{
    public partial class MortgageAppMain : Form
    {
        

        public MortgageAppMain()
        {
            InitializeComponent();

        }

        private void btnCalculateMortgageSchedule_Click(object sender, EventArgs e)
        {
            var mortgageExtraPayments = new MortgageInputExtraPayments();
        }
    }
}
