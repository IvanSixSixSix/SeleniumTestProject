using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class ShoppingСart : BasePage
    {
        public ShoppingСart(IWebDriver webdriver) : base(webdriver)
        {
        }

        private IWebElement bntContinueShopping =>
            _webdriver.FindElement(By.XPath("//button[@name = 'continue-shopping']"));

        public void GoToOrderListPage()
        {
            bntContinueShopping.Click();
        }
        public IWebElement GetItemInCard(string item)
        {
            return _webdriver.FindElement(By.XPath($"//div[text() = '{item}']"));
        }
    }
}
