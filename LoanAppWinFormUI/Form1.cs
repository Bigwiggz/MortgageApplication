using MortgageAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanAppWinFormUI
{
    public partial class Mortgage : Form
    {
        private DataGridView dgvExtraPayment = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        private BindingList<ExtraPayments> extraPaymentList = new BindingList<ExtraPayments>();
        public Mortgage()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void extraPayment_Enter(object sender, EventArgs e)
        {

        }

        
        
        private void AddExtraPayment(object sender, EventArgs e)
        {
            
            var extraPayment = new ExtraPayments()
            {
                ExtraPaymentAmount = Decimal.Parse(txtExtraPaymentAmount.Text),
                NumberofPayments=Int32.Parse(txtNumberofPayments.Text),
                PaymentInterval= Int32.Parse(txtPaymentInterval.Text),
                StartDate=DateTime.Parse(dtExtraPaymentStartDate.Text)
            };

            extraPaymentList.Add(extraPayment);
            bindingSource1.Add(extraPayment);

           
            // Initialize the DataGridView.
            dgvExtraPayment.AutoGenerateColumns = false;
            dgvExtraPayment.AutoSize = true;
            dgvExtraPayment.DataSource = bindingSource1;

            // Initialize and add a text box column.
            DataGridViewColumn column1 = new DataGridViewTextBoxColumn();
            column1.DataPropertyName = "ExtraPaymentAmount";
            column1.Name = "Extra Payment";
            dgvExtraPayment.Columns.Add(column1);

            // Initialize and add a text box column.
            DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
            column2.DataPropertyName = "StartDate";
            column2.Name = "Dateof First Payment";
            dgvExtraPayment.Columns.Add(column2);

            // Initialize and add a text box column.
            DataGridViewColumn column3 = new DataGridViewTextBoxColumn();
            column3.DataPropertyName = "NumberofPayments";
            column3.Name = "No of Payments";
            dgvExtraPayment.Columns.Add(column3);

            // Initialize and add a text box column.
            DataGridViewColumn column4 = new DataGridViewTextBoxColumn();
            column4.DataPropertyName = "PaymentInterval";
            column4.Name = "Interval";
            dgvExtraPayment.Columns.Add(column4);

            //Clear all textbox values
            txtExtraPaymentAmount.Clear();
            txtDownPayment.Clear();
            txtNumberofPayments.Clear();
            txtPaymentInterval.Clear();
        }

        private void CreateMortgage(object sender, EventArgs e)
        {
            if (extraPaymentList.Count>0)
            {
                //Continue with programs
            }
            else
            {

                string message= "Are you sure you do not want to add any extra payments?";
                string title = "Extra Payments?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                var warning = MessageBoxIcon.Warning;

                DialogResult result = MessageBox.Show(message, title, buttons, warning);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    //Continue with programs
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
