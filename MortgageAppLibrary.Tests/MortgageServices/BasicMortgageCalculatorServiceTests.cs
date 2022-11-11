using MortgageAppLibrary.Services.MortgageServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MortgageAppLibrary.Tests.MortgageServices;

public class BasicMortgageCalculatorServiceTests
{
    public BasicMortgageCalculatorServiceTests()
    {
    }

    [Fact]  
    public void CalculateRemainingLoanAmount_ShouldCalculateSimpleValues()
    {
        //Arrange
        decimal downPayment = 1M;
        decimal totalLoanAmount = 1M;
        decimal expected = 0M;
        var basicMortgageCalculationService = new BasicMortgageCalculationService();
        //Act
        decimal actual = basicMortgageCalculationService.CalculateRemainingLoanAmount(downPayment, totalLoanAmount);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Add_SimpleValuesShouldCalculate()
    {
        //Arrange
        double expected = 5;
        //Act
        double actual = 5;
        //Assert
        Assert.Equal(expected, actual);
    }
}
