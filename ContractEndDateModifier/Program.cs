using OpenQA.Selenium;
using System.Configuration;

namespace ContractEndDateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parallel.ForEach(Excel.GetNumberOfUsedRows(), new ParallelOptions { MaxDegreeOfParallelism = int.Parse(ConfigurationManager.AppSettings.Get("ParallelisationLevel")) }, Contract =>
            {
                IWebDriver Driver = new Browsers().LaunchChrome();
                Driver.Manage().Window.Maximize();
                try
                {
                    var LoginPage = new LoginPage(Driver);
                    LoginPage.GoToUrl();
                    LoginPage.Login();
                    var RentalsPage = new RentalsPage(Driver);
                    RentalsPage.GoTo();
                    RentalsPage.SearchContractByCode(Contract.Code);
                    var RentalsDetailsPage = new RentalsDetailsPage(Driver, Contract.ContractRowId);
                    RentalsDetailsPage.GoTo();
                    RentalsDetailsPage.OpenEditContractMode();
                    Thread.Sleep(5000);
                    RentalsDetailsPage.EditDate();
                    Thread.Sleep(5000);
                    //TODO EDIT DATE 1 DAY FORWARD AND SAVE CONTRACT MODIFICATION
                    //TODO EDIT DATE 1 DAY BACK AND SAVE CONTRACT MODIFICATION
                    Driver.Quit();
                }
                catch (Exception)
                {
                    Driver.Quit();
                }
            });
        }
    }
}