using AutoMapper;
using LoanWinFormsV2UI.ViewModels;
using MortgageAppLibrary.Models;
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


    //Create all Validators
    private MortgageInputValidator validateMortgageInput=new MortgageInputValidator();
    private ExtraPaymentsValidator validateExtraPayment=new ExtraPaymentsValidator();

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

        //Add Automapper
        _mapper = mapper;

        //DataGrid Extra Payment Setup


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
        _mortgageInputExtraPayments.ExtraPayments=new List<ExtraPayments>();    


        //validate Mortgage information
        var resultTraditionalMortgageInput = validateMortgageInput.Validate(_mortgageInput);

        if (resultTraditionalMortgageInput.IsValid)
        {
            //Test
            MessageBox.Show("You got here!");
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
            popup.TitleText = "Extra Payment has been added";
            popup.ContentText = "Thank you";
            popup.Popup();// show 
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

        //Clear extra payment
        _extraPayments = new ExtraPayments();
    }
}