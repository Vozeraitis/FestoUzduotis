using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoUzduotis.Pages
{
    internal class mainPage : BasePage
    {
        public mainPage(IWebDriver webDriver) : base(webDriver) { }
        private const string PageAdress = "https://www.festo.com/us/en/";
        private static IWebElement searchField => Driver.FindElement(By.Id("search-input"));
        private static IWebElement productName => Driver.FindElement(By.Id("main-headline"));
        private static IWebElement cookieButton => Driver.FindElement(By.XPath("//*[@class='primary--zcAW6 medium--hu0Ij accept-button--xmuLn']"));
        private static IWebElement searchResult => Driver.FindElement(By.CssSelector("a[href*='id_ADN_S']"));
        private static IWebElement secondProductToAdd => Driver.FindElement(By.XPath("(//*[@class='icon--JE4vu add-to-cart-button--wfpa3'])[2]"));

        public void OpenMainPage()
        {
            Driver.Url = PageAdress;
        }

        public void ClickCookies()
        {
            GetWait(5).Until(c => cookieButton.Displayed);
            cookieButton.Click();
        }

        public void EnterSearch(string firstField)
        {
            searchField.SendKeys(firstField);
        }

        public void ClickSearchResult(string item)
        {
            //IWebElement searchResult = Driver.FindElement(By.CssSelector($"a[href*='{item}']"));
            GetWait(10).Until(c => searchResult.Displayed);
            searchResult.Click();
        }

        public void AssertIfCorrectPage(string productPageName)
        {
            Assert.AreEqual(productName.Text.ToLower(), productPageName.ToLower());
        }

        public void AddItemToCart()
        {
            secondProductToAdd.Click();
        }
    }
}
