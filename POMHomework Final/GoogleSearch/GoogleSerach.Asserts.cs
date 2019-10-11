using NUnit.Framework;

namespace POMHomework.GoogleSearch
{
    public partial class GoogleSerach
    {
        public void FoundResult(string foundResult)
        {
            Assert.AreEqual("Selenium - Web Browser Automation", foundResult);
        }
    }
}
