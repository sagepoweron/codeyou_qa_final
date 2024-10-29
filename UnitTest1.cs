using FinalProject.Helpers;
using FinalProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace FinalProject
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;
        private SiteHelpers _helpers;
        private Actions _actions;
        private WebDriverWait _wait;
        private LoginPage _login_page;
        private DashboardPage _dashboard_page;
        private ViewSystemUsersPage _view_system_users_page;
        private SaveSystemUserPage _save_system_user_page;
        private ViewPersonalDetailsPage _view_personal_details_page;
        private EditUserPage _edit_user_page;


        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _helpers = new SiteHelpers(_driver);
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _login_page = new LoginPage(_driver);
            _dashboard_page = new DashboardPage(_driver);
            _view_system_users_page = new ViewSystemUsersPage(_driver);
            _save_system_user_page = new SaveSystemUserPage(_driver);
            _view_personal_details_page = new ViewPersonalDetailsPage(_driver);
            _edit_user_page = new EditUserPage(_driver);

            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            _driver.Manage().Window.Maximize();
        }
        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        /// <summary>
        /// Test 1
        /// </summary>
        [TestMethod]
        [DataRow("SearchUser")]
        public void SearchAndEditUserTest(string user_name)
        {
            #region login page
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.UserLogin(SiteHelpers.AdminId, SiteHelpers.AdminPassword);
            #endregion

            #region admin page
            _wait.Until(d => _dashboard_page.AdminButton.Displayed);
            _dashboard_page.AdminButton.Click();
            #endregion

            #region view system users page
            _wait.Until(d => _view_system_users_page.AddButton.Displayed);
            _view_system_users_page.AddButton.Click();
            #endregion

            #region save system user page
            _wait.Until(d => _save_system_user_page.UserRoleDropdown.Displayed);

            _save_system_user_page.UserRoleDropdown.Click();
            _actions
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();

            _save_system_user_page.StatusDropdown.Click();
            _actions
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();

            _save_system_user_page.EmployeeNameSearchBox.Click();
            _actions
                .SendKeys("a")
                .Pause(TimeSpan.FromSeconds(3))
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();
            string employee_name = _save_system_user_page.EmployeeNameSearchBox.GetAttribute("value");
            string first_name = employee_name.Split(' ')[0];
            string last_name = employee_name.Split(' ').Last();

            _save_system_user_page.UserNameTextBox.SendKeys(user_name);
            _save_system_user_page.PasswordTextBox.SendKeys("admin123");
            _save_system_user_page.ConfirmPasswordTextBox.SendKeys("admin123");
            _save_system_user_page.SaveButton.Click();

            _actions.Pause(TimeSpan.FromSeconds(5)).Perform();
            #endregion
            //end add user

            //find and edit user
            #region view system users page
            _wait.Until(d => _view_system_users_page.UserSearchBox.Displayed);
            _view_system_users_page.UserSearchBox.SendKeys(user_name);
            _view_system_users_page.SearchButton.Click();
            _actions.Pause(TimeSpan.FromSeconds(3)).Perform();

            _wait.Until(d => _view_system_users_page.UserNameText(user_name).Displayed);
            Assert.IsTrue(_view_system_users_page.UserNameText(user_name).Displayed);
            _view_system_users_page.EditButton.Click();
            #endregion


            #region edit user page
            _wait.Until(d => _edit_user_page.UserRoleDropdown.Displayed);
            _save_system_user_page.UserRoleDropdown.Click();
            _actions
                .KeyDown(Keys.Down)
                .KeyDown(Keys.Down)
                .KeyDown(Keys.Enter)
                .Perform();

            _actions.Pause(TimeSpan.FromSeconds(1)).Perform();
            //_save_system_user_page.EditUserNameTextBox.Click();
            //_save_system_user_page.EditUserNameTextBox.SendKeys(Keys.Control + "a" + Keys.Delete);
            //_actions.Pause(TimeSpan.FromSeconds(1)).Perform();
            //_save_system_user_page.EditUserNameTextBox.SendKeys(user_name2);
            //_actions.Pause(TimeSpan.FromSeconds(1)).Perform();
            //_save_system_user_page.EditUserNameTextBox.SendKeys(Keys.Tab);
            //_actions.Pause(TimeSpan.FromSeconds(1)).Perform();

            _edit_user_page.SaveButton.Click();
            #endregion

            #region view system users page
            _wait.Until(d => _view_system_users_page.UserSearchBox.Displayed);
            _view_system_users_page.UserSearchBox.SendKeys(user_name);
            _view_system_users_page.SearchButton.Click();
            _actions.Pause(TimeSpan.FromSeconds(5)).Perform();
            _wait.Until(d => _view_system_users_page.UserNameText(user_name).Displayed);
            Assert.IsTrue(_view_system_users_page.UserNameText(user_name).Displayed);
            _view_system_users_page.DeleteButton.Click();
            _view_system_users_page.ConfirmDeleteButton.Click();
            //wait for delete
            _actions.Pause(TimeSpan.FromSeconds(5)).Perform();

            _save_system_user_page.UserDropdown.Click();
            _save_system_user_page.UserDropdownLogoutButton.Click();
            #endregion
        }















        /// <summary>
        /// Test 2 - Completed
        /// </summary>
        [TestMethod]
        [DataRow("TestUser", "admin123")]
        public void AddUserTest(string user_name, string user_password)
        {
            #region login page
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.UserLogin(SiteHelpers.AdminId, SiteHelpers.AdminPassword);
            #endregion

            #region admin page
            _wait.Until(d => _dashboard_page.AdminButton.Displayed);
            _dashboard_page.AdminButton.Click();
            #endregion

            #region view system users page
            _wait.Until(d => _view_system_users_page.AddButton.Displayed);
            _view_system_users_page.AddButton.Click();
            #endregion

            #region save system user page
            _wait.Until(d => _save_system_user_page.UserRoleDropdown.Displayed);

            _save_system_user_page.UserRoleDropdown.Click();
            _actions
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();

            _save_system_user_page.StatusDropdown.Click();
            _actions
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();

            _save_system_user_page.EmployeeNameSearchBox.Click();
            _actions
                .SendKeys("a")
                .Pause(TimeSpan.FromSeconds(5))
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();
            string employee_name = _save_system_user_page.EmployeeNameSearchBox.GetAttribute("value");
            string first_name = employee_name.Split(' ')[0];
            string last_name = employee_name.Split(' ').Last();

            _save_system_user_page.UserNameTextBox.SendKeys(user_name);
            _save_system_user_page.PasswordTextBox.SendKeys(user_password);
            _save_system_user_page.ConfirmPasswordTextBox.SendKeys(user_password);
            _save_system_user_page.SaveButton.Click();

            _actions.Pause(TimeSpan.FromSeconds(5)).Perform();

            _save_system_user_page.UserDropdown.Click();
            _save_system_user_page.UserDropdownLogoutButton.Click();
            #endregion

            LoginAsUserAndVerify(user_name, user_password, first_name, last_name);
            LoginAsAdminAndDeleteUser(user_name);
        }

        private void LoginAsAdminAndAddUser(string user_name, string user_password)
        {
            #region login page
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.UserLogin(SiteHelpers.AdminId, SiteHelpers.AdminPassword);
            #endregion

            #region admin page
            _wait.Until(d => _dashboard_page.AdminButton.Displayed);
            _dashboard_page.AdminButton.Click();
            #endregion

            #region view system users page
            _wait.Until(d => _view_system_users_page.AddButton.Displayed);
            _view_system_users_page.AddButton.Click();
            #endregion

            #region save system user page
            _wait.Until(d => _save_system_user_page.UserRoleDropdown.Displayed);

            _save_system_user_page.UserRoleDropdown.Click();
            _actions
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();

            _save_system_user_page.StatusDropdown.Click();
            _actions
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();

            _save_system_user_page.EmployeeNameSearchBox.Click();
            _actions
                .SendKeys("a")
                .Pause(TimeSpan.FromSeconds(5))
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();
            string employee_name = _save_system_user_page.EmployeeNameSearchBox.GetAttribute("value");
            string first_name = employee_name.Split(' ')[0];
            string last_name = employee_name.Split(' ').Last();

            _save_system_user_page.UserNameTextBox.SendKeys(user_name);
            _save_system_user_page.PasswordTextBox.SendKeys(user_password);
            _save_system_user_page.ConfirmPasswordTextBox.SendKeys(user_password);
            _save_system_user_page.SaveButton.Click();

            _actions.Pause(TimeSpan.FromSeconds(5)).Perform();

            _save_system_user_page.UserDropdown.Click();
            _save_system_user_page.UserDropdownLogoutButton.Click();
            #endregion
        }
        private void LoginAsUserAndVerify(string user_name, string user_password, string first_name, string last_name)
        {
            #region login page
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            _login_page.UserLogin(user_name, user_password);
            #endregion

            #region dashboard page
            _wait.Until(d => _dashboard_page.UserDropDownName.Text);

            //verify user is logged in
            Assert.IsTrue(_dashboard_page.UserDropDownName.Text == $"{first_name} {last_name}");

            //logout
            _dashboard_page.UserDropDownName.Click();
            _dashboard_page.UserDropdownLogoutButton.Click();
            #endregion
        }
        private void LoginAsAdminAndDeleteUser(string user_name)
        {
            #region login page
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.UserLogin(SiteHelpers.AdminId, SiteHelpers.AdminPassword);
            #endregion

            #region admin page
            _wait.Until(d => _dashboard_page.AdminButton.Displayed);
            _dashboard_page.AdminButton.Click();
            #endregion

            #region view system users page
            _wait.Until(d => _view_system_users_page.UserSearchBox.Displayed);
            _view_system_users_page.UserSearchBox.SendKeys(user_name);
            _view_system_users_page.SearchButton.Click();

            _actions.Pause(TimeSpan.FromSeconds(5)).Perform();
            _wait.Until(d => _view_system_users_page.UserNameText(user_name).Displayed);
            Assert.IsTrue(_view_system_users_page.UserNameText(user_name).Displayed);
            _view_system_users_page.DeleteButton.Click();
            _view_system_users_page.ConfirmDeleteButton.Click();

            //wait for delete
            _actions.Pause(TimeSpan.FromSeconds(5)).Perform();

            //logout
            _dashboard_page.UserDropDownName.Click();
            _dashboard_page.UserDropdownLogoutButton.Click();
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
