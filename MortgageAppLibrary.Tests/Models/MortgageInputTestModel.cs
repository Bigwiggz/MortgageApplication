using MortgageAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageAppLibrary.Tests.Models;

public class MortgageInputTestModel
{
    public MortgageInput MortgageInput { get; set; }
    public MonthlyCalculatedValues[] MonthlyCalculatedValuesList { get; set;}
}

