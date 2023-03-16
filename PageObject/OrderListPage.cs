using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class OrderListPage : BasePage
    {
        public OrderListPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        private IWebElement jacet =>
            _webdriver.FindElement(By.XPath("//*[contains(text(), 'Fleece Jacket')]"));
        private IWebElement tshirt =>
            _webdriver.FindElement(By.XPath("//*[contains(text(), ' Bolt T-Shirt')]"));
        private IWebElement btnAddJacketOrder =>
            _webdriver.FindElement(By.XPath("//button[@name='add-to-cart-sauce-labs-fleece-jacket']"));
        private IWebElement btnAddTShirtOrder =>
            _webdriver.FindElement(By.XPath("//button[@name='add-to-cart-sauce-labs-bolt-t-shirt']"));

        private IWebElement btnRmvJacketOrder =>
            _webdriver.FindElement(By.XPath("//button[@name='remove-sauce-labs-fleece-jacket']"));
        private IWebElement btnRmvTShirtOrder =>
            _webdriver.FindElement(By.XPath("//button[@name='remove-sauce-labs-bolt-t-shirt']"));

        private IWebElement shoppingСart =>
            _webdriver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a"));

        private IWebElement btnSort =>
            _webdriver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/div/span/select"));

        private IWebElement btnToHigh =>
            _webdriver.FindElement(By.XPath("//*[@id='header_container']/div[2]/div/span/select/option[3]"));
        private IWebElement btnToLow =>
            _webdriver.FindElement(By.XPath("//*[@id='header_container']/div[2]/div/span/select/option[4]"));

        public IWebElement AddJacketOrder()
        {
            btnAddJacketOrder.Click();
            return btnRmvJacketOrder;
        }

        public IWebElement AddTShirtOrder()
        {
            btnAddTShirtOrder.Click();
            return btnRmvTShirtOrder;
        }

        public IWebElement GetJacet()
        {
            return jacet;
        }

        public IWebElement GetTshirt()
        {
            return tshirt;
        }

        public void GoToShoppingСart()
        {
            shoppingСart.Click();
        }
        public void ToSort(string value)
        {
            btnSort.Click();
            switch (value) 
            {
                case ("ToHigh"):
                    btnToHigh.Click();
                    break;
                case ("ToLow"):
                    btnToLow.Click();
                    break;
                default: throw new Exception("Unavailable values");
            }
        }
        public double[] GetSortPrice()
        {
            var items = _webdriver.FindElements
                   (By.XPath($"//div[@id='inventory_container']//div[@class='inventory_item_price']"));

            var count = items.Count;
            double[] orders = new double[count];
            var i = 0;

            foreach (var j in items)
            {
                string? item = j.Text;
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                var price = Convert.ToDouble(item.Remove(0, 1), formatter);
                orders[i] = price;
                i++;
            }


            //for (int i = 1; i <= count; i++)
            //{
            //    var items = _webdriver.FindElements
            //        (By.XPath($"//div[@id='inventory_container']//div[@class='inventory_item_price']"));
               
            //}
            return orders;
        }
    }
}
