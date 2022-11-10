using MortgageAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortgageAppLibrary.Services.MortgageServices
{
    public class MortgageExecutiveSummaryService
    {
        //Methods
        public MortgageExecutiveSummary CalculateMortgageExecutiveSummary(List<MonthlyCalculatedValuesExtraPayments> amortizationExtraPaymentSchedule, MortgageInputExtraPayments extraPaymentMortgageInput)
        {
            //Mortgage exec summary object
            MortgageExecutiveSummary mortgageExecutiveSummary = new MortgageExecutiveSummary();

            //
            var basicMortgageCalculationService =new BasicMortgageCalculationService();

            //Mortgage Input

            mortgageExecutiveSummary.ActualLoanAmount = extraPaymentMortgageInput.TotalLoanAmount - extraPaymentMortgageInput.DownPayment;

            mortgageExecutiveSummary.OriginalLoanTerm = extraPaymentMortgageInput.LoanTerm;

            mortgageExecutiveSummary.InterestRate = extraPaymentMortgageInput.InterestRate;

            mortgageExecutiveSummary.LoanDescription = extraPaymentMortgageInput.LoanDescription;

            mortgageExecutiveSummary.StartDate = extraPaymentMortgageInput.StartDate;

            //Extra Payment Info

            mortgageExecutiveSummary.TotalInterestPaid = amortizationExtraPaymentSchedule.Last().TotalInterestPaid;

            mortgageExecutiveSummary.CumulativeExtraPayment = amortizationExtraPaymentSchedule.Last().CumulativeExtraPayment;

            mortgageExecutiveSummary.ExtraPaymentLoanTerm = amortizationExtraPaymentSchedule.Last().IDNumber / 12;

            mortgageExecutiveSummary.ExtraPaymentLastDate = amortizationExtraPaymentSchedule.Last().DateColumn;

            //Add the interest on a conventional loan

            //1) First calculate the fixed monthly payment
            mortgageExecutiveSummary.FixedMonthlyPayment = basicMortgageCalculationService.CalculateFixedMonthlyPayment(mortgageExecutiveSummary.ActualLoanAmount, mortgageExecutiveSummary.InterestRate, mortgageExecutiveSummary.OriginalLoanTerm);

            //2) Calculate Total Interest Paid
            mortgageExecutiveSummary.ConventionalInterestAmount = basicMortgageCalculationService.CalculateTotalInterestPaid(mortgageExecutiveSummary.FixedMonthlyPayment, mortgageExecutiveSummary.OriginalLoanTerm, mortgageExecutiveSummary.ActualLoanAmount);

            mortgageExecutiveSummary.TotalConvetionalLoanPayment = mortgageExecutiveSummary.ConventionalInterestAmount + mortgageExecutiveSummary.ActualLoanAmount;

            mortgageExecutiveSummary.TotalActualLoanPayment = mortgageExecutiveSummary.TotalInterestPaid + mortgageExecutiveSummary.ActualLoanAmount;

            //3) Calculate Interest Reduction
            mortgageExecutiveSummary.ExtraPaymentInterestReduction = mortgageExecutiveSummary.ConventionalInterestAmount - mortgageExecutiveSummary.TotalInterestPaid;

            return mortgageExecutiveSummary;
        }
    }
}
