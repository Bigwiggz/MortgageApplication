using System;
using System.Collections.Generic;
using MortgageAppLibrary.Models;
using MortgageAppLibrary.Services.Excel;
using MortgageAppLibrary.Services.TextFile;
using MortgageAppLibrary.Validators;

namespace LoanApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mortgage Application");

            Console.ForegroundColor = ConsoleColor.Green;

            var mortgageValues = new MortgageInput()
            {
                LoanDescription = "This is a test loan",
                LoanTerm = 30,
                InterestRate = 0.03875M,
                DownPayment = 11960M,
                TotalLoanAmount = 119600M,
                StartDate = new DateTime(2015, 1, 1)

            };

            var validateMortgageInput = new MortgageInputValidator();
            var resultTraditionalMortgageInput = validateMortgageInput.Validate(mortgageValues); 

            var amortizationSchedule = mortgageValues.CalculatedPeriodMortgageData();
            //--------------------------------------------------------------------------------------------------------

            List<ExtraPayments> testExtraPayments = new List<ExtraPayments>();
            
            var extraPayment1 = new ExtraPayments()
            {
                ExtraPaymentAmount = 1000M,
                NumberofPayments = 1,
                PaymentInterval = 1,
                StartDate= new DateTime(2037,11,1)
            };
            
            var validateExtraPayment1 = new ExtraPaymentsValidator();
            var result1 = validateExtraPayment1.Validate(extraPayment1);
            if (result1.IsValid)
            {
                testExtraPayments.Add(extraPayment1);
            }

            /*
            var extraPayment2 = new ExtraPayments()
            {
                ExtraPaymentAmount = 10M,
                NumberofPayments = 20,
                PaymentInterval = 3,
                StartDate = new DateTime(2016, 1, 1)
            };

            var validateExtraPayment2 = new ExtraPaymentsValidator();
            var result2 = validateExtraPayment2.Validate(extraPayment2);

            if (result2.IsValid)
            {
                testExtraPayments.Add(extraPayment2);
            }

            var extraPayment3 = new ExtraPayments()
            {
                ExtraPaymentAmount = 1M,
                NumberofPayments = 10,
                PaymentInterval = 1,
                StartDate = new DateTime(2016, 11, 1)
            };
            
            
            var validateExtraPayment3 = new ExtraPaymentsValidator();
            var result3 = validateExtraPayment3.Validate(extraPayment3);
            if (result3.IsValid)
            {
                testExtraPayments.Add(extraPayment3);
            }
            */

            var testMortgageValuesExtraPayments = new MortgageInputExtraPayments()
            {
                LoanDescription = "This is a test loan",
                LoanTerm = 30,
                InterestRate = 0.03875M,
                DownPayment = 10000M,
                TotalLoanAmount = 119600M,
                StartDate = new DateTime(2015, 1, 1),
                ExtraPayments=testExtraPayments

            };

            var validateMortgageValues = new MortgageInputExtraPaymentsValidator();
            var mortgageResult = validateMortgageValues.Validate(testMortgageValuesExtraPayments);

            //Create Amortization Schedule

            var testAmortizationSchedule = testMortgageValuesExtraPayments.CalculatedPeriodMortgageData();

            //Calculate Summary Values
            var summaryMortgageInfo = new MortgageExecutiveSummary();

            summaryMortgageInfo.CalculateMortgageExecutiveSummary(testAmortizationSchedule, testMortgageValuesExtraPayments);


            //Print out results
            foreach (var period in testAmortizationSchedule)
            {
                Console.WriteLine($"Period No:{period.IDNumber}");
                Console.WriteLine($"Date:{period.DateColumn}");
                Console.WriteLine($"Remaining Balance:{String.Format("{0:C2}", period.RemainingBalance)}");
                Console.WriteLine($"Principal Paid:{String.Format("{0:C2}", period.PrincipalPaid)}");
                Console.WriteLine($"Interest Paid:{String.Format("{0:C2}", period.InterestPaid)}");
                Console.WriteLine($"Fixed Payment:{String.Format("{0:C2}", period.fixedPayment)}");
                Console.WriteLine($"Total Interest Paid:{String.Format("{0:C2}", period.TotalInterestPaid)}");
                Console.WriteLine($"Extra Payment:{String.Format("{0:C2}", period.ExtraPayment)}");
                Console.WriteLine($"Extra Payment Cumulative:{String.Format("{0:C2}", period.CumulativeExtraPayment)}");
                Console.WriteLine($"------------------------------------------------");
            }

            //Final Results
            Console.WriteLine("");
            Console.WriteLine($"------------------------------------------------");
            Console.WriteLine("FINAL RESULTS");
           
            Console.WriteLine($"------------------------------------------------");

            //--------------------------------------------------------------------------------

            //Excel Print
            var excelApp = new ExcelMortgageOutput();

            var excelbyteArray=excelApp.CreateExcelTestFile(amortizationSchedule, testAmortizationSchedule, summaryMortgageInfo);

            //Text File Print
            var textPrint = new TextMortgageOutput();

            var textByteArray=textPrint.CreateTextFile(testAmortizationSchedule);
        }
    }
}
