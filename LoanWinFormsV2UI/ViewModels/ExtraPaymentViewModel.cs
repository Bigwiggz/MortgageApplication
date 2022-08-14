using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWinFormsV2UI.ViewModels
{
    internal class ExtraPaymentViewModel
    {
        //[DisplayName("Payment Start Date")]
        //[DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }

        //[DisplayName("Extra Payment Amt")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ExtraPaymentAmount { get; set; }

        //[DisplayName("No of Payments")]
        public int NumberofPayments { get; set; }

        //[DisplayName("Payment Interval")]
        public int PaymentInterval { get; set; }
    }
}
