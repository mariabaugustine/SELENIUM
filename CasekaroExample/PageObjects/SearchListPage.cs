using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasekaroExample.PageObjects
{
    internal class SearchListPage
    {
        IWebDriver driver;

        public SearchListPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//li[@class='list-view-item'][position()=1]")]
        private IWebElement product { get; set; }
        public SelectedProduct  ClickFirstItem()
        {
          product.Click();
            return new SelectedProduct(driver);
        }
    }
}
