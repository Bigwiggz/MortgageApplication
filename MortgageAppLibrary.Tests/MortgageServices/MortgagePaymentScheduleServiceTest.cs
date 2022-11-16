using MortgageAppLibrary.Tests.Extensions;
using MortgageAppLibrary.Models;
using MortgageAppLibrary.Services.MortgageServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageAppLibrary.Tests.MortgageServices;

public class MortgagePaymentScheduleServiceTest
{
    private MortgagePaymentScheduleService _MortgagePaymentScheduleService;
    private TestExtensions _testExtensions;
    private decimal _percentTolerance;

    public MortgagePaymentScheduleServiceTest()
	{
        _percentTolerance = 0.005M;
        _testExtensions = new TestExtensions();
        _MortgagePaymentScheduleService = new MortgagePaymentScheduleService();
	}

    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
               new MortgageInput
               { 
                   DownPayment=10000M,
                   InterestRate=0.05M,
                   LoanDescription="",
                   StartDate=new DateTime(2020,1,1),
                   LoanTerm=30,
                   TotalLoanAmount=210000M
               },
               new List<MonthlyCalculatedValues>
               {

               }

            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(CalculatorTestData))]
	public void CalculatedPeriodMortgageData_ShouldCalculateMortgageAmortizationSchedule(object[] insertedObject)
	{
        //Arrange
        var mortgageInput=(MortgageInput)insertedObject[0];
        List<MonthlyCalculatedValues> amortizationSchedule = (List<MonthlyCalculatedValues>)insertedObject[1];

        //Act
        var actual = _MortgagePaymentScheduleService.CalculatedPeriodMortgageData(mortgageInput);

        foreach (var expectedValue in amortizationSchedule)
        {
            foreach (var actualValue in actual)
            {
                bool isInterestPaidWithinTolerance = _testExtensions.IsNumberWithinPercentage(expectedValue.InterestPaid, actualValue.InterestPaid, _percentTolerance);
                bool isWithinTolerance=_testExtensions.IsNumberWithinPercentage(expectedValue.RemainingBalance,actualValue.RemainingBalance, _percentTolerance);

                //TODO: Finish Test
                if (isInterestPaidWithinTolerance == false || isWithinTolerance == false)
                {

                }
            }
        }

		//Assert
	}
}
