using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BDD_Casekaro.Utilities;

namespace BDD_Casekaro.Hooks
{
    [Binding]
    public sealed class AllHooks
    {
        public static IWebDriver? driver;
        public static ExtentReports extent;
        static ExtentSparkReporter sparkReporter;
        public static ExtentTest test;


        [BeforeFeature]
        public static void InitializeBrowser()
        {
            //ReadConfigFile.ReadConfigSettings();
            ReadConfigFile.ReadConfigSettings();
            string currDir = Directory.GetParent(@"../../../").FullName;

            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/Reports/extent-report"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            extent.AttachReporter(sparkReporter);


            if (ReadConfigFile.properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (ReadConfigFile.properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }

            driver.Url = ReadConfigFile.properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }
        [BeforeScenario]
        public static void CreateLogFile()
        {
            string? curDir = Directory.GetParent(@"../../../").FullName;
            string? fileName = curDir + "/Logs/log_" +
                DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(fileName, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
        public static void NavigateBack()
        {
            driver.Navigate().GoToUrl(ReadConfigFile.properties["baseUrl"]);
            Log.CloseAndFlush();
        }
        [AfterFeature]
        public static void CloseBrowser()
        {
            driver?.Close();
            extent.Flush();
        }
    }
}