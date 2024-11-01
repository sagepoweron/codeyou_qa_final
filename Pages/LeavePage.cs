using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Pages
{
    public class LeavePage
    {
        public IWebElement ApplyButton => _driver.FindElement(By.XPath("//a[normalize-space()='Apply']"));
        public IWebElement FromDropdown => _driver.FindElement(By.XPath("(//input[@placeholder='yyyy-dd-mm'])[1]"));
        public IWebElement ToDropdown => _driver.FindElement(By.XPath("(//input[@placeholder='yyyy-dd-mm'])[2]"));
        public IWebElement SearchButton => _driver.FindElement(By.XPath("//button[normalize-space()='Search']"));
        public IWebElement CommentsText(string comments) => _driver.FindElement(By.XPath($"//div[contains(text(),'{comments}')]"));
        public IWebElement ThreeDotsMenu => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-three-dots-vertical']"));
        public IWebElement CancelLeaveButton => _driver.FindElement(By.XPath("//p[normalize-space()='Cancel Leave']"));
        public IWebElement MyLeaveButton => _driver.FindElement(By.XPath("//a[normalize-space()='My Leave']"));

        public IWebElement LeavePendingText => _driver.FindElement(By.XPath("//div[contains(text(),'Pending Approval')]"));
        public IWebElement LeaveCanceledText => _driver.FindElement(By.XPath("//div[contains(text(),'Cancelled')]"));
        public IWebElement NoRecordsFoundText => _driver.FindElement(By.XPath("//span[normalize-space()='No Records Found']"));


        readonly private IWebDriver _driver;
        public LeavePage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
