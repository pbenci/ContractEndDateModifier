using OpenQA.Selenium;

namespace InsuranceAdjuster
{
    public class Interactions
    {
        protected IWebDriver Driver { get; private set; }
        protected Waits Wait { get; private set; }
        protected int LoadingOverlay { get; private set; }
        protected string ActiveTabId
        {
            get
            {
                if (Driver.FindElement(By.Id("tab-header")).FindElements(By.ClassName("active")).Count > 0)
                {
                    return Driver.FindElement(By.Id("tab-header")).FindElement(By.ClassName("active")).GetAttribute("id");
                }
                else
                {
                    return "";
                }
            }
        }

        public WebElements ProcessingOverlay => new(Driver, By.Id(string.Format($"table-{ActiveTabId}_processing")));

        public Interactions(IWebDriver Driver)
        {
            this.Driver = Driver;
            Wait = new Waits(Driver);
        }

        public void ScrollTo(IWebElement Element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'instant', block: 'center'})", Element);
        }

        public void Click(IWebElement Element)
        {
            Wait.ForElementToBeClickable(Element);
            ScrollTo(Element);
            try
            {
                Element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(10000);
                Element.Click();
            }
        }

        public void Write(IWebElement Element, string Input)
        {
            Wait.ForElementToBeClickable(Element);
            ScrollTo(Element);
            Element.Clear();
            Element.SendKeys(Input);
        }

        public void SwitchCrudPage(IWebElement Element)
        {
            Element.Click();
            Wait.ForElementToBeInvisible(ProcessingOverlay);
        }
    }
}