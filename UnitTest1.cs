using FinalProject.Helpers;
using FinalProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        private ViewSystemUsersPage _view_system_users_page;
        private SaveSystemUserPage _save_system_user_page;

        
        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _helpers = new SiteHelpers(_driver);

            _login_page = new LoginPage(_driver);
            _dashboard_page = new DashboardPage(_driver);
            _view_system_users_page = new ViewSystemUsersPage(_driver);
            _save_system_user_page = new SaveSystemUserPage(_driver);
        }
        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        /*
        [TestMethod]
        public void LoginTest()
        {
            LoginPage login_page = new LoginPage(_driver);
            ViewSystemUsersPage home_page = new ViewSystemUsersPage(_driver);
            DashboardPage dashboard_page = new DashboardPage(_driver);

            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => login_page.UsernameTextBox.Displayed);

            Assert.IsTrue(login_page.UsernameTextBox.Displayed);

            login_page.UserLogin("Admin", "admin123");

            //wait.Until(d => home_page.UserDropdownName.Displayed);
            //Assert.IsTrue(home_page.UserDropdownName.Text.ToLower().Contains("user"));
        }*/

        //finished
        /// <summary>
        /// Test 1
        /// </summary>
        [TestMethod]
        [DataRow("User")]
        public void SearchAndEditUserTest(string user_name)
        {
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            _driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            string user_name2 = "User2";

            //login_page.UsernameTextBox.ScrollAndClickButtonByJS(_driver);
            //Actions act = new Actions(_driver);
            //act.Pause(TimeSpan.FromSeconds(10));
            //Assert.IsTrue(login_page.TitleText.Text.ToLower().Contains("Login"));

            #region login page
            wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.UserLogin("Admin", "admin123");
            #endregion

            #region admin page
            wait.Until(d => _dashboard_page.AdminButton.Displayed);
            _dashboard_page.AdminButton.Click();
            #endregion

            #region view system users page
            wait.Until(d => _view_system_users_page.UserSearchBox.Displayed);
            _view_system_users_page.UserSearchBox.SendKeys(user_name);
            _view_system_users_page.SearchButton.Click();
            wait.Until(d => _view_system_users_page.UserNameText(user_name).Displayed);
            Assert.IsTrue(_view_system_users_page.UserNameText(user_name).Displayed);
            _view_system_users_page.EditButton.Click();
            #endregion

            #region save system user page
            wait.Until(d => _save_system_user_page.UserRoleDropdown.Displayed);
            //_save_system_user_page.UserRoleDropdown.Click();
            //_save_system_user_page.UserRoleDropdownAdminSelection.Click();
            //_save_system_user_page.StatusDropdown.Click();
            //_save_system_user_page.StatusDropdownEnabledSelection.Click();
            _save_system_user_page.UserNameTextBox.SendKeys(user_name2);
            _save_system_user_page.SaveButton.Click();
            #endregion

            #region view system users page
            wait.Until(d => _view_system_users_page.UserSearchBox.Displayed);
            _view_system_users_page.UserSearchBox.SendKeys(user_name2);
            _view_system_users_page.SearchButton.Click();
            wait.Until(d => _view_system_users_page.UserNameText(user_name2).Displayed);
            Assert.IsTrue(_view_system_users_page.UserNameText(user_name2).Displayed);
            _view_system_users_page.DeleteButton.Click();
            #endregion
        }


        //finished
        /// <summary>
        /// Test 2
        /// </summary>
        [TestMethod]
        [DataRow("Andres Stiven Gomez", "Andres Gomez")]
        public void AddUserTest(string employee_name, string user_name_dropdown)
        {
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            _driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            string user_name = "TestUser";
            string user_password = "admin123";

            #region login page
            wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.UserLogin("Admin", "admin123");
            #endregion

            #region admin page
            wait.Until(d => _dashboard_page.AdminButton.Displayed);
            _dashboard_page.AdminButton.Click();
            #endregion

            #region view system users page
            wait.Until(d => _view_system_users_page.AddButton.Displayed);
            _view_system_users_page.AddButton.Click();
            #endregion

            #region save system user page
            wait.Until(d => _save_system_user_page.UserRoleDropdown.Displayed);
            _save_system_user_page.UserRoleDropdown.Click();
            _save_system_user_page.UserRoleDropdownAdminSelection.Click();
            _save_system_user_page.StatusDropdown.Click();
            _save_system_user_page.StatusDropdownEnabledSelection.Click();
            _save_system_user_page.EmployeeNameSearchBox.SendKeys(employee_name);
            _save_system_user_page.EmployeeNameSearchBoxEmployeeSelection(employee_name).Click();
            _save_system_user_page.UserNameTextBox.SendKeys(user_name);
            _save_system_user_page.PasswordTextBox.SendKeys(user_password);
            _save_system_user_page.ConfirmPasswordTextBox.SendKeys(user_password);
            _save_system_user_page.SaveButton.Click();
            //logout
            _save_system_user_page.UserDropdown.Click();
            _save_system_user_page.UserDropdownLogoutButton.Click();
            #endregion

            #region login page
            wait.Until(d => _login_page.UsernameTextBox.Displayed);
            _login_page.UserLogin(user_name, user_password);
            #endregion

            #region dashboard page
            wait.Until(d => _dashboard_page.UserDropDownName.Text);
            //verify user is logged in
            Assert.IsTrue(_dashboard_page.UserDropDownName.Text == user_name_dropdown);
            #endregion
        }



        /// <summary>
        /// Test 3
        /// </summary>
        [TestMethod]
        [DataRow("User")]
        public void ChangeUserNameTest(string user_name)
        {
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            _driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            string employee_name = "Some Employee";

            #region login page
            wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.UserLogin("Admin", "admin123");
            #endregion

            #region admin page
            wait.Until(d => _dashboard_page.AdminButton.Displayed);
            _dashboard_page.AdminButton.Click();
            #endregion

            #region view system users page
            wait.Until(d => _view_system_users_page.UserSearchBox.Displayed);
            _view_system_users_page.UserSearchBox.SendKeys(user_name);
            _view_system_users_page.SearchButton.Click();
            wait.Until(d => _view_system_users_page.UserNameText(user_name).Displayed);
            Assert.IsTrue(_view_system_users_page.UserNameText(user_name).Displayed);
            _view_system_users_page.EditButton.Click();
            #endregion

            //#region save system user page
            //wait.Until(d => _save_system_user_page.UserRoleDropdown.Displayed);
            //_save_system_user_page.UserNameTextBox.SendKeys(user_name2);
            //_save_system_user_page.SaveButton.Click();
            //#endregion
        }


        /// <summary>
        /// Test 4
        /// </summary>
        [TestMethod]
        public void ApplyForLeaveTest()
        {
        }


        /// <summary>
        /// Test 5
        /// </summary>
        [TestMethod]
        public void OpenNewTabTest()
        {
        }


        /// <summary>
        /// Test 6
        /// </summary>
        [TestMethod]
        public void UploadFileTest()
        {
        }


        /// <summary>
        /// Test 7
        /// </summary>
        [TestMethod]
        public void WildCardNegativeTest()
        {
        }
    }
}
