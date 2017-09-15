using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using MyMallProject.Pages;

namespace MyMallProject
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
  
    public class BasketTests
    {
        IWebDriver driverChrome = new ChromeDriver();

        [TestInitialize]
        public void TestInitialize()
        {
           driverChrome.Url = "http://sports.mymall.bg/login.php?action=login";

            driverChrome.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");
            Console.InputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");
            driverChrome.Manage().Window.Maximize();
            driverChrome.Manage().Cookies.DeleteAllCookies();
            IWebElement emailForLogIn = driverChrome.FindElement(By.Id("login_email"));
            emailForLogIn.SendKeys("vhidd3n@gmail.com");
            IWebElement passForLogIn = driverChrome.FindElement(By.Id("header_login_pass"));
            passForLogIn.SendKeys("testPass");
            IWebElement logInButton = driverChrome.FindElement(By.Id("LoginButton"));
            logInButton.Click();
        }

       //[TestCleanup]
       //public void TestCleanup()
       //{
       //    driverChrome.Quit();
       //}
        
        [TestMethod]
        public void AddItemsToBasket_PageObjectModel()
        {
            TheSearchFieldPage searchField = new TheSearchFieldPage(driverChrome);
            searchField.SearchField.Click();
            searchField.SearchField.SendKeys("мъжки къси панталони");
            searchField.GoSearchButton.Click();
            //adding first item
            IList<IWebElement> EvenResultsList = driverChrome.FindElements(By.XPath("//li[@class='ListView ListViewEven product']"));
            EvenResultsList[0].Click();
            AddItemPage addingFirstItem = new AddItemPage(driverChrome);
            SelectElement sizeMenuFirstItem = addingFirstItem.getSelectSizeOptions();
            sizeMenuFirstItem.SelectByIndex(1);
            Thread.Sleep(3000);
            addingFirstItem.AddToBasket.Click();
            MyCartPage myCart = new MyCartPage(driverChrome);
            myCart.SeeTheCartButton.Click();
            //adding second item to basket
            searchField.SearchField.Click();
            searchField.SearchField.SendKeys("мъжки къси панталони");
            searchField.GoSearchButton.Click();
            IList<IWebElement> OddResultsList = driverChrome.FindElements(By.XPath("//li[@class='ListView ListViewOdd product']"));
            OddResultsList[0].Click();
            AddItemPage addingSecondItem = new AddItemPage(driverChrome);
            SelectElement sizeMenuSecondItem = addingSecondItem.getSelectSizeOptions();
            sizeMenuSecondItem.SelectByIndex(1);
            Thread.Sleep(3000);
            addingSecondItem.AddToBasket.Click();
            myCart.SeeTheCartButton.Click();
            IWebElement firstItemInBasket = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Puma Essential')]"));
            Assert.AreEqual("True", firstItemInBasket.Displayed);
            IWebElement secondItemInBasket = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Jack and Jones')]"));
            Assert.AreEqual("True", secondItemInBasket.Displayed);
            
        }

       [TestMethod]
       public void AddItemsToBasketAndChangeQuantityOfFirstItemTo30_PageObjectModel()
       {
           TheSearchFieldPage searchField = new TheSearchFieldPage(driverChrome);
           searchField.SearchField.Click();
           searchField.SearchField.SendKeys("мъжки къси панталони");
           searchField.GoSearchButton.Click();
           //adding first item
           IList<IWebElement> EvenResultsList = driverChrome.FindElements(By.XPath("//li[@class='ListView ListViewEven product']"));
           EvenResultsList[0].Click();
           AddItemPage addingFirstItem = new AddItemPage(driverChrome);
           SelectElement sizeMenuFirstItem = addingFirstItem.getSelectSizeOptions();
           sizeMenuFirstItem.SelectByIndex(1);
           Thread.Sleep(3000);
           addingFirstItem.AddToBasket.Click();
           MyCartPage myCart = new MyCartPage(driverChrome);
           myCart.SeeTheCartButton.Click();
           //adding second item to basket
           searchField.SearchField.Click();
           searchField.SearchField.SendKeys("мъжки къси панталони");
           searchField.GoSearchButton.Click();
           IList<IWebElement> OddResultsList = driverChrome.FindElements(By.XPath("//li[@class='ListView ListViewOdd product']"));
           OddResultsList[0].Click();
           AddItemPage addingSecondItem = new AddItemPage(driverChrome);
           SelectElement sizeMenuSecondItem = addingSecondItem.getSelectSizeOptions();
           sizeMenuSecondItem.SelectByIndex(1);
           Thread.Sleep(3000);
           addingSecondItem.AddToBasket.Click();
           myCart.SeeTheCartButton.Click();
           IWebElement firstItemInBasket = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Puma Essential')]"));
           IWebElement secondItemInBasket = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Jack and Jones')]"));
           string wholePriceInStringBeforeChangingQuantity = driverChrome.FindElement(By.XPath("//tr[@class='First Odd Even']/td/em/span")).Text;
           string levaPrice = wholePriceInStringBeforeChangingQuantity.Substring(0, wholePriceInStringBeforeChangingQuantity.Length - 5);
           string stotinkiPrice = driverChrome.FindElement(By.XPath("//tr[@class='First Odd Even']/td/em/span/sup")).Text;
           string firstItemPrice = levaPrice + "." + stotinkiPrice;
           SelectElement firstItemQuantity = new SelectElement(driverChrome.FindElement(By.XPath("//div[@class='Value select_big_arr']/select")));
           firstItemQuantity.SelectByValue("30");
           Thread.Sleep(3000);
           bool isMessageForSuccessfulyChangedQuantityPresent = myCart.SuccesfulyChangedQuantity.Displayed;
           Assert.AreEqual("True", isMessageForSuccessfulyChangedQuantityPresent.ToString());
           //IWebElement isTheMessageHere = driverChrome.FindElement(By.XPath("//*[@id='CartStatusMessage']/div[1]/text()"));
           IList<IWebElement> quantityErrrorMessage = driverChrome.FindElements(By.ClassName("dangerMessage"));
           string wholePriceInStringAfterChangingQuantity = driverChrome.FindElement(By.XPath("//tr[@class='First Odd Even']/td/em/span")).Text;
           string levaPriceAfterChangingQuantity = wholePriceInStringAfterChangingQuantity.Substring(0, wholePriceInStringAfterChangingQuantity.Length - 5);
           string stotinkiPriceAfterChangingQuantity = driverChrome.FindElement(By.XPath("//tr[@class='First Odd Even']/td/em/span/sup")).Text;
           string firstItemPriceAfterChangingQuantity = levaPrice + "." + stotinkiPrice;
       
           if (quantityErrrorMessage.Count == 0)
           {
               Assert.AreNotEqual(firstItemPrice, firstItemPriceAfterChangingQuantity);
           }
           else
           {
               // the price should be the same, the quantity also the same
           
               Assert.AreEqual(wholePriceInStringBeforeChangingQuantity, wholePriceInStringAfterChangingQuantity);
           }
       }
       
           [TestMethod]
       public void AddItemsToBasketAndChangeQuantityOfFirstItemTo0_PageObjectModel()
       {
           TheSearchFieldPage searchField = new TheSearchFieldPage(driverChrome);
           searchField.SearchField.Click();
           searchField.SearchField.SendKeys("мъжки къси панталони");
           searchField.GoSearchButton.Click();
           //adding first item
           IList<IWebElement> EvenResultsList = driverChrome.FindElements(By.XPath("//li[@class='ListView ListViewEven product']"));
           EvenResultsList[0].Click();
           AddItemPage addingFirstItem = new AddItemPage(driverChrome);
           SelectElement sizeMenuFirstItem = addingFirstItem.getSelectSizeOptions();
           sizeMenuFirstItem.SelectByIndex(1);
           Thread.Sleep(3000);
           addingFirstItem.AddToBasket.Click();
           MyCartPage myCart = new MyCartPage(driverChrome);
           myCart.SeeTheCartButton.Click();
           //adding second item to basket
           searchField.SearchField.Click();
           searchField.SearchField.SendKeys("мъжки къси панталони");
           searchField.GoSearchButton.Click();
           IList<IWebElement> OddResultsList = driverChrome.FindElements(By.XPath("//li[@class='ListView ListViewOdd product']"));
           OddResultsList[0].Click();
           AddItemPage addingSecondItem = new AddItemPage(driverChrome);
           SelectElement sizeMenuSecondItem = addingSecondItem.getSelectSizeOptions();
           sizeMenuSecondItem.SelectByIndex(1);
           Thread.Sleep(3000);
           addingSecondItem.AddToBasket.Click();
           myCart.SeeTheCartButton.Click();
           IWebElement firstItemInBasket = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Puma Essential')]"));
           IWebElement secondItemInBasket = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Jack and Jones')]"));
           string wholePriceInStringBeforeChangingQuantity = driverChrome.FindElement(By.XPath("//tr[@class='First Odd Even']/td/em/span")).Text;
           string levaPrice = wholePriceInStringBeforeChangingQuantity.Substring(0, wholePriceInStringBeforeChangingQuantity.Length - 5);
           string stotinkiPrice = driverChrome.FindElement(By.XPath("//tr[@class='First Odd Even']/td/em/span/sup")).Text;
           string firstItemPrice = levaPrice + "." + stotinkiPrice;
           //changing quantity to 0
           SelectElement firstItemQuantity = new SelectElement(driverChrome.FindElement(By.XPath("//div[@class='Value select_big_arr']/select")));
           firstItemQuantity.SelectByValue("0");
           Thread.Sleep(3000);
           IAlert alert = driverChrome.SwitchTo().Alert();
           alert.Accept();
           IList<IWebElement> listOfMissingtems = driverChrome.FindElements(By.XPath("//*[contains(text(), 'Puma Essential')]"));
           Assert.AreEqual(0, listOfMissingtems.Count);
         
       }
       
       [TestMethod]
       public void AddItemsToBasketAndRemoveAnItem_PageObjectModel()
       {
           TheSearchFieldPage searchField = new TheSearchFieldPage(driverChrome);
           searchField.SearchField.Click();
           searchField.SearchField.SendKeys("мъжки къси панталони");
           searchField.GoSearchButton.Click();
           //adding first item
           IList<IWebElement> EvenResultsList = driverChrome.FindElements(By.XPath("//li[@class='ListView ListViewEven product']"));
           EvenResultsList[0].Click();
           AddItemPage addingFirstItem = new AddItemPage(driverChrome);
           SelectElement sizeMenuFirstItem = addingFirstItem.getSelectSizeOptions();
           sizeMenuFirstItem.SelectByIndex(1);
           Thread.Sleep(3000);
           addingFirstItem.AddToBasket.Click();
           MyCartPage myCart = new MyCartPage(driverChrome);
           myCart.SeeTheCartButton.Click();
           //adding second item to basket
           searchField.SearchField.Click();
           searchField.SearchField.SendKeys("мъжки къси панталони");
           searchField.GoSearchButton.Click();
           IList<IWebElement> OddResultsList = driverChrome.FindElements(By.XPath("//li[@class='ListView ListViewOdd product']"));
           OddResultsList[0].Click();
           AddItemPage addingSecondItem = new AddItemPage(driverChrome);
           SelectElement sizeMenuSecondItem = addingSecondItem.getSelectSizeOptions();
           sizeMenuSecondItem.SelectByIndex(1);
           Thread.Sleep(3000);
           addingSecondItem.AddToBasket.Click();
           myCart.SeeTheCartButton.Click();
           IWebElement firstItemInBasket = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Puma Essential')]"));
           IWebElement secondItemInBasket = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Jack and Jones')]"));
           string wholePriceInStringBeforeChangingQuantity = driverChrome.FindElement(By.XPath("//tr[@class='First Odd Even']/td/em/span")).Text;
           string levaPrice = wholePriceInStringBeforeChangingQuantity.Substring(0, wholePriceInStringBeforeChangingQuantity.Length - 5);
           string stotinkiPrice = driverChrome.FindElement(By.XPath("//tr[@class='First Odd Even']/td/em/span/sup")).Text;
           string firstItemPrice = levaPrice + "." + stotinkiPrice;
           //removing item
           myCart.RemoveItemLink.Click();
           Thread.Sleep(3000);
           IAlert alert = driverChrome.SwitchTo().Alert();
           alert.Accept();
           IList<IWebElement> listOfMissingtems = driverChrome.FindElements(By.XPath("//*[contains(text(), 'Puma Essential')]"));
           Assert.AreEqual(0, listOfMissingtems.Count);
       
       }
    }
}
