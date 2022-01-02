using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageAppLibrary.Models
{
    public class MortgageInput
    {
        public decimal TotalLoanAmount { get; set; }

        public decimal DownPayment { get; set; }

        public int LoanTerm { get; set; }

        public decimal InterestRate { get; set; }

        public string LoanDescription { get; set; }

        public DateTime StartDate { get; set; }

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

        public List<MonthlyCalculatedValues> CalculatedPeriodMortgageData() 
        {
            var result = new List<MonthlyCalculatedValues>();
            decimal loanAmount = CalculateRemainingLoanAmount(this.DownPayment, this.TotalLoanAmount);
            decimal fixedPeriodPayment = CalculateFixedMonthlyPayment(loanAmount, this.InterestRate, this.LoanTerm);
            int numberOfPeriods = this.LoanTerm * 12;
            decimal cumulativePrincipalPayments = 0M;
            decimal totalInterest = 0M;
            decimal previousRemainingBalance = 0;

            for (int i = 0; i < numberOfPeriods; i++)
            {
                var record = new MonthlyCalculatedValues();
                //Add Number
                record.IDNumber = i+1;

                //Add in date
                record.DateColumn = new DateTime(StartDate.AddMonths(i).Year, StartDate.AddMonths(i).Month, 1);

                //Add in fixed monthly amount
                record.fixedPayment = fixedPeriodPayment;

                //Calculate the interest paid
                if (i == 0)
                {
                    record.InterestPaid=CalculatePeriodInterest(loanAmount,this.InterestRate);
                }
                else
                {
                    record.InterestPaid = CalculatePeriodInterest(previousRemainingBalance, this.InterestRate);
                }

                //Add total interest paid
                totalInterest = totalInterest + record.InterestPaid;
                record.TotalInterestPaid = totalInterest;

                //Add in monthly principal paid
                record.PrincipalPaid = CalculatePeriodPrincipal(record.InterestPaid, fixedPeriodPayment);
                cumulativePrincipalPayments = cumulativePrincipalPayments + record.PrincipalPaid;

                //Add remaining balance
                record.RemainingBalance = loanAmount - cumulativePrincipalPayments;
                previousRemainingBalance = record.RemainingBalance;

                //Add to result list
                result.Add(record);
            }
            
            return result;
        }
    }
}
