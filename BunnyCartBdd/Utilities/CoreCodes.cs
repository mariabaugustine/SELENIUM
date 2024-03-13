﻿using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCartBdd.Utilities
{
    public class CoreCodes
    {
       
        public void TakeScreenSot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot ss= screenshot.GetScreenshot();
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            string filePth = currentDirectory + "/Screenshot/screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                ".png";
            ss.SaveAsFile(filePth);
        }
        public void LogTestResult(string testName,string result,string errrorMessage=null)

        {
            Log.Information(result);
            if(errrorMessage==null)
            {
                Log.Information(testName + "passed");
            }
            else
            {
                Log.Information($"Test failed for {testName}\nException:{errrorMessage}");
            }
        }
    }
}