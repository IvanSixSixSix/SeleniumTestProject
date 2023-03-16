using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace PageObject
{
    public class BasePage
    {
        protected static IWebDriver _webdriver;
        public BasePage(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }
        private IWebElement userNameField => _webdriver.FindElement(By.XPath("//input[@name = 'user-name']"));
        private IWebElement userPassField => _webdriver.FindElement(By.XPath("//input[@name = 'password']"));
        private IWebElement butoonLogin => _webdriver.FindElement(By.XPath("//input[@name='login-button']"));
        private void InputName() => userNameField.SendKeys("performance_glitch_user");
        private void InputPass() => userPassField.SendKeys("secret_sauce");
        public void Login()
        {
            InputName();
            InputPass();
            butoonLogin.Click();
            Thread.Sleep(10000);
        }


    }
}