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
    public class SortToLow : BaseTest
    {
        [Test]
        public void SortOrdersToLow()
        {
            BasePage longinPage = new BasePage(driver);
            OrderListPage orderPage = new OrderListPage(driver);

            longinPage.Login();
            Thread.Sleep(5000);

            orderPage.ToSort("ToLow");
            Thread.Sleep(2000);
            var sortPrice = orderPage.GetSortPrice();
            for (int i = 0; i >= sortPrice.Length - 2; i++)
            {
                Assert.IsTrue(sortPrice[i] >= sortPrice[i + 1], "The items are sorted incorrectly");
            }
        }
    }
}
