using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages
{
    public class DashboardPage
    {
        //public string Title => "Title";
        public IWebElement AdminButton => _driver.FindElement(By.XPath("//span[normalize-space()='Admin']"));
        public IWebElement UserDropDownName => _driver.FindElement(By.XPath("//p[@class='oxd-userdropdown-name']"));

        readonly private IWebDriver _driver;
        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
