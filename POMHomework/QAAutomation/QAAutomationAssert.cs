using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace POMHomework.QAAutomation
{
    [TestFixture]
   public class QAAutomationAssert
    {
        private ChromeDriver _driver;
        private SUMainPage _sUMainPage;
        private QACursPage _qACursPage;

        [SetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            
            _sUMainPage = new SUMainPage(_driver);
            _qACursPage = new QACursPage(_driver);
        }

        [Test]
        public void QAAutomationCurs()
        {
            _sUMainPage.Navigate();
           
            Assert.AreEqual(_qACursPage.Result(), "QA Automation - септември 2019");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
