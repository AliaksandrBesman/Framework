using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverLab.pageobject_model.page
{
    class DeliveryAddressPage:Page<DeliveryAddressPage>
    {
   
        [FindsBy(How = How.Id, Using = "mat-input-1")]
        private IWebElement mailField;
        [FindsBy(How = How.Id, Using = "mat-input-2")]
        private IWebElement phoneField;
        [FindsBy(How = How.Id, Using = "mat-input-3")]
        private IWebElement firstNameField;
        [FindsBy(How = How.Id, Using = "mat-input-4")]
        private IWebElement lastNameField;
        [FindsBy(How = How.Id, Using = "mat-input-6")]
        private IWebElement addressLineField;
        [FindsBy(How = How.Id, Using = "mat-input-10")]
        private IWebElement townField;
        [FindsBy(How = How.Id, Using = "mat-input-9")]
        private IWebElement zipCodeField;
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'mat-select-value')]")]
        private IWebElement stateField;
    
        public DeliveryAddressPage(IWebDriver driver) : base(driver)
        {
            //mailField = driver.FindElement(By.XPath(@"//input[1]"));
            PageFactory.InitElements(driver, this);


        }

        public DeliveryAddressPage FillAddressField()
        {
            string temp = "alex.l@mai.ru";
            string phone = "2134852121";
            string firstName = "Alex";
            string lastName = "Bubo";
            string addressLineOne = "Los Angeles CA";
            string town = "Los Angeles";
            string zipCode = "90011";



            mailField.SendKeys(temp);
            phoneField.SendKeys(phone);
            firstNameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            addressLineField.SendKeys(addressLineOne);
            townField.SendKeys(town);
            zipCodeField.SendKeys(zipCode);

            Thread.Sleep(1000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", stateField);
          
            Thread.Sleep(1000);
            IWebElement combobox = driver.FindElement(By.XPath("//span[contains(text(),' California ')]"));
            Thread.Sleep(1000);
            jse.ExecuteScript("arguments[0].click()", combobox);
      
            int fsdf = 20;

            return this;
        }


        public DeliveryShippingPage CotinueToShippingMethod()
        {
            IWebElement CotinueToShippingMethodButton = driver.FindElement(By.XPath("//button[contains(text(),'Continue to Shipping Method')]"));
            CotinueToShippingMethodButton.Click();
           
            return new DeliveryShippingPage(driver);
        }



        public override DeliveryAddressPage openPage()
        {
            throw new NotImplementedException();
        }
    }
}
