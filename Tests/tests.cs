using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoUzduotis.Tests
{
    internal class tests : BaseTests
    {
        public static string productNumber;
        public static string searchFieldEntry = "ADN";
        public static string searchResult = "id_ADN_S";
        public static string productNameToAssert = "Compact cylinder, double-acting ADN-S";

        [Test]
        public static void SerchTest()
        {
            _mainPage.OpenMainPage();
            _mainPage.ClickCookies();
            _mainPage.EnterSearch(searchFieldEntry);
            _mainPage.ClickSearchResult(searchResult);
            _mainPage.AssertIfCorrectPage(productNameToAssert);
            productNumber = _productPage.GetProductNumber();
            _productPage.AddChosenProductToCard();
            _productPage.ClickContinueShopping();
            _cartPage.GoToCartPage();
            _cartPage.AssertIfAddedItemIsCorrect(productNumber);
        }
    }
}
