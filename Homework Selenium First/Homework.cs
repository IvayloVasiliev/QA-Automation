using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SeleniunTests
{
    [TestFixture]
    public class Homework
    {
       
        [Test]
        public void GoogleSearch()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.google.com";

            var googleSearchBar = driver.FindElement(By.Name("q"));
            googleSearchBar.SendKeys("Selenium"); 
            googleSearchBar.Submit();

            ////*[@id="rso"]/div[1]/div/div/div/div[1]/a[1]/h3/di      
            driver.FindElement(By.XPath(@"//*[@id=""rso""]/div[1]/div/div/div/div[1]/a[1]/h3/div")).Click();
           
            var foundResult = driver.Title;

            Assert.AreEqual("Selenium - Web Browser Automation", foundResult); 
            driver.Quit();
        }

        [Test]
        public void QAAutomation()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.softuni.bg";

            ////*[@id="header-nav"]/div[1]/ul/li[2]/a/span
            var pushNavBarButton = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/a/span"));
            pushNavBarButton.Click();

            //*[@id="header-nav"]/div[1]/ul/li[2]/div/div/div[2]/div[2]/div/div[1]/ul[2]/div[1]/ul/li/a
            var pushQAButton = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/div/div/div[2]/div[2]/div/div[1]/ul[2]/div[1]/ul/li/a"));
            pushQAButton.Click();

            //  /html/body/div[2]/header/h1
            var foundResult = driver.FindElement(By.XPath(@"/html/body/div[2]/header/h1"));

            Assert.AreEqual(foundResult.Text, "QA Automation - септември 2019");

            driver.Quit();
        }

        [Test]
        public void AutomationPracticeRegistration()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Url = "http://automationpractice.com/index.php";

            //*[@id="header"]/div[2]/div/div/nav/div[1]/a
            var signInButton = driver.FindElement(By.XPath(@"//*[@id=""header""]/div[2]/div/div/nav/div[1]/a"));
            signInButton.Click();

            //*[@id="email_create"]
            var userNameInput = driver.FindElement(By.Id(@"email_create"));
            userNameInput.SendKeys("ivailo13@abv.bg");

            //*[@id="SubmitCreate"]/span
            var submitButton = driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]/span"));
            submitButton.Click();

            //*[@id="email"]          
            var registeredEmail = driver.FindElement(By.Id(@"email"));
           

            Assert.AreEqual(userNameInput.Text, registeredEmail.Text);

            driver.Quit();
        }


    }
}
