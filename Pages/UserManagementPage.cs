using OpenQA.Selenium;

namespace FinalProject.Pages
{
    public class UserManagementPage
    {
        public IWebElement UserSearchBox => _driver.FindElement(By.XPath("//input[@class='oxd-input oxd-input--focus']"));
        public IWebElement AddButton => _driver.FindElement(By.XPath("//button[normalize-space()='Add']"));


        readonly private IWebDriver _driver;
        public UserManagementPage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
