using OpenQA.Selenium;
using System;
using System.Threading;

namespace Homework
{
    public class CustomWait
    {
        public IWebElement WaitForElement(IWebDriver driver, TimeSpan timeSpan)
        {
            var startTime = DateTime.Now;
            IWebElement element;

            while (DateTime.Now < startTime.AddSeconds(timeSpan.Seconds))
            {
                try
                {
                    element = driver.FindElement(By.Id("id"));
                    if (element != null)
                    {
                        return element;
                    }
                }
                catch (NoSuchElementException ex)
                {
                    if (DateTime.Now < startTime.AddSeconds(2))
                    {
                        throw;
                    }
                    continue;
                }

                Thread.Sleep(100);
            }

            throw new ArgumentException("UYGU");
        }
    }
}
