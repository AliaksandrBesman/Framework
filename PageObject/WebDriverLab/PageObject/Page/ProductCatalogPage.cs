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
    class ProductCatalogPage : Page<ProductCatalogPage>
    {
        private const string PAGE_URL = "https://www.razer.com/shop/mice/gaming-mice";
        const string allMicePrefix = @"//*[@class='cx-product-container']//app-razer-product-grid-item";

        [FindsBy(How = How.XPath, Using = allMicePrefix)]
        private IList<IWebElement> allProducts;


        public ProductCatalogPage(IWebDriver driver) : base(driver)
        {

        }


        public override ProductCatalogPage openPage()
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            WaitAnswerFromPage();
            WaitLoadedPage();
            PageFactory.InitElements(driver, page: this);
            return this;
        }


        public AddedProductPage AddProductToCartByName(string productName)
        {
         foreach (IWebElement product in allProducts)
            {
                IWebElement productNameElement = product.FindElement(By.XPath(@".//a[contains(@class,'product-item-title')]"));
                if (productNameElement != null && productNameElement.Text.Contains(productName))
                {
                    IWebElement addToCartButton = product.FindElement(By.ClassName("add-to-cart-btn"));
                    IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                    jse.ExecuteScript("arguments[0].click()", addToCartButton);
                    return new AddedProductPage(driver, addToCartButton);
                }
            }
            return null;
         
        }
    }
}
