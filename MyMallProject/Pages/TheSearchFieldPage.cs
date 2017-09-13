using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMallProject.Pages
{
    class TheSearchFieldPage
    {
        public TheSearchFieldPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);


        }

        [FindsBy(How = How.Id, Using = "search_query")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How=How.Id, Using = "search_submit")]
        public IWebElement GoSearchButton { get; set; }
    }
}
