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
using WebDriverLab.Model;

namespace WebDriverLab.Service
{
    class ProductCreator
    {

        public static Product WithFirstWireMice()
        {
            return new Product("Razer DeathAdder V2 Pro",
                                "Mice",
                                129.99f,
                                new List<string>()
                                {
                                    "Razer™ HyperSpeed Wireless",
                                    "Razer™ Focus+ Optical Sensor",
                                    "2nd Gen Razer™ Optical Mouse Switch"
                                });
        }
        public static Product WithSecondWireMice()
        {
            return new Product("Razer Naga Pro",
                                "Mice",
                                149.99f,
                                new List<string>()
                                {
                                    "Razer™ Hyperspeed Wireless technology",
                                    "Razer™ Focus+ Optical Sensor",
                                    "Razer™ Optical Mouse Switches"
                                });
        }
    }
}
