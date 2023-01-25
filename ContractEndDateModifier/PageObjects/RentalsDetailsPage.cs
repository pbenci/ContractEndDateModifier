using OpenQA.Selenium;

namespace ContractEndDateModifier
{
    public class RentalsDetailsPage : BackendMenu
    {
        private WebElements ContractRow => new(Driver, By.CssSelector($"tbody > tr:nth-of-type(1)"));
        private WebElements EditItemsButton => new(Driver, By.CssSelector($".btn-action"));
        private IWebElement MainEquipmentAccordionArrow => Driver.FindElement(By.CssSelector($"div[data-contract-row-id='{CartRowId}'] .fa-angle-down"));
        private IList<IWebElement> AccessoriesAccordionArrows => Driver.FindElements(By.CssSelector($"[data-contract-row-id='{CartRowId}'] .crud-accordion-header .fa-angle-down"));
        private IWebElement MainEquipmentInsuranceLock => Driver.FindElement(By.CssSelector($"div[data-contract-row-id='{CartRowId}'] div[data-row-type='insurance'] .fa-lock"));
        private IWebElement MainEquipmentInsuranceLockOpen => Driver.FindElement(By.CssSelector($"div[data-contract-row-id='{CartRowId}'] div[data-row-type='insurance'] .fa-lock-open"));
        private IWebElement TiersModelsDropdown => Driver.FindElement(By.Id("booking_price_list_flat_row_price_tier_model_id_chosen\r\n"));
        private IWebElement DailyTier => Driver.FindElement(By.CssSelector("#booking_price_list_flat_row_price_tier_model_id_chosen > div > ul > li:nth-child(2)"));
        private IWebElement DailyPriceField => Driver.FindElement(By.Id("booking_price_list_flat_row_price_tier_model_row_2_1_1"));
        private IWebElement DailyPriceFieldAlreadyEdited => Driver.FindElement(By.Id("booking_price_list_whole_period_row_unit_price"));        
        private IWebElement SavePricesButton => Driver.FindElement(By.ClassName("prevent-close"));
        private IWebElement SaveContractModificationButton => Driver.FindElement(By.CssSelector("div.contract-accordion-header.pl-5 > a"));
        private IWebElement ConfirmContractModificationButton => Driver.FindElement(By.CssSelector("div.px-4.pb-4.modal-footer-button > div > div > div > div > button"));        

        public string CartRowId { get; set; }

        public RentalsDetailsPage(IWebDriver Driver, string CartRowId) : base(Driver)
        {
            this.Driver = Driver;
            Wait = new(Driver);
            this.CartRowId = CartRowId;
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

        public void EditInsurancePrice(string Price)
        {
            Interaction.Click(MainEquipmentAccordionArrow);
            Interaction.Click(AccessoriesAccordionArrows[AccessoriesAccordionArrows.Count() - 1]);
            try
            {
                Interaction.Click(MainEquipmentInsuranceLock);
                WaitForOverlayToDisappear();
                Interaction.Click(TiersModelsDropdown);
                Interaction.Click(DailyTier);
                WaitForOverlayToDisappear();
                try
                {
                    Interaction.Write(DailyPriceField, Price);
                }
                catch (NoSuchElementException)
                {
                    Interaction.Write(DailyPriceFieldAlreadyEdited, Price);
                }
                Interaction.Write(DailyPriceField, Price);
                Interaction.Click(SavePricesButton);
                WaitForOverlayToDisappear();
            }
            catch(NoSuchElementException) 
            {
                Interaction.Click(MainEquipmentInsuranceLockOpen);
                WaitForOverlayToDisappear();
                try
                {
                    Interaction.Write(DailyPriceField, Price);
                }
                catch (NoSuchElementException)
                {
                    Interaction.Write(DailyPriceFieldAlreadyEdited, Price);
                }
                Interaction.Click(SavePricesButton);
                WaitForOverlayToDisappear();
            }
            Interaction.Click(SaveContractModificationButton);
            WaitForOverlayToDisappear();
            Interaction.Click(ConfirmContractModificationButton);
            WaitForOverlayToDisappear();
        }
    }
}