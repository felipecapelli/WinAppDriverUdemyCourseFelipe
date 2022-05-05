using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWithoutRunningAppDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            var appiumLocalService = new AppiumServiceBuilder().UsingPort(4723).WithLogFile(new FileInfo(@"C:\Users\felip\source\repos\RunNotePad\TestingLog.txt")).Build(); //using file log eh opcional aqui
            appiumLocalService.Start();
            AppiumOptions ao = new AppiumOptions();
            ao.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            WindowsDriver<WindowsElement> session = new WindowsDriver<WindowsElement>(appiumLocalService, ao);

            session.Quit();
        }
    }
}
