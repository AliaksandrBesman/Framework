﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverLab.pageobject_model.page
{
    abstract class Page<T>
    {
        protected IWebDriver driver;

        public abstract T openPage();

        protected const int WAIT_TIMEOUT_SECONDS = 30;
        protected const string HOMEPAGE_URL = @"https://www.razer.com/";

        protected Page(IWebDriver driver)
        {
            this.driver = driver;
        }
        protected void WaitAnswerFromPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT_SECONDS))
          .Until(CustomConditions.JQueryAJAXsCompleted(driver));

        }
        protected void WaitLoadedPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WAIT_TIMEOUT_SECONDS);

        }
    }
}
