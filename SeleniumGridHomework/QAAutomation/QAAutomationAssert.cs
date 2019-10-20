using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace POMHomework.QAAutomation
{
    [TestFixture]
   public class QAAutomationAssert
    {
        private IWebDriver _driver;
        private SUMainPage _sUMainPage;
        private QACursPage _qACursPage;

        [SetUp]
        public void CalssInit()
        {
            ChromeOptions options = new ChromeOptions();

            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";

            _driver = new RemoteWebDriver(new Uri("http://192.168.1.103:10608/wd/hub"), options
                .ToCapabilities(), TimeSpan.FromSeconds(50));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
            
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
