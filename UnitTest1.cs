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
        private LoginPage _login_page;
        private DashboardPage _dashboard_page;
        private UserManagementPage _user_management_page;
        private SaveSystemUserPage _save_system_user_page;


        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _helpers = new SiteHelpers(_driver);

            _login_page = new LoginPage(_driver);
            _dashboard_page = new DashboardPage(_driver);
            _user_management_page = new UserManagementPage(_driver);
            _save_system_user_page = new SaveSystemUserPage(_driver);
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


        /// <summary>
        /// Test 1
        /// </summary>
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

        /// <summary>
        /// Test 2
        /// </summary>
        [TestMethod]
        public void AddUserTest()
        {
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => _login_page.UsernameTextBox.Displayed);

            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);

            _login_page.UserLogin("Admin", "admin123");

            wait.Until(d => _dashboard_page.AdminButton.Displayed);
            _dashboard_page.AdminButton.Click();


            wait.Until(d => _user_management_page.AddButton.Displayed);
            _user_management_page.AddButton.Click();

            wait.Until(d => _save_system_user_page.UserRoleDropdown.Displayed);
            _save_system_user_page.UserRoleDropdown.Click();
            _save_system_user_page.UserRoleDropdownAdminSelection.Click();

            _save_system_user_page.StatusDropdown.Click();
            _save_system_user_page.StatusDropdownEnabledSelection.Click();

            _save_system_user_page.EmployeeNameSearchBox.SendKeys("a");
            _save_system_user_page.EmployeeNameSearchBoxEmployeeSelection("aaa aaa aaa").Click();

            _save_system_user_page.UserNameTextBox.SendKeys("TestAdmin");

            _save_system_user_page.PasswordTextBox.SendKeys("admin123");
            _save_system_user_page.ConfirmPasswordTextBox.SendKeys("admin123");

            //savesystemuser_page.SaveButton.Click();

            _save_system_user_page.UserDropdown.Click();
            _save_system_user_page.UserDropdownLogoutButton.Click();

            _login_page.UserLogin("TestAdmin", "admin123");

            //verify user is logged in

            //Assert.IsTrue(dashboard_page.AdminButton.Displayed);
        }



        /// <summary>
        /// Test 3
        /// </summary>
        [TestMethod]
        public void ChangeUserNameTest()
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


        }


        /// <summary>
        /// Test 4
        /// </summary>
        [TestMethod]
        public void ApplyForLeaveTest()
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


        }


        /// <summary>
        /// Test 5
        /// </summary>
        [TestMethod]
        public void OpenNewTabTest()
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


        }


        /// <summary>
        /// Test 6
        /// </summary>
        [TestMethod]
        public void UploadFileTest()
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


        }


        /// <summary>
        /// Test 7
        /// </summary>
        [TestMethod]
        public void WildCardNegativeTest()
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


        }
    }
}
