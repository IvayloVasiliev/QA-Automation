using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Homework
{
    class TableTests
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;
        private RegistrationUser _user;
        private List<IWebElement> _rows;

        [OneTimeSetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();

            _user = UserFactory.CreateValidUser();
        }

        [Test]
        public void Table()
        {
            _driver.Url = "https://www.w3schools.com/html/html_tables.asp";

            var table = _driver.FindElement(By.Id("customers"));
            var innerhtml = table.GetAttribute("innerHTML");
            var headers = table
                .FindElements(By.TagName("tr"))
                .Where(r => r.GetAttribute("innerHTML")
                .Contains("</th>"))
                .Where(r => r.Text.Contains("tttt"))
                .ToList();

            _rows = table
                .FindElements(By.TagName("tr"))
                .Where(r => r.GetAttribute("innerHTML")
                .Contains("</td>"))
                .ToList();

            var cell = _rows[3].FindElement(By.TagName("td"));

            var text = cell.Text;
        }

        private IWebElement GetCell(int rowIndex)
        {
            return _rows[rowIndex].FindElement(By.TagName("td"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
