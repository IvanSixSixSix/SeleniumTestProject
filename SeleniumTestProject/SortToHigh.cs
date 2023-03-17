using NUnit.Framework;
using PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public class SortToHigh : BaseTest
    {
        [Test]
        public void SortOrdersToHigh()
        {
            BasePage longinPage = new BasePage(driver);
            OrderListPage orderPage = new OrderListPage(driver);

            longinPage.Login();
            Console.WriteLine("Авторизация");
            Thread.Sleep(2000);

            orderPage.ToSort("ToHigh");
            Console.WriteLine("Отсортировываем товары по убыванию цены");
            Thread.Sleep(2000);
            var sortPrice = orderPage.GetSortPrice();
            for (int i = 0; i <= sortPrice.Length - 2; i++)
            {
                Assert.IsTrue(sortPrice[i] <= sortPrice[i + 1], "Товары отсортированы некорретно");
            }
            Console.WriteLine("Проверяем что каждый товар в списке больше или равен по цене предыдущему");
        }
    }
}
