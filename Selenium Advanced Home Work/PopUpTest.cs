using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SeleniumAdvanced
{
    [TestFixture]
    public class PopUpTest
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void TestInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .Location));
            _driver.Navigate().GoToUrl("https://www.toolsqa.com/automation-practice-switch-windows/");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void OpenNewTab()
        {
            //*[@id="cookie_action_close_header"]
            var popButton = _driver.FindElement(By.XPath(@"//*[@id='cookie_action_close_header']"));
            popButton.Click();

            var tabButton = _driver.FindElement(By.XPath(@"//*[@id='content']/div[1]/div[2]/div/div/div/div/p[5]/button"));
            tabButton.Click();

            string newTabName = _driver.WindowHandles.Last();
            var newTab = _driver.SwitchTo().Window(newTabName);

            Assert.That(_driver.Title, Does.Contain("QA Automation Tools Tutorial"));
            newTab.Close();
            Assert.IsTrue(_driver.WindowHandles.Count == 1);
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
