using MortgageAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageAppLibrary.Services.MortgageServices
{
    public class MortgagePaymentScheduleService
    {
        public List<MonthlyCalculatedValues> CalculatedPeriodMortgageData(MortgageInput mortgageInput)
        {
            var basicMortgageCalculatorService = new BasicMortgageCalculationService();

            var result = new List<MonthlyCalculatedValues>();
            decimal loanAmount = basicMortgageCalculatorService.CalculateRemainingLoanAmount(mortgageInput.DownPayment, mortgageInput.TotalLoanAmount);
            decimal fixedPeriodPayment = basicMortgageCalculatorService.CalculateFixedMonthlyPayment(loanAmount, mortgageInput.InterestRate, mortgageInput.LoanTerm);
            int numberOfPeriods = mortgageInput.LoanTerm * 12;
            decimal cumulativePrincipalPayments = 0M;
            decimal totalInterest = 0M;
            decimal previousRemainingBalance = 0;

            for (int i = 0; i < numberOfPeriods; i++)
            {
                var record = new MonthlyCalculatedValues();
                //Add Number
                record.IDNumber = i + 1;

                //Add in date
                record.DateColumn = new DateTime(mortgageInput.StartDate.AddMonths(i).Year, mortgageInput.StartDate.AddMonths(i).Month, 1);

                //Add in fixed monthly amount
                record.fixedPayment = fixedPeriodPayment;

                //Calculate the interest paid
                if (i == 0)
                {
                    record.InterestPaid = basicMortgageCalculatorService.CalculatePeriodInterest(loanAmount, mortgageInput.InterestRate);
                }
                else
                {
                    record.InterestPaid = basicMortgageCalculatorService.CalculatePeriodInterest(previousRemainingBalance, mortgageInput.InterestRate);
                }

                //Add total interest paid
                totalInterest = totalInterest + record.InterestPaid;
                record.TotalInterestPaid = totalInterest;

                //Add in monthly principal paid
                record.PrincipalPaid = basicMortgageCalculatorService.CalculatePeriodPrincipal(record.InterestPaid, fixedPeriodPayment);
                cumulativePrincipalPayments = cumulativePrincipalPayments + record.PrincipalPaid;

                //Add remaining balance
                record.RemainingBalance = loanAmount - cumulativePrincipalPayments;
                previousRemainingBalance = record.RemainingBalance;

                //Add to result list
                result.Add(record);
            }

            return result;
        }

        public List<MonthlyCalculatedValuesExtraPayments> CalculatedExtraPaymentPeriodMortgageData(MortgageInputExtraPayments mortgageInputExtraPayments)
        {
            var basicMortgageCalculatorService = new BasicMortgageCalculationService();
            var extraPaymentService = new ExtraPaymentService();

            var result = new List<MonthlyCalculatedValuesExtraPayments>();
            decimal loanAmount = basicMortgageCalculatorService.CalculateRemainingLoanAmount(mortgageInputExtraPayments.DownPayment, mortgageInputExtraPayments.TotalLoanAmount);
            decimal fixedPeriodPayment = basicMortgageCalculatorService.CalculateFixedMonthlyPayment(loanAmount, mortgageInputExtraPayments.InterestRate, mortgageInputExtraPayments.LoanTerm);
            int numberOfPeriods = mortgageInputExtraPayments.LoanTerm * 12;
            decimal totalInterest = 0M;
            decimal cumulativeExtraPayment = 0M;
            decimal cumulativePrincipalPayments = 0M;
            int i = 1;
            decimal remainingBalanceCounter;
            decimal previousRemainingBalance = 0;

            //Loop thru amortization schedule
            do
            {
                var record = new MonthlyCalculatedValuesExtraPayments();
                //Add Number
                record.IDNumber = i;

                //Add in date
                record.DateColumn = new DateTime(mortgageInputExtraPayments.StartDate.AddMonths(i - 1).Year, mortgageInputExtraPayments.StartDate.AddMonths(i - 1).Month, 1);

                //Add in fixed monthly amount
                record.fixedPayment = fixedPeriodPayment;

                //Get the previous Extrapayment
                //ExtraPayment column
                record.ExtraPayment = 0;

                foreach (var payment in mortgageInputExtraPayments.ExtraPayments)
                {
                    //Run the apply payment method
                    bool makeExtraPayment = extraPaymentService.ApplyPayment(record.DateColumn, payment);

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


                //TODO: FIX THIS LOOK AT CFT LOAN SHARK ON YOUR GITHUB
                if (i == 1)
                {
                    record.InterestPaid = basicMortgageCalculatorService.CalculatePeriodInterest(loanAmount - record.CumulativeExtraPayment, mortgageInputExtraPayments.InterestRate);
                }
                else
                {
                    //Calculate the interest paid
                    record.InterestPaid = basicMortgageCalculatorService.CalculatePeriodInterest(previousRemainingBalance, mortgageInputExtraPayments.InterestRate);
                }

                //Add total interest paid
                totalInterest = totalInterest + record.InterestPaid;
                record.TotalInterestPaid = totalInterest;

                //Add in monthly principal paid
                record.PrincipalPaid = basicMortgageCalculatorService.CalculatePeriodPrincipal(record.InterestPaid, fixedPeriodPayment);
                cumulativePrincipalPayments = cumulativePrincipalPayments + record.PrincipalPaid;

                //Add remaining balance
                record.RemainingBalance = loanAmount - cumulativePrincipalPayments - record.CumulativeExtraPayment;
                previousRemainingBalance = record.RemainingBalance;

                //Add to result list
                result.Add(record);

                //reference remaining balance and change interation
                remainingBalanceCounter = record.RemainingBalance;
                i++;
            } while (remainingBalanceCounter > 0);

            return result;
        }


    }
}
