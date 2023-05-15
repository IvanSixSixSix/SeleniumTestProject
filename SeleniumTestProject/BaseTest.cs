using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json.Linq;
using System.IO;

namespace SeleniumTestProject
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            var jsonFilePath = "appconfig.json";
            var jsonContent = File.ReadAllText(jsonFilePath);
            JObject config = JObject.Parse(jsonContent);
            var connectionString = (string)config["connectionString"];

            driver.Navigate().GoToUrl(connectionString);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}