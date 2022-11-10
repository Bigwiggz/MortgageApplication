using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageAppLibrary.Services.MortgageServices
{
    internal class BasicMortgageCalculationService
    {
        public decimal CalculateRemainingLoanAmount(decimal DownPayment, decimal TotalLoanAmt)
        {
            return TotalLoanAmt - DownPayment;
        }

        public decimal CalculateFixedMonthlyPayment(decimal remainingLoanAmt, decimal interestRate, int loanTerm)
        {
            double L = (double)remainingLoanAmt;
            double c = (double)interestRate / 12;
            int n = loanTerm * 12;
            double P;

            P = L * (c * Math.Pow(1 + c, n)) / (Math.Pow(1 + c, n) - 1);

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
            double c = (double)interestRate / 12;
            int n = loanTerm;
            double p = (double)fixedMonthlyPayment;
            double B;

            B = L * (Math.Pow(1 + c, n)) - p * ((Math.Pow(1 + c, n) - 1) / c);

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
    }
}
