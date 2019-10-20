using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace POMHomework.GoogleSearch
{
    [TestFixture]
    public partial class GoogleSearchTest
    {
        private IWebDriver _driver;
        private GoogleSearchPage _googleSearchPage;
        private GoogleResultsPage _googleResultsPage;

        [SetUp]
        public void SelSearcInit()
        {
            ChromeOptions options = new ChromeOptions();

            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";

            _driver = new RemoteWebDriver(new Uri("http://192.168.1.103:10608/wd/hub"), options
                .ToCapabilities(), TimeSpan.FromSeconds(50));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);

            _googleSearchPage = new GoogleSearchPage(_driver);
            _googleResultsPage = new GoogleResultsPage(_driver);

        }
                     
        [Test]
        public void SeleniumSearch()
        {
            _googleResultsPage.Navigate(_googleSearchPage);
            var foundResult = _driver.Title;
                       
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
