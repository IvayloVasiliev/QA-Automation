using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Homework
{
    [TestFixture]
    public class AutomationPractice
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
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");
            _user = UserFactory.CreateValidUser();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void FillRegistrationForm()
        {
            _user.FirstName = "";
            
            var emailInput = _driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys("ivailo24@abv.bg");

            var createAccountButton = _driver.FindElement(By.Id("SubmitCreate"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[1].Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys(_user.FirstName);

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys(_user.LastName);

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys(_user.Password);

            var dateDD = _wait.Until(d => d.FindElement(By.Id("days")));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue(_user.Date);

            var monthDD = _driver.FindElement(By.Id("months"));
            SelectElement months = new SelectElement(monthDD);
            months.SelectByValue(_user.Month);

            var yearDD = _driver.FindElement(By.Id("years"));
            SelectElement years = new SelectElement(yearDD);
            years.SelectByValue(_user.Year);

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.Clear();
            realFirstName.SendKeys(_user.FirstName);

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys(_user.LastName);

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys(_user.Address);

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys(_user.City);

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText(_user.State);

            var postcode = _driver.FindElement(By.Id("postcode"));
            postcode.SendKeys(_user.PostCode);

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            phone.SendKeys(_user.Phone);

            var alias = _driver.FindElement(By.Id("alias"));
            alias.Clear();
            alias.SendKeys(_user.Alias);

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
            Assert.AreEqual("firstname is required.", errorMassage.Text);
        }

        [Test]
        public void FillRegistrationForm2()
        {
            _user.LastName = "";

            var emailInput = _driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys("ivailo24@abv.bg");

            var createAccountButton = _driver.FindElement(By.Id("SubmitCreate"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[1].Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys(_user.FirstName);

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys(_user.LastName);

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys(_user.Password);

            var dateDD = _wait.Until(d => d.FindElement(By.Id("days")));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue(_user.Date);

            var monthDD = _driver.FindElement(By.Id("months"));
            SelectElement months = new SelectElement(monthDD);
            months.SelectByValue(_user.Month);

            var yearDD = _driver.FindElement(By.Id("years"));
            SelectElement years = new SelectElement(yearDD);
            years.SelectByValue(_user.Year);

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.Clear();
            realFirstName.SendKeys(_user.FirstName);

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys(_user.LastName);

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys(_user.Address);

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys(_user.City);

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText(_user.State);

            var postcode = _driver.FindElement(By.Id("postcode"));
            postcode.SendKeys(_user.PostCode);

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            phone.SendKeys(_user.Phone);

            var alias = _driver.FindElement(By.Id("alias"));
            alias.Clear();
            alias.SendKeys(_user.Alias);

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
            Assert.AreEqual("lastname is required.", errorMassage.Text);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
