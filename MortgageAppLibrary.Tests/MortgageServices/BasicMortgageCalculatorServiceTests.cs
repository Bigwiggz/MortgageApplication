using MortgageAppLibrary.Tests.Extensions;
using MortgageAppLibrary.Services.MortgageServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageAppLibrary.Tests.MortgageServices;

public class BasicMortgageCalculatorServiceTests
{
	private BasicMortgageCalculationService _basicMortgageCalculationService;
	private TestExtensions _testExtensions;
	private decimal _percentTolerance;

	public BasicMortgageCalculatorServiceTests()
	{
		_basicMortgageCalculationService = new BasicMortgageCalculationService();
        _testExtensions=new TestExtensions();
		_percentTolerance = 0.005M;
    }

	[Theory]
	[InlineData(10,30,20)]
    [InlineData(0, 0, 0)]
    [InlineData(100, 300, 200)]
	[InlineData(0,300,300)]
    public void CalculateRemainingLoanAmount_ShouldSubtractValues(decimal downPayment, decimal totalLoanAmount, decimal expected)
	{
        //Arrange

		//Act
		decimal actual = _basicMortgageCalculationService.CalculateRemainingLoanAmount(downPayment, totalLoanAmount);

		//Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(100000,0.05,10,1060.66)]
	[InlineData(200000,0.0694,30,1322)]
	public void CalculateFixedMonthlyPayment_ShouldProvideFixedMonthlyPayment(decimal remainingLoanAmt, decimal interestRate, int loanTerm, decimal expected)
	{
		//Arrange

		//Act
		decimal actual = _basicMortgageCalculationService.CalculateFixedMonthlyPayment(remainingLoanAmt, interestRate, loanTerm);
		var answer=_testExtensions.IsNumberWithinPercentage(expected, actual, _percentTolerance);

        //Assert
        Assert.True(answer);
    }

	[Theory]
	[InlineData(1322,30,200000,275920)]
	public void CalculateTotalInterestPaid_ShouldCalculateTotalInterestCorrectly(decimal fixedMonthlyPayment, int loanTerm, decimal remainingLoanAmt, decimal expected)
	{
		//Arrange

		//Act
		decimal actual = _basicMortgageCalculationService.CalculateTotalInterestPaid(fixedMonthlyPayment, loanTerm, remainingLoanAmt);
		var answer=_testExtensions.IsNumberWithinPercentage(expected,actual, _percentTolerance);

		//Assert
		Assert.True(answer);
	}

	
}
