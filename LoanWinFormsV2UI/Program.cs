using AutoMapper;
using LoanWinFormsV2UI.ViewModels;
using MortgageAppLibrary.Models;

namespace LoanWinFormsV2UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Initiate Automapper
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<ExtraPayments, ExtraPaymentViewModel>();
                config.CreateMap<ExtraPaymentViewModel, ExtraPayments>();
            });

            IMapper mapper = config.CreateMapper();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new loanAppMainForm(mapper));

            
        }
    }
}