using MortgageAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace MortgageAppLibrary.Services.TextFile
{
    public class TextMortgageOutput
    {
        public byte[] CreateTextFile(List<MonthlyCalculatedValuesExtraPayments> amortizationSchedule)
        {
            using (var memStream = new MemoryStream()) 
            {
                using (StreamWriter writer = new StreamWriter(memStream)) //// true to append data to the file
                {
                    // Print out results

                    writer.WriteLine($"Mortgage Amortization Schedule");
                    writer.WriteLine($"Created:{DateTime.Now}");
                    writer.WriteLine($"------------------------------------------------");
                    foreach (var period in amortizationSchedule)
                    {
                        writer.WriteLine($"Period No:{period.IDNumber}");
                        writer.WriteLine($"Date:{period.DateColumn}");
                        writer.WriteLine($"Remaining Balance:{String.Format("{0:C2}", period.RemainingBalance)}");
                        writer.WriteLine($"Principal Paid:{String.Format("{0:C2}", period.PrincipalPaid)}");
                        writer.WriteLine($"Interest Paid:{String.Format("{0:C2}", period.InterestPaid)}");
                        writer.WriteLine($"Fixed Payment:{String.Format("{0:C2}", period.fixedPayment)}");
                        writer.WriteLine($"Total Interest Paid:{String.Format("{0:C2}", period.TotalInterestPaid)}");
                        writer.WriteLine($"Extra Payment:{String.Format("{0:C2}", period.ExtraPayment)}");
                        writer.WriteLine($"Extra Payment Cumulative:{String.Format("{0:C2}", period.CumulativeExtraPayment)}");
                        writer.WriteLine($"------------------------------------------------");
                    }

                    writer.Flush();
                    memStream.Seek(0, SeekOrigin.Begin);
                    return memStream.ToArray();
                }
            }
        }

        public void CreateStandardAmortizationSchedule(List<MonthlyCalculatedValues> standardAmortizationSchedule, string filePathName)
        {
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            var jsonText = JsonSerializer.Serialize(standardAmortizationSchedule, jsonOptions);
            File.WriteAllText(filePathName, jsonText);
        }
    }
}
