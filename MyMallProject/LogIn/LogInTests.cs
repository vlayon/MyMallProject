using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;

namespace MyMallProject
{
    [TestClass]
    public class LogInTests
    {
        public IWebDriver driverChrome = new ChromeDriver();

        [TestInitialize]
        public void TestInitialize()
        {
            //LogIn in to my account
            driverChrome.Url = "http://sports.mymall.bg/login.php?action=login";

            driverChrome.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");
            Console.InputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");

           
        }

        [TestCleanup]
        public void TestCLeanup()
        {
            driverChrome.Quit();
        
        }

          [TestMethod]
          public void LoginWithvalidCredentials()
          {
              IWebElement emailForLogIn = driverChrome.FindElement(By.Id("login_email"));
              emailForLogIn.SendKeys("vhidd3n@gmail.com");
              IWebElement passForLogIn = driverChrome.FindElement(By.Id("header_login_pass"));
              passForLogIn.SendKeys("testPass");
              IWebElement logInButton = driverChrome.FindElement(By.Id("LoginButton"));
              logInButton.Click();
              IWebElement firstName = driverChrome.FindElement(By.Id("account_firstname"));
              Assert.AreEqual("Владимир", firstName.GetAttribute("value"));
          }
        
          [TestMethod]
          public void LoginWithFakeEmail()
          {
              IWebElement emailForLogIn = driverChrome.FindElement(By.Id("login_email"));
              emailForLogIn.SendKeys("vhidd8n@gmail.com");
              IWebElement passForLogIn = driverChrome.FindElement(By.Id("header_login_pass"));
              passForLogIn.SendKeys("testPass");
              IWebElement logInButton = driverChrome.FindElement(By.Id("LoginButton"));
              logInButton.Click();
              IWebElement wrongEmailMessage= driverChrome.FindElement(By.XPath("//*[contains(text(),'Въведени некоректно E-mail или парола.')]"));
               bool errorMessageIsPresent = wrongEmailMessage.Displayed;
               Assert.AreEqual("True", errorMessageIsPresent.ToString());
              
          }
        
         [TestMethod]
         public void LoginWithCorrectEmailAndWrongPassword()
         {
             IWebElement emailForLogIn = driverChrome.FindElement(By.Id("login_email"));
             emailForLogIn.SendKeys("vhidd3n@gmail.com");
             IWebElement passForLogIn = driverChrome.FindElement(By.Id("header_login_pass"));
             passForLogIn.SendKeys("testP1ss");
             IWebElement logInButton = driverChrome.FindElement(By.Id("LoginButton"));
             logInButton.Click();
             IWebElement wrongEmailMessage = driverChrome.FindElement(By.XPath("//*[contains(text(),'Въведени некоректно E-mail или парола.')]"));
             bool errorMessageIsPresent = wrongEmailMessage.Displayed;
             Assert.AreEqual("True", errorMessageIsPresent.ToString());
        
         }
         [TestMethod]
         public void LoginWithCorrectEmailAndEmptyPassword()
         {
             IWebElement emailForLogIn = driverChrome.FindElement(By.Id("login_email"));
             emailForLogIn.SendKeys("vhidd3n@gmail.com");
             IWebElement logInButton = driverChrome.FindElement(By.Id("LoginButton"));
             logInButton.Click();
             IWebElement emptyPasswordMessage = driverChrome.FindElement(By.XPath("//*[contains(text(),'Моля, въведете поне 3 символа.')]"));
             bool errorMessageEmptyPasswordIsPresent = emptyPasswordMessage.Displayed;
             Assert.AreEqual("True", errorMessageEmptyPasswordIsPresent.ToString());
        
         }

          [TestMethod]
          public void ForgotPasswordAndTypeYourRealEmailForRecovering()
          {
              driverChrome.Navigate().GoToUrl("http://sports.mymall.bg/login.php?action=reset_password");
              IWebElement emailField = driverChrome.FindElement(By.Id("email"));
              emailField.SendKeys("vhidd3n@gmail.com");
              IWebElement sendEmailButton = driverChrome.FindElement(By.Id("ForgotPassModalSubmitButton"));
              sendEmailButton.Click();
              IWebElement successfulRecoveryMessage = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Успешно направена заявка.' )]"));
              bool emailSuccessfulSentMessageIsPresent = successfulRecoveryMessage.Displayed;
              Assert.AreEqual("True", emailSuccessfulSentMessageIsPresent.ToString());
          }

          [TestMethod]
          public void ForgotPasswordAndTypeEmptyEmailForRecovering()
          {
              driverChrome.Navigate().GoToUrl("http://sports.mymall.bg/login.php?action=reset_password");
              IWebElement sendEmailButton = driverChrome.FindElement(By.Id("ForgotPassModalSubmitButton"));
              sendEmailButton.Click();
              IWebElement unSuccessfulRecoveryMessage = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Моля въведи e-mail' )]"));
              bool emailUnsuccessfulSentMessageIsPresent= unSuccessfulRecoveryMessage.Displayed;
              Assert.AreEqual("True", emailUnsuccessfulSentMessageIsPresent.ToString());
          }

         [TestMethod]
          public void ForgotPasswordAndTypeWrongEmailForRecovering()
          {
              driverChrome.Navigate().GoToUrl("http://sports.mymall.bg/login.php?action=reset_password");
              IWebElement emailField = driverChrome.FindElement(By.Id("email"));
              emailField.SendKeys("vhidd8n@gmail.com");
              IWebElement sendEmailButton = driverChrome.FindElement(By.Id("ForgotPassModalSubmitButton"));
              sendEmailButton.Click();
              IWebElement unSuccessfulSentEmailMessage = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Няма потребител с такъв e-mail.' )]"));
              bool worngEmailMessageIsPresent = unSuccessfulSentEmailMessage.Displayed;
              Assert.AreEqual("True", worngEmailMessageIsPresent.ToString());
          }

        [TestMethod]
          public void ForgotPasswordAndTypeInvalidEmailForRecovering()
          {
              driverChrome.Navigate().GoToUrl("http://sports.mymall.bg/login.php?action=reset_password");
              IWebElement emailField = driverChrome.FindElement(By.Id("email"));
              emailField.SendKeys("12345");
              IWebElement sendEmailButton = driverChrome.FindElement(By.Id("ForgotPassModalSubmitButton"));
              sendEmailButton.Click();
              IWebElement invalidEmailMessage = driverChrome.FindElement(By.XPath("//*[contains(text(), 'Невалиден e-mail' )]"));
              bool isInvalidEmail = invalidEmailMessage.Displayed;
              Assert.AreEqual("True", isInvalidEmail.ToString());
          }

    }
}
