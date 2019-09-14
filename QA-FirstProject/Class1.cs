using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;

namespace SeleniunTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void LogoSrc()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Manage().Window.Maximize();
            driver.Url = "https://softuni.bg";

            ////*[@id="page-header"]/div/div/div/div[1]/a/img[1]
            var logo = driver.FindElement(By.XPath(@"//*[@id=""page-header""]/div/div/div/div[1]/a/img[1]"));
            var actualImgSrc = logo.GetAttribute("src");

            driver.Quit();

            Assert.AreEqual("https://softuni.bg/content/images/svg-logos/software-university-logo.svg",
                actualImgSrc);
        }

        [Test]
        public void LoginWithInvalidCredential()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Url = "https://softuni.bg";

            ////*[@id="header-nav"]/div[2]/ul/li[2]/span/a
            var loginButton = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[2]/ul/li[2]/span/a"));
            loginButton.Click();

            var userNameInput = driver.FindElement(By.Id(@"username"));
            userNameInput.SendKeys("PeshoVodkata");

            var passwordInput = driver.FindElement(By.Id(@"password"));
            passwordInput.SendKeys("12345678");

            var loginButtonWithCredentials = driver.FindElement(By.XPath(@"/html/body/main/div[2]/div/div[2]/div[1]/form/div[4]/input"));
            loginButtonWithCredentials.Click();

            driver.Quit();
        }

        [Test]
        public void Logos()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Url = "https://softuni.bg";

            ////*[@id="header-nav"]/div[2]/ul/li[2]/span/a
            var loginButton = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[2]/ul/li[2]/span/a"));
            loginButton.Click();
            
            var logos = driver.FindElements(By.XPath(@"/html/body/main/div[2]/div/div[1]/div/div[2]/div"));
            Assert.AreEqual(6, logos.Count);

            driver.Quit();
        }
    }
}
