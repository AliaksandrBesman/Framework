using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverLab.pageobject_model.page;
using WebDriverLab.Driver;
using WebDriverLab.Model;
using WebDriverLab.Service;

namespace WebDriverLab
{
    class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void BrowserSetup()
        {
            driver = DriverSingleton.GetDriver("Chrome");        
   
        }


        [Test]
        public void CheckProductAddedToCart() 
        {
            Product firstTestMice = ProductCreator.WithFirstWireMice();
       
            ProductCatalogPage allMicePage = new ProductCatalogPage(driver).openPage();
            CartPage cartPage= allMicePage.AddProductToCartByName(firstTestMice.ProductName)
                        .ViewCart();
            bool isAdded = cartPage.isProductAdded(firstTestMice.ProductName);
            Assert.IsTrue(isAdded, "Product is not added");
            Assert.IsTrue(cartPage.CountAddedProducts() == 1, "Count added product does not match ");
            List<string> productDescr =cartPage.GetProductDescription(firstTestMice.ProductName);
            Assert.AreEqual(productDescr, firstTestMice.ProductDescriptions, "Descriptions does not math");
        }


 
        [Test]
        public void RemoveProducFromCart()
        {
            Product firstTestMice = ProductCreator.WithFirstWireMice();
            ProductCatalogPage allMicePage = new ProductCatalogPage(driver).openPage();
            CartPage cartPage = allMicePage.AddProductToCartByName(firstTestMice.ProductName)
                        .ViewCart().RemoveProduct(firstTestMice.ProductName);
            string emptyCartText= cartPage.GetTextAboutEmptyCart();

            Assert.AreEqual(emptyCartText, "Your cart is empty", "Descriptions does not math");
        }
        [Test]
        public void AddTwoDifferentProductToCart()
        {
            Product firstTestMice = ProductCreator.WithFirstWireMice();
            Product secondTestMice = ProductCreator.WithSecondWireMice();
            ProductCatalogPage allMicePage = new ProductCatalogPage(driver).openPage();
            allMicePage.AddProductToCartByName(firstTestMice.ProductName);

            CartPage cartPage = allMicePage.openPage().
                AddProductToCartByName(secondTestMice.ProductName)
                .ViewCart();
            Assert.IsTrue(cartPage.CountAddedProducts() == 2);
            Assert.IsTrue(cartPage.isProductAdded("Razer DeathAdder V2 Pro"), "Product is not added");
            Assert.IsTrue(cartPage.isProductAdded("Razer Naga Pro"), "Product is not added");
        }

        [Test]
        public void CheckLocalTaxesForState()
        {
            Product firstTestMice = ProductCreator.WithFirstWireMice();
            ProductCatalogPage allMicePage = new ProductCatalogPage(driver).openPage();
            DeliveryShippingPage cartPage = allMicePage.AddProductToCartByName(firstTestMice.ProductName)
                        .ViewCart()
                        .ProceedToCheckout()
                        .FillAddressField()
                        .CotinueToShippingMethod()
                        .SelectExpressShipping();
            float localTaxes = cartPage.GetLocalTaxes();


        }



        [TearDown]
        public void BrowserTearDown()
        {
            DriverSingleton.CloseDriver();
        }

    }
}
