using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages
{
    public class HelpPage
    {
        public IWebElement AdminUserGuide => _driver.FindElement(By.XPath("//span[normalize-space()='Admin User Guide']"));
        public IWebElement EmployeeUserGuide => _driver.FindElement(By.XPath("//span[normalize-space()='Employee User Guide']"));
        public IWebElement MobileApp => _driver.FindElement(By.XPath("//span[normalize-space()='Mobile App']"));
        public IWebElement AWSGuide => _driver.FindElement(By.XPath("//span[normalize-space()='AWS Guide']"));
        public IWebElement FAQs => _driver.FindElement(By.XPath("//span[normalize-space()='FAQs']"));
        public IWebElement SearchTextbox => _driver.FindElement(By.Id("query"));
        public IWebElement SignInLink => _driver.FindElement(By.ClassName("sign-in"));


        readonly private IWebDriver _driver;
        public HelpPage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
