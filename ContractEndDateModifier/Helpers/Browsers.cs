using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Reflection;

namespace InsuranceAdjuster
{
    public class Browsers
    {
        private string OutputDirectory { get => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }

        public IWebDriver LaunchChrome()
        {
            ChromeOptions ChromeOptions = new ChromeOptions();
            ChromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            if (bool.Parse(ConfigurationManager.AppSettings.Get("HeadlessBrowser")))
            {
                ChromeOptions.AddArguments("headless", "no-sandbox", "--disable-gpu", "--window-size=1920x1080");
            }
            return new ChromeDriver(OutputDirectory, ChromeOptions);
        }
    }
}