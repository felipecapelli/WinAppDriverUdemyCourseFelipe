using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunNotePad
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsDriver<WindowsElement> notePadSession;
            AppiumOptions desiredCapabilities = new AppiumOptions();
            desiredCapabilities
                .AddAdditionalCapability("app", @"C:\Windows\System32\notepad.exe");
            notePadSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), desiredCapabilities);
            if (notePadSession == null)
            {
                Console.WriteLine("App not started.");
                return;
            }

            Console.WriteLine($"Application title: {notePadSession.Title}");
            notePadSession.Manage().Window.Maximize();

            var screenShot = notePadSession.GetScreenshot();
            screenShot.SaveAsFile($".\\Screenshot{DateTime.Now.ToString("ddMMyyyyhhmmss")}.png",
                                    OpenQA.Selenium.ScreenshotImageFormat.Png);

            notePadSession.Quit();
        }
    }
}
