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
    public class InteractionTestsDraggable
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void TestInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .Location));
            _driver.Navigate().GoToUrl("https://demoqa.com/draggable/");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void MovingBoxDiagonaly()
        {
            var dragBox = _driver.FindElement(By.Id("draggable"));
            var expectedWidth = dragBox.Size.Width;
            var expectedHeight = dragBox.Size.Height;

            Actions builder = new Actions(_driver);
            builder
                .MoveToElement(dragBox)
                .ClickAndHold()
                .MoveByOffset(150, 150)
                .Release()
                .Perform();

            var actualWidth = dragBox.Size.Width;
            var actualHeight = dragBox.Size.Height;

            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [Test]
        public void MovingBoxRight()
        {
            var dragBox = _driver.FindElement(By.Id("draggable"));
            var expectedWidth = dragBox.Size.Width;
      
            Actions builder = new Actions(_driver);
            builder
                .MoveToElement(dragBox)
                .ClickAndHold()
                .MoveByOffset(150, 0)
                .Release()
                .Perform();

            var actualWidth = dragBox.Size.Width;
            
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [Test]
        public void MovingBoxDown()
        {
            var dragBox = _driver.FindElement(By.Id("draggable"));
            var expectedHeight = dragBox.Size.Height;

            Actions builder = new Actions(_driver);
            builder
                .MoveToElement(dragBox)
                .ClickAndHold()
                .MoveByOffset(0, 150)
                .Release()
                .Perform();

           var actualHeight = dragBox.Size.Height;

            Assert.AreEqual(expectedHeight, actualHeight);
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
