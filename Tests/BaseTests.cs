using FestoUzduotis.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoUzduotis.Tests
{
    internal class BaseTests
    {
        protected static IWebDriver Driver;

        public static mainPage _mainPage;
        public static productPage _productPage;
        public static cartPage _cartPage;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            Driver = new FirefoxDriver();

            _mainPage = new mainPage(Driver);
            _productPage = new productPage(Driver);
            _cartPage = new cartPage(Driver);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Driver.Quit();
        }
    }
}
