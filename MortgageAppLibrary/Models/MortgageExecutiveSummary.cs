using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MortgageAppLibrary.Models
{
    public class MortgageExecutiveSummary
    {
        //------------------------------------------------------------------EXECUTIVE SUMMARY
        public decimal ExtraPaymentLoanTerm { get; set; }

        public decimal ExtraPaymentInterestReduction { get; set; }

        public DateTime ExtraPaymentLastDate { get; set; }

        //------------------------------------------------------------------MORTGAGE INPUT

        public decimal ActualLoanAmount { get; set; }

        public int OriginalLoanTerm { get; set; }

        public decimal InterestRate { get; set; }

        public string LoanDescription { get; set; }

        public DateTime StartDate { get; set; }

        public decimal FixedMonthlyPayment { get; set; }

        public decimal ConventionalInterestAmount { get; set; }

        public decimal TotalConvetionalLoanPayment { get; set; }

        //-------------------------------------------------------------------TOTAL INTEREST PAID-Extra Payments

        public decimal TotalInterestPaid { get; set; }

        public decimal CumulativeExtraPayment { get; set; }

        public decimal TotalActualLoanPayment { get; set; }

        //-------------------------------------------------------------------

        private decimal CalculateFixedMonthlyPayment(decimal remainingLoanAmt, decimal interestRate, int loanTerm)
        {
            double L = (double)remainingLoanAmt;
            double c = (double)interestRate / 12;
            int n = loanTerm * 12;
            double P;

            P = L * (c * Math.Pow(1 + c, n)) / (Math.Pow(1 + c, n) - 1);

            decimal fixedMonthlyPayment = (decimal)P;

            return fixedMonthlyPayment;
        }

        private decimal CalculateTotalInterestPaid(decimal fixedMonthlyPayment, int loanTerm, decimal remainingLoanAmt)
        {
            return loanTerm * 12 * fixedMonthlyPayment - remainingLoanAmt;
        }


        //Methods
        public void CalculateMortgageExecutiveSummary(List<MonthlyCalculatedValuesExtraPayments> amortizationExtraPaymentSchedule, MortgageInputExtraPayments extraPaymentMortgageInput)
        {
            //Mortgage Input

            this.ActualLoanAmount = extraPaymentMortgageInput.TotalLoanAmount - extraPaymentMortgageInput.DownPayment;

            this.OriginalLoanTerm = extraPaymentMortgageInput.LoanTerm;

            this.InterestRate = extraPaymentMortgageInput.InterestRate;

            this.LoanDescription = extraPaymentMortgageInput.LoanDescription;

            this.StartDate = extraPaymentMortgageInput.StartDate;

            //Extra Payment Info

            this.TotalInterestPaid = amortizationExtraPaymentSchedule.Last().TotalInterestPaid;

            this.CumulativeExtraPayment = amortizationExtraPaymentSchedule.Last().CumulativeExtraPayment;

            this.ExtraPaymentLoanTerm = amortizationExtraPaymentSchedule.Last().IDNumber/12;

            this.ExtraPaymentLastDate = amortizationExtraPaymentSchedule.Last().DateColumn;

            //Add the interest on a conventional loan

            //1) First calculate the fixed monthly payment
            this.FixedMonthlyPayment = CalculateFixedMonthlyPayment(this.ActualLoanAmount, this.InterestRate, this.OriginalLoanTerm);

            //2) Calculate Total Interest Paid
            this.ConventionalInterestAmount = CalculateTotalInterestPaid(this.FixedMonthlyPayment, this.OriginalLoanTerm, this.ActualLoanAmount);

            this.TotalConvetionalLoanPayment = this.ConventionalInterestAmount + this.ActualLoanAmount;

            this.TotalActualLoanPayment = this.TotalInterestPaid + this.ActualLoanAmount;

            //3) Calculate Interest Reduction
            this.ExtraPaymentInterestReduction = this.ConventionalInterestAmount - this.TotalInterestPaid;
        }
    }
}
