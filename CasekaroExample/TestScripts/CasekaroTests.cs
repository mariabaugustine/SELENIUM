using CasekaroExample.PageObjects;
using CasekaroExample.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasekaroExample.TestScripts
{
    internal class CasekaroTests:CoreCodes
    {
        [Test]
        public void MobileCover()
        {
            List<ExcelData>InputData;
            string? currentDirectory = Directory.GetParent(@"../../../").FullName;
            string? logfilepath = currentDirectory + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")+".txt";
            Log.Logger=new LoggerConfiguration().WriteTo.Console().WriteTo.File(logfilepath,rollingInterval:RollingInterval.Day).CreateLogger();
            HomePage home=new HomePage(driver);
            test = extent.CreateTest("Buying Mobile Cover Test");
            home.SearchBuutonClick();
            Log.Information("Search button clicked");
            test.Info("Search button clicked");
            string? excelFilePath =currentDirectory+ "/TestData/InputData.xlsx";
            string sheetName = "search";
            InputData=ExcelUtilities.ReadExcelData(excelFilePath, sheetName);

            string input=string.Empty;
            foreach (var cdata in InputData)
            {

                Thread.Sleep(3000);
               // var searchlist=home.TypeInput(cdata.Input);
                Thread.Sleep(5000);
               input = cdata.Input;
                
                

            }
            var searchlist = home.TypeInput(input);
            Log.Information("Mobile name entered");
            test.Info("Mobile name entered");
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("apple"));
                Log.Information("Mobile cover page loaded successfully");
                test.Info("Mobile cover page loaded successfully");
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(ss);
            }
            catch(AssertionException ex)
            {
                Log.Error($"Test failed for Product Page. \n Exception: {ex.Message}");
                Log.Information("Mobile cover page loaded failed");
                test.Info("Mobile cover page loaded failed");

            }
            var selectedproduct = searchlist.ClickFirstItem();
            Thread.Sleep(3000);
            
        }
    }
}
