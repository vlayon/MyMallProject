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
    class ForgotPasswordPage
    {
        public ForgotPasswordPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.Id, Using = "ForgotPassModalSubmitButton")]
        public IWebElement SendEmailButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Успешно направена заявка.' )]")]
        public IWebElement SuccessfulRecoveryMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Моля въведи e-mail' )]")]
        public IWebElement UnSuccessfulRecoveryMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Няма потребител с такъв e-mail.' )]")]
        public IWebElement UserWithThisEmailDoesntExist { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Невалиден e-mail' )]")]
        public IWebElement InvalidEmailMessage { get; set; }
        

    }
}
