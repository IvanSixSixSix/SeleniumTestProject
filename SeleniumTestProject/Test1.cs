using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V108.Debugger;
using PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    
    public class Test1 : BaseTest
    {
        [Test]
        public void FirstTest()
        {
            BasePage longinPage = new BasePage(driver);
            OrderListPage orderPage = new OrderListPage(driver);
            ShoppingСart cartPage = new ShoppingСart(driver);

            longinPage.Login();
            Thread.Sleep(5000);

            var jacet = orderPage.GetJacet().Text;
            var removeJacet = orderPage.AddJacketOrder();
            Assert.IsTrue(removeJacet.Text == "Remove");

            orderPage.GoToShoppingСart();
            Thread.Sleep(2000);

            var bookedJacet = cartPage.GetItemInCard(jacet).Text;

            Assert.IsTrue(jacet == bookedJacet);

            cartPage.GoToOrderListPage();
            Thread.Sleep(2000);

            var tshirt = orderPage.GetTshirt().Text;
            var removeTshirt = orderPage.AddTShirtOrder();
            Assert.IsTrue(removeTshirt.Text == "Remove");

            orderPage.GoToShoppingСart();
            Thread.Sleep(2000);

            var bookedTshirt  = cartPage.GetItemInCard(tshirt).Text;

            Assert.Multiple(() =>
            {
                Assert.IsTrue(jacet == bookedJacet);
                Assert.IsTrue(tshirt == bookedTshirt);
            });
        }
    }
}
