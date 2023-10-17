using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MortgageAppLibrary.Tests.Models;

public class TestJSONObject<T>
{
    public T[] TestObjectsList { get; set; }
}
