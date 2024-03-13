using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasekaroExample.PageObjects
{
    internal class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//*[@id=\"shopify-section-header\"]/div/header/div/div[2]/div/button[1]")]
        private IWebElement searchButton {  get; set; }
        [FindsBy(How =How.XPath,Using = "(//input[@type='search'])[position()=1]")]
        private IWebElement InputBox { get; set; }
        public void SearchBuutonClick()
        {
            searchButton.Click();
        }
        public SearchListPage TypeInput(string input)
        {
            InputBox.SendKeys(input);
            Thread.Sleep(1000);
            InputBox.SendKeys(Keys.Enter);
            return new SearchListPage(driver);
        }
    }
}
