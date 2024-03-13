using BDD_Casekaro.Hooks;
using BDD_Casekaro.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace BDD_Casekaro.StepDefinitions
{
    [Binding]
    public class SelectingAndAddingMobileCoverToAddtoCartStepDefinitions:CoreCodes
    {
        IWebDriver driver = AllHooks.driver;
        [When(@"User click on search button")]
        public void WhenUserClickOnSearchButton()
        {
            AllHooks.test = AllHooks.extent.CreateTest("Add mobile cover to AddToCart");
            IWebElement searchButton = driver.FindElement(By.XPath("//*[@id=\"shopify-section-header\"]/div/header/div/div[2]/div/button[1]"));
            searchButton.Click();
        }

        [When(@"User Type'([^']*)' and press enter")]
        public void WhenUserTypeAndPressEnter(string searchText)
        {
            IWebElement input = driver.FindElement(By.XPath("(//input[@type='search'])[position()=1]"));
            input.SendKeys(searchText);
            input.SendKeys(Keys.Enter);
        }

        [Then(@"SearcList page is loaded with url contains '([^']*)'")]
        public void ThenSearcListPageIsLoadedWithUrlContains(string searchText)
        {
            try
            {
                TakeScreenShot(driver);
                Assert.That(driver.Url.Contains("apple"));
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                AllHooks.test.AddScreenCaptureFromBase64String(ss);
            }
            catch(AssertionException ex)
            {
                LogTestResult("Title Test", "Title Test Failed", ex.Message);
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                AllHooks.test.AddScreenCaptureFromBase64String(ss);
                AllHooks.test.Info("Title Test Failed");
            }
        }
    }
}
