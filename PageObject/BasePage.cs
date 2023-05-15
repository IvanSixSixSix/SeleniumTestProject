using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace PageObject
{
    public class BasePage
    {

        protected static IWebDriver _webdriver;

        private readonly string login;
        private readonly string password;

        public BasePage(IWebDriver webdriver)
        {
            _webdriver = webdriver;

            var jsonFilePath = "appconfig.json";
            var jsonContent = File.ReadAllText(jsonFilePath);
            //JObject config = JObject.Parse(jsonContent);
            JObject config = JObject.Parse(jsonContent);
            

            login = (string?)config["login"];
            password = (string?)config["password"];
        }
        private IWebElement userNameField => _webdriver.FindElement(By.XPath("//input[@name = 'user-name']"));
        private IWebElement userPassField => _webdriver.FindElement(By.XPath("//input[@name = 'password']"));
        private IWebElement butoonLogin => _webdriver.FindElement(By.XPath("//input[@name='login-button']"));
        private void InputName() => userNameField.SendKeys(login);
        private void InputPass() => userPassField.SendKeys(password);
        public void Login()
        {
            InputName();
            InputPass();
            butoonLogin.Click();
            Thread.Sleep(10000);
        }


    }
}