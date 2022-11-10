using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MortgageAppLibrary.Models
{
    public class ExtraPayments
    {
        public decimal ExtraPaymentAmount { get; set; }

        public DateTime StartDate { get; set; }

        public int NumberofPayments { get; set; }

        public int PaymentCurrentCounter { get; set; } = 0;

        public int PaymentInterval { get; set; }

        public int PaymentIntervalCounter { get; set; } = 0;

        public decimal CumulativeExtraPayment { get; set; } = 0;

        //Methods
        public bool ApplyPayment(DateTime paymentAmortizationDate) 
        {

            DateTime paymentAmortizationDateFOM=new DateTime(paymentAmortizationDate.Year,paymentAmortizationDate.Month,1);
            DateTime startDateFOM = new DateTime(this.StartDate.Year, this.StartDate.Month, 1);
            
            //1) Check to see if year/month of the value 
            bool hitStartDate = false;
            if (paymentAmortizationDateFOM >= startDateFOM)
            {
                hitStartDate = true;
            };

            //2) Check the payment number AND decrease payment current count
            bool paymentCountIsPositive = true;
            if (PaymentCurrentCounter>=this.NumberofPayments)
            {
                paymentCountIsPositive = false;
            };

            //3) Check interval with payment number AND reset interval counter
            bool hitPaymentInterval = false;
            //Increase the counter by 1
            this.PaymentIntervalCounter ++;

            if (this.PaymentIntervalCounter==this.PaymentInterval ||
                paymentAmortizationDateFOM == startDateFOM)
            {
                hitPaymentInterval = true;
                //Reset the counter
                this.PaymentIntervalCounter = 0;
            };

            //4) Tabulate if payment is to be applied
            bool applyPayment = false;
            if (hitStartDate==true && paymentCountIsPositive == true && hitPaymentInterval==true)
            {
                applyPayment = true;

                //if Payment is made, then the payment current counter increases
                this.PaymentCurrentCounter ++;
                this.CumulativeExtraPayment += this.ExtraPaymentAmount;
            };
            return applyPayment;
        }
    }
}
