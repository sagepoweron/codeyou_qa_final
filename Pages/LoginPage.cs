using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages
{
    public class LoginPage
    {
        public IWebElement UsernameTextBox => _driver.FindElement(By.XPath("//input[@placeholder='Username']"));
        public IWebElement PasswordTextBox => _driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement LoginButtonByXPath => _driver.FindElement(By.XPath("//button[normalize-space()='Login']"));
        public IWebElement RequiredText => _driver.FindElement(By.XPath("//span[normalize-space()='Required']"));

        readonly private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Login(string user_name, string password)
        {
            UsernameTextBox.SendKeys(user_name);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
        }
    }
}
