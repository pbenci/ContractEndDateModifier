using OpenQA.Selenium;
using System.Xml.Linq;

namespace ContractEndDateModifier
{
    public class BackendMenu
    {
        protected IWebDriver Driver { get; set; }
        protected Interactions Interaction { get; set; }
        protected Waits Wait { get; set; }
        protected WebElements RentalMainMenuButton => new(Driver, By.Id("voceMenu_rentals"));
        protected WebElements RentalMenuButton => new(Driver, By.CssSelector("#voceMenu_rentals.level_1"));
        protected WebElements BookingMenuButton => new(Driver, By.Id("voceMenu_booking"));
        protected WebElements FleetMainMenuButton => new(Driver, By.Id("voceMenu_fleet"));
        protected WebElements SparePartsMenuButton => new(Driver, By.Id("voceMenu_spare_part"));
        protected WebElements Overlay => new(Driver, By.CssSelector("div > svg"), 2);
        protected WebElements CloseAllTabsButton => new(Driver, By.Id("close-all-tabs"));
        protected WebElements ConfirmClosingAllTabsButton => new(Driver, By.CssSelector(".bootbox-accept"));
        protected string ActiveTabId => Driver.FindElement(By.Id("tab-header")).FindElement(By.ClassName("active")).GetAttribute("id");
        protected WebElements CrudPageNumberButton => new(Driver, By.LinkText(string.Format($"{CrudNextPage}")));
        protected IWebElement InfoIcon => Driver.FindElement(By.ClassName("info-icon-center"));
        protected int CrudNextPage { get; set; }

        public BackendMenu(IWebDriver Driver)
        {
            this.Driver = Driver;
            Interaction = new(Driver);
            Wait = new(Driver);
        }

        public void WaitForOverlayToDisappear()
        {
            Wait.ForElementToBeInvisible(Overlay);

            //if (Overlay.Elements.Count > 0)
            //{
            //    Wait.ForElementToBeInvisible(Overlay);
            //}
        }
    }
}