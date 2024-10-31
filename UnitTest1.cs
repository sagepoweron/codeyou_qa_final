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
        private WebDriverWait _wait;
        private LoginPage _login_page;
        private Dashboard _dashboard;
        private ViewSystemUsersPage _view_users_page;
        private CreateUserPage _create_user_page;
        private ViewPersonalDetailsPage _view_personal_details_page;
        private EditUserPage _edit_user_page;
        private UserInfoPage _user_info_page;


        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _helpers = new SiteHelpers(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _login_page = new LoginPage(_driver);
            _dashboard = new Dashboard(_driver);
            _view_users_page = new ViewSystemUsersPage(_driver);
            _create_user_page = new CreateUserPage(_driver);
            _view_personal_details_page = new ViewPersonalDetailsPage(_driver);
            _edit_user_page = new EditUserPage(_driver);
            _user_info_page = new UserInfoPage(_driver);

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
        [DataRow("SomeTestUser")]
        public void SearchAndEditUserTest(string user_name)
        {
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.Login(SiteHelpers.AdminId, SiteHelpers.AdminPassword);

            AdminAddUser(user_name, "admin123");

            //find and edit user
            _wait.Until(d => _view_users_page.UserSearchBox.Displayed);
            _view_users_page.UserSearchBox.SendKeys(user_name);
            _view_users_page.SearchButton.Click();
            new Actions(_driver).Pause(TimeSpan.FromSeconds(3)).Perform();
            //_wait.Until(d => _view_system_users_page.UserNameText(user_name).Displayed);
            //Assert.IsTrue(_view_system_users_page.UserNameText(user_name).Displayed);
            _view_users_page.EditButton.Click();


            _wait.Until(d => _edit_user_page.UserRoleDropdown.Displayed);
            _edit_user_page.UserRoleDropdown.Click();
            new Actions(_driver)
                .KeyDown(Keys.Down)
                .KeyDown(Keys.Down)
                .KeyDown(Keys.Enter)
                .Perform();
            //_edit_user_page.UserNameTextBox.Clear();
            new Actions(_driver).Pause(TimeSpan.FromSeconds(3)).Perform();
            _edit_user_page.SaveButton.Click();

            AdminDeleteUser(user_name);

            _dashboard.Logout();

        }

        /// <summary>
        /// Test 2
        /// </summary>
        [TestMethod]
        [DataRow("TestUser", "admin123")]
        public void AddUserTest(string user_name, string user_password)
        {
            //login as admin
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.Login(SiteHelpers.AdminId, SiteHelpers.AdminPassword);

            //add user and save the employee name used
            string employee_name = AdminAddUser(user_name, user_password);

            _dashboard.Logout();

            //login as user
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.Login(user_name, user_password);

            VerifyUserEmployeeName(employee_name);
            _dashboard.Logout();

            //admin again
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.Login(SiteHelpers.AdminId, SiteHelpers.AdminPassword);

            AdminDeleteUser(user_name);

            _dashboard.Logout();
        }

        private string AdminAddUser(string user_name, string user_password)
        {
            _wait.Until(d => _dashboard.AdminButton.Displayed);
            _dashboard.AdminButton.Click();

            _wait.Until(d => _view_users_page.AddButton.Displayed);
            _view_users_page.AddButton.Click();

            _wait.Until(d => _create_user_page.UserRoleDropdown.Displayed);
            _create_user_page.UserRoleDropdown.Click();
            new Actions(_driver)
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();
            _create_user_page.StatusDropdown.Click();
            new Actions(_driver)
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();
            _create_user_page.EmployeeNameSearchBox.Click();
            new Actions(_driver)
                .SendKeys("a")
                .Pause(TimeSpan.FromSeconds(5))
                .KeyDown(Keys.ArrowDown)
                .KeyDown(Keys.Enter)
                .Perform();
            string employee_name = _create_user_page.EmployeeNameSearchBox.GetAttribute("value");
            string first_name = employee_name.Split(' ')[0];
            string last_name = employee_name.Split(' ').Last();

            _create_user_page.UserNameTextBox.SendKeys(user_name);
            new Actions(_driver).Pause(TimeSpan.FromSeconds(1)).Perform();
            _create_user_page.PasswordTextBox.SendKeys("admin123");
            _create_user_page.ConfirmPasswordTextBox.SendKeys("admin123");
            _create_user_page.SaveButton.Click();
            new Actions(_driver).Pause(TimeSpan.FromSeconds(5)).Perform();

            return employee_name;

        }
        private void AdminDeleteUser(string user_name)
        {
            _wait.Until(d => _dashboard.AdminButton.Displayed);
            _dashboard.AdminButton.Click();

            _wait.Until(d => _view_users_page.UserSearchBox.Displayed);
            _view_users_page.UserSearchBox.SendKeys(user_name);
            _view_users_page.SearchButton.Click();

            new Actions(_driver).Pause(TimeSpan.FromSeconds(5)).Perform();
            _wait.Until(d => _view_users_page.UserNameText(user_name).Displayed);
            Assert.IsTrue(_view_users_page.UserNameText(user_name).Displayed);
            _view_users_page.DeleteButton.Click();
            _view_users_page.ConfirmDeleteButton.Click();

            //wait for delete
            new Actions(_driver).Pause(TimeSpan.FromSeconds(5)).Perform();
        }
        private void VerifyUserEmployeeName(string employee_name)
        {
            _wait.Until(d => _dashboard.UserNameDropDown.Displayed);
            string first_name = employee_name.Split(' ')[0];
            string last_name = employee_name.Split(' ').Last();
            Assert.IsTrue(_dashboard.UserNameDropDown.Text == $"{first_name} {last_name}");
        }
        



        /// <summary>
        /// Test 3
        /// </summary>
        [TestMethod]
        [DataRow("Phil", "McCracken")]
        public void ChangeUserNameTest(string first_name, string last_name)
        {
            _wait.Until(d => _login_page.UsernameTextBox.Displayed);
            Assert.IsTrue(_login_page.UsernameTextBox.Displayed);
            _login_page.Login("Admin", "admin123");

            _wait.Until(d => _dashboard.InfoButton.Displayed);
            _dashboard.InfoButton.Click();

            _wait.Until(d => _user_info_page.FirstNameBox.Displayed);
            _user_info_page.FirstNameBox.Click();
            new Actions(_driver)
                .KeyDown(Keys.Control)
                .SendKeys("a").KeyUp(Keys.Control)
                .SendKeys(Keys.Delete)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(first_name)
                .Pause(TimeSpan.FromSeconds(1))
                .Perform();

            _user_info_page.LastNameBox.Click();
            new Actions(_driver)
                .KeyDown(Keys.Control)
                .SendKeys("a").KeyUp(Keys.Control)
                .SendKeys(Keys.Delete)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(first_name)
                .Pause(TimeSpan.FromSeconds(1))
                .Perform();

            _user_info_page.SaveButton1.Click();
            new Actions(_driver).Pause(TimeSpan.FromSeconds(5)).Perform();
            _dashboard.AdminButton.Click();
            new Actions(_driver).Pause(TimeSpan.FromSeconds(5)).Perform();

            VerifyUserEmployeeName(first_name + " " + last_name);

            _dashboard.Logout();
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
