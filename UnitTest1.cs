using FinalProject.Helpers;
using FinalProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace FinalProject
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;
        private SiteHelpers _helpers;


        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _helpers = new SiteHelpers(_driver);
        }
        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [TestMethod]
        public void LoginTest()
        {
            LoginPage login_page = new LoginPage(_driver);
            UserManagementPage home_page = new UserManagementPage(_driver);
            DashboardPage dashboard_page = new DashboardPage(_driver);

            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => login_page.UsernameTextBox.Displayed);

            Assert.IsTrue(login_page.UsernameTextBox.Displayed);

            login_page.UserLogin("Admin", "admin123");

            //wait.Until(d => home_page.UserDropdownName.Displayed);
            //Assert.IsTrue(home_page.UserDropdownName.Text.ToLower().Contains("manda user"));
        }

        [TestMethod]
        //[DataRow("Admin", "admin123")]
        //public void LoginTest(string user_name, string password)
        public void RandomTest()
        {
            LoginPage login_page = new LoginPage(_driver);
            UserManagementPage home_page = new UserManagementPage(_driver);

            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => login_page.UsernameTextBox.Displayed);

            Assert.IsTrue(login_page.UsernameTextBox.Displayed);

            //_helpers.LoadWebsite();
            //login_page.UsernameTextBox.ScrollAndClickButtonByJS(_driver);
            //Actions act = new Actions(_driver);
            //act.Pause(TimeSpan.FromSeconds(10));

            //Assert.IsTrue(login_page.TitleText.Text.ToLower().Contains("Login"));

            login_page.UserLogin("Admin", "admin123");

            //Actions act = new Actions(_driver);
            //act.Pause(TimeSpan.FromSeconds(10));

            //wait.Until(d => home_page.UserDropdownName.Displayed);

            //Assert.IsTrue(home_page.UserDropdownName.Displayed);

            //Assert.IsTrue(home_page.UserDropdownName.Text.ToLower().Contains("test user"));
        }



        [TestMethod]
        public void SearchAndEditUserTest()
        {
            LoginPage login_page = new LoginPage(_driver);
            DashboardPage dashboard_page = new DashboardPage(_driver);
            UserManagementPage usermanagement_page = new UserManagementPage(_driver);

            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => login_page.UsernameTextBox.Displayed);

            Assert.IsTrue(login_page.UsernameTextBox.Displayed);

            login_page.UserLogin("Admin", "admin123");

            wait.Until(d => dashboard_page.AdminButton.Displayed);
            dashboard_page.AdminButton.Click();

            wait.Until(d => usermanagement_page.UserSearchBox.Displayed);
            usermanagement_page.UserSearchBox.SendKeys("");



            Assert.IsTrue(dashboard_page.AdminButton.Displayed);
        }

        [TestMethod]
        public void AddUserTest()
        {
            LoginPage login_page = new LoginPage(_driver);
            DashboardPage dashboard_page = new DashboardPage(_driver);
            UserManagementPage usermanagement_page = new UserManagementPage(_driver);
            SaveSystemUserPage savesystemuser_page = new SaveSystemUserPage(_driver);

            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => login_page.UsernameTextBox.Displayed);

            Assert.IsTrue(login_page.UsernameTextBox.Displayed);

            login_page.UserLogin("Admin", "admin123");

            wait.Until(d => dashboard_page.AdminButton.Displayed);
            dashboard_page.AdminButton.Click();


            wait.Until(d => usermanagement_page.AddButton.Displayed);
            usermanagement_page.AddButton.Click();

            wait.Until(d => savesystemuser_page.UserRoleDropdown.Displayed);
            savesystemuser_page.UserRoleDropdown.Click();
            savesystemuser_page.UserRoleDropdownAdminSelection.Click();

            savesystemuser_page.StatusDropdown.Click();
            savesystemuser_page.StatusDropdownEnabledSelection.Click();

            savesystemuser_page.EmployeeNameSearchBox.SendKeys("a");
            savesystemuser_page.EmployeeNameSearchBoxEmployeeSelection.Click();

            savesystemuser_page.UserNameTextBox.SendKeys("TestAdmin");

            savesystemuser_page.PasswordTextBox.SendKeys("admin123");
            savesystemuser_page.ConfirmPasswordTextBox.SendKeys("admin123");

            //savesystemuser_page.SaveButton.Click();

            savesystemuser_page.UserDropdown.Click();
            savesystemuser_page.UserDropdownLogoutButton.Click();

            login_page.UserLogin("TestAdmin", "admin123");

            //verify user is logged in

            //Assert.IsTrue(dashboard_page.AdminButton.Displayed);
        }


    }
}
