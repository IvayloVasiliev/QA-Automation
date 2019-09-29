using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumAdvanced
{
    [TestFixture]
    public class InteractionTestsSelectable
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void TestInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .Location));
            _driver.Navigate().GoToUrl("https://demoqa.com/selectable/");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void SelectBoxNumberSeven()
        {
            var seventhBox = _driver.FindElement(By.XPath(@"//*[@id=""selectable""]/li[7]"));
            seventhBox.Click();

            Assert.AreEqual("Item 7", seventhBox.Text);
        }

        [Test]
        public void SelectBoxNumberSix()
        {

            var sixthBox = _driver.FindElement(By.XPath(@"//*[@id=""selectable""]/li[6]"));
            var boxColour = sixthBox.GetCssValue("color");
            sixthBox.Click();

            var afterBoxcolor = sixthBox.GetCssValue("color");
            Assert.AreNotEqual(boxColour, afterBoxcolor);
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
