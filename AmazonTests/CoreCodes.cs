using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTests
{
    public class CoreCodes
    {
        public IWebDriver driver;
        public Dictionary<string, string> properties;
        public void ReadConfigurationFile()
        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string path = currentDirectory + "/configsettings/config.properties";
            string[] file = File.ReadAllLines(path);
            foreach (string line in file)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0];
                    string value = parts[1];
                    properties[key] = value;
                }


            }

        }
        [OneTimeSetUp]
        public void InitializeWebDriver()
        {
            ReadConfigurationFile();
            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            driver.Url = properties["baseurl"];
            driver.Manage().Window.Maximize();

        }
        [OneTimeTearDown]
        public void CleanupWebDriver()
        {
            driver.Quit();
        }
    }
}
