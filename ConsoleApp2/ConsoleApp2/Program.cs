using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );

            IWebDriver driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://kinobox.in.ua/");

            IWebElement LoginButton = driver.FindElement(By.LinkText("Увійти"));
            LoginButton.Click();

            IWebElement login = driver.FindElement(By.Name("username"));
            login.SendKeys("skrypt10");

            IWebElement pass = driver.FindElement(By.Name("password"));
            pass.SendKeys("skrypt10");

            IWebElement auth = driver.FindElement(By.Name("auth"));
            auth.Click();

            IWebElement points = driver.FindElement(By.ClassName("points_value"));

            string point = points.Text;
            Console.WriteLine(point);

            IWebElement logout = driver.FindElement(By.ClassName("logout_profile"));
            logout.Click();

            driver.Close();
        }
    }
}
