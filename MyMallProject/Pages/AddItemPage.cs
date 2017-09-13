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
    class AddItemPage
    {
        public AddItemPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "variation[1]")]
        private IWebElement dropDown;
        public SelectElement getSelectSizeOptions()
        {
            return new SelectElement(dropDown);
        }


        [FindsBy(How = How.Id, Using = "qty_")]
        private IWebElement quantityDropDown;
        public SelectElement getSelectQuantityOptions()
        {
            return new SelectElement(quantityDropDown);
        }

        [FindsBy(How= How.Id, Using = "effect")]
        public IWebElement AddToBasket { get; set; }

        

    }
}
