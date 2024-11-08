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
        public IWebElement SaveButton1 => _driver.FindElement(By.XPath("(//button[@type='submit'][normalize-space()='Save'])[1]"));//index is bad practice
        //button[@type='submit']
        //button[@type='button']

        public IWebElement AddButton => _driver.FindElement(By.XPath("//button[normalize-space()='Add']"));
        public IWebElement FileInput => _driver.FindElement(By.XPath("//input[@type='file']"));
        public IWebElement CommentTextArea => _driver.FindElement(By.XPath("//textarea[@placeholder='Type comment here']"));
        public IWebElement SaveButton3 => _driver.FindElement(By.XPath("(//button[@type='submit'][normalize-space()='Save'])[3]"));
        public IWebElement DateAddedText(string date_text) => _driver.FindElement(By.XPath($"//div[contains(text(),'{date_text}')]"));
        public IWebElement DescriptionText(string description) => _driver.FindElement(By.XPath($"//div[contains(text(),'{description}')]"));
        public IWebElement DeleteBasedOnDescription(string description) => _driver.FindElement(By.XPath($"//div[contains(text(),'{description}')]/../..//i[@class='oxd-icon bi-trash']"));
        public IWebElement ConfirmDeleteButton => _driver.FindElement(By.XPath("//button[normalize-space()='Yes, Delete']"));

        //for wildcard test
        public By AddButtonByXPath => By.XPath("//button[normalize-space()='Yes, Delete']");


        readonly private IWebDriver _driver;
        public UserInfoPage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
