using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages
{
    public class Dashboard
    {
        public IWebElement AdminButton => _driver.FindElement(By.XPath("//span[normalize-space()='Admin']"));
        public IWebElement InfoButton => _driver.FindElement(By.XPath("//span[normalize-space()='My Info']"));
        public IWebElement UserNameDropDown => _driver.FindElement(By.XPath("//p[@class='oxd-userdropdown-name']"));
        //public IWebElement UserDropdown => _driver.FindElement(By.XPath("//li[@class='oxd-userdropdown']"));
        public IWebElement UserDropdownLogoutButton => _driver.FindElement(By.XPath("//a[normalize-space()='Logout']"));

        readonly private IWebDriver _driver;
        public Dashboard(IWebDriver driver)
        {
            _driver = driver;
        }


        public void Logout()
        {
            UserNameDropDown.Click();
            UserDropdownLogoutButton.Click();
        }
    }
}
