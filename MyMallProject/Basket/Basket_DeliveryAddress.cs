﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMallProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMallProject.Basket
{
    [TestClass]
    public class Basket_DeliveryAddress
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
            TheSearchFieldPage searchField = new TheSearchFieldPage(driverChrome);
            searchField.SearchField.Click();
            searchField.SearchField.SendKeys("мъжки къси панталони");
            searchField.GoSearchButton.Click();
            //adding item
            IList<IWebElement> EvenResultsList = driverChrome.FindElements(By.XPath("//li[@class='ListView ListViewEven product']"));
            EvenResultsList[0].Click();
            AddItemPage addingFirstItem = new AddItemPage(driverChrome);
            SelectElement sizeMenuFirstItem = addingFirstItem.getSelectSizeOptions();
            sizeMenuFirstItem.SelectByIndex(1);
            Thread.Sleep(3000);
            addingFirstItem.AddToBasket.Click();
            MyCartPage myCart = new MyCartPage(driverChrome);
            myCart.SeeTheCartButton.Click();
            myCart.ProceedToCheckOut.Click();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driverChrome.Quit();
        }


        [TestMethod]
        public void InputRealAddressDetails()
        {
            MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
            addressPage.FirstNameField.Click();
            addressPage.FirstNameField.SendKeys("Владимир");
            addressPage.SurnameField.Click();
            addressPage.SurnameField.SendKeys("Йончев");
            addressPage.TelephoneField.Click();
            addressPage.TelephoneField.SendKeys("0878878576");
            addressPage.CityOrVillageField.Click();
            addressPage.CityOrVillageField.SendKeys("София");
            addressPage.PostCodeField.Click();
            addressPage.PostCodeField.SendKeys("1000");
            addressPage.ProvinceField.Click();
            addressPage.ProvinceField.SendKeys("София");
            addressPage.StreetField.Click();
            addressPage.StreetField.SendKeys("бул. Васил Левски");
            addressPage.StreetNumberField.Click();
            addressPage.StreetNumberField.SendKeys("33");
            addressPage.BlockEntranceField.Click();
            addressPage.BlockEntranceField.SendKeys("A");
            addressPage.FloorField.Click();
            addressPage.FloorField.SendKeys("2");
            addressPage.ApartmentField.Click();
            addressPage.ApartmentField.SendKeys("4");
            addressPage.InvoiceDetailsField.Click();
            addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
            addressPage.ProceedToCourierChoice.Click();
            Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");
                
        }


        [TestMethod]
        public void InputAddressDetailsWithBlankFirstName()
        {
            MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
            
            addressPage.SurnameField.Click();
            addressPage.SurnameField.SendKeys("Йончев");
            addressPage.TelephoneField.Click();
            addressPage.TelephoneField.SendKeys("0878878576");
            addressPage.CityOrVillageField.Click();
            addressPage.CityOrVillageField.SendKeys("София");
            addressPage.PostCodeField.Click();
            addressPage.PostCodeField.SendKeys("1000");
            addressPage.ProvinceField.Click();
            addressPage.ProvinceField.SendKeys("София");
            addressPage.StreetField.Click();
            addressPage.StreetField.SendKeys("бул. Васил Левски");
            addressPage.StreetNumberField.Click();
            addressPage.StreetNumberField.SendKeys("33");
            addressPage.BlockEntranceField.Click();
            addressPage.BlockEntranceField.SendKeys("A");
            addressPage.FloorField.Click();
            addressPage.FloorField.SendKeys("2");
            addressPage.ApartmentField.Click();
            addressPage.ApartmentField.SendKeys("4");
            addressPage.InvoiceDetailsField.Click();
            addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
            addressPage.ProceedToCourierChoice.Click();
            IWebElement enterNameMessage = driverChrome.FindElement(By.Id("FormField_4-error"));
            Assert.AreEqual("Моля въведи име", addressPage.pleaseEnterNameMessage.Text.ToString());
        }
       
        [TestMethod]
         public void InputAddressDetails_NameWithOver100Characters()
         {
             MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
             addressPage.FirstNameField.Click();
             addressPage.FirstNameField.SendKeys("ВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВлади");
             addressPage.SurnameField.Click();
             addressPage.SurnameField.SendKeys("Йончев");
             addressPage.TelephoneField.Click();
             addressPage.TelephoneField.SendKeys("0878878576");
             addressPage.CityOrVillageField.Click();
             addressPage.CityOrVillageField.SendKeys("София");
             addressPage.PostCodeField.Click();
             addressPage.PostCodeField.SendKeys("1000");
             addressPage.ProvinceField.Click();
             addressPage.ProvinceField.SendKeys("София");
             addressPage.StreetField.Click();
             addressPage.StreetField.SendKeys("бул. Васил Левски");
             addressPage.StreetNumberField.Click();
             addressPage.StreetNumberField.SendKeys("33");
             addressPage.BlockEntranceField.Click();
             addressPage.BlockEntranceField.SendKeys("A");
             addressPage.FloorField.Click();
             addressPage.FloorField.SendKeys("2");
             addressPage.ApartmentField.Click();
             addressPage.ApartmentField.SendKeys("4");
             addressPage.InvoiceDetailsField.Click();
             addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
             addressPage.ProceedToCourierChoice.Click();
             Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");

        }
       
        [TestMethod]
        public void InputAddressDetails_NameWithSpecialCharacters()
        {
            MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
            addressPage.FirstNameField.Click();
            addressPage.FirstNameField.SendKeys("Вл1д/м%р");
            addressPage.SurnameField.Click();
            addressPage.SurnameField.SendKeys("Йончев");
            addressPage.TelephoneField.Click();
            addressPage.TelephoneField.SendKeys("0878878576");
            addressPage.CityOrVillageField.Click();
            addressPage.CityOrVillageField.SendKeys("София");
            addressPage.PostCodeField.Click();
            addressPage.PostCodeField.SendKeys("1000");
            addressPage.ProvinceField.Click();
            addressPage.ProvinceField.SendKeys("София");
            addressPage.StreetField.Click();
            addressPage.StreetField.SendKeys("бул. Васил Левски");
            addressPage.StreetNumberField.Click();
            addressPage.StreetNumberField.SendKeys("33");
            addressPage.BlockEntranceField.Click();
            addressPage.BlockEntranceField.SendKeys("A");
            addressPage.FloorField.Click();
            addressPage.FloorField.SendKeys("2");
            addressPage.ApartmentField.Click();
            addressPage.ApartmentField.SendKeys("4");
            addressPage.InvoiceDetailsField.Click();
            addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
            addressPage.ProceedToCourierChoice.Click();
            Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");
        }
       
         [TestMethod]
         public void InputAddressDetails_LeaveSurnameEmpty()
         {
             MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
             addressPage.FirstNameField.Click();
             addressPage.FirstNameField.SendKeys("Владимир");
             addressPage.TelephoneField.Click();
             addressPage.TelephoneField.SendKeys("0878878576");
             addressPage.CityOrVillageField.Click();
             addressPage.CityOrVillageField.SendKeys("София");
             addressPage.PostCodeField.Click();
             addressPage.PostCodeField.SendKeys("1000");
             addressPage.ProvinceField.Click();
             addressPage.ProvinceField.SendKeys("София");
             addressPage.StreetField.Click();
             addressPage.StreetField.SendKeys("бул. Васил Левски");
             addressPage.StreetNumberField.Click();
             addressPage.StreetNumberField.SendKeys("33");
             addressPage.BlockEntranceField.Click();
             addressPage.BlockEntranceField.SendKeys("A");
             addressPage.FloorField.Click();
             addressPage.FloorField.SendKeys("2");
             addressPage.ApartmentField.Click();
             addressPage.ApartmentField.SendKeys("4");
             addressPage.InvoiceDetailsField.Click();
             addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
             addressPage.ProceedToCourierChoice.Click();
             Assert.AreEqual("Моля въведи фамилия", addressPage.SurnameIsMissingMessage.Text.ToString());
            
        
         }
       
        [TestMethod]
        public void InputAddressDetails_TypeForSurnameMoreThan100Characters()
        {
            MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
            addressPage.FirstNameField.Click();
            addressPage.FirstNameField.SendKeys("Владимир");
            addressPage.SurnameField.Click();
            addressPage.SurnameField.SendKeys("ВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВлади");
            addressPage.TelephoneField.Click();
            addressPage.TelephoneField.SendKeys("0878878576");
            addressPage.CityOrVillageField.Click();
            addressPage.CityOrVillageField.SendKeys("София");
            addressPage.PostCodeField.Click();
            addressPage.PostCodeField.SendKeys("1000");
            addressPage.ProvinceField.Click();
            addressPage.ProvinceField.SendKeys("София");
            addressPage.StreetField.Click();
            addressPage.StreetField.SendKeys("бул. Васил Левски");
            addressPage.StreetNumberField.Click();
            addressPage.StreetNumberField.SendKeys("33");
            addressPage.BlockEntranceField.Click();
            addressPage.BlockEntranceField.SendKeys("A");
            addressPage.FloorField.Click();
            addressPage.FloorField.SendKeys("2");
            addressPage.ApartmentField.Click();
            addressPage.ApartmentField.SendKeys("4");
            addressPage.InvoiceDetailsField.Click();
            addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
            addressPage.ProceedToCourierChoice.Click();
            Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page"); 
            
        }
        
           [TestMethod]
           public void InputAddressDetails_TypeSurnameWithCharacters()
           {
               MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
               addressPage.FirstNameField.Click();
               addressPage.FirstNameField.SendKeys("Владимир");
               addressPage.SurnameField.Click();
               addressPage.SurnameField.SendKeys("Йонч#$%^в");
               addressPage.TelephoneField.Click();
               addressPage.TelephoneField.SendKeys("0878878576");
               addressPage.CityOrVillageField.Click();
               addressPage.CityOrVillageField.SendKeys("София");
               addressPage.PostCodeField.Click();
               addressPage.PostCodeField.SendKeys("1000");
               addressPage.ProvinceField.Click();
               addressPage.ProvinceField.SendKeys("София");
               addressPage.StreetField.Click();
               addressPage.StreetField.SendKeys("бул. Васил Левски");
               addressPage.StreetNumberField.Click();
               addressPage.StreetNumberField.SendKeys("33");
               addressPage.BlockEntranceField.Click();
               addressPage.BlockEntranceField.SendKeys("A");
               addressPage.FloorField.Click();
               addressPage.FloorField.SendKeys("2");
               addressPage.ApartmentField.Click();
               addressPage.ApartmentField.SendKeys("4");
               addressPage.InvoiceDetailsField.Click();
               addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
               addressPage.ProceedToCourierChoice.Click();
               Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");
         
           }
        
          [TestMethod]
          public void InputAddressDetails_TypeMobileTelephoneNumberWith10DigitsStartingWith09()
          {
              MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
              addressPage.FirstNameField.Click();
              addressPage.FirstNameField.SendKeys("Владимир");
              addressPage.SurnameField.Click();
              addressPage.SurnameField.SendKeys("Йончев");
              addressPage.TelephoneField.Click();
              addressPage.TelephoneField.SendKeys("0988878576");
              addressPage.CityOrVillageField.Click();
              addressPage.CityOrVillageField.SendKeys("София");
              addressPage.PostCodeField.Click();
              addressPage.PostCodeField.SendKeys("1000");
              addressPage.ProvinceField.Click();
              addressPage.ProvinceField.SendKeys("София");
              addressPage.StreetField.Click();
              addressPage.StreetField.SendKeys("бул. Васил Левски");
              addressPage.StreetNumberField.Click();
              addressPage.StreetNumberField.SendKeys("33");
              addressPage.BlockEntranceField.Click();
              addressPage.BlockEntranceField.SendKeys("A");
              addressPage.FloorField.Click();
              addressPage.FloorField.SendKeys("2");
              addressPage.ApartmentField.Click();
              addressPage.ApartmentField.SendKeys("4");
              addressPage.InvoiceDetailsField.Click();
              addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
              addressPage.ProceedToCourierChoice.Click();
              Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");

        }
        
         [TestMethod]
         public void InputAddressDetails_TypeStationaryTelephoneNumberWith13Digits()
         {
             MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
             addressPage.FirstNameField.Click();
             addressPage.FirstNameField.SendKeys("Владимир");
             addressPage.SurnameField.Click();
             addressPage.SurnameField.SendKeys("Йончев");
             addressPage.TelephoneField.Click();
             addressPage.TelephoneField.SendKeys("0432978878576");
             addressPage.CityOrVillageField.Click();
             addressPage.CityOrVillageField.SendKeys("София");
             addressPage.PostCodeField.Click();
             addressPage.PostCodeField.SendKeys("1000");
             addressPage.ProvinceField.Click();
             addressPage.ProvinceField.SendKeys("София");
             addressPage.StreetField.Click();
             addressPage.StreetField.SendKeys("бул. Васил Левски");
             addressPage.StreetNumberField.Click();
             addressPage.StreetNumberField.SendKeys("33");
             addressPage.BlockEntranceField.Click();
             addressPage.BlockEntranceField.SendKeys("A");
             addressPage.FloorField.Click();
             addressPage.FloorField.SendKeys("2");
             addressPage.ApartmentField.Click();
             addressPage.ApartmentField.SendKeys("4");
             addressPage.InvoiceDetailsField.Click();
             addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
             addressPage.ProceedToCourierChoice.Click();
             Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");

         }
        
         [TestMethod]
         public void InputAddressDetails_TypeStationaryTelephoneNumberWith12Digits()
         {
             MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
             addressPage.FirstNameField.Click();
             addressPage.FirstNameField.SendKeys("Владимир");
             addressPage.SurnameField.Click();
             addressPage.SurnameField.SendKeys("Йончев");
             addressPage.TelephoneField.Click();
             addressPage.TelephoneField.SendKeys("043297887857");
             addressPage.CityOrVillageField.Click();
             addressPage.CityOrVillageField.SendKeys("София");
             addressPage.PostCodeField.Click();
             addressPage.PostCodeField.SendKeys("1000");
             addressPage.ProvinceField.Click();
             addressPage.ProvinceField.SendKeys("София");
             addressPage.StreetField.Click();
             addressPage.StreetField.SendKeys("бул. Васил Левски");
             addressPage.StreetNumberField.Click();
             addressPage.StreetNumberField.SendKeys("33");
             addressPage.BlockEntranceField.Click();
             addressPage.BlockEntranceField.SendKeys("A");
             addressPage.FloorField.Click();
             addressPage.FloorField.SendKeys("2");
             addressPage.ApartmentField.Click();
             addressPage.ApartmentField.SendKeys("4");
             addressPage.InvoiceDetailsField.Click();
             addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
             addressPage.ProceedToCourierChoice.Click();
             Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");

        }
       
         [TestMethod]
         public void InputAddressDetails_TypeStationaryTelephoneNumberWith8Digits()
         {
             MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
             addressPage.FirstNameField.Click();
             addressPage.FirstNameField.SendKeys("Владимир");
             addressPage.SurnameField.Click();
             addressPage.SurnameField.SendKeys("Йончев");
             addressPage.TelephoneField.Click();
             addressPage.TelephoneField.SendKeys("02989887");
             addressPage.CityOrVillageField.Click();
             addressPage.CityOrVillageField.SendKeys("София");
             addressPage.PostCodeField.Click();
             addressPage.PostCodeField.SendKeys("1000");
             addressPage.ProvinceField.Click();
             addressPage.ProvinceField.SendKeys("София");
             addressPage.StreetField.Click();
             addressPage.StreetField.SendKeys("бул. Васил Левски");
             addressPage.StreetNumberField.Click();
             addressPage.StreetNumberField.SendKeys("33");
             addressPage.BlockEntranceField.Click();
             addressPage.BlockEntranceField.SendKeys("A");
             addressPage.FloorField.Click();
             addressPage.FloorField.SendKeys("2");
             addressPage.ApartmentField.Click();
             addressPage.ApartmentField.SendKeys("4");
             addressPage.InvoiceDetailsField.Click();
             addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
             addressPage.ProceedToCourierChoice.Click();
             Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");

        }
       
          [TestMethod]
          public void InputAddressDetails_TypeStationaryTelephoneNumberWith7Digits()
          {
              MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
              addressPage.FirstNameField.Click();
              addressPage.FirstNameField.SendKeys("Владимир");
              addressPage.SurnameField.Click();
              addressPage.SurnameField.SendKeys("Йончев");
              addressPage.TelephoneField.Click();
              addressPage.TelephoneField.SendKeys("0345555");
              addressPage.CityOrVillageField.Click();
              addressPage.CityOrVillageField.SendKeys("София");
              addressPage.PostCodeField.Click();
              addressPage.PostCodeField.SendKeys("1000");
              addressPage.ProvinceField.Click();
              addressPage.ProvinceField.SendKeys("София");
              addressPage.StreetField.Click();
              addressPage.StreetField.SendKeys("бул. Васил Левски");
              addressPage.StreetNumberField.Click();
              addressPage.StreetNumberField.SendKeys("33");
              addressPage.BlockEntranceField.Click();
              addressPage.BlockEntranceField.SendKeys("A");
              addressPage.FloorField.Click();
              addressPage.FloorField.SendKeys("2");
              addressPage.ApartmentField.Click();
              addressPage.ApartmentField.SendKeys("4");
              addressPage.InvoiceDetailsField.Click();
              addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
              addressPage.ProceedToCourierChoice.Click();
              Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");

          }
        
        [TestMethod]
        public void InputAddressDetails_LeaveTelephoneNumberEmpty()
        {
            MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
            addressPage.FirstNameField.Click();
            addressPage.FirstNameField.SendKeys("Владимир");
            addressPage.SurnameField.Click();
            addressPage.SurnameField.SendKeys("Йончев");
            addressPage.CityOrVillageField.Click();
            addressPage.CityOrVillageField.SendKeys("София");
            addressPage.PostCodeField.Click();
            addressPage.PostCodeField.SendKeys("1000");
            addressPage.ProvinceField.Click();
            addressPage.ProvinceField.SendKeys("София");
            addressPage.StreetField.Click();
            addressPage.StreetField.SendKeys("бул. Васил Левски");
            addressPage.StreetNumberField.Click();
            addressPage.StreetNumberField.SendKeys("33");
            addressPage.BlockEntranceField.Click();
            addressPage.BlockEntranceField.SendKeys("A");
            addressPage.FloorField.Click();
            addressPage.FloorField.SendKeys("2");
            addressPage.ApartmentField.Click();
            addressPage.ApartmentField.SendKeys("4");
            addressPage.InvoiceDetailsField.Click();
            addressPage.InvoiceDetailsField.SendKeys("Арбилис ООД");
            addressPage.ProceedToCourierChoice.Click();
            Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");

        }
        
        [TestMethod]
        public void InputAddressDetails_TypeOver255CharsInIvoiceDetailsField()
        {
            MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
            addressPage.FirstNameField.Click();
            addressPage.FirstNameField.SendKeys("Владимир");
            addressPage.SurnameField.Click();
            addressPage.SurnameField.SendKeys("Йончев");
            addressPage.TelephoneField.Click();
            addressPage.TelephoneField.SendKeys("0878878576");
            addressPage.CityOrVillageField.Click();
            addressPage.CityOrVillageField.SendKeys("София");
            addressPage.PostCodeField.Click();
            addressPage.PostCodeField.SendKeys("1000");
            addressPage.ProvinceField.Click();
            addressPage.ProvinceField.SendKeys("София");
            addressPage.StreetField.Click();
            addressPage.StreetField.SendKeys("бул. Васил Левски");
            addressPage.StreetNumberField.Click();
            addressPage.StreetNumberField.SendKeys("33");
            addressPage.BlockEntranceField.Click();
            addressPage.BlockEntranceField.SendKeys("A");
            addressPage.FloorField.Click();
            addressPage.FloorField.SendKeys("2");
            addressPage.ApartmentField.Click();
            addressPage.ApartmentField.SendKeys("4");
            addressPage.InvoiceDetailsField.Click();
            addressPage.InvoiceDetailsField.SendKeys("ВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВладимирееВлади");
            addressPage.ProceedToCourierChoice.Click();
            Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");

        }
        
        [TestMethod]
        public void InputAddressDetails_TypeSpecialCharsInIvoiceDetailsField()
        {
            MyCart_Addrespage addressPage = new MyCart_Addrespage(driverChrome);
            addressPage.FirstNameField.Click();
            addressPage.FirstNameField.SendKeys("Владимир");
            addressPage.SurnameField.Click();
            addressPage.SurnameField.SendKeys("Йончев");
            addressPage.TelephoneField.Click();
            addressPage.TelephoneField.SendKeys("0878878576");
            addressPage.CityOrVillageField.Click();
            addressPage.CityOrVillageField.SendKeys("София");
            addressPage.PostCodeField.Click();
            addressPage.PostCodeField.SendKeys("1000");
            addressPage.ProvinceField.Click();
            addressPage.ProvinceField.SendKeys("София");
            addressPage.StreetField.Click();
            addressPage.StreetField.SendKeys("бул. Васил Левски");
            addressPage.StreetNumberField.Click();
            addressPage.StreetNumberField.SendKeys("33");
            addressPage.BlockEntranceField.Click();
            addressPage.BlockEntranceField.SendKeys("A");
            addressPage.FloorField.Click();
            addressPage.FloorField.SendKeys("2");
            addressPage.ApartmentField.Click();
            addressPage.ApartmentField.SendKeys("4");
            addressPage.InvoiceDetailsField.Click();
            addressPage.InvoiceDetailsField.SendKeys("\"№$%%€*@ Арбилис");
            addressPage.ProceedToCourierChoice.Click();
            Assert.IsTrue(addressPage.SuccesfullyWentOnTheCourierPage.Displayed, "You were not redirected to courier page");

        }

    }
}
