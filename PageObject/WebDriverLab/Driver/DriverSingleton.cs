using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverLab.Driver
{
    class DriverSingleton
    {
        private static IWebDriver driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver(string browser)
        {
            if (driver == null)
            {

                switch (browser)
                {
                    case "Firefox":
                        {
                            FirefoxOptions options = new FirefoxOptions();
                            options.AddArguments("--start-fullscreen");
                            driver = new FirefoxDriver(options);
                            break;
                        };
                    default:
                        {
                            ChromeOptions options = new ChromeOptions();
                            options.AddArguments("--start-fullscreen");
                            driver = new ChromeDriver(options);
                            break;
                        }
                }
            }
            return driver;
        }

        public static void CloseDriver()
        {
            if (driver != null)
                driver.Quit();
            driver = null;
        }
    }
}
