
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace MortgageAppLibrary.Models.SavedFile
{

    public class SavedFile
    {
        //File information
        public string FileName { get; set; }
        public string FileExtension { get; set; } =".dat";

        //Input information
        public MortgageInputExtraPayments MortgageInputExtraPayments { get; set; }
        public MortgageInput MortgageInput { get; set; }

        //Calculated information
        public List<MonthlyCalculatedValuesExtraPayments>? AmortizationScheduleExtraPayments { get; set; }
        public List<MonthlyCalculatedValues>? AmortizationScheduleBasic { get; set; }
        public MortgageExecutiveSummary? MortgageExecutiveSummary { get; set; }

        //Other File Byte Arrays
        public byte[]? ExcelFileBytes { get; set; }
        public byte[]? TextFileBytes { get; set; }
    }
}
