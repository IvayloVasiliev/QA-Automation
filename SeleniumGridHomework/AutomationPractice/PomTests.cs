using Homework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Homework
{
    [TestFixture]
    public class PomTests
    {
        private LoginPage _loginPage;
        private RegistrationPage _regPage;
        private RegistrationUser _user;
        private IWebDriver _driver;

        [SetUp]
        public void CalssInit()
        {
            ChromeOptions options = new ChromeOptions();

            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";

            _driver = new RemoteWebDriver(new Uri("http://192.168.1.103:10608/wd/hub"), options
                .ToCapabilities(), TimeSpan.FromSeconds(50));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _loginPage = new LoginPage(_driver);
            _regPage = new RegistrationPage(_driver);

            _user = UserFactory.CreateValidUser();

        }

        [Test]
        public void AutomationpracticeRegistrationPageOpen()
        {
          
            _regPage.Navigate(_loginPage);

            var registrationAssertion = _driver.FindElement(By.XPath(@"//*[@id='account-creation_form']/div[1]/h3"));
            
            Assert.AreEqual("YOUR PERSONAL INFORMATION", registrationAssertion.Text);

        }

        [Test]
        public void FillRegistrationFormWithOutPhoneNumber()
        {
            _user.Phone = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);
            
            _regPage.AssertErrorMessage("You must register at least one phone number.");

        }

        [Test]
        public void FillRegistrationFormWithOutLastName()
        {
            _user.LastName = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);


            _regPage.AssertErrorMessage("lastname is required.");

        }

        [Test]
        public void FillRegistrationFormWithOutFirstName()
        {
            _user.FirstName = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);


            _regPage.AssertErrorMessage("firstname is required.");

        }

        [Test]
        public void FillRegistrationFormWithOutPassword()
        {
            _user.Password = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("passwd is required.");
        }

        [Test]
        public void FillRegistrationFormWithOutAdress()
        {
            _user.Address = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("address1 is required.");
        }

        [Test]
        public void FillRegistrationFormWithOutCity()
        {
            _user.City = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("city is required.");
        }

        [Test]
        public void FillRegistrationFormWithInvalidPostCode()
        {
            _user.PostCode = "0000";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("The Zip/Postal code you've entered is invalid. It must follow this format: 00000");
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
