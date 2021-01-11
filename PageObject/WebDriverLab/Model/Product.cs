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

namespace WebDriverLab.Model
{
    class Product
    {
        private string productName;
        private string productCategiry;
        private float productPrice;
        private List<string> productDescriptions;

        public string ProductName { get => productName; set => productName = value; }
        public string ProductCategiry { get => productCategiry; set => productCategiry = value; }
        public float ProductPrice { get => productPrice; set => productPrice = value; }
        public List<string> ProductDescriptions { get => productDescriptions; set => productDescriptions = value; }

        public Product (string productName, string productCategiry, float productPrice, List<string> productDescriptions)
        {
            this.productName = productName;
            this.productCategiry = productCategiry;
            this.productPrice = productPrice;
            this.productDescriptions = productDescriptions;
        }
        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return this.productName.Equals(product.productName) &&
                    this.productCategiry.Equals(product.productCategiry) &&
                    this.productPrice.Equals(product.productPrice) &&
                    this.productDescriptions.Equals(product.productDescriptions);
        }
    }
}
