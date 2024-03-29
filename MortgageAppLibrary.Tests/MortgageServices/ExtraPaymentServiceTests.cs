﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortgageAppLibrary.Models;
using MortgageAppLibrary.Services.MortgageServices;

namespace MortgageAppLibrary.Tests.MortgageServices;

public class ExtraPaymentServiceTests
{
	private ExtraPaymentService _extraPaymentService;

	public ExtraPaymentServiceTests()
	{
		_extraPaymentService = new ExtraPaymentService();
	}

	public static readonly object[][] ApplyPaymentData =
	{
		new object[] {new DateTime(2023,11,1),new DateTime(2022,12,1),400M,1,20,true},
		new object[] {new DateTime(2023,11,1), new DateTime(2022, 12, 1), 400M, 1, 20, true}
    };

	[Theory]
	[MemberData(nameof(ApplyPaymentData))]
	public void ApplyPayment_ShouldApplyPayment(DateTime paymentAmortizationDate, DateTime startDate,decimal extraPaymentAmount, int paymentInterval, int numberOfPayments, bool expected)
	{
		//Arrange
		var extraPayment = new ExtraPayments 
		{
            StartDate = startDate,
            ExtraPaymentAmount = extraPaymentAmount,
            PaymentInterval = paymentInterval,
            NumberofPayments = numberOfPayments
        };

		//Act
		bool actual = _extraPaymentService.ApplyPayment(paymentAmortizationDate, extraPayment);

		//Assert
		Assert.Equal(expected, actual);
	}
}
