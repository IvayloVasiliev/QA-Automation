using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumAdvancedHomework
{
    [TestFixture]
    public class RegistrationNegativeTests
    {
        private ChromeDriver _driver;

        [SetUp]
        public void TestInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .Location));
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);           
        }

        [Test]
        public void EmptyPhoneBox()
        { 
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            //*[@id="email_create"]
            var userNameInput = _driver.FindElement(By.Id(@"email_create"));
            userNameInput.SendKeys("ivailo19@abv.bg");

            //*[@id="SubmitCreate"]/span
            var createAccountButton = _driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]/span"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[0].Click();

            var firstName = _driver.FindElement(By.Id(@"customer_firstname"));
            Type(firstName, "Joro");

            var lastName = _driver.FindElement(By.Id(@"customer_lastname"));
            Type(lastName, "Doev");

            var passWord = _driver.FindElement(By.Id(@"passwd"));
            Type(passWord,"Fifi123");

            var dateDD = _driver.FindElement(By.Id(@"days"));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id(@"months"));
            SelectElement month = new SelectElement(monthDD);
            month.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id(@"years"));
            SelectElement year = new SelectElement(yearDD);
            year.SelectByValue("2016");

            var realfirstName = _driver.FindElement(By.Id(@"firstname"));
            Type(realfirstName, "Joro");

            var reallastName = _driver.FindElement(By.Id(@"lastname"));
            Type(reallastName, "Doev");

            var adress = _driver.FindElement(By.Id(@"address1"));
            Type(adress, "Vitoshka");

            var city = _driver.FindElement(By.Id(@"city"));
            Type(city, "Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            Type(postcode, "85001");

            //var phone = _driver.FindElement(By.Id("phone_mobile"));
            //Type(phone, "08887654321");

            var alias = _driver.FindElement(By.Id(@"alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li")); 
            Assert.AreEqual("You must register at least one phone number.", errorMassage.Text);

        }

        [Test]
        public void EmptyLastNameBox()
        {
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            //*[@id="email_create"]
            var userNameInput = _driver.FindElement(By.Id(@"email_create"));
            userNameInput.SendKeys("ivailo19@abv.bg");

            //*[@id="SubmitCreate"]/span
            var createAccountButton = _driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]/span"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[0].Click();

            var firstName = _driver.FindElement(By.Id(@"customer_firstname"));
            Type(firstName, "Joro");

            var passWord = _driver.FindElement(By.Id(@"passwd"));
            Type(passWord, "Fifi123");

            var dateDD = _driver.FindElement(By.Id(@"days"));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id(@"months"));
            SelectElement month = new SelectElement(monthDD);
            month.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id(@"years"));
            SelectElement year = new SelectElement(yearDD);
            year.SelectByValue("2016");

            var realfirstName = _driver.FindElement(By.Id(@"firstname"));
            Type(realfirstName, "Joro");

            var reallastName = _driver.FindElement(By.Id(@"lastname"));
            Type(reallastName, "Doev");

            var adress = _driver.FindElement(By.Id(@"address1"));
            Type(adress, "Vitoshka");

            var city = _driver.FindElement(By.Id(@"city"));
            Type(city, "Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            Type(postcode, "85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            Type(phone, "08887654321");

            var alias = _driver.FindElement(By.Id(@"alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
            Assert.AreEqual("lastname is required.", errorMassage.Text);

        }

        [Test]
        public void EmptyFirstNameBox()
        {
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            //*[@id="email_create"]
            var userNameInput = _driver.FindElement(By.Id(@"email_create"));
            userNameInput.SendKeys("ivailo19@abv.bg");

            //*[@id="SubmitCreate"]/span
            var createAccountButton = _driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]/span"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[0].Click();

            var lastName = _driver.FindElement(By.Id(@"customer_lastname"));
            Type(lastName, "Doev");

            var passWord = _driver.FindElement(By.Id(@"passwd"));
            Type(passWord, "Fifi123");

            var dateDD = _driver.FindElement(By.Id(@"days"));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id(@"months"));
            SelectElement month = new SelectElement(monthDD);
            month.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id(@"years"));
            SelectElement year = new SelectElement(yearDD);
            year.SelectByValue("2016");

            var realfirstName = _driver.FindElement(By.Id(@"firstname"));
            Type(realfirstName, "Joro");

            var reallastName = _driver.FindElement(By.Id(@"lastname"));
            Type(reallastName, "Doev");

            var adress = _driver.FindElement(By.Id(@"address1"));
            Type(adress, "Vitoshka");

            var city = _driver.FindElement(By.Id(@"city"));
            Type(city, "Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            Type(postcode, "85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            Type(phone, "08887654321");

            var alias = _driver.FindElement(By.Id(@"alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
            Assert.AreEqual("firstname is required.", errorMassage.Text);

        }

        [Test]
        public void EmptyEmailBox()
        {
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            //*[@id="email_create"]
            var userNameInput = _driver.FindElement(By.Id(@"email_create"));
            userNameInput.SendKeys("ivailo20@abv.bg");

            //*[@id="SubmitCreate"]/span
            var createAccountButton = _driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]/span"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[0].Click();

            var firstName = _driver.FindElement(By.Id(@"customer_firstname"));
            Type(firstName, "Joro");

            var lastName = _driver.FindElement(By.Id(@"customer_lastname"));
            Type(lastName, "Doev");

            var email = _driver.FindElement(By.Id(@"email"));
            Type(email, "");

            var passWord = _driver.FindElement(By.Id(@"passwd"));
            Type(passWord, "Fifi123");

            var dateDD = _driver.FindElement(By.Id(@"days"));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id(@"months"));
            SelectElement month = new SelectElement(monthDD);
            month.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id(@"years"));
            SelectElement year = new SelectElement(yearDD);
            year.SelectByValue("2016");

            var realfirstName = _driver.FindElement(By.Id(@"firstname"));
            Type(realfirstName, "Joro");

            var reallastName = _driver.FindElement(By.Id(@"lastname"));
            Type(reallastName, "Doev");

            var adress = _driver.FindElement(By.Id(@"address1"));
            Type(adress, "Vitoshka");

            var city = _driver.FindElement(By.Id(@"city"));
            Type(city, "Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            Type(postcode, "85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            Type(phone, "08887654321");

            var alias = _driver.FindElement(By.Id(@"alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
            Assert.AreEqual("email is required.", errorMassage.Text);

        }

        [Test]
        public void EmptyPasswordBox()
        {
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            //*[@id="email_create"]
            var userNameInput = _driver.FindElement(By.Id(@"email_create"));
            userNameInput.SendKeys("ivailo19@abv.bg");

            //*[@id="SubmitCreate"]/span
            var createAccountButton = _driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]/span"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[0].Click();

            var firstName = _driver.FindElement(By.Id(@"customer_firstname"));
            Type(firstName, "Joro");

            var lastName = _driver.FindElement(By.Id(@"customer_lastname"));
            Type(lastName, "Doev");

            var dateDD = _driver.FindElement(By.Id(@"days"));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id(@"months"));
            SelectElement month = new SelectElement(monthDD);
            month.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id(@"years"));
            SelectElement year = new SelectElement(yearDD);
            year.SelectByValue("2016");

            var realfirstName = _driver.FindElement(By.Id(@"firstname"));
            Type(realfirstName, "Joro");

            var reallastName = _driver.FindElement(By.Id(@"lastname"));
            Type(reallastName, "Doev");

            var adress = _driver.FindElement(By.Id(@"address1"));
            Type(adress, "Vitoshka");

            var city = _driver.FindElement(By.Id(@"city"));
            Type(city, "Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            Type(postcode, "85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            Type(phone, "08887654321");

            var alias = _driver.FindElement(By.Id(@"alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
            Assert.AreEqual("passwd is required.", errorMassage.Text);

        }
        [Test]
        public void EmptyAddressBox()
        {
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            //*[@id="email_create"]
            var userNameInput = _driver.FindElement(By.Id(@"email_create"));
            userNameInput.SendKeys("ivailo19@abv.bg");

            //*[@id="SubmitCreate"]/span
            var createAccountButton = _driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]/span"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[0].Click();

            var firstName = _driver.FindElement(By.Id(@"customer_firstname"));
            Type(firstName, "Joro");

            var lastName = _driver.FindElement(By.Id(@"customer_lastname"));
            Type(lastName, "Doev");

            var passWord = _driver.FindElement(By.Id(@"passwd"));
            Type(passWord, "Fifi123");

            var dateDD = _driver.FindElement(By.Id(@"days"));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id(@"months"));
            SelectElement month = new SelectElement(monthDD);
            month.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id(@"years"));
            SelectElement year = new SelectElement(yearDD);
            year.SelectByValue("2016");

            var realfirstName = _driver.FindElement(By.Id(@"firstname"));
            Type(realfirstName, "Joro");

            var reallastName = _driver.FindElement(By.Id(@"lastname"));
            Type(reallastName, "Doev");
       
            var city = _driver.FindElement(By.Id(@"city"));
            Type(city, "Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            Type(postcode, "85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            Type(phone, "08887654321");

            var alias = _driver.FindElement(By.Id(@"alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
            Assert.AreEqual("address1 is required.", errorMassage.Text);

        }
        [Test]
        public void EmptyCityBox()
        {
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            //*[@id="email_create"]
            var userNameInput = _driver.FindElement(By.Id(@"email_create"));
            userNameInput.SendKeys("ivailo19@abv.bg");

            //*[@id="SubmitCreate"]/span
            var createAccountButton = _driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]/span"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[0].Click();

            var firstName = _driver.FindElement(By.Id(@"customer_firstname"));
            Type(firstName, "Joro");

            var lastName = _driver.FindElement(By.Id(@"customer_lastname"));
            Type(lastName, "Doev");

            var passWord = _driver.FindElement(By.Id(@"passwd"));
            Type(passWord, "Fifi123");

            var dateDD = _driver.FindElement(By.Id(@"days"));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id(@"months"));
            SelectElement month = new SelectElement(monthDD);
            month.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id(@"years"));
            SelectElement year = new SelectElement(yearDD);
            year.SelectByValue("2016");

            var realfirstName = _driver.FindElement(By.Id(@"firstname"));
            Type(realfirstName, "Joro");

            var reallastName = _driver.FindElement(By.Id(@"lastname"));
            Type(reallastName, "Doev");

            var adress = _driver.FindElement(By.Id(@"address1"));
            Type(adress, "Vitoshka");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            Type(postcode, "85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            Type(phone, "08887654321");

            var alias = _driver.FindElement(By.Id(@"alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
            Assert.AreEqual("city is required.", errorMassage.Text);

        }
        [Test]
        public void InvalidZipCode()
        {
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            //*[@id="email_create"]
            var userNameInput = _driver.FindElement(By.Id(@"email_create"));
            userNameInput.SendKeys("ivailo19@abv.bg");

            //*[@id="SubmitCreate"]/span
            var createAccountButton = _driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]/span"));
            createAccountButton.Click();

            var radioButtons = _driver.FindElements(By.XPath("//div[@class='radio']//input"));
            radioButtons[0].Click();

            var firstName = _driver.FindElement(By.Id(@"customer_firstname"));
            Type(firstName, "Joro");

            var lastName = _driver.FindElement(By.Id(@"customer_lastname"));
            Type(lastName, "Doev");

            var passWord = _driver.FindElement(By.Id(@"passwd"));
            Type(passWord, "Fifi123");

            var dateDD = _driver.FindElement(By.Id(@"days"));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id(@"months"));
            SelectElement month = new SelectElement(monthDD);
            month.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id(@"years"));
            SelectElement year = new SelectElement(yearDD);
            year.SelectByValue("2016");

            var realfirstName = _driver.FindElement(By.Id(@"firstname"));
            Type(realfirstName, "Joro");

            var reallastName = _driver.FindElement(By.Id(@"lastname"));
            Type(reallastName, "Doev");

            var adress = _driver.FindElement(By.Id(@"address1"));
            Type(adress, "Vitoshka");

            var city = _driver.FindElement(By.Id(@"city"));
            Type(city, "Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            Type(postcode, "0101");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            Type(phone, "08887654321");

            var alias = _driver.FindElement(By.Id(@"alias"));
            Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            var errorMassage = _driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", errorMassage.Text);

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}