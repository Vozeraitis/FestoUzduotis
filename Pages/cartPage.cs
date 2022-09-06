using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoUzduotis.Pages
{
    internal class cartPage : BasePage
    {
        public cartPage(IWebDriver webDriver) : base(webDriver) { }
        private const string PageAdress = "https://www.festo.com/us/en/cart/";

        private static IReadOnlyCollection<IWebElement> cartProductsSerialNumber => Driver.FindElements(By.XPath("//*[@class='article-part-number--RloZ5']"));

        public void GoToCartPage()
        {
            Driver.Navigate().GoToUrl(PageAdress);
        }

        public void AssertIfAddedItemIsCorrect(string expectedProductNumber)
        {
            string actualResult = cartProductsSerialNumber.Last().Text;
            string expectedResult = expectedProductNumber;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
