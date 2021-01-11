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
    class DeliveryShippingPage: Page<DeliveryShippingPage>
    {
        
       
     
        public DeliveryShippingPage(IWebDriver driver) : base(driver)
        {
            
            PageFactory.InitElements(driver, this);


        }

        public override DeliveryShippingPage openPage()
        {
            throw new NotImplementedException();
        }

        public DeliveryShippingPage SelectStandartShipping()
        {
            IWebElement standartShippingButton = driver.FindElement(By.Id("deliverymode-standard-us"));
            standartShippingButton.Click();
            return this;
        }

        public DeliveryShippingPage SelectExpressShipping()
        {
            IWebElement expressShippingButton = driver.FindElement(By.Id("deliverymode-express-us"));
            expressShippingButton.Click();
            return this;
        }

        public float GetLocalTaxes()
        {
            Thread.Sleep(1000);
           IWebElement localTaxes = driver.FindElement(By.XPath("//app-razer-order-summary/div/div[2]/div/div[2]"));
          
            string temp = localTaxes.Text.Substring(3);
            return float.Parse(temp.Replace('.',','));
        }

        public float GetShippingCost()
        {
            IWebElement shipping = driver.FindElement(By.XPath("//div[contains(@class,'summary-block')][2]//div[contains(@class,'value')]"));
            return float.Parse(shipping.Text.Substring(3));
        }

        public float GetTotal()
        {
            IWebElement total = driver.FindElement(By.XPath("//div[contains(@class,'summary-block')][3]//div[contains(@class,'value')]"));
            return float.Parse(total.Text.Substring(3));
        }
        public float GetShippingCostText()
        {
            IWebElement shipping = driver.FindElement(By.XPath("//div[contains(@class,'summary-block')][3]//div[contains(@class,'value')]"));
            return float.Parse(shipping.Text);
        }

        public float GetSubTotal()
        {
            IWebElement localTaxes = driver.FindElement(By.XPath("//div[contains(@class,'summary-block')][0]//div[contains(@class,'value')]"));
            return float.Parse(localTaxes.Text.Substring(3));
        }
    }
}
