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
            Console.WriteLine("Авторизация");
            //Thread.Sleep(1000);

            var jacet = orderPage.GetJacet().Text;
            var removeJacet = orderPage.AddJacketOrder();
            Console.WriteLine($"Добовляем товар \"{jacet}\" в корзину");
            Assert.IsTrue(removeJacet.Text == "Remove", "Кнопка \"Add to cart\" не поменялась после нажатия");

            orderPage.GoToShoppingСart();
            Console.WriteLine($"Переходим в корзину");
            Thread.Sleep(1000);

            var bookedJacet = cartPage.GetItemInCard(jacet).Text;
            Assert.IsTrue(jacet == bookedJacet);
            Console.WriteLine($"Проверяем наличие товара \"{bookedJacet}\" в корзине");

            cartPage.GoToOrderListPage();
            Console.WriteLine($"Переходим на страницу с товарами");
            Thread.Sleep(2000);

            var tshirt = orderPage.GetTshirt().Text;
            var removeTshirt = orderPage.AddTShirtOrder();
            Console.WriteLine($"Добовляем товар \"{tshirt}\" в корзину");
            Assert.IsTrue(removeTshirt.Text == "Remove", "Кнопка \"Add to cart\" не поменялась после нажатия");

            Console.WriteLine($"Переходим в корзину");
            orderPage.GoToShoppingСart();
            Thread.Sleep(1000);

            var bookedTshirt  = cartPage.GetItemInCard(tshirt).Text;

            Assert.Multiple(() =>
            {
                Assert.IsTrue(jacet == bookedJacet);
                Assert.IsTrue(tshirt == bookedTshirt);
            });
            Console.WriteLine($"Проверяем наличие товара \"{bookedJacet}\" и \"{bookedTshirt}\" в корзине");
        }
    }
}
