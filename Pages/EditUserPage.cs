using OpenQA.Selenium;

namespace FinalProject.Pages
{
    public class EditUserPage
    {
        public IWebElement UserRoleDropdown => _driver.FindElement(By.XPath("//div[contains(text(),'Admin')]"));
        //public IWebElement UserNameTextBox => _driver.FindElement(By.XPath("//input[@autocomplete='off']"));
        public IWebElement SaveButton => _driver.FindElement(By.XPath("//button[normalize-space()='Save']"));

        public IWebElement UserDropdown => _driver.FindElement(By.XPath("//li[@class='oxd-userdropdown']"));
        public IWebElement UserDropdownLogoutButton => _driver.FindElement(By.XPath("//a[normalize-space()='Logout']"));

        //public IWebElement UserRoleDropdownAdminSelection => _driver.FindElement(By.XPath("//span[contains(text(),'Admin')]"));
        //public IWebElement StatusDropdownEnabledSelection => _driver.FindElement(By.XPath("//span[normalize-space()='Enabled']"));
        

        readonly private IWebDriver _driver;
        public EditUserPage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
