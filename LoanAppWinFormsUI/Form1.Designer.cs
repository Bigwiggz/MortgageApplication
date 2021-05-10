
namespace LoanAppWinFormsUI
{
    partial class MortgageAppMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalLoanAmount = new System.Windows.Forms.TextBox();
            this.txtDownPayment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoanTerm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStartDateofLoan = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtExtraPaymentAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumberofPayments = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPaymentInterval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtDateofFirstExtraPayment = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvExtraPaymentLog = new System.Windows.Forms.DataGridView();
            this.btnAddExtraPayment = new System.Windows.Forms.Button();
            this.btnCalculateMortgageSchedule = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtraPaymentLog)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCalculateMortgageSchedule);
            this.groupBox1.Controls.Add(this.dtStartDateofLoan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLoanTerm);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtInterestRate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDownPayment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTotalLoanAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mortgage Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Loan Amount ($)";
            // 
            // txtTotalLoanAmount
            // 
            this.txtTotalLoanAmount.Location = new System.Drawing.Point(134, 32);
            this.txtTotalLoanAmount.Name = "txtTotalLoanAmount";
            this.txtTotalLoanAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalLoanAmount.TabIndex = 1;
            // 
            // txtDownPayment
            // 
            this.txtDownPayment.Location = new System.Drawing.Point(134, 70);
            this.txtDownPayment.Name = "txtDownPayment";
            this.txtDownPayment.Size = new System.Drawing.Size(100, 20);
            this.txtDownPayment.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Down Payment ($)";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(133, 108);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(100, 20);
            this.txtInterestRate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Interest Rate (%)";
            // 
            // txtLoanTerm
            // 
            this.txtLoanTerm.Location = new System.Drawing.Point(133, 145);
            this.txtLoanTerm.Name = "txtLoanTerm";
            this.txtLoanTerm.Size = new System.Drawing.Size(100, 20);
            this.txtLoanTerm.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Loan Term (yrs)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Start Date of Loan";
            // 
            // dtStartDateofLoan
            // 
            this.dtStartDateofLoan.Location = new System.Drawing.Point(134, 187);
            this.dtStartDateofLoan.Name = "dtStartDateofLoan";
            this.dtStartDateofLoan.Size = new System.Drawing.Size(200, 20);
            this.dtStartDateofLoan.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddExtraPayment);
            this.groupBox2.Controls.Add(this.dgvExtraPaymentLog);
            this.groupBox2.Controls.Add(this.dtDateofFirstExtraPayment);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPaymentInterval);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtNumberofPayments);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtExtraPaymentAmount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(392, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(644, 306);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extra Payments";
            // 
            // txtExtraPaymentAmount
            // 
            this.txtExtraPaymentAmount.Location = new System.Drawing.Point(151, 29);
            this.txtExtraPaymentAmount.Name = "txtExtraPaymentAmount";
            this.txtExtraPaymentAmount.Size = new System.Drawing.Size(100, 20);
            this.txtExtraPaymentAmount.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Extra Payment Amount ($)";
            // 
            // txtNumberofPayments
            // 
            this.txtNumberofPayments.Location = new System.Drawing.Point(151, 66);
            this.txtNumberofPayments.Name = "txtNumberofPayments";
            this.txtNumberofPayments.Size = new System.Drawing.Size(100, 20);
            this.txtNumberofPayments.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Number of Payments";
            // 
            // txtPaymentInterval
            // 
            this.txtPaymentInterval.Location = new System.Drawing.Point(151, 105);
            this.txtPaymentInterval.Name = "txtPaymentInterval";
            this.txtPaymentInterval.Size = new System.Drawing.Size(100, 20);
            this.txtPaymentInterval.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Payment Interval (mths)";
            // 
            // dtDateofFirstExtraPayment
            // 
            this.dtDateofFirstExtraPayment.Location = new System.Drawing.Point(152, 152);
            this.dtDateofFirstExtraPayment.Name = "dtDateofFirstExtraPayment";
            this.dtDateofFirstExtraPayment.Size = new System.Drawing.Size(200, 20);
            this.dtDateofFirstExtraPayment.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Start Date of Extra Payment";
            // 
            // dgvExtraPaymentLog
            // 
            this.dgvExtraPaymentLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtraPaymentLog.Location = new System.Drawing.Point(9, 187);
            this.dgvExtraPaymentLog.Name = "dgvExtraPaymentLog";
            this.dgvExtraPaymentLog.Size = new System.Drawing.Size(629, 96);
            this.dgvExtraPaymentLog.TabIndex = 18;
            // 
            // btnAddExtraPayment
            // 
            this.btnAddExtraPayment.Location = new System.Drawing.Point(474, 90);
            this.btnAddExtraPayment.Name = "btnAddExtraPayment";
            this.btnAddExtraPayment.Size = new System.Drawing.Size(119, 35);
            this.btnAddExtraPayment.TabIndex = 19;
            this.btnAddExtraPayment.Text = "Add Extra Payment";
            this.btnAddExtraPayment.UseVisualStyleBackColor = true;
            // 
            // btnCalculateMortgageSchedule
            // 
            this.btnCalculateMortgageSchedule.Location = new System.Drawing.Point(76, 242);
            this.btnCalculateMortgageSchedule.Name = "btnCalculateMortgageSchedule";
            this.btnCalculateMortgageSchedule.Size = new System.Drawing.Size(146, 41);
            this.btnCalculateMortgageSchedule.TabIndex = 10;
            this.btnCalculateMortgageSchedule.Text = "Get Mortgage Schedule";
            this.btnCalculateMortgageSchedule.UseVisualStyleBackColor = true;
            this.btnCalculateMortgageSchedule.Click += new System.EventHandler(this.btnCalculateMortgageSchedule_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(22, 364);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1014, 277);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(999, 170);
            this.dataGridView1.TabIndex = 0;
            // 
            // MortgageAppMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 653);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MortgageAppMain";
            this.Text = "Mortgage Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtraPaymentLog)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotalLoanAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoanTerm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDownPayment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStartDateofLoan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvExtraPaymentLog;
        private System.Windows.Forms.DateTimePicker dtDateofFirstExtraPayment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPaymentInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumberofPayments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtExtraPaymentAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddExtraPayment;
        private System.Windows.Forms.Button btnCalculateMortgageSchedule;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

