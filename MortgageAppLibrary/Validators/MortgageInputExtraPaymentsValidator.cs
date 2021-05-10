using FluentValidation;
using MortgageAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageAppLibrary.Validators
{
    public class MortgageInputExtraPaymentsValidator: AbstractValidator<MortgageInputExtraPayments>
    {
        public MortgageInputExtraPaymentsValidator()
        {
            //Total Loan Amount has to be,not empty, greater than 1 dollar
            RuleFor(MortgageInputExtraPayments => MortgageInputExtraPayments.TotalLoanAmount)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter an amount for the Total Loan Balance")
                .GreaterThanOrEqualTo(1).WithMessage("Please enter an amount greater than 1 dollar for the Total Loan Balance.");

            //Down Payment must be less than the Total Loan Amount
            RuleFor(MortgageInputExtraPayments => MortgageInputExtraPayments.DownPayment)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter an amount for the Down Payment")
                .GreaterThanOrEqualTo(0).WithMessage("The Down Payment must be a positive amount.")
                .LessThan(MortgageInputExtraPayments => MortgageInputExtraPayments.TotalLoanAmount).WithMessage("The Down Payment must be less than the Total Loan Balance.");

            //Loan Term
            RuleFor(MortgageInputExtraPayments => MortgageInputExtraPayments.LoanTerm)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter an amount for the Loan Term")
                .GreaterThanOrEqualTo(1).WithMessage("The Loan Term must be a positive amount and greater than 1.");

            //Interest Rate
            RuleFor(MortgageInputExtraPayments => MortgageInputExtraPayments.InterestRate)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Please enter an amount for the Interest Rate.")
               .ExclusiveBetween(0, 1).WithMessage("If you have an interest rate less than 0% greater than 100%, please do yourself a favor and don't get it.");

            //Extra Payments
            //RuleFor(MortgageInputExtraPayments => MortgageInputExtraPayments.ValidateExtraPaymentBeLessThanLoanAmount)
               // .Must(BeLessThanInitalLoanBalance).WithMessage("All Extra payments must be less than the initial loan balance");

            //Loan Description
            RuleFor(MortgageInputExtraPayments => MortgageInputExtraPayments.LoanDescription)
                .Length(0, 250).WithMessage("Please keep the description less than 250 characters.");

            //StartDate greater than January 1, 1904
            var earliestDate = new DateTime(1904, 1, 1);
            RuleFor(MortgageInputExtraPayments => MortgageInputExtraPayments.StartDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter a Start Date")
                .GreaterThan(earliestDate).WithMessage("Please enter a date after January 1st, 1904");
        }

        //
        protected bool BeLessThanInitalLoanBalance(bool extraPaymentValidator)
        {
            return extraPaymentValidator;
        }

        //To check if a number is a decimal or an Int
        protected bool BeADecimalNumber(string testNumber)
        {
            var result = false;
            decimal n;
            result = decimal.TryParse(testNumber, out n);
            return result;
        }

        protected bool BeAnIntNumber(string testNumber)
        {
            var result = false;
            int n;
            result = int.TryParse(testNumber, out n);
            return result;
        }
    }
}
