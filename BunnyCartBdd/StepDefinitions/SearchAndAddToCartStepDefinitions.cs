using BunnyCartBdd.Hooks;
using BunnyCartBdd.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCartBdd.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartStepDefinitions:CoreCodes
    {
        IWebDriver driver=AllHooks.driver;
        [Given(@"User will be on the home page")]
        public void GivenUserWillBeOnTheHomePage()
        {
            driver.Url = "https://www.bunnycart.com/";
            driver.Manage().Window.Maximize();
        }
        [When(@"User will type the '([^']*)' in the input box")]
        public void WhenUserWillTypeTheInTheInputBox(string searchtext)
        {
            IWebElement? searchbox = driver.FindElement(By.Id("search"));
            searchbox.SendKeys(searchtext);
            searchbox.SendKeys(Keys.Enter);
            Log.Information("Typed input is" + searchtext);
        }

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            TakeScreenSot(driver);
            Log.Information("Screenshot Taken");
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Success");

            }
            catch (AssertionException ex)
            {
                LogTestResult("search test", "Test failed", ex.Message);
            }

        }





    }
}
