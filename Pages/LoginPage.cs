using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages
{
    public class LoginPage
    {
        public IWebElement TitleText => _driver.FindElement(By.Name("title"));
        public IWebElement UserNameTextBox => _driver.FindElement(By.Id("username"));
        public IWebElement PasswordTextBox => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(By.Id("login"));


        readonly private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void UserLogin(string user_name, string password)
        {
            UserNameTextBox.SendKeys(user_name);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
        }
    }
}
