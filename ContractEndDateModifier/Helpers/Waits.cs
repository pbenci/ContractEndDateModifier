using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace InsuranceAdjuster
{
    public class Waits
    {
        protected IWait<IWebDriver> Wait { get; private set; }
        protected IWebDriver Driver { get; private set; }
        protected int Timer => 240;

        public Waits(IWebDriver Driver)
        {
            this.Driver = Driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Timer));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void ForPageToBeLoaded()
        {
            Wait.Until(Driver => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void ForElementToBeClickable(IWebElement Element)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(Element));
        }

        public void ForElementToExist(WebElements Element)
        {
            Wait.Until(ExpectedConditions.ElementExists(Element.Locator));
        }

        public void ForElementToBeInvisible(WebElements Element)
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Element.Locator));
        }

        public void ForElementToBeVisible(WebElements Element)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(Element.Locator));
        }
    }
}