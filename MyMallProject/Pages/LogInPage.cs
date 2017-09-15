using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMallProject.Pages
{
    class LogInPage
    {

        public LogInPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "login_email")]
        public IWebElement EmailForLogIn { get; set; }

        [FindsBy(How = How.Id, Using = "header_login_pass")]
        public IWebElement PassForLogIn { get; set; }

        [FindsBy(How = How.Id, Using = "LoginButton")]
        public IWebElement LogInButton { get; set; }

        [FindsBy(How = How.Id, Using = "account_firstname")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Въведени некоректно E-mail или парола.')]")]
        public IWebElement WrongEmailMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Моля, въведете поне 3 символа.')]")]
        public IWebElement EmptyPasswordMessage { get; set; }
     
    }
}
