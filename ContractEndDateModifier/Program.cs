using OpenQA.Selenium;
using System.Configuration;

namespace ContractEndDateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int TotalNumberOfRowsToModify = Excel.RowsToModify().Count;
            int NumberOfRowsAlreadyModified = 0;
            Results.Log($"Started process with {TotalNumberOfRowsToModify} rows to modify");
            Parallel.ForEach(Excel.RowsToModify(), new ParallelOptions { MaxDegreeOfParallelism = int.Parse(ConfigurationManager.AppSettings.Get("ParallelisationLevel")) }, Contract =>
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
                    var RentalsDetailsPage = new RentalsDetailsPage(Driver, Contract.RowId);
                    RentalsDetailsPage.GoTo();
                    RentalsDetailsPage.OpenEditContractMode();
                    RentalsDetailsPage.EditEndDate(Contract.NewEndDate);
                    RentalsDetailsPage.ConfirmContractModification();
                    RentalsDetailsPage.OpenEditContractMode();
                    RentalsDetailsPage.EditEndDate(Contract.PreviousEndDate);
                    RentalsDetailsPage.ConfirmContractModification();
                    Driver.Quit();
                    NumberOfRowsAlreadyModified++;
                    Results.Log($"Rows left to modify {TotalNumberOfRowsToModify - NumberOfRowsAlreadyModified}");
                }
                catch (Exception)
                {
                    Driver.Quit();
                    Results.Log($"Couldn't modify the row {Contract.RowId} in contract {Contract.Code}");
                    NumberOfRowsAlreadyModified++;
                    Results.Log($"Rows left to modify {TotalNumberOfRowsToModify - NumberOfRowsAlreadyModified}");
                }
            });
            Results.Log($"Started ended");
        }
    }
}