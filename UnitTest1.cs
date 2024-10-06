using FinalProject.Helpers;
using FinalProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalProject
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;
        private SeleniumHelpers _helpers;


        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _helpers = new SeleniumHelpers(_driver);
        }
        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
        }


        [TestMethod]
        [DataRow("User", "Password")]
        public void LoginTest(string user_name, string password)
        {
            _helpers.LoadWebsite();
            //_driver.Navigate().GoToUrl(SeleniumHelpers.URL);
            LoginPage login_page = new LoginPage(_driver);

            Assert.IsTrue(login_page.TitleText.Text.ToLower().Contains("login page"));

            login_page.UserLogin(user_name, password);

            HomePage home_page = new HomePage(_driver);

            Assert.IsTrue(home_page.UserNameTextBox.Text.ToLower().Contains(user_name));
        }





        [TestMethod]
        public void SearchAndEditUserTest()
        {
            _helpers.LoadWebsite();
        }




    }
}
