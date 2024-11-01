using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages
{
    public class ApplyLeavePage
    {
        public IWebElement LeaveTypeDropdown => _driver.FindElement(By.XPath("//div[@class='oxd-select-text-input']"));
        public IWebElement FromDropdown => _driver.FindElement(By.XPath("(//input[@placeholder='yyyy-dd-mm'])[1]"));
        public IWebElement ToDropdown => _driver.FindElement(By.XPath("(//input[@placeholder='yyyy-dd-mm'])[2]"));
        public IWebElement TodayButton => _driver.FindElement(By.XPath("//div[@class='oxd-date-input-link --today']"));
        public IWebElement ApplyButton => _driver.FindElement(By.XPath("//button[normalize-space()='Apply']"));
        public IWebElement CommentsTextbox => _driver.FindElement(By.XPath("(//textarea)[1]"));


        readonly private IWebDriver _driver;
        public ApplyLeavePage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
