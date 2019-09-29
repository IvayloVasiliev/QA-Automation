﻿using NUnit.Framework;
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
    public class InteractionTestsDroppable
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void TestInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .Location));
            _driver.Navigate().GoToUrl("https://demoqa.com/droppable/");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void DroppableLocation()
        {
            var draggable = _driver.FindElement(By.Id("draggable"));
            var target = _driver.FindElement(By.Id("droppable"));

            var dragX = draggable.Location.X;
            var dragY = draggable.Location.Y;


            Actions builder = new Actions(_driver);
            builder
                .MoveToElement(draggable)
                .ClickAndHold()
                .MoveByOffset(145, 25)
                .Release()
                .Perform();

            Assert.AreEqual(632, draggable.Location.X, "X coordinates are wrong");
            Assert.AreEqual(354, draggable.Location.Y, "Y coordinates are wrong");

        }

        [Test]
        public void DropBoxText()
        {
            var draggable = _driver.FindElement(By.Id("draggable"));
            var target = _driver.FindElement(By.Id("droppable"));

            var dragX = draggable.Location.X;
            var dragY = draggable.Location.Y;

            Actions builder = new Actions(_driver);
            builder
                .MoveToElement(draggable)
                .ClickAndHold()
                .MoveByOffset(145, 25)
                .Release()
                .Perform();

            var boxText = _driver.FindElement(By.XPath(@"//*[@id=""droppable""]/p"));
            Assert.AreEqual("Dropped!", boxText.Text);
        }

        [Test]
        public void BoxColour()
        {
            var draggable = _driver.FindElement(By.Id("draggable"));
            var target = _driver.FindElement(By.Id("droppable"));

            var dragX = draggable.Location.X;
            var dragY = draggable.Location.Y;

            var targetColor = target.GetCssValue("color");

            Actions builder = new Actions(_driver);
            builder
                .MoveToElement(draggable)
                .ClickAndHold()
                .MoveByOffset(145, 25)
                .Release()
                .Perform();

           var afterColor = target.GetCssValue("color");

            Assert.AreNotEqual(targetColor, afterColor);

        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}