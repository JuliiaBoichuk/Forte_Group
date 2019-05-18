using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace task2
{
    [TestFixture]
    public class Class1
    {
        public IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );


            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://automationpractice.com");

            IWebElement LoginButton = driver.FindElement(By.ClassName("login"));
            LoginButton.Click();

            IWebElement login = driver.FindElement(By.Name("email"));
            login.SendKeys("testacount@gmail.com");

            IWebElement pass = driver.FindElement(By.Name("passwd"));
            pass.SendKeys("testacount");
            
            IWebElement auth = driver.FindElement(By.Name("SubmitLogin"));
            auth.Click();
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
       
        [Test]
        public void CheckAccount()
        {
            var Account = driver.FindElement(By.Id("my-account"));
            Account.Click();

            Assert.AreEqual("My account - My Store", driver.Title);
        }

        [Test]
        public void CheckAccountChange()
        {
            IWebElement InformButton = driver.FindElement(By.ClassName("icon-user"));
            InformButton.Click();

            IWebElement name = driver.FindElement(By.Name("firstname"));
            name.Clear();
            name.SendKeys("Julia");

            IWebElement lname = driver.FindElement(By.Name("lastname"));
            lname.Clear();
            lname.SendKeys("Boichuk");

            IWebElement oldPass = driver.FindElement(By.Name("old_passwd"));
            oldPass.SendKeys("testacount");

            IWebElement SaveButton = driver.FindElement(By.Name("submitIdentity"));
            SaveButton.Click();
            
            var User = driver.FindElement(By.ClassName("account"));
            Assert.AreEqual("Julia Boichuk", User.Text);
        }
    }
}
