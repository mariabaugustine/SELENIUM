using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCartDemo.PageObjects
{
    internal class BHP
    {
        IWebDriver driver;

        public BHP(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.Id,Using ="search")]
        private IWebElement input {  get; set; }
        [FindsBy(How =How.XPath,Using = "//button//span[text()='Search']")]
        private IWebElement searchButton { get; set; }
        
        public SearchPage TypeInput(string name)
        {
           input.SendKeys(name);
            input.SendKeys(Keys.Enter);
            return new SearchPage(driver);

        }
        
    }
}
