using MortgageAppLibrary.Services.MortgageServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageAppLibrary.Tests.MortgageServices;

public class BasicMortgageCalculatorServiceTests
{
	BasicMortgageCalculationService _basicMortgageCalculationService;

	public BasicMortgageCalculatorServiceTests()
	{
		_basicMortgageCalculationService = new BasicMortgageCalculationService();
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
	[InlineData(100000,.05,120,1060.66)]
	public void CalculateFixedMonthlyPayment_ShouldProvideFixedMonthlyPayment(decimal remainingLoanAmt, decimal interestRate, int loanTerm, decimal expected)
	{
		//Arrange

		//Act
		decimal actual = _basicMortgageCalculationService.CalculateFixedMonthlyPayment(remainingLoanAmt, interestRate, loanTerm);

        //Assert
        Assert.Equal(expected, actual);
    }
}
