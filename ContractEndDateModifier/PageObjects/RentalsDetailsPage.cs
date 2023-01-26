using OpenQA.Selenium;

namespace ContractEndDateModifier
{
    public class RentalsDetailsPage : BackendMenu
    {
        private WebElements ContractRow => new(Driver, By.CssSelector($"tbody > tr:nth-of-type(1)"));
        private WebElements EditItemsButton => new(Driver, By.CssSelector($".btn-action"));
        private IList<IWebElement> CalendarIcons => Driver.FindElements(By.CssSelector($"div[data-contract-row-id='{ContractRowId}'] .fa-calendar"));
        private IWebElement SaveContractModificationButton => Driver.FindElement(By.CssSelector("div.contract-accordion-header.pl-5 > a"));
        private IWebElement ConfirmContractModificationButton => Driver.FindElement(By.CssSelector("div.px-4.pb-4.modal-footer-button > div > div > div > div > button"));
        public string ContractRowId { get; set; }

        public RentalsDetailsPage(IWebDriver Driver, string ContractRowId) : base(Driver)
        {
            this.Driver = Driver;
            Wait = new(Driver);
            this.ContractRowId = ContractRowId;
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
        
        public void EditEndDate(string NewEndDate)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"document.querySelector(\"div[data-contract-row-id='{ContractRowId}'] [id$=date_to_rent]\").value = '{NewEndDate}';");
            Interaction.Click(CalendarIcons[1]);
            WaitForOverlayToDisappear();
        }

        public void ConfirmContractModification()
        {
            Interaction.Click(SaveContractModificationButton);
            WaitForOverlayToDisappear();
            Interaction.Click(ConfirmContractModificationButton);
            WaitForOverlayToDisappear();
        }
    }
}