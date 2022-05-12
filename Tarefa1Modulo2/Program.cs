using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefa1Modulo2
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsDriver<WindowsElement> sessionFilmesTV;
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", "Microsoft.ZuneVideo_8wekyb3d8bbwe!Microsoft.ZuneVideo");
            
            //OPTION 1: RUN WINAPPDRIVER MANUALLY
            var serviceAlredyRunning = new Uri("http://127.0.0.1:4723");

            //OPTION 2: RUN WINAPPDRIVER USING THE SERVICE BUILDER - Comment this chunk if not using
            var appiumLocalService = new AppiumServiceBuilder()
                .UsingPort(4723)
                .WithLogFile(new FileInfo(@"C:\Users\felip\source\repos\RunNotePad\TestingLog.txt"))
                .Build();
            appiumLocalService.Start();


            //MUST CHOOSE BETWEEN OPTION 1 OR 2 FOR THE FIRST PARAMETER
            sessionFilmesTV = new WindowsDriver<WindowsElement>(
                appiumLocalService, //serviceAlredyRunning,
                appiumOptions
            );
        }
    }
}
