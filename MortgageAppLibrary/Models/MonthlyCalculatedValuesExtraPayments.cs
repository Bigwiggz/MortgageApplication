using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageAppLibrary.Models
{
    public class MonthlyCalculatedValuesExtraPayments
    {
        public int IDNumber { get; set; }
        public DateTime DateColumn { get; set; }
        public decimal RemainingBalance { get; set; }
        public decimal fixedPayment { get; set; }
        public decimal PrincipalPaid { get; set; }
        public decimal InterestPaid { get; set; }
        public decimal TotalInterestPaid { get; set; }
        public decimal ExtraPayment { get; set; }

        public decimal CumulativeExtraPayment { get; set; }
    }
}
