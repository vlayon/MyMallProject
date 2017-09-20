using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using MyMallProject.Pages;

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
            LogInPage logInPage = new LogInPage(driverChrome);
            logInPage.EmailForLogIn.SendKeys("vhidd3n@gmail.com");
            logInPage.PassForLogIn.SendKeys("testPass");
            logInPage.LogInButton.Click();
            Assert.AreEqual("Владимир", logInPage.FirstName.GetAttribute("value"));
          }
        
          [TestMethod]
          public void LoginWithFakeEmail()
          {
            LogInPage logInPage = new LogInPage(driverChrome);
            logInPage.EmailForLogIn.SendKeys("vhidd8n@gmail.com");
            logInPage.PassForLogIn.SendKeys("testPass");
            logInPage.LogInButton.Click();
            bool errorMessageIsPresent = logInPage.WrongEmailMessage.Displayed;
            Assert.IsTrue(errorMessageIsPresent);
              
          }
        
         [TestMethod]
         public void LoginWithCorrectEmailAndWrongPassword()
         {
            LogInPage logInPage = new LogInPage(driverChrome);
            logInPage.EmailForLogIn.SendKeys("vhidd3n@gmail.com");
            logInPage.PassForLogIn.SendKeys("testP1ss");
            logInPage.LogInButton.Click();
            bool errorMessageIsPresent = logInPage.WrongEmailMessage.Displayed;
            Assert.IsTrue(errorMessageIsPresent);
        
         }
         [TestMethod]
         public void LoginWithCorrectEmailAndEmptyPassword()
         {
            LogInPage logInPage = new LogInPage(driverChrome);
            logInPage.EmailForLogIn.SendKeys("vhidd3n@gmail.com");
            logInPage.LogInButton.Click();
            bool errorMessageEmptyPasswordIsPresent = logInPage.EmptyPasswordMessage.Displayed;
            Assert.IsTrue(errorMessageEmptyPasswordIsPresent);
        
         }

          [TestMethod]
          public void ForgotPasswordAndTypeYourRealEmailForRecovering()
          {
              driverChrome.Navigate().GoToUrl("http://sports.mymall.bg/login.php?action=reset_password");
              ForgotPasswordPage forgotPass = new ForgotPasswordPage(driverChrome);
              forgotPass.EmailField.SendKeys("vhidd3n@gmail.com");
              forgotPass.SendEmailButton.Click();
              bool emailSuccessfulSentMessageIsPresent = forgotPass.SuccessfulRecoveryMessage.Displayed;
              Assert.IsTrue(emailSuccessfulSentMessageIsPresent);
          }

          [TestMethod]
          public void ForgotPasswordAndTypeEmptyEmailForRecovering()
          {
              driverChrome.Navigate().GoToUrl("http://sports.mymall.bg/login.php?action=reset_password");
              ForgotPasswordPage forgotPass = new ForgotPasswordPage(driverChrome);
              forgotPass.SendEmailButton.Click();
              bool emailUnsuccessfulSentMessageIsPresent= forgotPass.UnSuccessfulRecoveryMessage.Displayed;
              Assert.IsTrue(emailUnsuccessfulSentMessageIsPresent);
          }

         [TestMethod]
          public void ForgotPasswordAndTypeWrongEmailForRecovering()
          {
              driverChrome.Navigate().GoToUrl("http://sports.mymall.bg/login.php?action=reset_password");
              ForgotPasswordPage forgotPass = new ForgotPasswordPage(driverChrome);
              forgotPass.EmailField.SendKeys("vhidd8n@gmail.com");
              forgotPass.SendEmailButton.Click();
              
              bool wrongEmailMessageIsPresent = forgotPass.UserWithThisEmailDoesntExist.Displayed;
              Assert.IsTrue(wrongEmailMessageIsPresent);
          }

        [TestMethod]
          public void ForgotPasswordAndTypeInvalidEmailForRecovering()
          {
              driverChrome.Navigate().GoToUrl("http://sports.mymall.bg/login.php?action=reset_password");
              ForgotPasswordPage forgotPass = new ForgotPasswordPage(driverChrome);
              forgotPass.EmailField.SendKeys("12345");
              forgotPass.SendEmailButton.Click();
              bool isInvalidEmail = forgotPass.InvalidEmailMessage.Displayed;
              Assert.IsTrue(isInvalidEmail);
          }

    }
}
