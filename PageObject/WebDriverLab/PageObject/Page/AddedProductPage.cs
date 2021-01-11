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
    class AddedProductPage : Page<AddedProductPage>
    {
        IWebElement targetProduct;
        const string viewCartButtonPrefix = @"//app-razer-main-sku//button[@class='button-primary']";
        [FindsBy(How = How.XPath, Using = viewCartButtonPrefix)]
        private IWebElement viewCartButton;

        public AddedProductPage(IWebDriver driver, IWebElement targetProduct) : base(driver)
        {
            this.targetProduct = targetProduct;
            PageFactory.InitElements(driver, this);
            
        }

        public CartPage ViewCart()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", viewCartButton);
            return new CartPage(driver);
        }

        public override AddedProductPage openPage()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", targetProduct);
            WaitAnswerFromPage();
            WaitLoadedCurrentPage();
            PageFactory.InitElements(driver, this);
            return this;
        }


        private void WaitLoadedCurrentPage()
        {
            while(true)
            {
                try
                {
                    IWebElement viewCartButton = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(viewCartButtonPrefix)));
                    if (viewCartButton != null)
                        return;
                }
                catch
                {

                }
            }
           
        }
    }
}
