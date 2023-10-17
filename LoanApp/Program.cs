using System;
using System.IO;
using System.Collections.Generic;
using MortgageAppLibrary.Models;
using MortgageAppLibrary.Services.Excel;
using MortgageAppLibrary.Services.TextFile;
using MortgageAppLibrary.Validators;
using MortgageAppLibrary.Services.MortgageServices;
using MortgageAppLibrary.Tests.Models;

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
                LoanTerm = 5,
                InterestRate = 0.0374M,
                DownPayment = 10000M,
                TotalLoanAmount = 32000M,
                StartDate = new DateTime(2022, 11, 10)

            };

            var validateMortgageInput = new MortgageInputValidator();
            var resultTraditionalMortgageInput = validateMortgageInput.Validate(mortgageValues); 

            if (resultTraditionalMortgageInput.IsValid == false)
            {
                throw new NotImplementedException();
            }

            var mortgageAmortizationScheduleService = new MortgagePaymentScheduleService();
            var amortizationSchedule = mortgageAmortizationScheduleService.CalculatedPeriodMortgageData(mortgageValues);
            //--------------------------------------------------------------------------------------------------------

            List<ExtraPayments> testExtraPayments = new List<ExtraPayments>();
            
            var extraPayment1 = new ExtraPayments()
            {
                ExtraPaymentAmount = 10000M,
                NumberofPayments = 1,
                PaymentInterval = 1,
                StartDate= new DateTime(2022, 11, 10)
            };
            
            var validateExtraPayment1 = new ExtraPaymentsValidator();
            var result1 = validateExtraPayment1.Validate(extraPayment1);
            if (result1.IsValid)
            {
                testExtraPayments.Add(extraPayment1);
            }

            
            var extraPayment2 = new ExtraPayments()
            {
                ExtraPaymentAmount = 2500M,
                NumberofPayments = 1,
                PaymentInterval = 1,
                StartDate = new DateTime(2023, 4, 11)
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
                NumberofPayments = 1,
                PaymentInterval = 1,
                StartDate = new DateTime(2022, 11, 10)
            };
            
            
            var validateExtraPayment3 = new ExtraPaymentsValidator();
            var result3 = validateExtraPayment3.Validate(extraPayment3);
            if (result3.IsValid)
            {
                testExtraPayments.Add(extraPayment3);
            }
            

            var testMortgageValuesExtraPayments = new MortgageInputExtraPayments()
            {
                LoanDescription = "This is a test loan",
                LoanTerm = 5,
                InterestRate = 0.0374M,
                DownPayment = 10000M,
                TotalLoanAmount = 32000M,
                StartDate = new DateTime(2022, 11, 10),
                ExtraPayments =testExtraPayments

            };

            var validateMortgageValues = new MortgageInputExtraPaymentsValidator();
            var mortgageResult = validateMortgageValues.Validate(testMortgageValuesExtraPayments);

            //Create Amortization Schedule
            var testAmortizationSchedule = mortgageAmortizationScheduleService.CalculatedExtraPaymentPeriodMortgageData(testMortgageValuesExtraPayments);

            //Calculate Summary Values
            var executiveMortgageSummaryService = new MortgageExecutiveSummaryService();
            var summaryMortgageInfo = executiveMortgageSummaryService.CalculateMortgageExecutiveSummary(testAmortizationSchedule, testMortgageValuesExtraPayments);

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

            var excelByteArray=excelApp.CreateExcelTestFile(amortizationSchedule, testAmortizationSchedule, summaryMortgageInfo);

            string excelFileNameAndPath = @"C:\Users\Brian Wiggins\source\repos\LoanAppConsoleUI\LoanApp\Output\excelOutputFile.xlsx";
            File.WriteAllBytes(excelFileNameAndPath, excelByteArray);

            //Text File Print
            var textPrint = new TextMortgageOutput();

            var textByteArray=textPrint.CreateTextFile(testAmortizationSchedule);

            string textFileNameAndPath = @"C:\Users\Brian Wiggins\source\repos\LoanAppConsoleUI\LoanApp\Output\textOutputFile.txt";
            File.WriteAllBytes(textFileNameAndPath, textByteArray);

            //Testing information

            var testInfo = new MortgageInput
            {
                DownPayment = 10000M,
                InterestRate = 0.05M,
                LoanDescription = "",
                StartDate = new DateTime(2020, 1, 1),
                LoanTerm = 30,
                TotalLoanAmount = 210000M
            };

            var resultTraditionalMortgageInputValidation = validateMortgageInput.Validate(testInfo);

            if (resultTraditionalMortgageInputValidation.IsValid == false)
            {
                throw new NotImplementedException();
            }

            var testingAmortizationSchedule = mortgageAmortizationScheduleService.CalculatedPeriodMortgageData(testInfo);
            


            List<MortgageInputTestModel> mortgageInputTestModels = new();
            MortgageInputTestModel mortgageInputTest = new MortgageInputTestModel
            {
                MortgageInput = testInfo,
                MonthlyCalculatedValuesList = testingAmortizationSchedule.ToArray()
            };

            mortgageInputTestModels.Add(mortgageInputTest);

            var testJSONObject = new TestJSONObject<MortgageInputTestModel>
            {
                TestObjectsList=mortgageInputTestModels.ToArray()
            };

            string testFileNameAndPath = @"C:\Users\Brian Wiggins\source\repos\LoanAppConsoleUI\MortgageAppLibrary.Tests\TestInputs\MortgageTestInput.json";
            textPrint.CreateStandardAmortizationSchedule(testJSONObject, testFileNameAndPath);

        }
    }
}
