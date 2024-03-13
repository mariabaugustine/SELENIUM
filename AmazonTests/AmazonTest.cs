using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace AmazonTests
{
    public class AmazonTest:CoreCodes
    {
        [Test]
        public void SearchProduct()
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fwait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            fwait.Message = "Element not found";
            IWebElement search = fwait.Until(d => d.FindElement(By.XPath("//input[@id='twotabsearchtextbox']")));
            search.SendKeys("laptop");
            search.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }
    }
}