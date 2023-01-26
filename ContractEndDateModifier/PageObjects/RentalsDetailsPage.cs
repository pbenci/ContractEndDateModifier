using OpenQA.Selenium;

namespace ContractEndDateModifier
{
    public class RentalsDetailsPage : BackendMenu
    {
        private WebElements ContractRow => new(Driver, By.CssSelector($"tbody > tr:nth-of-type(1)"));
        private WebElements EditItemsButton => new(Driver, By.CssSelector($".btn-action"));
        private IList<IWebElement> CalendarIcons => Driver.FindElements(By.CssSelector($"div[data-contract-row-id='{ContractRowId}'] .fa-calendar"));
        public string ContractRowId { get; set; }
        public string NewEndDate { get; set; }

        public RentalsDetailsPage(IWebDriver Driver, string ContractRowId, string NewEndDate) : base(Driver)
        {
            this.Driver = Driver;
            Wait = new(Driver);
            this.ContractRowId = ContractRowId;
            this.NewEndDate = NewEndDate;
        }

        public void GoTo()
        {
            WaitForOverlayToDisappear();
            Interaction.Click(ContractRow.Element);
            WaitForOverlayToDisappear();
        }

        public void OpenEditContractMode()
        {
            Interaction.Click(EditItemsButton.Element);
            WaitForOverlayToDisappear();
        }
        
        public void EditEndDate()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"document.querySelector(\"div[data-contract-row-id='{ContractRowId}'] [id$=date_to_rent]\").value = '{NewEndDate}';");
            Interaction.Click(CalendarIcons[1]);
            WaitForOverlayToDisappear();
        }
    }
}