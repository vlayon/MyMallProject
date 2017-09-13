using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMallProject.Pages
{
    class MyCartPage
    {
        public MyCartPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How= How.XPath, Using = "//a[@href='http://sports.mymall.bg/cart.php']/span")]
        public IWebElement SeeTheCartButton { get; set; }

        [FindsBy(How= How.XPath, Using = "//*[@id='CartBreadcrumb']/ul/li/a")]
        public IWebElement ContinueShopping { get; set; }

        [FindsBy(How= How.XPath, Using = "//*[@id='cartForm']/div/div[2]/a")]
        public IWebElement ProceedToCheckOut { get; set; }

        [FindsBy(How = How.ClassName, Using = "successMessage")]
        public IWebElement SuccesfulyChangedQuantity { get; set; }

        [FindsBy(How = How.ClassName, Using = "CartRemoveLink")]
        public IWebElement RemoveItemLink { get; set; }



    }
}
