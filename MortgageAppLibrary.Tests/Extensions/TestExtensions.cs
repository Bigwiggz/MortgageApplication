using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageAppLibrary.Tests.Extensions;

internal class TestExtensions
{
    internal bool IsNumberWithinPercentage(decimal baseNumber, decimal slaveNumber, decimal percentage)
    {
        bool result = false;
        decimal floor=baseNumber*(1-percentage);
        decimal ceiling=baseNumber*(1+percentage);
        if (slaveNumber >= floor && slaveNumber < ceiling)
        {
            result = true;
        }
        return result;
    }
}
