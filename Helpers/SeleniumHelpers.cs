using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Helpers
{
    public class SeleniumHelpers
    {
        public static string URL => "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        readonly private IWebDriver _driver;

        public SeleniumHelpers(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SelectTextFromDropDown(IWebElement element, string option_text)
        {
            SelectElement select_element = new SelectElement(element);
            select_element.SelectByText(option_text);
        }

        public void SelectValueFromDropDown(IWebElement element, string option)
        {
            SelectElement select_element = new SelectElement(element);
            select_element.SelectByValue(option);
        }

        public void SelectRandomOptionFromDropDown(IWebElement element, string option)
        {
            SelectElement select_element = new SelectElement(element);
            var options = select_element.Options;
        }

        public void SelectIndexFromDropDown(IWebElement element, int option)
        {
            SelectElement select_element = new SelectElement(element);
            select_element.SelectByIndex(option);
        }

        public void ScrollAndClickButton(IWebElement element)
        {
            Actions act = new Actions(_driver);
            //act.MoveToElement(_apply_page.SubmitButton).Click();

            act.ScrollToElement(element).Perform();
            element.Click();
        }

        public void ScrollAndClickButtonByJS(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            js.ExecuteScript("arguments[0].click();", element);
        }



        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        public void LoadWebsite()
        {
            _driver.Navigate().GoToUrl(URL);
        }
    }
}
