using OpenQA.Selenium;

namespace FinalProject.Pages
{
    public class SaveSystemUserPage
    {
        public IWebElement UserRoleDropdown => _driver.FindElement(By.XPath("//div[@class='oxd-grid-2 orangehrm-full-width-grid']//div[1]//div[1]//div[2]//div[1]//div[1]//div[1]"));
        
        public IWebElement StatusDropdown => _driver.FindElement(By.XPath("//div[3]//div[1]//div[2]//div[1]//div[1]//div[1]"));
        
        public IWebElement EmployeeNameSearchBox => _driver.FindElement(By.XPath("//input[@placeholder='Type for hints...']"));

        public IWebElement UserNameTextBox => _driver.FindElement(By.XPath("//div[@class='oxd-form-row']//div[@class='oxd-grid-2 orangehrm-full-width-grid']//div[@class='oxd-grid-item oxd-grid-item--gutters']//div[@class='oxd-input-group oxd-input-field-bottom-space']//div//input[@class='oxd-input oxd-input--active']"));

        public IWebElement PasswordTextBox => _driver.FindElement(By.XPath("//div[@class='oxd-grid-item oxd-grid-item--gutters user-password-cell']//div[@class='oxd-input-group oxd-input-field-bottom-space']//div//input[@type='password']"));
        public IWebElement ConfirmPasswordTextBox => _driver.FindElement(By.XPath("//div[@class='oxd-grid-item oxd-grid-item--gutters']//div[@class='oxd-input-group oxd-input-field-bottom-space']//div//input[@type='password']"));

        public IWebElement SaveButton => _driver.FindElement(By.XPath("//button[normalize-space()='Save']"));

        public IWebElement UserDropdown => _driver.FindElement(By.XPath("//li[@class='oxd-userdropdown']"));
        public IWebElement UserDropdownLogoutButton => _driver.FindElement(By.XPath("//a[normalize-space()='Logout']"));

        //public IWebElement UserRoleDropdownAdminSelection => _driver.FindElement(By.XPath("//span[contains(text(),'Admin')]"));
        //public IWebElement StatusDropdownEnabledSelection => _driver.FindElement(By.XPath("//span[normalize-space()='Enabled']"));
        

        readonly private IWebDriver _driver;
        public SaveSystemUserPage(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
