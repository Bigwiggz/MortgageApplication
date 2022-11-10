using MortgageAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageAppLibrary.Services.MortgageServices
{
    internal class ExtraPaymentService
    {
        public bool ApplyPayment(DateTime paymentAmortizationDate, ExtraPayments extraPayment)
        {

            DateTime paymentAmortizationDateFOM = new DateTime(paymentAmortizationDate.Year, paymentAmortizationDate.Month, 1);
            DateTime startDateFOM = new DateTime(extraPayment.StartDate.Year, extraPayment.StartDate.Month, 1);

            //1) Check to see if year/month of the value 
            bool hitStartDate = false;
            if (paymentAmortizationDateFOM >= startDateFOM)
            {
                hitStartDate = true;
            };

            //2) Check the payment number AND decrease payment current count
            bool paymentCountIsPositive = true;
            if (extraPayment.PaymentCurrentCounter >= extraPayment.NumberofPayments)
            {
                paymentCountIsPositive = false;
            };

            //3) Check interval with payment number AND reset interval counter
            bool hitPaymentInterval = false;
            //Increase the counter by 1
            extraPayment.PaymentIntervalCounter++;

            if (extraPayment.PaymentIntervalCounter == extraPayment.PaymentInterval ||
                paymentAmortizationDateFOM == startDateFOM)
            {
                hitPaymentInterval = true;
                //Reset the counter
                extraPayment.PaymentIntervalCounter = 0;
            };

            //4) Tabulate if payment is to be applied
            bool applyPayment = false;
            if (hitStartDate == true && paymentCountIsPositive == true && hitPaymentInterval == true)
            {
                applyPayment = true;

                //if Payment is made, then the payment current counter increases
                extraPayment.PaymentCurrentCounter++;
                extraPayment.CumulativeExtraPayment += extraPayment.ExtraPaymentAmount;
            };
            return applyPayment;
        }
    }
}
