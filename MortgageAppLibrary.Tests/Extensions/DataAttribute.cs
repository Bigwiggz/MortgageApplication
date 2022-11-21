using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MortgageAppLibrary.Tests.Extensions;

public abstract class DataAttribute:Attribute
{
    public virtual string Skip { get; set; }

    public abstract IEnumerable<object[]> GetData(MethodInfo testMethod);
}
