using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcRunnerAppium
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsDriver<WindowsElement> sessionCalc;
            AppiumOptions appOptions = new AppiumOptions();
            /*Para pegar o codigo da calculadora (UWP software) - para UWP pracisamos pegar o App User Mode ID (Target Field)
                1)Ir em executar, no windows, e inserir esse comando: shell:appsfolder
                2)Encontrar a calculadora e criar um atalho no desktop
                3)Abrir o UI recorder e clicar com o botão direito /  propriedades no atalho da calculadora
                4)Pegar o nome entre aspas da pripriedade name (Text)
            */
            appOptions.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            sessionCalc = new WindowsDriver<WindowsElement>(
                    new Uri("http://127.0.0.1:4723"),
                    appOptions
                );

            //TimeOut
            sessionCalc.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var btnTwo = sessionCalc.FindElementByName("Dois");
            btnTwo.Click();

            var btnPlus = sessionCalc.FindElementByName("Mais");
            btnPlus.Click();

            btnTwo.Click();

            var btnEquals = sessionCalc.FindElementByName("Igual a");
            btnEquals.Click();
            
            //nesse caso pegar o AutomationId
            var txtField = sessionCalc.FindElementByAccessibilityId("CalculatorResults");
            Console.WriteLine($"Valor mostrado pela calculadora: {txtField.Text}");

            if(txtField.Text.EndsWith("4"))
            {
                Console.WriteLine("O resultado está correto");
            }
            else
            {
                Console.WriteLine("O resultado está incorreto");
            }

            // aperta o botão Esc do teclado
            txtField.SendKeys(Keys.Escape); 

            txtField.SendKeys("4");
            txtField.SendKeys("+");
            txtField.SendKeys("16");
            txtField.SendKeys("=");

            Console.WriteLine($"Valor mostrado pela calculadora: {txtField.Text}");

            if (txtField.Text.EndsWith("4"))
            {
                Console.WriteLine("O resultado está correto");
            }
            else
            {
                Console.WriteLine("O resultado está incorreto");
            }

        }
    }
}
