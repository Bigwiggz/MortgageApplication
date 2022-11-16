using MortgageAppLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageAppLibrary.Tests.MortgageServices;

public class MortgagePaymentScheduleServiceTest
{

	public MortgagePaymentScheduleServiceTest()
	{

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
	public void CalculatedPeriodMortgageData_ShouldCalculateMortgageAmortizationSchedule(MortgageInput mortgageInput, List<MonthlyCalculatedValues> expected)
	{
		//Arrange

		//Act

		//Assert
	}
}
