using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMallProject.Pages
{
    class MyCart_Addrespage
    {
        public MyCart_Addrespage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "FormField_4")]
        public IWebElement FirstNameField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_5")]
        public IWebElement SurnameField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_7")]
        public IWebElement TelephoneField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_10")]
        public IWebElement CityOrVillageField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_13")]
        public IWebElement PostCodeField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_12")]
        public IWebElement ProvinceField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_8")]
        public IWebElement StreetField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_92")]
        public IWebElement StreetNumberField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_93")]
        public IWebElement BlockField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_94")]
        public IWebElement BlockEntranceField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_95")]
        public IWebElement FloorField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_96")]
        public IWebElement ApartmentField { get; set; }

        [FindsBy(How = How.Id, Using = "FormField_9")]
        public IWebElement InvoiceDetailsField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='NewBillingAddress']/div[2]/div/input")]
        public IWebElement ProceedToCourierChoice { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Избери куриер')]")]
        public IWebElement SuccesfullyWentOnTheCourierPage { get; set; }

        [FindsBy(How=How.Id, Using = "FormField_5-error")]
        public IWebElement SurnameIsMissingMessage {get; set;}
        
        [FindsBy(How = How.Id, Using = "FormField_4-erro")]
        public IWebElement pleaseEnterNameMessage { get; set; }
        
        
    }
}
