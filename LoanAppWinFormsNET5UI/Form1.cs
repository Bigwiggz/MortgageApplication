using MortgageAppLibrary.Models;
using MortgageAppLibrary.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoanAppWinFormsNET5UI.FormattingExtensions;
using LoanAppWinFormsNET5UI.Properties;
using MortgageAppLibrary.Services.Excel;
using System.IO;
using MortgageAppLibrary.Services.TextFile;
using MortgageAppLibrary.Services.MortgageServices;
using System.Globalization;

namespace LoanAppWinFormsNET5UI
{
    public partial class mainForm : Form
    {

        
        private BindingList<ExtraPayments> extraPaymentsList = new BindingList<ExtraPayments>();
        private MortgageInputExtraPayments mortgageInput = new MortgageInputExtraPayments();
        private MortgageInput baseMortgageInput = new MortgageInput();
        private BindingList<MonthlyCalculatedValuesExtraPayments> amortizationScheduleBindingList = new BindingList<MonthlyCalculatedValuesExtraPayments>();
        private MortgageExecutiveSummary execSummary = new MortgageExecutiveSummary();
        private List<MonthlyCalculatedValues> basicAmmortizationSchedule = new List<MonthlyCalculatedValues>();


        private MortgageExecutiveSummaryService _mortgageExecutiveSummaryService=new MortgageExecutiveSummaryService();
        private MortgagePaymentScheduleService _mortgagePaymentScheduleService = new MortgagePaymentScheduleService();

        private decimal? enteredTxtTotalAmount;
        private decimal? enteredtxtDownPayment;
        private decimal? enteredtxtExtraPaymentAmount;
        private decimal? enteredTxtInterestRate;

        //Add Event Class
        public event EventHandler btnAddExtraPaymentClicked;

        protected virtual void OnClickbtnAddExtraPaymentTest(EventArgs e)
        {
            btnAddExtraPaymentClicked?.Invoke(this, e);
        }

        public mainForm()
        {
            InitializeComponent();

            var imageProcessor = new ImageProcessing();
            Image excelIconCopy = new Bitmap(Resources.excelIcon);
            excelIconCopy = imageProcessor.resizeImage(excelIconCopy, new Size(40, 40));

            btnCreateExcelFile.Enabled = false;
            btnCreateTextFile.Enabled = false;


        }
        
        private void btnAddExtraPayment_Click(object sender, EventArgs e)
        {
            //clear all extra payments

            lblExtraPaymentAmountValidation.Text = "ValidationText";
            lblExtraPaymentAmountValidation.Visible = false;

            lblExtraPaymentsStartDateValidation.Text = "ValidationText";
            lblExtraPaymentsStartDateValidation.Visible = false;

            lblNumberofPaymentsValidation.Text = "ValidationText";
            lblNumberofPaymentsValidation.Visible = false;

            lblPaymentIntervalValidation.Text = "ValidationText";
            lblPaymentIntervalValidation.Visible = false;

            //Fire Event
            OnClickbtnAddExtraPaymentTest(EventArgs.Empty);

            //Create new extra payment
            ExtraPayments extraPayment = new ExtraPayments();

            //Add value to extra payment
            extraPayment.ExtraPaymentAmount = enteredtxtExtraPaymentAmount.Value;
            extraPayment.NumberofPayments = Int32.Parse(txtNumberofExtraPayments.Text);
            extraPayment.PaymentInterval = Int32.Parse(txtPaymentInterval.Text);
            extraPayment.StartDate = dtFirstExtraPayment.Value;

            //Validate the extra payment
            var extraPaymentValidator = new ExtraPaymentsValidator();
            var result = extraPaymentValidator.Validate(extraPayment);

            if (result.IsValid)
            {
                //Add extra payment to list
                extraPaymentsList.Add(extraPayment);
            }
            else
            {
                //throw an error
                foreach (var failure in result.Errors)
                {
                    switch (failure.PropertyName)
                    {
                        case "ExtraPaymentAmount":
                            lblExtraPaymentAmountValidation.Text = failure.ErrorMessage;
                            lblExtraPaymentAmountValidation.Visible = true;
                            break;
                        case "StartDate":
                            lblExtraPaymentsStartDateValidation.Text = failure.ErrorMessage;
                            lblExtraPaymentsStartDateValidation.Visible = true;
                            break;
                        case "NumberofPayments":
                            lblNumberofPaymentsValidation.Text = failure.ErrorMessage;
                            lblNumberofPaymentsValidation.Visible = true;
                            break;
                        case "PaymentInterval":
                            lblPaymentIntervalValidation.Text = failure.ErrorMessage;
                            lblPaymentIntervalValidation.Visible = true;
                            break;
                    }
                }
            }

            if (extraPaymentsList.Count == 1)
            {
                //Extra Payments
                dgvExtraPaymentsTable.AutoGenerateColumns = false;
                //dgvExtraPaymentsTable.AutoSizeColumnsMode = true;
                var source2 = new BindingSource(extraPaymentsList, null);
                dgvExtraPaymentsTable.DataSource = source2;

                // Initialize and add column Extra Payment Amt
                DataGridViewColumn column1A = new DataGridViewTextBoxColumn();
                column1A.DataPropertyName = "ExtraPaymentAmount";
                column1A.Frozen = false;
                column1A.Name = "Extra Payment Amt";
                dgvExtraPaymentsTable.Columns.Add(column1A);

                // Initialize and add column Date
                DataGridViewColumn column2A = new DataGridViewTextBoxColumn();
                column2A.DataPropertyName = "StartDate";
                column2A.Frozen = false;
                column2A.Name = "Date";
                dgvExtraPaymentsTable.Columns.Add(column2A);

                // Initialize and add column No of Payments
                DataGridViewColumn column3A = new DataGridViewTextBoxColumn();
                column3A.DataPropertyName = "NumberofPayments";
                column3A.Frozen = false;
                column3A.Name = "No of Payments";
                dgvExtraPaymentsTable.Columns.Add(column3A);

                // Initialize and add column Payment Interval
                DataGridViewColumn column4A = new DataGridViewTextBoxColumn();
                column4A.DataPropertyName = "PaymentInterval";
                column4A.Frozen = false;
                column4A.Name = "Payment Interval";
                dgvExtraPaymentsTable.Columns.Add(column4A);

                //Column formatting
                dgvExtraPaymentsTable.Columns["Extra Payment Amt"].DefaultCellStyle.Format = "c";
                dgvExtraPaymentsTable.ScrollBars = ScrollBars.Vertical;
            }


        }

        private void btnCalculateMortgage_Click(object sender, EventArgs e)
        {
            //clear all ValidationText and make them invisible

            lblTotalLoanAmountValidation.Text = "ValidationText";
            lblTotalLoanAmountValidation.Visible = false;

            lblDownPaymentValidation.Text = "ValidationText";
            lblDownPaymentValidation.Visible = false;

            lblLoanTermValidation.Text = "ValidationText";
            lblLoanTermValidation.Visible = false;

            lblInterestRateValidation.Text = "ValidationText";
            lblInterestRateValidation.Visible = false;

            lblExtraPaymentsStartDateValidation.Text = "ValidationText";
            lblExtraPaymentsStartDateValidation.Visible = false;


            //Add the Mortgage Value Information
            mortgageInput.TotalLoanAmount = enteredTxtTotalAmount.Value;
            mortgageInput.DownPayment = enteredtxtDownPayment.Value;
            mortgageInput.InterestRate = enteredTxtInterestRate.Value;
            mortgageInput.LoanTerm = Int32.Parse(txtLoanTerm.Text);
            mortgageInput.StartDate = dtMortgageStartDate.Value;
            mortgageInput.ExtraPayments = extraPaymentsList.ToList();

            //Add base mortgageInput
            baseMortgageInput.TotalLoanAmount = enteredTxtTotalAmount.Value;
            baseMortgageInput.DownPayment = enteredtxtDownPayment.Value;
            baseMortgageInput.InterestRate = enteredTxtInterestRate.Value;
            baseMortgageInput.LoanTerm = Int32.Parse(txtLoanTerm.Text);
            baseMortgageInput.StartDate = dtMortgageStartDate.Value;

            //Validate
            var mortgageInputValidator = new MortgageInputExtraPaymentsValidator();
            var result = mortgageInputValidator.Validate(mortgageInput);
            
            if (result.IsValid)
            {
                //Show Group Results Box
                gbResults.Visible = true;

                //Create Amortization Schedule
                var amortizationSchedule = _mortgagePaymentScheduleService.CalculatedExtraPaymentPeriodMortgageData(mortgageInput);

                //Create Base Amortization Schedule
                var baseAmortizationSchedule1 = _mortgagePaymentScheduleService.CalculatedPeriodMortgageData(baseMortgageInput);
                basicAmmortizationSchedule = baseAmortizationSchedule1;

                //Map schedule to dgv in results
                amortizationScheduleBindingList = new BindingList<MonthlyCalculatedValuesExtraPayments>(amortizationSchedule);

                //Amortization Schedule
                dgvAmortizationSchedule.AutoGenerateColumns = false;
                //dgvAmortizationSchedule.AutoSize = true;
                var source = new BindingSource(amortizationScheduleBindingList, null);
                dgvAmortizationSchedule.DataSource = source;

                // Initialize and add column IDNumber
                DataGridViewColumn column0 = new DataGridViewTextBoxColumn();
                column0.DataPropertyName = "IDNumber";
                column0.Frozen = false;
                column0.Name = "No";
                dgvAmortizationSchedule.Columns.Add(column0);

                // Initialize and add column DateColumn
                DataGridViewColumn column1 = new DataGridViewTextBoxColumn();
                column1.DataPropertyName = "DateColumn";
                column1.Frozen = false;
                column1.Name = "Date";
                dgvAmortizationSchedule.Columns.Add(column1);

                // Initialize and add column RemainingBalance
                DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
                column2.DataPropertyName = "RemainingBalance";
                column2.Frozen = false;
                column2.Name = "Balance";
                dgvAmortizationSchedule.Columns.Add(column2);

                // Initialize and add column fixedPayment
                DataGridViewColumn column3 = new DataGridViewTextBoxColumn();
                column3.DataPropertyName = "fixedPayment";
                column3.Frozen = false;
                column3.Name = "Monthly Payment";
                dgvAmortizationSchedule.Columns.Add(column3);

                // Initialize and add column PrincipalPaid
                DataGridViewColumn column4 = new DataGridViewTextBoxColumn();
                column4.DataPropertyName = "PrincipalPaid";
                column4.Frozen = false;
                column4.Name = "Principal";
                dgvAmortizationSchedule.Columns.Add(column4);

                // Initialize and add column InterestPaid
                DataGridViewColumn column5 = new DataGridViewTextBoxColumn();
                column5.DataPropertyName = "InterestPaid";
                column5.Frozen = false;
                column5.Name = "Interest";
                dgvAmortizationSchedule.Columns.Add(column5);

                // Initialize and add column TotalInterestPaid
                DataGridViewColumn column6 = new DataGridViewTextBoxColumn();
                column6.DataPropertyName = "TotalInterestPaid";
                column6.Frozen = false;
                column6.Name = "Cum. Interest";
                dgvAmortizationSchedule.Columns.Add(column6);

                // Initialize and add column ExtraPayment
                DataGridViewColumn column7 = new DataGridViewTextBoxColumn();
                column7.DataPropertyName = "ExtraPayment";
                column7.Frozen = false;
                column7.Name = "Extra Payments";
                dgvAmortizationSchedule.Columns.Add(column7);

                // Initialize and add column CumulativeExtraPayment
                DataGridViewColumn column8 = new DataGridViewTextBoxColumn();
                column8.DataPropertyName = "CumulativeExtraPayment";
                column8.Frozen = false;
                column8.Name = "Cum. Extra Payment";
                dgvAmortizationSchedule.Columns.Add(column8);

                //Format Grid
                dgvAmortizationSchedule.Columns["Balance"].DefaultCellStyle.Format = "c";
                dgvAmortizationSchedule.Columns["Monthly Payment"].DefaultCellStyle.Format = "c";
                dgvAmortizationSchedule.Columns["Principal"].DefaultCellStyle.Format = "c";
                dgvAmortizationSchedule.Columns["Interest"].DefaultCellStyle.Format = "c";
                dgvAmortizationSchedule.Columns["Cum. Interest"].DefaultCellStyle.Format = "c";
                dgvAmortizationSchedule.Columns["Extra Payments"].DefaultCellStyle.Format = "c";
                dgvAmortizationSchedule.Columns["Cum. Extra Payment"].DefaultCellStyle.Format = "c";
                dgvAmortizationSchedule.ScrollBars = ScrollBars.Vertical;

                //Calculate Summary Values
                var summaryMortgageInfo = _mortgageExecutiveSummaryService.CalculateMortgageExecutiveSummary(amortizationSchedule, mortgageInput);
                execSummary = summaryMortgageInfo;

                //Map values to correct labels
                lblLoanAmount.Text = summaryMortgageInfo.ActualLoanAmount.ToString("c");
                lblTotalTerm.Text = summaryMortgageInfo.ExtraPaymentLoanTerm.ToString();
                lblInterestRate.Text = $"{summaryMortgageInfo.InterestRate*100}";
                lblStartDate.Text = summaryMortgageInfo.StartDate.ToShortDateString();
                lblTotalExtraPayments.Text = summaryMortgageInfo.CumulativeExtraPayment.ToString("c");
                lblEndDate.Text= summaryMortgageInfo.ExtraPaymentLastDate.ToShortDateString();
                lblTotalInterestPaid.Text = summaryMortgageInfo.TotalInterestPaid.ToString("c");
                lblInterestReduction.Text = summaryMortgageInfo.ExtraPaymentInterestReduction.ToString("c");
                lblTotalPaid.Text = summaryMortgageInfo.TotalActualLoanPayment.ToString("c");
                lblConventionalLoanAmt.Text = summaryMortgageInfo.TotalConvetionalLoanPayment.ToString("c");

                if (amortizationScheduleBindingList.Count > 1)
                {
                    btnCreateExcelFile.Enabled = true;
                    btnCreateTextFile.Enabled = true;

                }
                else
                {
                    btnCreateExcelFile.Enabled = false;
                    btnCreateTextFile.Enabled = false;

                }
            }
            else
            {
                //throw an error
                foreach (var failure in result.Errors)
                {
                    switch (failure.PropertyName)
                    {
                        case "TotalLoanAmount":
                            lblTotalLoanAmountValidation.Text = failure.ErrorMessage;
                            lblTotalLoanAmountValidation.Visible = true;
                            break;
                        case "DownPayment":
                            lblDownPaymentValidation.Text= failure.ErrorMessage;
                            lblDownPaymentValidation.Visible = true;
                            break;
                        case "LoanTerm":
                            lblLoanTermValidation.Text = failure.ErrorMessage;
                            lblLoanTermValidation.Visible = true;
                            break;
                        case "InterestRate":
                            lblInterestRateValidation.Text = failure.ErrorMessage;
                            lblInterestRateValidation.Visible = true;
                            break;
                        case "StartDate":
                            lblExtraPaymentsStartDateValidation.Text = failure.ErrorMessage;
                            lblExtraPaymentsStartDateValidation.Visible = true;
                            break;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            extraPaymentsList = new BindingList<ExtraPayments>();
            mortgageInput = new MortgageInputExtraPayments();
            baseMortgageInput = new MortgageInput();
            amortizationScheduleBindingList = new BindingList<MonthlyCalculatedValuesExtraPayments>();
            execSummary = new MortgageExecutiveSummary();
            basicAmmortizationSchedule = new List<MonthlyCalculatedValues>();

            txtExtraPaymentAmount.Clear();
            enteredtxtExtraPaymentAmount = null;
            txtNumberofExtraPayments.Clear();
            txtPaymentInterval.Clear();
            dgvExtraPaymentsTable.ClearSelection();
            dgvExtraPaymentsTable.DataSource = null;

            enteredtxtDownPayment = null;
            enteredTxtTotalAmount = null;
            txtTotalLoanAmount.Clear();
            txtDownPayment.Clear();
            txtInterestRate.Clear();
            txtLoanTerm.Clear();
            extraPaymentsList.Clear();
            dgvAmortizationSchedule.ClearSelection();
            dgvAmortizationSchedule.DataSource = null;


            lblLoanAmount.Hide();
            lblTotalTerm.Hide();
            lblInterestRate.Hide();
            lblStartDate.Hide();
            lblTotalExtraPayments.Hide();
            lblEndDate.Hide();
            lblTotalInterestPaid.Hide();
            lblInterestReduction.Hide();
            lblTotalPaid.Hide();
            lblConventionalLoanAmt.Hide();

            gbResults.Visible = false;

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            //Mortgage Payment
            toolTip1.SetToolTip(this.labelDownPayment, "Please enter your down payment amount on your loan.");
            toolTip1.SetToolTip(this.labelInterestRate, "Please enter your interest rate.  Ex. 4.175");
            toolTip1.SetToolTip(this.labelLoanTerm, "Please enter your loan term in years.");
            toolTip1.SetToolTip(this.labelTotalLoanAmount, "Please enter your total loan amount.  This includes your down payment.");
            toolTip1.SetToolTip(this.labelMortgageStartDate, "Please select the start date of your mortgage");

            //Extra Payment
            toolTip1.SetToolTip(this.labelExtraPaymentAmount, "Please enter the amount of your extra payment.");
            toolTip1.SetToolTip(this.labelNumberofExtraPayments, "Please enter the number of extra payments.");
            toolTip1.SetToolTip(this.labelPaymentInterval, "Please enter your payment interval in months.  For example a payment interval of every 2 months would be 2.");
            toolTip1.SetToolTip(this.labelFirstExtraPayment, "Please enter the date of your first extra payment.");

            //Results buttons
            
            toolTip1.SetToolTip(this.btnCreateExcelFile, "Click here to create an excel file of the amortization schedule.");
            toolTip1.SetToolTip(this.btnCreateTextFile, "Click here to create a text file of the amortization schedule.");
        }

        private void btnCreateExcelFile_Click(object sender, EventArgs e)
        {
            var excelApp = new ExcelMortgageOutput();

            var excelByteArray = excelApp.CreateExcelTestFile(basicAmmortizationSchedule, amortizationScheduleBindingList.ToList(), execSummary);

            //create a SaveFileDialog instance with some properties
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save Excel sheet";
            saveFileDialog1.Filter = "Excel files|*.xlsx|All files|*.*";
            saveFileDialog1.FileName = "MortgageExcelSheet_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

            //check if user clicked the save button
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //write the file to the disk
                File.WriteAllBytes(saveFileDialog1.FileName, excelByteArray);
            }

        }

        private void btnCreateTextFile_Click(object sender, EventArgs e)
        {
            var textApp = new TextMortgageOutput();

            var textByteArray = textApp.CreateTextFile(amortizationScheduleBindingList.ToList());

            //create a SaveFileDialog instance with some properties
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save Text File";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FileName = "MortgageTextFile_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            //check if user clicked the save button
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //write the file to the disk
                File.WriteAllBytes(saveFileDialog1.FileName, textByteArray);
            }

        }

        private void btnCreateChart_Click(object sender, EventArgs e)
        {
            //Create chart here
        }

        //TextBox Formatting
        private void txtTotalLoanAmount_Leave(object sender, EventArgs e)
        {
            decimal value;
            if(decimal.TryParse(txtTotalLoanAmount.Text, out value))
            {
                enteredTxtTotalAmount = value;
                txtTotalLoanAmount.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", value);
            }
            else
            {
                enteredTxtTotalAmount = null;
                txtTotalLoanAmount.Text = String.Empty;
            }
        }

        private void txtDownPayment_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(txtDownPayment.Text, out value))
            {
                enteredtxtDownPayment = value;
                txtDownPayment.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", value);
            }
            else
            {
                enteredtxtDownPayment = null;
                txtDownPayment.Text = String.Empty;
            }
        }

        private void txtExtraPaymentAmount_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(txtExtraPaymentAmount.Text, out value))
            {
                enteredtxtExtraPaymentAmount = value;
                txtExtraPaymentAmount.Text = String.Format(CultureInfo.CurrentCulture, "{0:C2}", value);
            }
            else
            {
                enteredtxtExtraPaymentAmount = null;
                txtExtraPaymentAmount.Text = String.Empty;
            }
        }

        private void txtInterestRate_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(txtInterestRate.Text, out value))
            {
                enteredTxtInterestRate = value/100;
                txtInterestRate.Text = String.Format(CultureInfo.CurrentCulture, "{0:0%}", value);
            }
            else
            {
                enteredTxtInterestRate = null;
                txtInterestRate.Text = String.Empty;
            }
        }
    }
}
