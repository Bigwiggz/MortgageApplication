using System;
using System.Collections.Generic;
using System.Text;
using MortgageAppLibrary.Models;

namespace MortgageAppLibrary.Models
{
    public class MortgageInputExtraPayments
    {
        public decimal TotalLoanAmount { get; set; }

        public decimal DownPayment { get; set; }

        public int LoanTerm { get; set; }

        public decimal InterestRate { get; set; }

        public string LoanDescription { get; set; }

        public DateTime StartDate { get; set; }

        public List<ExtraPayments> ExtraPayments { get; set; }


        private bool validateExtraPaymentBeLessThanLoanAmount;

        public bool ValidateExtraPaymentBeLessThanLoanAmount { get { return validateExtraPaymentBeLessThanLoanAmount; } set { ExtraPaymentBeLessThanLoanAmountValidator(); } }

        //Add Methods

        public decimal CalculateRemainingLoanAmount(decimal DownPayment,decimal TotalLoanAmt)
        {
            return TotalLoanAmt - DownPayment;
        }

        public decimal CalculateFixedMonthlyPayment(decimal remainingLoanAmt, decimal interestRate, int loanTerm) 
        {
            double L=(double)remainingLoanAmt;
            double c = (double)interestRate/12;
            int n = loanTerm*12;
            double P;

            P = L * (c *Math.Pow(1 + c, n))/ (Math.Pow(1 + c, n)-1);

            decimal fixedMonthlyPayment = (decimal)P;

            return fixedMonthlyPayment;
        }

        public decimal CalculateTotalInterestPaid(decimal fixedMonthlyPayment, int loanTerm, decimal remainingLoanAmt)
        {
            return loanTerm * 12 * fixedMonthlyPayment - remainingLoanAmt;
        }

        //Monthly figures

        public decimal CalculateRemainingLoanBalance(decimal remainingLoanAmt, decimal interestRate, int loanTerm, decimal fixedMonthlyPayment) 
        {
            double L = (double)remainingLoanAmt;
            double c = (double)interestRate/12;
            int n = loanTerm;
            double p=(double)fixedMonthlyPayment;
            double B;

            B = L * (Math.Pow(1 + c, n))-p*((Math.Pow(1 + c, n)-1) /c);

            decimal remainingLoanBalance = (decimal)B;

            return remainingLoanBalance;
        }

        public decimal CalculatePeriodInterest(decimal remainingLoanBalance, decimal interestRate) 
        {

            decimal periodInterest = remainingLoanBalance * (interestRate / 12);
            return periodInterest;
        }

        public decimal CalculatePeriodPrincipal(decimal periodInterest, decimal fixedMonthlyPayment) 
        {
            return fixedMonthlyPayment - periodInterest;
        }

        public List<MonthlyCalculatedValuesExtraPayments> CalculatedPeriodMortgageData() 
        {
            var result = new List<MonthlyCalculatedValuesExtraPayments>();
            decimal loanAmount = CalculateRemainingLoanAmount(this.DownPayment, this.TotalLoanAmount);
            decimal fixedPeriodPayment = CalculateFixedMonthlyPayment(loanAmount, this.InterestRate, this.LoanTerm);
            int numberOfPeriods = this.LoanTerm * 12;
            decimal totalInterest = 0M;
            decimal cumulativeExtraPayment = 0M;
            decimal cumulativePrincipalPayments = 0M;
            int i = 1;
            decimal remainingBalanceCounter;

            //Loop thru amortization schedule
            do
            {
                var record = new MonthlyCalculatedValuesExtraPayments();
                //Add Number
                record.IDNumber = i;

                //Add in date
                record.DateColumn = new DateTime(StartDate.AddMonths(i-1).Year, StartDate.AddMonths(i-1).Month, 1);

                //Add in fixed monthly amount
                record.fixedPayment = fixedPeriodPayment;

                //Get the previous Extrapayment
                //ExtraPayment column
                record.ExtraPayment = 0;

                foreach (var payment in this.ExtraPayments)
                {
                    //Run the apply payment method
                    bool makeExtraPayment = payment.ApplyPayment(record.DateColumn);

                    //Tally up all the cumulative extra payments

                    //Add up the monthly extra payments
                    if (makeExtraPayment == true)
                    {
                        record.ExtraPayment = record.ExtraPayment + payment.ExtraPaymentAmount;
                        cumulativeExtraPayment = cumulativeExtraPayment + payment.ExtraPaymentAmount;
                    }
                }

                //Add together the cumulative extra payments
                record.CumulativeExtraPayment = cumulativeExtraPayment;

                //Add remaining balance
                record.RemainingBalance = loanAmount - cumulativePrincipalPayments - record.CumulativeExtraPayment;

                //Calculate the interest paid
                record.InterestPaid = CalculatePeriodInterest(record.RemainingBalance, this.InterestRate);

                //Add in monthly principal paid
                record.PrincipalPaid = CalculatePeriodPrincipal(record.InterestPaid, fixedPeriodPayment);
                cumulativePrincipalPayments = cumulativePrincipalPayments + record.PrincipalPaid;

                //Add total interest paid
                totalInterest = totalInterest + record.InterestPaid;
                record.TotalInterestPaid = totalInterest;

                //Add to result list
                result.Add(record);

                //reference remaining balance and change interation
                remainingBalanceCounter = record.RemainingBalance;
                i++;
            } while (remainingBalanceCounter > 0);
            
            return result;
        }

        //Validator Methods

        //Validation 1: Extra Payment amounts must be less than the initial loan balance
        private bool ExtraPaymentBeLessThanLoanAmountValidator() 
        {
            bool finalResult = true;

            var initalLoanBalance = this.TotalLoanAmount - this.DownPayment;

            if (this.ExtraPayments.Count>0)
            {
                foreach (var item in this.ExtraPayments)
                {
                    if (item.ExtraPaymentAmount>initalLoanBalance)
                    {
                        finalResult = false;
                    }
                }
            }
            return finalResult;
        }
    }
}
