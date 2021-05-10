
namespace LoanAppWinFormUI
{
    partial class Mortgage
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.txtMortgageLoanAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mortgageGroup = new System.Windows.Forms.GroupBox();
            this.lblNumberofExtraPayments = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtLoanStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoanTerm = new System.Windows.Forms.TextBox();
            this.txtDownPayment = new System.Windows.Forms.TextBox();
            this.extraPayment = new System.Windows.Forms.GroupBox();
            this.dgvExtraPayment = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dtExtraPaymentStartDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPaymentInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumberofPayments = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExtraPaymentAmount = new System.Windows.Forms.TextBox();
            this.mortgageGroup.SuspendLayout();
            this.extraPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtraPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(32, 19);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(123, 15);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Mortgage Application";
            // 
            // txtMortgageLoanAmount
            // 
            this.txtMortgageLoanAmount.Location = new System.Drawing.Point(157, 35);
            this.txtMortgageLoanAmount.Name = "txtMortgageLoanAmount";
            this.txtMortgageLoanAmount.Size = new System.Drawing.Size(131, 23);
            this.txtMortgageLoanAmount.TabIndex = 1;
            this.txtMortgageLoanAmount.Tag = "txtMortgageLoanAmount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Loan Amount ($)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // mortgageGroup
            // 
            this.mortgageGroup.Controls.Add(this.lblNumberofExtraPayments);
            this.mortgageGroup.Controls.Add(this.label10);
            this.mortgageGroup.Controls.Add(this.button2);
            this.mortgageGroup.Controls.Add(this.label8);
            this.mortgageGroup.Controls.Add(this.label7);
            this.mortgageGroup.Controls.Add(this.dtLoanStartDate);
            this.mortgageGroup.Controls.Add(this.label2);
            this.mortgageGroup.Controls.Add(this.label3);
            this.mortgageGroup.Controls.Add(this.txtLoanTerm);
            this.mortgageGroup.Controls.Add(this.txtDownPayment);
            this.mortgageGroup.Controls.Add(this.label1);
            this.mortgageGroup.Controls.Add(this.txtMortgageLoanAmount);
            this.mortgageGroup.Location = new System.Drawing.Point(32, 48);
            this.mortgageGroup.Name = "mortgageGroup";
            this.mortgageGroup.Size = new System.Drawing.Size(383, 311);
            this.mortgageGroup.TabIndex = 3;
            this.mortgageGroup.TabStop = false;
            this.mortgageGroup.Text = "Mortagage Information";
            // 
            // lblNumberofExtraPayments
            // 
            this.lblNumberofExtraPayments.AutoSize = true;
            this.lblNumberofExtraPayments.Location = new System.Drawing.Point(157, 194);
            this.lblNumberofExtraPayments.Name = "lblNumberofExtraPayments";
            this.lblNumberofExtraPayments.Size = new System.Drawing.Size(13, 15);
            this.lblNumberofExtraPayments.TabIndex = 12;
            this.lblNumberofExtraPayments.Tag = "LblNumberofExtraPayments";
            this.lblNumberofExtraPayments.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 194);
            this.label10.MaximumSize = new System.Drawing.Size(140, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 30);
            this.label10.TabIndex = 11;
            this.label10.Text = "Number of Extra Payment Streams";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Create Mortgage Schedule";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CreateMortgage);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Loan Start Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1126, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Loan Term (yrs)";
            // 
            // dtLoanStartDate
            // 
            this.dtLoanStartDate.Location = new System.Drawing.Point(157, 153);
            this.dtLoanStartDate.Name = "dtLoanStartDate";
            this.dtLoanStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtLoanStartDate.TabIndex = 6;
            this.dtLoanStartDate.Tag = "dtLoanStartDate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Down Payment ($)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Loan Term (yrs)";
            // 
            // txtLoanTerm
            // 
            this.txtLoanTerm.Location = new System.Drawing.Point(157, 111);
            this.txtLoanTerm.Name = "txtLoanTerm";
            this.txtLoanTerm.Size = new System.Drawing.Size(131, 23);
            this.txtLoanTerm.TabIndex = 1;
            this.txtLoanTerm.Tag = "txtLoanTerm";
            // 
            // txtDownPayment
            // 
            this.txtDownPayment.Location = new System.Drawing.Point(157, 74);
            this.txtDownPayment.Name = "txtDownPayment";
            this.txtDownPayment.Size = new System.Drawing.Size(131, 23);
            this.txtDownPayment.TabIndex = 4;
            this.txtDownPayment.Tag = "txtDownPayment";
            // 
            // extraPayment
            // 
            this.extraPayment.Controls.Add(this.dgvExtraPayment);
            this.extraPayment.Controls.Add(this.button1);
            this.extraPayment.Controls.Add(this.dtExtraPaymentStartDate);
            this.extraPayment.Controls.Add(this.label9);
            this.extraPayment.Controls.Add(this.txtPaymentInterval);
            this.extraPayment.Controls.Add(this.label4);
            this.extraPayment.Controls.Add(this.label5);
            this.extraPayment.Controls.Add(this.txtNumberofPayments);
            this.extraPayment.Controls.Add(this.label6);
            this.extraPayment.Controls.Add(this.txtExtraPaymentAmount);
            this.extraPayment.Location = new System.Drawing.Point(421, 48);
            this.extraPayment.Name = "extraPayment";
            this.extraPayment.Size = new System.Drawing.Size(748, 311);
            this.extraPayment.TabIndex = 4;
            this.extraPayment.TabStop = false;
            this.extraPayment.Text = "Extra Payment Streams";
            this.extraPayment.Enter += new System.EventHandler(this.extraPayment_Enter);
            // 
            // dgvExtraPayment
            // 
            this.dgvExtraPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtraPayment.Location = new System.Drawing.Point(6, 227);
            this.dgvExtraPayment.Name = "dgvExtraPayment";
            this.dgvExtraPayment.RowTemplate.Height = 25;
            this.dgvExtraPayment.Size = new System.Drawing.Size(736, 59);
            this.dgvExtraPayment.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 9;
            this.button1.Tag = "btnAddExtraPayment";
            this.button1.Text = "Add Extra Payment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddExtraPayment);
            // 
            // dtExtraPaymentStartDate
            // 
            this.dtExtraPaymentStartDate.Location = new System.Drawing.Point(156, 71);
            this.dtExtraPaymentStartDate.Name = "dtExtraPaymentStartDate";
            this.dtExtraPaymentStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtExtraPaymentStartDate.TabIndex = 8;
            this.dtExtraPaymentStartDate.Tag = "dtExtraPaymentStartDate";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Payment Interval (months)";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtPaymentInterval
            // 
            this.txtPaymentInterval.Location = new System.Drawing.Point(156, 150);
            this.txtPaymentInterval.Name = "txtPaymentInterval";
            this.txtPaymentInterval.Size = new System.Drawing.Size(131, 23);
            this.txtPaymentInterval.TabIndex = 6;
            this.txtPaymentInterval.Tag = "txtPaymentInterval";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Start Date of Extra Payment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Number of Payments";
            // 
            // txtNumberofPayments
            // 
            this.txtNumberofPayments.Location = new System.Drawing.Point(157, 111);
            this.txtNumberofPayments.Name = "txtNumberofPayments";
            this.txtNumberofPayments.Size = new System.Drawing.Size(131, 23);
            this.txtNumberofPayments.TabIndex = 1;
            this.txtNumberofPayments.Tag = "txtNumberofPayments";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 15);
            this.label6.TabIndex = 2;
            this.label6.Tag = "";
            this.label6.Text = "Extra Payment Amount ($)";
            // 
            // txtExtraPaymentAmount
            // 
            this.txtExtraPaymentAmount.Location = new System.Drawing.Point(157, 35);
            this.txtExtraPaymentAmount.Name = "txtExtraPaymentAmount";
            this.txtExtraPaymentAmount.Size = new System.Drawing.Size(131, 23);
            this.txtExtraPaymentAmount.TabIndex = 1;
            this.txtExtraPaymentAmount.Tag = "txtExtraPaymentAmount";
            // 
            // Mortgage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 586);
            this.Controls.Add(this.extraPayment);
            this.Controls.Add(this.mortgageGroup);
            this.Controls.Add(this.titleLabel);
            this.Name = "Mortgage";
            this.Tag = "txtExtraPaymentAmount";
            this.Text = "Mortgage Application";
            this.mortgageGroup.ResumeLayout(false);
            this.mortgageGroup.PerformLayout();
            this.extraPayment.ResumeLayout(false);
            this.extraPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtraPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox txtMortgageLoanAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox mortgageGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDownPayment;
        private System.Windows.Forms.TextBox txtLoanTerm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox extraPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumberofPayments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExtraPaymentAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtLoanStartDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPaymentInterval;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtExtraPaymentStartDate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblNumberofExtraPayments;
        private System.Windows.Forms.Label label10;
    }
}

