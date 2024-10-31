using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages
{
    public class UserInfoPage
    {
        public IWebElement FirstNameBox => _driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
        public IWebElement LastNameBox => _driver.FindElement(By.XPath("//input[@placeholder='Last Name']"));
        public IWebElement SaveButton1 => _driver.FindElement(By.XPath("(//button[@type='submit'][normalize-space()='Save'])[1]"));

        readonly private IWebDriver _driver;
        public UserInfoPage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
