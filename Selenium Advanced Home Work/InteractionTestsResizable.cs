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
    public class InteractionTestsResizable
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void TestInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .Location));
            _driver.Navigate().GoToUrl("https://demoqa.com/resizable/");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void ResizeBox()
        {
            var box = _driver.FindElement(By.Id("resizable"));
            double expectedWidth = box.Size.Width + 83;
            double expectedHeight = box.Size.Height + 83;

            var resize = _driver.FindElement(By.XPath("//*[@id='resizable']/div[3]"));

            var builder = new Actions(_driver);
            builder.DragAndDropToOffset(resize, 100, 100).Perform();

            double actualWidth = box.Size.Width;
            double actualHeight = box.Size.Height;

            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [Test]
        public void SmallestBox()
        {
            var box = _driver.FindElement(By.Id("resizable"));
            double expectedWidth = box.Size.Width - 133;
            double expectedHeight = box.Size.Height -133;

            var resize = _driver.FindElement(By.XPath("//*[@id='resizable']/div[3]"));

            var builder = new Actions(_driver);
            builder.DragAndDropToOffset(resize, -140, -140).Perform();

            double actualWidth = box.Size.Width;
            double actualHeight = box.Size.Height;

           Assert.AreEqual(expectedWidth, actualWidth);
           Assert.AreEqual(expectedHeight, actualHeight);
        }
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}