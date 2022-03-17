using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PRACT17KON
{
    [TestFixture]
    public class HeaderTest
    {
        IWebDriver webDriver = new ChromeDriver();
        [TestCase]
        public void MainTitle()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            Assert.AreEqual("Портал государственных услуг Российской Федерации", webDriver.Title);
            webDriver.Close();
        }
        [TestCase]
        public void NameButton()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            IWebElement input = webDriver.FindElement(By.XPath("html/body/esia-root/div/esia-idp/div/div[1]/form/div[4]/button"));
            Assert.AreEqual("Войти", input.Text);
            webDriver.Close();
        }
        [TestCase]
        public void IsLogAndPass()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            IWebElement button = webDriver.FindElement(By.XPath("html/body/esia-root/div/esia-idp/div/div[1]/form/div[4]/button"));
            button.Click();
            IWebElement str = webDriver.FindElement(By.XPath("/html/body/esia-root/div/esia-idp/div/div[1]/form/div[2]/esia-input-password/div/div"));
            Assert.IsTrue(str.Displayed == true);
            webDriver.Close();
        }
        [TestCase]
        public void IsLinkChanged()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            IWebElement button = webDriver.FindElement(By.XPath("/html/body/esia-root/div/esia-idp/div/div[1]/esia-header/header/a"));
            button.Click();
            Assert.AreEqual(webDriver.Url, "http://gosuslugi.ru/");
            webDriver.Close();
        }
        [TestCase]
        public void IsEnabledInput()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            IWebElement input_text = webDriver.FindElement(By.XPath("/html/body/esia-root/div/esia-idp/div/div[1]/form/div[1]/esia-input/input"));
            input_text.Click();
            Assert.IsTrue(input_text.Enabled == true);
            webDriver.Close();
        }
        [TestCase]
        public void IsEnabledPassword()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            IWebElement input_text = webDriver.FindElement(By.XPath("/html/body/esia-root/div/esia-idp/div/div[1]/form/div[2]/esia-input-password/div/input"));
            input_text.Click();
            Assert.IsTrue(input_text.Enabled == true);
            webDriver.Close();
        }
        [TestCase]
        public void CanWriteLogin()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            IWebElement input_text = webDriver.FindElement(By.XPath("/html/body/esia-root/div/esia-idp/div/div[1]/form/div[1]/esia-input/input"));
            input_text.SendKeys("Cпецоперация");
            Assert.AreNotEqual(input_text.Text, "Война");
            webDriver.Close();
        }
        [TestCase]
        public void CanWritePassword()
        {
            webDriver.Url = "https://esia.gosuslugi.ru/login/";
            IWebElement input_text = webDriver.FindElement(By.XPath("/html/body/esia-root/div/esia-idp/div/div[1]/form/div[2]/esia-input-password/div/input"));
            input_text.SendKeys("Россия демократичная страна");
            Assert.AreNotEqual(input_text.Text, "Да");
            webDriver.Close();
        }
    }
}
