using OpenQA.Selenium;

namespace FinalProject.Pages
{
    public class ViewSystemUsersPage
    {
        public IWebElement AddButton => _driver.FindElement(By.XPath("//button[normalize-space()='Add']"));
        public IWebElement UserSearchBox => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space']//div//input[@class='oxd-input oxd-input--active']"));
        public IWebElement SearchButton => _driver.FindElement(By.XPath("//button[normalize-space()='Search']"));
        public IWebElement UserNameText(string user_name) => _driver.FindElement(By.XPath($"//div[contains(text(),'{user_name}')]"));
        public IWebElement UserRoleText(string text) => _driver.FindElement(By.XPath($"//div[contains(text(),'{text}')]"));
        public IWebElement DeleteButton => _driver.FindElement(By.XPath("(//button[@type='button'])[7]"));
        public IWebElement ConfirmDeleteButton => _driver.FindElement(By.XPath("//button[normalize-space()='Yes, Delete']"));
        public IWebElement EditButton => _driver.FindElement(By.XPath("(//button[@type='button'])[8]"));
        


        readonly private IWebDriver _driver;
        public ViewSystemUsersPage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
