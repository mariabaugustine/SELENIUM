using BunnyCartDemo.PageObjects;
using BunnyCartDemo.Utilites;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCartDemo.TestScript
{
    internal class BHPTesting:CoreCodes
    {
        [Test]
        public void Test() 
        {
            List<Product> ProductList;
            BHP bhp = new BHP(driver);
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currDir + "/Logs/log_" +
               DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
           .WriteTo.Console()
           .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
           .CreateLogger();
            string excelfilepath = currDir + "/TestData/InputData.xlsx";
            string sheetname = "product";
            ProductList=ExcelUtilities.ReadExcelData(excelfilepath, sheetname);
            foreach(var data in ProductList) 
            {
                bhp.TypeInput(data.Name);
                
            }
            Assert.That(driver.Url.Contains("water"));
            Thread.Sleep(5000);
            
        }
    }
}
