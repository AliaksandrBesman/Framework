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
using System.Threading.Tasks;

namespace WebDriverLab.pageobject_model.page
{
    class CartPage : Page<CartPage>
    {
        private const string PAGE_URL = "https://www.razer.com/cart";
        string findProductPathSecond = @"//a[contains(text(),'{0}')]";
        const string allAddedItemPrefix = @"//*[contains(@class,'cx-item-list-row')]";
        private IWebElement moveToThisPageButton;
        [FindsBy(How = How.XPath, Using = allAddedItemPrefix)]
        private IList<IWebElement> allAddedItem;


        public CartPage(IWebDriver driver, IWebElement targetButton) : base(driver)
        {
            this.moveToThisPageButton = targetButton;
        }
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver, page: this);
        }

        public override CartPage openPage()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", moveToThisPageButton);
            WaitAnswerFromPage();
            WaitLoadedPage();
            PageFactory.InitElements(this.driver, page: this);
            return this;
        }


        //-----------------------------
        public bool isProductAdded(string productName)
        {
            try
            {
                string pathToProduct = String.Format(findProductPathSecond, productName);
                IWebElement requariedProduct = driver.FindElement(By.XPath(pathToProduct));
                if (requariedProduct != null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }

           

        }

        public int CountAddedProducts()
        {
            return driver.FindElements(By.XPath(allAddedItemPrefix)).Count;
        }

        public List<string> GetProductDescription(string productName)
        {
            foreach (IWebElement product in allAddedItem)
            {
                string pathToProduct = String.Format(findProductPathSecond, productName);
                IWebElement productNameElement = product.FindElement(By.XPath("."+pathToProduct));
              
                if (productNameElement != null && productNameElement.Text.Contains(productName))
                {
                    List<string> productDescriptions = product.FindElements(By.XPath(".//li")).Select(p=>p.Text).ToList();
                    
                    return productDescriptions;
                }
            }
            return null;
        }

        public CartPage RemoveProduct(string productName)
        {
            foreach (IWebElement product in allAddedItem)
            {
                string pathToProduct = String.Format(findProductPathSecond, productName);
                IWebElement productNameElement = product.FindElement(By.XPath("." + pathToProduct));

                if (productNameElement != null && productNameElement.Text.Contains(productName))
                {
                    IWebElement removeProductButton = product.FindElement(By.XPath(".//button[contains(text(),'Remove')]"));
                    removeProductButton.Click();
                    return this;
                }
            }
            return null;
        }

        public string GetTextAboutEmptyCart()
        {
            return driver.FindElement(By.XPath(@"//div[contains(@class,'paragraph-component')]//h1")).Text;
        }

        public DeliveryAddressPage  ProceedToCheckout()
        {
            IWebElement checkoutButton = driver.FindElement(By.XPath("//button[contains(text(),'checkout')]"));
            checkoutButton.Click();
            IWebElement continueAsGuestButton = driver.FindElement(By.XPath("//button[contains(text(),'Continue as guest')]"));
            continueAsGuestButton.Click();
            return new DeliveryAddressPage(driver);
        }

    }
}
