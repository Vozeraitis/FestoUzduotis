using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoUzduotis.Pages
{
    internal class productPage : BasePage
    {
        public productPage(IWebDriver webDriver) : base(webDriver) { }
        private const string PageAdress = "https://www.festo.com/us/en/p/compact-cylinder-double-acting-id_ADN_S";

        private static IReadOnlyCollection<IWebElement> addToCartButtons => Driver.FindElements(By.XPath("//*[@class='icon--JE4vu add-to-cart-button--wfpa3']"));
        public static IReadOnlyCollection<IWebElement> productNumbers => Driver.FindElements(By.XPath("//p[@class='triad-part-number-text--lkyGv']"));
        private static IWebElement goToCartButton => Driver.FindElement(By.XPath("//*[@class='mini-cart-wrapper--yyV9v active--Vo4hf']"));
        private static IWebElement continueShoppingButton => Driver.FindElement(By.XPath("//*[@class='primary--zcAW6 medium--hu0Ij']"));
        private static IWebElement addedToCartMessage => Driver.FindElement(By.XPath("//*[@class='lineClamp--AGfOn text-message--idt4M']"));

        public void AddChosenProductToCard()
        {
            addToCartButtons.ElementAt(1).Click();
            GetWait(5).Until(c => addedToCartMessage.Displayed);
        }

        public void ClickContinueShopping()
        {
            try
            {
                GetWait(5).Until(c => continueShoppingButton.Displayed);
                continueShoppingButton.Click();
            }
            catch
            {

            }
        }

        public string GetProductNumber()
        {
            string productNumber = productNumbers.ElementAt(1).Text;
            return productNumber;
        }
    }
}
