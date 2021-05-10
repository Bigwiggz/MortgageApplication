using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageAppLibrary.Models
{
    public class ExtraPayments
    {
        public decimal ExtraPaymentAmount { get; set; }

        public DateTime StartDate { get; set; }

        public int NumberofPayments { get; set; }

        private int PaymentCurrentCounter { get; set; } = 0;

        public int PaymentInterval { get; set; }

        private int PaymentIntervalCounter { get; set; } = 0;

        public decimal CumulativeExtraPayment { get; private set; } = 0;

        //Methods
        public bool ApplyPayment(DateTime paymentAmortizationDate) 
        {
            

            //1) Check to see if year/month of the value 
            bool hitStartDate = false;
            if (paymentAmortizationDate.Month>= this.StartDate.Month && paymentAmortizationDate.Year>= this.StartDate.Year)
            {
                hitStartDate = true;
            };

            //2) Check the payment number AND decrease payment current count
            bool paymentCountIsPositive = false;
            if (PaymentCurrentCounter<this.NumberofPayments*this.PaymentInterval)
            {
                paymentCountIsPositive = true;
            };

            //3) Check interval with payment number AND reset interval counter
            bool hitPaymentInterval = false;
            //Increase the counter by 1
            this.PaymentIntervalCounter = this.PaymentIntervalCounter + 1;

            if (this.PaymentIntervalCounter==this.PaymentInterval ||
                this.StartDate.Month==paymentAmortizationDate.Month  && this.StartDate.Year== paymentAmortizationDate.Year)
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
                this.PaymentCurrentCounter = this.PaymentCurrentCounter + 1;
                this.CumulativeExtraPayment = this.CumulativeExtraPayment + this.ExtraPaymentAmount;
            };
            return applyPayment;
        }
    }
}
