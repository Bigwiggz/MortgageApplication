using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml;
using System.IO;
using MortgageAppLibrary.Models;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing.Chart;
using System.Globalization;
using System.Drawing;

namespace MortgageAppLibrary.Services.Excel
{
    public class ExcelMortgageOutput
    {

        public byte[] CreateExcelTestFile(List<MonthlyCalculatedValues> amortizationSchedule,List<MonthlyCalculatedValuesExtraPayments> extraPaymentSchedule, MortgageExecutiveSummary executiveSummary)
        {
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "Brian Wiggins";
                excelPackage.Workbook.Properties.Title = "Mortgage Sheet";
                excelPackage.Workbook.Properties.Subject = "Test Export";

                //---------------CREATE EXECUTIVE SUMMARY SHEET
                ExcelWorksheet worksheet0 = excelPackage.Workbook.Worksheets.Add("Executive Summary");

                //Add header text
                worksheet0.Cells["A1"].Value = "Executive Summary Schedule";
                worksheet0.Cells["A1:D1"].Merge = true;

                //Additional Sheet Formatting
                var tableTitle0 = worksheet0.Cells["A1:D1"];
                tableTitle0.Style.Font.Bold = true;
                tableTitle0.Style.Font.Size = 15;
                tableTitle0.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                tableTitle0.Style.Fill.PatternType = ExcelFillStyle.Solid;
                tableTitle0.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#BABABA"));

                // Assign borders
                tableTitle0.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                tableTitle0.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                tableTitle0.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                tableTitle0.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                //Add Column Text 1
                worksheet0.Cells[2,1].Value = "Loan Amount";
                worksheet0.Cells[3,1].Value = "Original Term";
                worksheet0.Cells[4,1].Value = "Interest Rate";
                worksheet0.Cells[5,1].Value = "Start Date";
                worksheet0.Cells[6,1].Value = "Monthly Payment";
                worksheet0.Cells[7,1].Value = "Total Conventional Interest";
                worksheet0.Cells[8,1].Value = "Total Amount";

                //Values in Column 2
                worksheet0.Cells[2, 2].Value = executiveSummary.ActualLoanAmount;
                worksheet0.Cells[3, 2].Value = executiveSummary.OriginalLoanTerm;
                worksheet0.Cells[4, 2].Value = executiveSummary.InterestRate;
                worksheet0.Cells[5, 2].Value = executiveSummary.StartDate;
                worksheet0.Cells[6, 2].Value = executiveSummary.FixedMonthlyPayment;
                worksheet0.Cells[7, 2].Value = executiveSummary.ConventionalInterestAmount;
                worksheet0.Cells[8, 2].Value = executiveSummary.TotalConvetionalLoanPayment;

                //Format Text in cells
                worksheet0.Cells[2, 2].Style.Numberformat.Format = "$#,##0.00";
                worksheet0.Cells[3, 2].Style.Numberformat.Format = "0.00";
                worksheet0.Cells[4, 2].Style.Numberformat.Format = "0.00%";
                worksheet0.Cells[5, 2].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                worksheet0.Cells[6, 2].Style.Numberformat.Format = "$#,##0.00";
                worksheet0.Cells[7, 2].Style.Numberformat.Format = "$#,##0.00";
                worksheet0.Cells[8, 2].Style.Numberformat.Format = "$#,##0.00";

                //Add Column Text 3
                worksheet0.Cells[2, 3].Value = "Total Extra Payments";
                worksheet0.Cells[3, 3].Value = "Extra Payment Loan Term";
                worksheet0.Cells[4, 3].Value = "";
                worksheet0.Cells[5, 3].Value = "End Date";
                worksheet0.Cells[6, 3].Value = "Total Interest Paid";
                worksheet0.Cells[7, 3].Value = "Interest Reduction";
                worksheet0.Cells[8, 3].Value = "Total Amount";

                //Values in Column 4
                worksheet0.Cells[2, 4].Value = executiveSummary.CumulativeExtraPayment;
                worksheet0.Cells[3, 4].Value = executiveSummary.ExtraPaymentLoanTerm;
                worksheet0.Cells[4, 4].Value = "";
                worksheet0.Cells[5, 4].Value = executiveSummary.ExtraPaymentLastDate;
                worksheet0.Cells[6, 4].Value = executiveSummary.TotalInterestPaid;
                worksheet0.Cells[7, 4].Value = executiveSummary.ExtraPaymentInterestReduction;
                worksheet0.Cells[8, 4].Value = executiveSummary.TotalActualLoanPayment;

                //Format Text in cells
                worksheet0.Cells[2, 4].Style.Numberformat.Format = "$#,##0.00";
                worksheet0.Cells[3, 4].Style.Numberformat.Format = "0.00";
                worksheet0.Cells[4, 4].Value = "";
                worksheet0.Cells[5, 4].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                worksheet0.Cells[6, 4].Style.Numberformat.Format = "$#,##0.00";
                worksheet0.Cells[7, 4].Style.Numberformat.Format = "$#,##0.00";
                worksheet0.Cells[8, 4].Style.Numberformat.Format = "$#,##0.00";

                //select table
                var modelTable0 = worksheet0.Cells["A2:D8"];

                // Assign borders
                modelTable0.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable0.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable0.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable0.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable0.AutoFitColumns();

                //---------------CREATE BASE AMORTIZATION SHEET

                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Mortgage Sch");

                //Add header text
                worksheet.Cells["A1"].Value = "Base Amortization Schedule";
                worksheet.Cells["A1:G1"].Merge = true;
                
                //Additional Sheet Formatting
                var tableTitle = worksheet.Cells["A1:G1"];
                tableTitle.Style.Font.Bold = true;
                tableTitle.Style.Font.Size = 15;
                tableTitle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Assign borders
                tableTitle.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                tableTitle.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                tableTitle.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                tableTitle.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                //Add Column Text
                worksheet.Cells["A3"].Value = "Bill No";
                worksheet.Cells["B3"].Value = "Date";
                worksheet.Cells["C3"].Value = "Remaining Balance";
                worksheet.Cells["D3"].Value = "Fixed Payment";
                worksheet.Cells["E3"].Value = "Principal Paid";
                worksheet.Cells["F3"].Value = "Interest Paid";
                worksheet.Cells["G3"].Value = "Total Interest Paid YTD";

                //Column Name Styling
                worksheet.Cells["A3:G3"].Style.Font.Bold = true;
                worksheet.Cells["A3:G3"].Style.Font.Size = 13;
                worksheet.Cells["A3:G3"].Style.WrapText = true;
                worksheet.Cells["A3:G3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A3:G3"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#BABABA"));

                //Fill in data
                worksheet.Cells["A4"].LoadFromCollection(amortizationSchedule);

                //Find out length of list
                int amorizationScheduleLength = amortizationSchedule.Count;
                int numberRangeofTable = amorizationScheduleLength + 3;
                string indexedTableValue = $"G{numberRangeofTable}";

                //select table
                var modelTable = worksheet.Cells[$"A3:{indexedTableValue}"];

                // Assign borders
                modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.AutoFitColumns();

                //Format Text in cells
                worksheet.Cells[$"B4:B{numberRangeofTable}"].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                worksheet.Cells[$"C4:G{numberRangeofTable}"].Style.Numberformat.Format = "$#,##0.00";
                worksheet.Cells[$"A4:A{numberRangeofTable}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                //---------------CREATE EXTRA PAYMENT AMORTIZATION SHEET

                //Create the worksheet3
                ExcelWorksheet worksheet3 = excelPackage.Workbook.Worksheets.Add("Extra Payment Sch");

                //Add header text
                worksheet3.Cells["A1"].Value = "Extra Payment Amortization Schedule";
                worksheet3.Cells["A1:I1"].Merge = true;

                //Additional Sheet Formatting
                var tableTitle3 = worksheet3.Cells["A1:I1"];
                tableTitle3.Style.Font.Bold = true;
                tableTitle3.Style.Font.Size = 15;
                tableTitle3.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Assign borders
                tableTitle3.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                tableTitle3.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                tableTitle3.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                tableTitle3.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                //Add Column Text
                worksheet3.Cells["A3"].Value = "Bill No";
                worksheet3.Cells["B3"].Value = "Date";
                worksheet3.Cells["C3"].Value = "Remaining Balance";
                worksheet3.Cells["D3"].Value = "Fixed Payment";
                worksheet3.Cells["E3"].Value = "Principal Paid";
                worksheet3.Cells["F3"].Value = "Interest Paid";
                worksheet3.Cells["G3"].Value = "Total Interest Paid YTD";
                worksheet3.Cells["H3"].Value = "Extra Payment";
                worksheet3.Cells["I3"].Value = "Cumulative Extra Payments ";

                //Column Name Styling
                worksheet3.Cells["A3:I3"].Style.Font.Bold = true;
                worksheet3.Cells["A3:I3"].Style.Font.Size = 13;
                worksheet3.Cells["A3:I3"].Style.WrapText = true;
                worksheet3.Cells["A3:I3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet3.Cells["A3:I3"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#BABABA"));

                //Fill in data
                worksheet3.Cells["A4"].LoadFromCollection(extraPaymentSchedule);

                //Find out length of list
                int amorizationScheduleLength3 = extraPaymentSchedule.Count;
                int numberRangeofTable3 = amorizationScheduleLength3 + 3;
                string indexedTableValue3 = $"I{numberRangeofTable3}";

                //select table
                var modelTable3 = worksheet3.Cells[$"A3:{indexedTableValue3}"];

                // Assign borders
                modelTable3.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable3.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable3.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable3.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable3.AutoFitColumns();

                //Format Text in cells
                worksheet3.Cells[$"B4:B{numberRangeofTable3}"].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                worksheet3.Cells[$"C4:I{numberRangeofTable3}"].Style.Numberformat.Format = "$#,##0.00";
                worksheet3.Cells[$"A4:A{numberRangeofTable3}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                
                //---------------CREATE BASE AMORTIZATION CHART

                //Create the WorkSheet
                ExcelWorksheet worksheet2 = excelPackage.Workbook.Worksheets.Add("Chart Sheet");

                //Create a line chart
                ExcelLineChart lineChart = worksheet2.Drawings.AddChart("Mortgage Chart", eChartType.Line) as ExcelLineChart;

                //set chart Title
                lineChart.Title.Text = "Base Mortgage Chart";

                //Create the ranges for the chart
                var xAxisLabel = worksheet.Cells[$"B3:B{numberRangeofTable}"];
                var principalRange = worksheet.Cells[$"E3:E{numberRangeofTable}"];
                var interestRange = worksheet.Cells[$"F3:F{numberRangeofTable}"];

                //add the ranges to the chart
                lineChart.Series.Add(principalRange, xAxisLabel);
                lineChart.Series.Add(interestRange, xAxisLabel);

                //set the names of the legend
                lineChart.Series[0].Header = worksheet.Cells["E3"].Value.ToString();
                lineChart.Series[1].Header = worksheet.Cells["F3"].Value.ToString();

                //position of the legend
                lineChart.Legend.Position = eLegendPosition.Right;

                //size of the chart
                int baseLineChartLength = 1500;
                lineChart.SetSize(baseLineChartLength, 400);

                //add the chart at cell B6
                lineChart.SetPosition(5, 0, 1, 0);

                //---------------CREATE EXTRA PAYMENT AMORTIZATION CHART

                //Create a line chart
                ExcelLineChart lineChart3 = worksheet2.Drawings.AddChart("Extra Payment Chart", eChartType.Line) as ExcelLineChart;

                //set chart Title
                lineChart3.Title.Text = "Extra Payment Chart";

                //Create the ranges for the chart
                var xAxisLabel3 = worksheet3.Cells[$"B3:B{numberRangeofTable3}"];
                var principalRange3 = worksheet3.Cells[$"E3:E{numberRangeofTable3}"];
                var interestRange3 = worksheet3.Cells[$"F3:F{numberRangeofTable3}"];

                //add the ranges to the chart
                lineChart3.Series.Add(principalRange3, xAxisLabel3);
                lineChart3.Series.Add(interestRange3, xAxisLabel3);

                //set the names of the legend
                lineChart3.Series[0].Header = worksheet3.Cells["E3"].Value.ToString();
                lineChart3.Series[1].Header = worksheet3.Cells["F3"].Value.ToString();

                //position of the legend
                lineChart3.Legend.Position = eLegendPosition.Right;

                //size of the chart

                int chartLength = (amorizationScheduleLength3 / amorizationScheduleLength) * baseLineChartLength;
                Console.WriteLine($"BaseChartLength:{chartLength}");
                lineChart3.SetSize(1500, 400);

                //add the chart at cell B6
                lineChart3.SetPosition(11, 0, 1, 0);

                //---------------SAVE FILE

                //directory of newly created Excel File
                string fileDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string dirPath = @"C:\Users\Brian Wiggins\source\repos\LoanAppConsoleUI\MortgageAppLibrary\Downloads\";


                //Return the time from DateTime object in string format
                var timeString = DateTime.Now.ToString("hh-mm-ss");

                //file name
                string fileName = $"MortgageFile-{timeString}.xlsx";

                //full path
                string fullPath = dirPath + fileName;
                //Save your file
                FileInfo fi = new FileInfo(fullPath);
                //excelPackage.SaveAs(fi);

                var excelByteArray = excelPackage.GetAsByteArray();
                return excelByteArray;
            }
        
        }
    }
}
