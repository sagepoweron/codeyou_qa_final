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
        //public IWebElement TitleText => _driver.FindElement(By.XPath("//h5[normalize-space()='Login']"));
        public IWebElement UsernameTextBox => _driver.FindElement(By.XPath("(//input[@placeholder='Username'])[1]"));
        public IWebElement PasswordTextBox => _driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement LoginButtonByXPath => _driver.FindElement(By.XPath("//button[normalize-space()='Login']"));

        readonly private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void UserLogin(string user_name, string password)
        {
            UsernameTextBox.SendKeys(user_name);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
        }
    }
}
