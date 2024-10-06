using OpenQA.Selenium;

namespace FinalProject.Pages
{
    public class HomePage
    {
        public IWebElement UserNameTextBox => _driver.FindElement(By.Id("username"));
        public IWebElement PasswordTextBox => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(By.Id("login"));


        readonly private IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void UserLogin(string user_name, string password)
        {
            UserNameTextBox.SendKeys(user_name);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
        }
    }
}
