using FluentValidation;
using MortgageAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageAppLibrary.Validators
{
    public class ExtraPaymentsValidator: AbstractValidator<ExtraPayments>
    {
        public ExtraPaymentsValidator()
        {
            //Extra Payment Amount
            RuleFor(ExtraPayment=>ExtraPayment.ExtraPaymentAmount)
                .Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Please enter an amount for the Extra Payment Amount")
                .GreaterThanOrEqualTo(1).WithMessage("Please enter an amount greater than 1 dollar for Extra Payment Amount.");

            //StartDate
            var earliestDate = new DateTime(1904, 1, 1);
            RuleFor(ExtraPayment => ExtraPayment.StartDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter a Start Date")
                .GreaterThan(earliestDate).WithMessage("Please enter a date after January 1st, 1904");

            //NumberofPayments
            RuleFor(ExtraPayment => ExtraPayment.NumberofPayments)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter an amount for the Loan Term")
                .GreaterThanOrEqualTo(1).WithMessage("The Loan Term must be a positive amount and greater than 1.");

            //PaymentInterval
            RuleFor(ExtraPayment => ExtraPayment.PaymentInterval)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter an amount for the Loan Term")
                .GreaterThanOrEqualTo(1).WithMessage("The Loan Term must be a positive amount and greater than 1.");
        }
    }
}
