using AutoMapper;
using LoanWinFormsV2UI.ViewModels;
using MortgageAppLibrary.Models;
using MortgageAppLibrary.Services.Excel;
using MortgageAppLibrary.Services.TextFile;
using MortgageAppLibrary.Validators;
using Tulpep.NotificationWindow;

namespace LoanWinFormsV2UI;

public partial class loanAppMainForm : Form
{
    //Create all necessary models for access to the entire form
    private MortgageInput _mortgageInput = new MortgageInput();
    private MortgageInputExtraPayments _mortgageInputExtraPayments = new MortgageInputExtraPayments();
    private ExtraPayments _extraPayments = new ExtraPayments();
    private List<ExtraPayments> _extraPaymentsList = new List<ExtraPayments>(); 
    private List<MonthlyCalculatedValuesExtraPayments> _amortizationScheduleResults=new List<MonthlyCalculatedValuesExtraPayments>();
    private List<MonthlyCalculatedValues> _baseAmortizationScheduleResults = new List<MonthlyCalculatedValues>();
    private MortgageExecutiveSummary _execSummary = new MortgageExecutiveSummary();


    //Create all Validators
    private MortgageInputValidator validateMortgageInput=new MortgageInputValidator();
    private ExtraPaymentsValidator validateExtraPayment=new ExtraPaymentsValidator();
    private MortgageInputExtraPaymentsValidator _validateMortgage=new MortgageInputExtraPaymentsValidator();

    //Tooltip Information
    private ToolTip toolTip1 = new ToolTip();
    private readonly IMapper _mapper;

    public loanAppMainForm(IMapper mapper)
    {
        

        InitializeComponent();

        
        //TOOLTIP

        // Set up the delays for the ToolTip.
        toolTip1.AutoPopDelay = 5000;
        toolTip1.InitialDelay = 1000;
        toolTip1.ReshowDelay = 500;
        // Force the ToolTip text to be displayed whether or not the form is active.
        toolTip1.ShowAlways = true;

        //Mortgage Payment
        toolTip1.SetToolTip(this.downPaymentLabel, "Please enter your down payment amount on your loan.");
        toolTip1.SetToolTip(this.interestRateLabel, "Please enter your interest rate.  Ex. 4.175");
        toolTip1.SetToolTip(this.loanTermLabel, "Please enter your loan term in years.");
        toolTip1.SetToolTip(this.totalLoanAmountLabel, "Please enter your total loan amount.  This includes your down payment.");
        toolTip1.SetToolTip(this.mortgageStartDateLabel, "Please select the start date of your mortgage");

        //Extra Payment
        toolTip1.SetToolTip(this.extraPaymentAmountLabel, "Please enter the amount of your extra payment.");
        toolTip1.SetToolTip(this.numberOfExtraPaymentsLabel, "Please enter the number of extra payments.");
        toolTip1.SetToolTip(this.paymentIntervalLabel, "Please enter your payment interval in months.  For example a payment interval of every 2 months would be 2.");
        toolTip1.SetToolTip(this.startDateOfExtraPaymentsLabel, "Please enter the date of your first extra payment.");

        //Textbox Mask
        

        //Add Automapper
        _mapper = mapper;

        //DataGrid Extra Payment Setup
        extraPaymentsDataGrid.AutoGenerateColumns = false;
        
        var startDateExtraPaymentField = new DataGridViewTextBoxColumn();
        startDateExtraPaymentField.HeaderText = "Start Date";
        startDateExtraPaymentField.DataPropertyName = "StartDate";
        startDateExtraPaymentField.DefaultCellStyle.Format = "MM/dd/yyyy";
        extraPaymentsDataGrid.Columns.Add(startDateExtraPaymentField);

        var extraPaymentAmountField = new DataGridViewTextBoxColumn();
        extraPaymentAmountField.HeaderText = "Payment Amt";
        extraPaymentAmountField.DataPropertyName = "ExtraPaymentAmount";
        extraPaymentAmountField.DefaultCellStyle.Format = "c";
        extraPaymentsDataGrid.Columns.Add(extraPaymentAmountField);

        var numberofPaymentsField = new DataGridViewTextBoxColumn();
        numberofPaymentsField.HeaderText = "No of Payments";
        numberofPaymentsField.DataPropertyName = "NumberofPayments";
        extraPaymentsDataGrid.Columns.Add(numberofPaymentsField);

        var extraPaymentPaymentIntervalField = new DataGridViewTextBoxColumn();
        extraPaymentPaymentIntervalField.HeaderText = "Payment Interval";
        extraPaymentPaymentIntervalField.DataPropertyName = "PaymentInterval";
        extraPaymentsDataGrid.Columns.Add(extraPaymentPaymentIntervalField);
        
        extraPaymentsDataGrid.ScrollBars = ScrollBars.Vertical;

        //DataGrid Results Setup
        
        resultsDataGrid.AutoGenerateColumns = false;

        // Initialize and add column IDNumber
        DataGridViewColumn column0 = new DataGridViewTextBoxColumn();
        column0.DataPropertyName = "IDNumber";
        column0.Frozen = false;
        column0.Name = "No";
        resultsDataGrid.Columns.Add(column0);

        // Initialize and add column DateColumn
        DataGridViewColumn column1 = new DataGridViewTextBoxColumn();
        column1.DataPropertyName = "DateColumn";
        column1.Frozen = false;
        column1.Name = "Date";
        resultsDataGrid.Columns.Add(column1);

        // Initialize and add column RemainingBalance
        DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
        column2.DataPropertyName = "RemainingBalance";
        column2.Frozen = false;
        column2.Name = "Balance";
        resultsDataGrid.Columns.Add(column2);

        // Initialize and add column fixedPayment
        DataGridViewColumn column3 = new DataGridViewTextBoxColumn();
        column3.DataPropertyName = "fixedPayment";
        column3.Frozen = false;
        column3.Name = "Monthly Payment";
        resultsDataGrid.Columns.Add(column3);

        // Initialize and add column PrincipalPaid
        DataGridViewColumn column4 = new DataGridViewTextBoxColumn();
        column4.DataPropertyName = "PrincipalPaid";
        column4.Frozen = false;
        column4.Name = "Principal";
        resultsDataGrid.Columns.Add(column4);

        // Initialize and add column InterestPaid
        DataGridViewColumn column5 = new DataGridViewTextBoxColumn();
        column5.DataPropertyName = "InterestPaid";
        column5.Frozen = false;
        column5.Name = "Interest";
        resultsDataGrid.Columns.Add(column5);

        // Initialize and add column TotalInterestPaid
        DataGridViewColumn column6 = new DataGridViewTextBoxColumn();
        column6.DataPropertyName = "TotalInterestPaid";
        column6.Frozen = false;
        column6.Name = "Cum. Interest";
        resultsDataGrid.Columns.Add(column6);

        // Initialize and add column ExtraPayment
        DataGridViewColumn column7 = new DataGridViewTextBoxColumn();
        column7.DataPropertyName = "ExtraPayment";
        column7.Frozen = false;
        column7.Name = "Extra Payments";
        resultsDataGrid.Columns.Add(column7);

        // Initialize and add column CumulativeExtraPayment
        DataGridViewColumn column8 = new DataGridViewTextBoxColumn();
        column8.DataPropertyName = "CumulativeExtraPayment";
        column8.Frozen = false;
        column8.Name = "Cum. Extra Payment";
        resultsDataGrid.Columns.Add(column8);

        //Format Grid
        resultsDataGrid.Columns["Balance"].DefaultCellStyle.Format = "c";
        resultsDataGrid.Columns["Monthly Payment"].DefaultCellStyle.Format = "c";
        resultsDataGrid.Columns["Principal"].DefaultCellStyle.Format = "c";
        resultsDataGrid.Columns["Interest"].DefaultCellStyle.Format = "c";
        resultsDataGrid.Columns["Cum. Interest"].DefaultCellStyle.Format = "c";
        resultsDataGrid.Columns["Extra Payments"].DefaultCellStyle.Format = "c";
        resultsDataGrid.Columns["Cum. Extra Payment"].DefaultCellStyle.Format = "c";
        resultsDataGrid.ScrollBars = ScrollBars.Vertical;

    }

    private void calculateMortgageButton_Click(object sender, EventArgs e)
    {
        // Clear all existing Validation Text
        totalLoanAmountValidationText.Text = "";
        downPaymentValidationText.Text = "";
        loanTermValidationText.Text = "";
        interestRateValidationText.Text = "";
        startDateofMortgageValidationText.Text = "";


        //Grab all Mortgage input information
        _mortgageInput.TotalLoanAmount=decimal.Parse(totalLoanAmountTextBox.Text);
        _mortgageInput.DownPayment=decimal.Parse(downPaymentTextBox.Text);
        _mortgageInput.LoanTerm=int.Parse(loanTermTextBox.Text);
        _mortgageInput.InterestRate = decimal.Parse(InterestRateTextBox.Text);
        _mortgageInput.StartDate = startDateOfMortgageDateTimePicker.Value;

        //Get Mortgage Input Extra Payments
        _mortgageInputExtraPayments.TotalLoanAmount= decimal.Parse(totalLoanAmountTextBox.Text);
        _mortgageInputExtraPayments.DownPayment = decimal.Parse(downPaymentTextBox.Text);
        _mortgageInputExtraPayments.LoanTerm = int.Parse(loanTermTextBox.Text);
        _mortgageInputExtraPayments.InterestRate = decimal.Parse(InterestRateTextBox.Text);
        _mortgageInputExtraPayments.StartDate = startDateOfMortgageDateTimePicker.Value;
        _mortgageInputExtraPayments.ExtraPayments = _extraPaymentsList;


        //validate Mortgage information
        var resultTraditionalMortgageInput = _validateMortgage.Validate(_mortgageInputExtraPayments);

        if (resultTraditionalMortgageInput.IsValid)
        {

            //Show Group Results Box
            resultsGroup.Visible = true;

            //Create Amortization Schedule
            var amortizationSchedule = _mortgageInputExtraPayments.CalculatedPeriodMortgageData();
            _amortizationScheduleResults = amortizationSchedule;

            //Create Base Amortization Schedule
            var baseAmortizationSchedule = _mortgageInput.CalculatedPeriodMortgageData();
            _baseAmortizationScheduleResults = baseAmortizationSchedule;

            //Save to dataGrid
            resultsDataGrid.DataSource = amortizationSchedule;

            //Calculate Summary Values
            _execSummary.CalculateMortgageExecutiveSummary(_amortizationScheduleResults, _mortgageInputExtraPayments);

            //Map values to correct labels
            loanAmountLabel.Text = _execSummary.ActualLoanAmount.ToString("c");
            totalTermLabel.Text = _execSummary.ExtraPaymentLoanTerm.ToString();
            interestRateLabel.Text = $"{_execSummary.InterestRate * 100}";
            startDateLabel.Text = _execSummary.StartDate.ToShortDateString();
            totalExtraPaymentsLabel.Text = _execSummary.CumulativeExtraPayment.ToString("c");
            endDateLabel.Text = _execSummary.ExtraPaymentLastDate.ToShortDateString();
            totalInterestPaidLabel.Text = _execSummary.TotalInterestPaid.ToString("c");
            interestReductionLabel.Text = _execSummary.ExtraPaymentInterestReduction.ToString("c");
            totalPaidLabel.Text = _execSummary.TotalActualLoanPayment.ToString("c");
            conventionalLoanAmtLabel.Text = _execSummary.TotalConvetionalLoanPayment.ToString("c");

            loanAmountLabel.Visible = true;
            totalTermLabel.Visible = true;
            interestRateLabel.Visible = true;
            startDateLabel.Visible = true;
            totalExtraPaymentsLabel.Visible = true;
            endDateLabel.Visible = true;
            totalInterestPaidLabel.Visible = true;
            interestReductionLabel.Visible = true;
            totalPaidLabel.Visible = true;
            conventionalLoanAmtLabel.Visible = true;

            if (_amortizationScheduleResults.Count > 1)
            {
                createExcelFileButton.Enabled = true;
                createTextFileButton.Enabled = true;
                createPDFButton.Enabled = true;

            }
            else
            {
                createExcelFileButton.Enabled = false;
                createTextFileButton.Enabled = false;
                createPDFButton.Enabled = false;
            }

            //Clear all fields
            _mortgageInput = new MortgageInput();
            _mortgageInputExtraPayments = new MortgageInputExtraPayments();

            //Add Notification
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "MORTGAGE CALCULATION NOTIFICATION";
            popup.ContentText = "Mortgage Amoritization has been calculated";
            popup.Popup();// show 
        }
        else
        {
            //throw an error
            foreach (var failure in resultTraditionalMortgageInput.Errors)
            {
                switch (failure.PropertyName)
                {
                    case "TotalLoanAmount":
                        totalLoanAmountValidationText.Text = failure.ErrorMessage;
                        totalLoanAmountValidationText.Visible = true;
                        break;
                    case "DownPayment":
                        downPaymentValidationText.Text = failure.ErrorMessage;
                        downPaymentValidationText.Visible = true;
                        break;
                    case "LoanTerm":
                        loanTermValidationText.Text = failure.ErrorMessage;
                        loanTermValidationText.Visible = true;
                        break;
                    case "InterestRate":
                        interestRateValidationText.Text = failure.ErrorMessage;
                        interestRateValidationText.Visible = true;
                        break;
                    case "StartDate":
                        startDateofMortgageValidationText.Text = failure.ErrorMessage;
                        startDateofMortgageValidationText.Visible = true;
                        break;
                }
            }
        }

    }

    private void addExtraPaymentsButton_Click(object sender, EventArgs e)
    {
        //Clear all existing Validation Text
        extraPaymentAmountValidationText.Text = "";
        numberOfExtraPaymentsValidationText.Text = "";
        paymentIntervalValidationText.Text = "";
        startDateOfExtraPaymentsValidationText.Text = "";

        //Get all extra payment information
        _extraPayments.ExtraPaymentAmount = Convert.ToDecimal(extraPaymentAmountTextBox.Text);
        _extraPayments.NumberofPayments=Convert.ToInt32(numberOfExtraPaymentsTextBox.Text);
        _extraPayments.PaymentInterval = Convert.ToInt32(paymentIntervalTextBox.Text);
        _extraPayments.StartDate = startDateOfExtraPaymentsDatePicker.Value;

        //validate Mortgage information
        var resultExtraPaymentInput = validateExtraPayment.Validate(_extraPayments);

        if (resultExtraPaymentInput.IsValid)
        { 

            _extraPaymentsList.Add(_extraPayments);

            var extraPaymentDataGridList = _mapper.Map<List<ExtraPaymentViewModel>>(_extraPaymentsList);

            extraPaymentsDataGrid.DataSource = extraPaymentDataGridList;

            //Add Notification
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "EXTRA PAYMENT NOTIFICATION";
            popup.ContentText = "Extra Payment has been added";
            popup.Popup();// show 

            //Clear extra payment
            _extraPayments = new ExtraPayments();

            //Clear all textbox fields
            extraPaymentAmountTextBox.Text = null;
            numberOfExtraPaymentsTextBox.Text = null;
            paymentIntervalTextBox.Text = null;
            paymentIntervalTextBox.Text=null;
        }
        else
        {
            //throw an error
            foreach (var failure in resultExtraPaymentInput.Errors)
            {
                switch (failure.PropertyName)
                {
                    case "ExtraPaymentAmount":
                        extraPaymentAmountValidationText.Text = failure.ErrorMessage;
                        extraPaymentAmountValidationText.Visible = true;
                        break;
                    case "StartDate":
                        startDateOfExtraPaymentsValidationText.Text = failure.ErrorMessage;
                        startDateOfExtraPaymentsValidationText.Visible = true;
                        break;
                    case "NumberofPayments":
                        numberOfExtraPaymentsValidationText.Text = failure.ErrorMessage;
                        numberOfExtraPaymentsValidationText.Visible = true;
                        break;
                    case "PaymentInterval":
                        paymentIntervalValidationText.Text = failure.ErrorMessage;
                        paymentIntervalValidationText.Visible = true;
                        break;
                }
            }
        }
    }

    private void createExcelFileButton_Click(object sender, EventArgs e)
    {
        var excelApp = new ExcelMortgageOutput();

        var excelByteArray = excelApp.CreateExcelTestFile(_baseAmortizationScheduleResults, _amortizationScheduleResults, _execSummary);

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

    private void createTextFileButton_Click(object sender, EventArgs e)
    {
        var textApp = new TextMortgageOutput();

        var textByteArray = textApp.CreateTextFile(_amortizationScheduleResults);

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

    private void createPDFButton_Click(object sender, EventArgs e)
    {
        //Not Yet Implemented
        MessageBox.Show("This feature is not yet implemented");
    }
}