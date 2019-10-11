using OpenQA.Selenium;

namespace POMHomework.QAAutomation
{
    public class SUMainPage : QABasePage
    {

        public SUMainPage(IWebDriver driver) : base(driver)
        {
        }
              
        public IWebElement PushNavBarButton => Driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/a/span"));
        
        public IWebElement PushQAButton => Driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/div/div/div[2]/div[2]/div/div[1]/ul[2]/div[1]/ul/li/a"));

        public void Navigate()
        {
            Navigate("http://www.softuni.bg");
            PushNavBarButton.Click();
            PushQAButton.Click();
        }

    }
}
