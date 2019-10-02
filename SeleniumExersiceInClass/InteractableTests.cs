using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Homework
{
    [TestFixture]
    class InteractableTests
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;
        private RegistrationUser _user;

        [SetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();

            _user = UserFactory.CreateValidUser();
        }

        [Test]
        public void ResizeBox()
        {
            _driver.Url = "https://demoqa.com/resizable/";

            var box = _driver.FindElement(By.Id("resizable"));
            double expectedWidth = box.Size.Width + 84;
            double expectedHeight = box.Size.Height + 84;

            var resize = _driver.FindElement(By.XPath("//*[@id='resizable']/div[3]"));

            var builder = new Actions(_driver);
            builder.DragAndDropToOffset(resize, 100, 100).Perform();

            double actualWidth = box.Size.Width;
            double actualHeight = box.Size.Height;

            Assert.AreEqual(expectedWidth, actualWidth, 2);
            Assert.AreEqual(expectedHeight, actualHeight, 2);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
