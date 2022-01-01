
namespace LoanAppWinFormsNET5UI
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.gpbxMortgageInformation = new System.Windows.Forms.GroupBox();
            this.lblMortgageStartDateValidation = new System.Windows.Forms.Label();
            this.lblInterestRateValidation = new System.Windows.Forms.Label();
            this.lblLoanTermValidation = new System.Windows.Forms.Label();
            this.lblDownPaymentValidation = new System.Windows.Forms.Label();
            this.lblTotalLoanAmountValidation = new System.Windows.Forms.Label();
            this.btnCalculateMortgage = new System.Windows.Forms.Button();
            this.dtMortgageStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelMortgageStartDate = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.labelInterestRate = new System.Windows.Forms.Label();
            this.txtLoanTerm = new System.Windows.Forms.TextBox();
            this.labelLoanTerm = new System.Windows.Forms.Label();
            this.txtDownPayment = new System.Windows.Forms.TextBox();
            this.labelDownPayment = new System.Windows.Forms.Label();
            this.txtTotalLoanAmount = new System.Windows.Forms.TextBox();
            this.labelTotalLoanAmount = new System.Windows.Forms.Label();
            this.gpbxExtraPayments = new System.Windows.Forms.GroupBox();
            this.lblExtraPaymentsStartDateValidation = new System.Windows.Forms.Label();
            this.lblPaymentIntervalValidation = new System.Windows.Forms.Label();
            this.lblNumberofPaymentsValidation = new System.Windows.Forms.Label();
            this.lblExtraPaymentAmountValidation = new System.Windows.Forms.Label();
            this.dgvExtraPaymentsTable = new System.Windows.Forms.DataGridView();
            this.btnAddExtraPayment = new System.Windows.Forms.Button();
            this.dtFirstExtraPayment = new System.Windows.Forms.DateTimePicker();
            this.labelFirstExtraPayment = new System.Windows.Forms.Label();
            this.txtPaymentInterval = new System.Windows.Forms.TextBox();
            this.labelPaymentInterval = new System.Windows.Forms.Label();
            this.txtNumberofExtraPayments = new System.Windows.Forms.TextBox();
            this.labelNumberofExtraPayments = new System.Windows.Forms.Label();
            this.txtExtraPaymentAmount = new System.Windows.Forms.TextBox();
            this.labelExtraPaymentAmount = new System.Windows.Forms.Label();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.dgvAmortizationSchedule = new System.Windows.Forms.DataGridView();
            this.lblConventionalLoanAmt = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblTotalPaid = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblInterestReduction = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTotalInterestPaid = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblTotalExtraPayments = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblInterestRate = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTotalTerm = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblLoanAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateExcelFile = new System.Windows.Forms.Button();
            this.btnCreateTextFile = new System.Windows.Forms.Button();
            this.btnCreatePDF = new System.Windows.Forms.Button();
            this.gpbxMortgageInformation.SuspendLayout();
            this.gpbxExtraPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtraPaymentsTable)).BeginInit();
            this.gbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizationSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbxMortgageInformation
            // 
            this.gpbxMortgageInformation.Controls.Add(this.lblMortgageStartDateValidation);
            this.gpbxMortgageInformation.Controls.Add(this.lblInterestRateValidation);
            this.gpbxMortgageInformation.Controls.Add(this.lblLoanTermValidation);
            this.gpbxMortgageInformation.Controls.Add(this.lblDownPaymentValidation);
            this.gpbxMortgageInformation.Controls.Add(this.lblTotalLoanAmountValidation);
            this.gpbxMortgageInformation.Controls.Add(this.btnCalculateMortgage);
            this.gpbxMortgageInformation.Controls.Add(this.dtMortgageStartDate);
            this.gpbxMortgageInformation.Controls.Add(this.labelMortgageStartDate);
            this.gpbxMortgageInformation.Controls.Add(this.txtInterestRate);
            this.gpbxMortgageInformation.Controls.Add(this.labelInterestRate);
            this.gpbxMortgageInformation.Controls.Add(this.txtLoanTerm);
            this.gpbxMortgageInformation.Controls.Add(this.labelLoanTerm);
            this.gpbxMortgageInformation.Controls.Add(this.txtDownPayment);
            this.gpbxMortgageInformation.Controls.Add(this.labelDownPayment);
            this.gpbxMortgageInformation.Controls.Add(this.txtTotalLoanAmount);
            this.gpbxMortgageInformation.Controls.Add(this.labelTotalLoanAmount);
            this.gpbxMortgageInformation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gpbxMortgageInformation.Location = new System.Drawing.Point(12, 46);
            this.gpbxMortgageInformation.Name = "gpbxMortgageInformation";
            this.gpbxMortgageInformation.Size = new System.Drawing.Size(417, 341);
            this.gpbxMortgageInformation.TabIndex = 0;
            this.gpbxMortgageInformation.TabStop = false;
            this.gpbxMortgageInformation.Text = "Mortgage Information";
            // 
            // lblMortgageStartDateValidation
            // 
            this.lblMortgageStartDateValidation.AutoSize = true;
            this.lblMortgageStartDateValidation.ForeColor = System.Drawing.Color.Red;
            this.lblMortgageStartDateValidation.Location = new System.Drawing.Point(14, 244);
            this.lblMortgageStartDateValidation.Name = "lblMortgageStartDateValidation";
            this.lblMortgageStartDateValidation.Size = new System.Drawing.Size(80, 15);
            this.lblMortgageStartDateValidation.TabIndex = 15;
            this.lblMortgageStartDateValidation.Text = "ValidationText";
            this.lblMortgageStartDateValidation.Visible = false;
            // 
            // lblInterestRateValidation
            // 
            this.lblInterestRateValidation.AutoSize = true;
            this.lblInterestRateValidation.ForeColor = System.Drawing.Color.Red;
            this.lblInterestRateValidation.Location = new System.Drawing.Point(14, 197);
            this.lblInterestRateValidation.Name = "lblInterestRateValidation";
            this.lblInterestRateValidation.Size = new System.Drawing.Size(80, 15);
            this.lblInterestRateValidation.TabIndex = 14;
            this.lblInterestRateValidation.Text = "ValidationText";
            this.lblInterestRateValidation.Visible = false;
            // 
            // lblLoanTermValidation
            // 
            this.lblLoanTermValidation.AutoSize = true;
            this.lblLoanTermValidation.ForeColor = System.Drawing.Color.Red;
            this.lblLoanTermValidation.Location = new System.Drawing.Point(14, 154);
            this.lblLoanTermValidation.Name = "lblLoanTermValidation";
            this.lblLoanTermValidation.Size = new System.Drawing.Size(80, 15);
            this.lblLoanTermValidation.TabIndex = 13;
            this.lblLoanTermValidation.Text = "ValidationText";
            this.lblLoanTermValidation.Visible = false;
            // 
            // lblDownPaymentValidation
            // 
            this.lblDownPaymentValidation.AutoSize = true;
            this.lblDownPaymentValidation.ForeColor = System.Drawing.Color.Red;
            this.lblDownPaymentValidation.Location = new System.Drawing.Point(14, 109);
            this.lblDownPaymentValidation.Name = "lblDownPaymentValidation";
            this.lblDownPaymentValidation.Size = new System.Drawing.Size(80, 15);
            this.lblDownPaymentValidation.TabIndex = 12;
            this.lblDownPaymentValidation.Text = "ValidationText";
            this.lblDownPaymentValidation.Visible = false;
            // 
            // lblTotalLoanAmountValidation
            // 
            this.lblTotalLoanAmountValidation.AutoSize = true;
            this.lblTotalLoanAmountValidation.ForeColor = System.Drawing.Color.Red;
            this.lblTotalLoanAmountValidation.Location = new System.Drawing.Point(14, 66);
            this.lblTotalLoanAmountValidation.Name = "lblTotalLoanAmountValidation";
            this.lblTotalLoanAmountValidation.Size = new System.Drawing.Size(80, 15);
            this.lblTotalLoanAmountValidation.TabIndex = 11;
            this.lblTotalLoanAmountValidation.Text = "ValidationText";
            this.lblTotalLoanAmountValidation.Visible = false;
            // 
            // btnCalculateMortgage
            // 
            this.btnCalculateMortgage.Location = new System.Drawing.Point(71, 284);
            this.btnCalculateMortgage.Name = "btnCalculateMortgage";
            this.btnCalculateMortgage.Size = new System.Drawing.Size(126, 39);
            this.btnCalculateMortgage.TabIndex = 10;
            this.btnCalculateMortgage.Text = "Calculate Mortgage";
            this.btnCalculateMortgage.UseVisualStyleBackColor = true;
            this.btnCalculateMortgage.Click += new System.EventHandler(this.btnCalculateMortgage_Click);
            // 
            // dtMortgageStartDate
            // 
            this.dtMortgageStartDate.Location = new System.Drawing.Point(153, 220);
            this.dtMortgageStartDate.Name = "dtMortgageStartDate";
            this.dtMortgageStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtMortgageStartDate.TabIndex = 9;
            // 
            // labelMortgageStartDate
            // 
            this.labelMortgageStartDate.AutoSize = true;
            this.labelMortgageStartDate.Location = new System.Drawing.Point(7, 220);
            this.labelMortgageStartDate.Name = "labelMortgageStartDate";
            this.labelMortgageStartDate.Size = new System.Drawing.Size(127, 15);
            this.labelMortgageStartDate.TabIndex = 8;
            this.labelMortgageStartDate.Text = "Start Date of Mortgage";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(153, 176);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(100, 23);
            this.txtInterestRate.TabIndex = 7;
            // 
            // labelInterestRate
            // 
            this.labelInterestRate.AutoSize = true;
            this.labelInterestRate.Location = new System.Drawing.Point(6, 179);
            this.labelInterestRate.Name = "labelInterestRate";
            this.labelInterestRate.Size = new System.Drawing.Size(93, 15);
            this.labelInterestRate.TabIndex = 6;
            this.labelInterestRate.Text = "Interest Rate (%)";
            // 
            // txtLoanTerm
            // 
            this.txtLoanTerm.Location = new System.Drawing.Point(153, 130);
            this.txtLoanTerm.Name = "txtLoanTerm";
            this.txtLoanTerm.Size = new System.Drawing.Size(100, 23);
            this.txtLoanTerm.TabIndex = 5;
            // 
            // labelLoanTerm
            // 
            this.labelLoanTerm.AutoSize = true;
            this.labelLoanTerm.Location = new System.Drawing.Point(6, 133);
            this.labelLoanTerm.Name = "labelLoanTerm";
            this.labelLoanTerm.Size = new System.Drawing.Size(88, 15);
            this.labelLoanTerm.TabIndex = 4;
            this.labelLoanTerm.Text = "Loan Term (yrs)";
            // 
            // txtDownPayment
            // 
            this.txtDownPayment.Location = new System.Drawing.Point(153, 86);
            this.txtDownPayment.Name = "txtDownPayment";
            this.txtDownPayment.Size = new System.Drawing.Size(100, 23);
            this.txtDownPayment.TabIndex = 3;
            // 
            // labelDownPayment
            // 
            this.labelDownPayment.AutoSize = true;
            this.labelDownPayment.Location = new System.Drawing.Point(6, 89);
            this.labelDownPayment.Name = "labelDownPayment";
            this.labelDownPayment.Size = new System.Drawing.Size(105, 15);
            this.labelDownPayment.TabIndex = 2;
            this.labelDownPayment.Text = "Down Payment ($)";
            // 
            // txtTotalLoanAmount
            // 
            this.txtTotalLoanAmount.Location = new System.Drawing.Point(153, 40);
            this.txtTotalLoanAmount.Name = "txtTotalLoanAmount";
            this.txtTotalLoanAmount.Size = new System.Drawing.Size(100, 23);
            this.txtTotalLoanAmount.TabIndex = 1;
            // 
            // labelTotalLoanAmount
            // 
            this.labelTotalLoanAmount.AutoSize = true;
            this.labelTotalLoanAmount.Location = new System.Drawing.Point(6, 43);
            this.labelTotalLoanAmount.Name = "labelTotalLoanAmount";
            this.labelTotalLoanAmount.Size = new System.Drawing.Size(125, 15);
            this.labelTotalLoanAmount.TabIndex = 0;
            this.labelTotalLoanAmount.Text = "Total Loan Amount ($)";
            // 
            // gpbxExtraPayments
            // 
            this.gpbxExtraPayments.Controls.Add(this.lblExtraPaymentsStartDateValidation);
            this.gpbxExtraPayments.Controls.Add(this.lblPaymentIntervalValidation);
            this.gpbxExtraPayments.Controls.Add(this.lblNumberofPaymentsValidation);
            this.gpbxExtraPayments.Controls.Add(this.lblExtraPaymentAmountValidation);
            this.gpbxExtraPayments.Controls.Add(this.dgvExtraPaymentsTable);
            this.gpbxExtraPayments.Controls.Add(this.btnAddExtraPayment);
            this.gpbxExtraPayments.Controls.Add(this.dtFirstExtraPayment);
            this.gpbxExtraPayments.Controls.Add(this.labelFirstExtraPayment);
            this.gpbxExtraPayments.Controls.Add(this.txtPaymentInterval);
            this.gpbxExtraPayments.Controls.Add(this.labelPaymentInterval);
            this.gpbxExtraPayments.Controls.Add(this.txtNumberofExtraPayments);
            this.gpbxExtraPayments.Controls.Add(this.labelNumberofExtraPayments);
            this.gpbxExtraPayments.Controls.Add(this.txtExtraPaymentAmount);
            this.gpbxExtraPayments.Controls.Add(this.labelExtraPaymentAmount);
            this.gpbxExtraPayments.Location = new System.Drawing.Point(444, 46);
            this.gpbxExtraPayments.Name = "gpbxExtraPayments";
            this.gpbxExtraPayments.Size = new System.Drawing.Size(652, 341);
            this.gpbxExtraPayments.TabIndex = 1;
            this.gpbxExtraPayments.TabStop = false;
            this.gpbxExtraPayments.Text = "Extra Paymnents";
            // 
            // lblExtraPaymentsStartDateValidation
            // 
            this.lblExtraPaymentsStartDateValidation.AutoSize = true;
            this.lblExtraPaymentsStartDateValidation.ForeColor = System.Drawing.Color.Red;
            this.lblExtraPaymentsStartDateValidation.Location = new System.Drawing.Point(12, 203);
            this.lblExtraPaymentsStartDateValidation.Name = "lblExtraPaymentsStartDateValidation";
            this.lblExtraPaymentsStartDateValidation.Size = new System.Drawing.Size(80, 15);
            this.lblExtraPaymentsStartDateValidation.TabIndex = 18;
            this.lblExtraPaymentsStartDateValidation.Text = "ValidationText";
            this.lblExtraPaymentsStartDateValidation.Visible = false;
            // 
            // lblPaymentIntervalValidation
            // 
            this.lblPaymentIntervalValidation.AutoSize = true;
            this.lblPaymentIntervalValidation.ForeColor = System.Drawing.Color.Red;
            this.lblPaymentIntervalValidation.Location = new System.Drawing.Point(12, 155);
            this.lblPaymentIntervalValidation.Name = "lblPaymentIntervalValidation";
            this.lblPaymentIntervalValidation.Size = new System.Drawing.Size(80, 15);
            this.lblPaymentIntervalValidation.TabIndex = 17;
            this.lblPaymentIntervalValidation.Text = "ValidationText";
            this.lblPaymentIntervalValidation.Visible = false;
            // 
            // lblNumberofPaymentsValidation
            // 
            this.lblNumberofPaymentsValidation.AutoSize = true;
            this.lblNumberofPaymentsValidation.ForeColor = System.Drawing.Color.Red;
            this.lblNumberofPaymentsValidation.Location = new System.Drawing.Point(12, 111);
            this.lblNumberofPaymentsValidation.Name = "lblNumberofPaymentsValidation";
            this.lblNumberofPaymentsValidation.Size = new System.Drawing.Size(80, 15);
            this.lblNumberofPaymentsValidation.TabIndex = 16;
            this.lblNumberofPaymentsValidation.Text = "ValidationText";
            this.lblNumberofPaymentsValidation.Visible = false;
            // 
            // lblExtraPaymentAmountValidation
            // 
            this.lblExtraPaymentAmountValidation.AutoSize = true;
            this.lblExtraPaymentAmountValidation.ForeColor = System.Drawing.Color.Red;
            this.lblExtraPaymentAmountValidation.Location = new System.Drawing.Point(9, 63);
            this.lblExtraPaymentAmountValidation.Name = "lblExtraPaymentAmountValidation";
            this.lblExtraPaymentAmountValidation.Size = new System.Drawing.Size(80, 15);
            this.lblExtraPaymentAmountValidation.TabIndex = 15;
            this.lblExtraPaymentAmountValidation.Text = "ValidationText";
            this.lblExtraPaymentAmountValidation.Visible = false;
            // 
            // dgvExtraPaymentsTable
            // 
            this.dgvExtraPaymentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtraPaymentsTable.Location = new System.Drawing.Point(6, 229);
            this.dgvExtraPaymentsTable.Name = "dgvExtraPaymentsTable";
            this.dgvExtraPaymentsTable.RowTemplate.Height = 25;
            this.dgvExtraPaymentsTable.Size = new System.Drawing.Size(640, 106);
            this.dgvExtraPaymentsTable.TabIndex = 15;
            // 
            // btnAddExtraPayment
            // 
            this.btnAddExtraPayment.Location = new System.Drawing.Point(469, 89);
            this.btnAddExtraPayment.Name = "btnAddExtraPayment";
            this.btnAddExtraPayment.Size = new System.Drawing.Size(121, 49);
            this.btnAddExtraPayment.TabIndex = 14;
            this.btnAddExtraPayment.Text = "Add Extra Payment";
            this.btnAddExtraPayment.UseVisualStyleBackColor = true;
            this.btnAddExtraPayment.Click += new System.EventHandler(this.btnAddExtraPayment_Click);
            // 
            // dtFirstExtraPayment
            // 
            this.dtFirstExtraPayment.Location = new System.Drawing.Point(174, 179);
            this.dtFirstExtraPayment.Name = "dtFirstExtraPayment";
            this.dtFirstExtraPayment.Size = new System.Drawing.Size(200, 23);
            this.dtFirstExtraPayment.TabIndex = 13;
            // 
            // labelFirstExtraPayment
            // 
            this.labelFirstExtraPayment.AutoSize = true;
            this.labelFirstExtraPayment.Location = new System.Drawing.Point(6, 184);
            this.labelFirstExtraPayment.Name = "labelFirstExtraPayment";
            this.labelFirstExtraPayment.Size = new System.Drawing.Size(156, 15);
            this.labelFirstExtraPayment.TabIndex = 12;
            this.labelFirstExtraPayment.Text = "Start Date of Extra Payments";
            // 
            // txtPaymentInterval
            // 
            this.txtPaymentInterval.Location = new System.Drawing.Point(174, 130);
            this.txtPaymentInterval.Name = "txtPaymentInterval";
            this.txtPaymentInterval.Size = new System.Drawing.Size(100, 23);
            this.txtPaymentInterval.TabIndex = 11;
            // 
            // labelPaymentInterval
            // 
            this.labelPaymentInterval.AutoSize = true;
            this.labelPaymentInterval.Location = new System.Drawing.Point(6, 133);
            this.labelPaymentInterval.Name = "labelPaymentInterval";
            this.labelPaymentInterval.Size = new System.Drawing.Size(134, 15);
            this.labelPaymentInterval.TabIndex = 10;
            this.labelPaymentInterval.Text = "Payment Interval (mths)";
            // 
            // txtNumberofExtraPayments
            // 
            this.txtNumberofExtraPayments.Location = new System.Drawing.Point(174, 86);
            this.txtNumberofExtraPayments.Name = "txtNumberofExtraPayments";
            this.txtNumberofExtraPayments.Size = new System.Drawing.Size(100, 23);
            this.txtNumberofExtraPayments.TabIndex = 9;
            // 
            // labelNumberofExtraPayments
            // 
            this.labelNumberofExtraPayments.AutoSize = true;
            this.labelNumberofExtraPayments.Location = new System.Drawing.Point(6, 89);
            this.labelNumberofExtraPayments.Name = "labelNumberofExtraPayments";
            this.labelNumberofExtraPayments.Size = new System.Drawing.Size(149, 15);
            this.labelNumberofExtraPayments.TabIndex = 8;
            this.labelNumberofExtraPayments.Text = "Number of Extra Payments";
            // 
            // txtExtraPaymentAmount
            // 
            this.txtExtraPaymentAmount.Location = new System.Drawing.Point(174, 40);
            this.txtExtraPaymentAmount.Name = "txtExtraPaymentAmount";
            this.txtExtraPaymentAmount.Size = new System.Drawing.Size(100, 23);
            this.txtExtraPaymentAmount.TabIndex = 7;
            // 
            // labelExtraPaymentAmount
            // 
            this.labelExtraPaymentAmount.AutoSize = true;
            this.labelExtraPaymentAmount.Location = new System.Drawing.Point(6, 43);
            this.labelExtraPaymentAmount.Name = "labelExtraPaymentAmount";
            this.labelExtraPaymentAmount.Size = new System.Drawing.Size(147, 15);
            this.labelExtraPaymentAmount.TabIndex = 6;
            this.labelExtraPaymentAmount.Text = "Extra Payment Amount ($)";
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.dgvAmortizationSchedule);
            this.gbResults.Controls.Add(this.lblConventionalLoanAmt);
            this.gbResults.Controls.Add(this.label27);
            this.gbResults.Controls.Add(this.lblTotalPaid);
            this.gbResults.Controls.Add(this.label29);
            this.gbResults.Controls.Add(this.lblInterestReduction);
            this.gbResults.Controls.Add(this.label19);
            this.gbResults.Controls.Add(this.lblTotalInterestPaid);
            this.gbResults.Controls.Add(this.label21);
            this.gbResults.Controls.Add(this.lblEndDate);
            this.gbResults.Controls.Add(this.label23);
            this.gbResults.Controls.Add(this.lblTotalExtraPayments);
            this.gbResults.Controls.Add(this.label25);
            this.gbResults.Controls.Add(this.lblStartDate);
            this.gbResults.Controls.Add(this.label16);
            this.gbResults.Controls.Add(this.lblInterestRate);
            this.gbResults.Controls.Add(this.label18);
            this.gbResults.Controls.Add(this.lblTotalTerm);
            this.gbResults.Controls.Add(this.label13);
            this.gbResults.Controls.Add(this.lblLoanAmount);
            this.gbResults.Controls.Add(this.label11);
            this.gbResults.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbResults.Location = new System.Drawing.Point(13, 394);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(1083, 297);
            this.gbResults.TabIndex = 2;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Results";
            this.gbResults.Visible = false;
            // 
            // dgvAmortizationSchedule
            // 
            this.dgvAmortizationSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmortizationSchedule.Location = new System.Drawing.Point(6, 98);
            this.dgvAmortizationSchedule.Name = "dgvAmortizationSchedule";
            this.dgvAmortizationSchedule.RowTemplate.Height = 25;
            this.dgvAmortizationSchedule.Size = new System.Drawing.Size(1071, 182);
            this.dgvAmortizationSchedule.TabIndex = 22;
            // 
            // lblConventionalLoanAmt
            // 
            this.lblConventionalLoanAmt.AutoSize = true;
            this.lblConventionalLoanAmt.Location = new System.Drawing.Point(966, 60);
            this.lblConventionalLoanAmt.Name = "lblConventionalLoanAmt";
            this.lblConventionalLoanAmt.Size = new System.Drawing.Size(47, 15);
            this.lblConventionalLoanAmt.TabIndex = 21;
            this.lblConventionalLoanAmt.Text = "label26";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label27.Location = new System.Drawing.Point(848, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(107, 15);
            this.label27.TabIndex = 20;
            this.label27.Text = "Conventional Amt";
            // 
            // lblTotalPaid
            // 
            this.lblTotalPaid.AutoSize = true;
            this.lblTotalPaid.Location = new System.Drawing.Point(966, 31);
            this.lblTotalPaid.Name = "lblTotalPaid";
            this.lblTotalPaid.Size = new System.Drawing.Size(47, 15);
            this.lblTotalPaid.TabIndex = 19;
            this.lblTotalPaid.Text = "label28";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label29.Location = new System.Drawing.Point(843, 31);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(81, 15);
            this.label29.TabIndex = 18;
            this.label29.Text = "Total Paid  ($)";
            // 
            // lblInterestReduction
            // 
            this.lblInterestReduction.AutoSize = true;
            this.lblInterestReduction.Location = new System.Drawing.Point(767, 60);
            this.lblInterestReduction.Name = "lblInterestReduction";
            this.lblInterestReduction.Size = new System.Drawing.Size(47, 15);
            this.lblInterestReduction.TabIndex = 17;
            this.lblInterestReduction.Text = "label10";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(649, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 15);
            this.label19.TabIndex = 16;
            this.label19.Text = "Interest Reduction";
            // 
            // lblTotalInterestPaid
            // 
            this.lblTotalInterestPaid.AutoSize = true;
            this.lblTotalInterestPaid.Location = new System.Drawing.Point(767, 31);
            this.lblTotalInterestPaid.Name = "lblTotalInterestPaid";
            this.lblTotalInterestPaid.Size = new System.Drawing.Size(47, 15);
            this.lblTotalInterestPaid.TabIndex = 15;
            this.lblTotalInterestPaid.Text = "label20";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(644, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(126, 15);
            this.label21.TabIndex = 14;
            this.label21.Text = "Total Interest Paid ($)";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(582, 60);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(47, 15);
            this.lblEndDate.TabIndex = 13;
            this.lblEndDate.Text = "label22";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(522, 60);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 15);
            this.label23.TabIndex = 12;
            this.label23.Text = "End Date";
            // 
            // lblTotalExtraPayments
            // 
            this.lblTotalExtraPayments.AutoSize = true;
            this.lblTotalExtraPayments.Location = new System.Drawing.Point(582, 31);
            this.lblTotalExtraPayments.Name = "lblTotalExtraPayments";
            this.lblTotalExtraPayments.Size = new System.Drawing.Size(47, 15);
            this.lblTotalExtraPayments.TabIndex = 11;
            this.lblTotalExtraPayments.Text = "label24";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(443, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(141, 15);
            this.label25.TabIndex = 10;
            this.label25.Text = "Total Extra Payments ($)";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(358, 60);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(47, 15);
            this.lblStartDate.TabIndex = 9;
            this.lblStartDate.Text = "label15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(274, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 15);
            this.label16.TabIndex = 8;
            this.label16.Text = "Start Date";
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.AutoSize = true;
            this.lblInterestRate.Location = new System.Drawing.Point(358, 31);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(47, 15);
            this.lblInterestRate.TabIndex = 7;
            this.lblInterestRate.Text = "label17";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(259, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 15);
            this.label18.TabIndex = 6;
            this.label18.Text = "Interest Rate (%)";
            // 
            // lblTotalTerm
            // 
            this.lblTotalTerm.AutoSize = true;
            this.lblTotalTerm.Location = new System.Drawing.Point(152, 60);
            this.lblTotalTerm.Name = "lblTotalTerm";
            this.lblTotalTerm.Size = new System.Drawing.Size(47, 15);
            this.lblTotalTerm.TabIndex = 5;
            this.lblTotalTerm.Text = "label14";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(68, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "Total Term";
            // 
            // lblLoanAmount
            // 
            this.lblLoanAmount.AutoSize = true;
            this.lblLoanAmount.Location = new System.Drawing.Point(152, 31);
            this.lblLoanAmount.Name = "lblLoanAmount";
            this.lblLoanAmount.Size = new System.Drawing.Size(33, 15);
            this.lblLoanAmount.TabIndex = 3;
            this.lblLoanAmount.Text = "label";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(49, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Loan Amount ($)";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(987, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 39);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 28);
            this.label1.TabIndex = 14;
            this.label1.Text = "Brian\'s Mortgage Calculator With Extra Payments";
            // 
            // btnCreateExcelFile
            // 
            this.btnCreateExcelFile.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateExcelFile.Image")));
            this.btnCreateExcelFile.Location = new System.Drawing.Point(861, 5);
            this.btnCreateExcelFile.Name = "btnCreateExcelFile";
            this.btnCreateExcelFile.Size = new System.Drawing.Size(50, 50);
            this.btnCreateExcelFile.TabIndex = 15;
            this.btnCreateExcelFile.UseVisualStyleBackColor = true;
            this.btnCreateExcelFile.Click += new System.EventHandler(this.btnCreateExcelFile_Click);
            // 
            // btnCreateTextFile
            // 
            this.btnCreateTextFile.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateTextFile.Image")));
            this.btnCreateTextFile.Location = new System.Drawing.Point(917, 5);
            this.btnCreateTextFile.Name = "btnCreateTextFile";
            this.btnCreateTextFile.Size = new System.Drawing.Size(50, 50);
            this.btnCreateTextFile.TabIndex = 16;
            this.btnCreateTextFile.UseVisualStyleBackColor = true;
            this.btnCreateTextFile.Click += new System.EventHandler(this.btnCreateTextFile_Click);
            // 
            // btnCreatePDF
            // 
            this.btnCreatePDF.Image = ((System.Drawing.Image)(resources.GetObject("btnCreatePDF.Image")));
            this.btnCreatePDF.Location = new System.Drawing.Point(805, 5);
            this.btnCreatePDF.Name = "btnCreatePDF";
            this.btnCreatePDF.Size = new System.Drawing.Size(50, 50);
            this.btnCreatePDF.TabIndex = 17;
            this.btnCreatePDF.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 696);
            this.Controls.Add(this.btnCreatePDF);
            this.Controls.Add(this.btnCreateTextFile);
            this.Controls.Add(this.btnCreateExcelFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.gpbxExtraPayments);
            this.Controls.Add(this.gpbxMortgageInformation);
            this.Name = "mainForm";
            this.Text = "Mortgage Application";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.gpbxMortgageInformation.ResumeLayout(false);
            this.gpbxMortgageInformation.PerformLayout();
            this.gpbxExtraPayments.ResumeLayout(false);
            this.gpbxExtraPayments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtraPaymentsTable)).EndInit();
            this.gbResults.ResumeLayout(false);
            this.gbResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizationSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbxMortgageInformation;
        private System.Windows.Forms.TextBox txtTotalLoanAmount;
        private System.Windows.Forms.Label labelTotalLoanAmount;
        private System.Windows.Forms.GroupBox gpbxExtraPayments;
        private System.Windows.Forms.DateTimePicker dtMortgageStartDate;
        private System.Windows.Forms.Label labelMortgageStartDate;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label labelInterestRate;
        private System.Windows.Forms.TextBox txtLoanTerm;
        private System.Windows.Forms.Label labelLoanTerm;
        private System.Windows.Forms.TextBox txtDownPayment;
        private System.Windows.Forms.Label labelDownPayment;
        private System.Windows.Forms.TextBox txtPaymentInterval;
        private System.Windows.Forms.Label labelPaymentInterval;
        private System.Windows.Forms.TextBox txtNumberofExtraPayments;
        private System.Windows.Forms.Label labelNumberofExtraPayments;
        private System.Windows.Forms.TextBox txtExtraPaymentAmount;
        private System.Windows.Forms.Label labelExtraPaymentAmount;
        private System.Windows.Forms.Button btnCalculateMortgage;
        private System.Windows.Forms.DataGridView dgvExtraPaymentsTable;
        private System.Windows.Forms.Button btnAddExtraPayment;
        private System.Windows.Forms.DateTimePicker dtFirstExtraPayment;
        private System.Windows.Forms.Label labelFirstExtraPayment;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.Label lblInterestReduction;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblTotalInterestPaid;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblTotalExtraPayments;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblInterestRate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTotalTerm;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblLoanAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblConventionalLoanAmt;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblTotalPaid;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DataGridView dgvAmortizationSchedule;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMortgageStartDateValidation;
        private System.Windows.Forms.Label lblInterestRateValidation;
        private System.Windows.Forms.Label lblLoanTermValidation;
        private System.Windows.Forms.Label lblDownPaymentValidation;
        private System.Windows.Forms.Label lblTotalLoanAmountValidation;
        private System.Windows.Forms.Label lblExtraPaymentsStartDateValidation;
        private System.Windows.Forms.Label lblPaymentIntervalValidation;
        private System.Windows.Forms.Label lblNumberofPaymentsValidation;
        private System.Windows.Forms.Label lblExtraPaymentAmountValidation;
        private System.Windows.Forms.Button btnCreateExcelFile;
        private System.Windows.Forms.Button btnCreateTextFile;
        private System.Windows.Forms.Button btnCreatePDF;
    }
}

