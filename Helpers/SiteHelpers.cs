using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace FinalProject.Helpers
{
    public class SiteHelpers
    {
        public static string URL => "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        public static string AdminId => "Admin";
        public static string AdminPassword => "admin123";


        readonly private IWebDriver _driver;

        public SiteHelpers(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ScrollAndClickButton(IWebElement element)
        {
            new Actions(_driver)
                .ScrollToElement(element)
                .Click()
                .Perform();
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



        //public void SelectTextFromDropDown(IWebElement element, string option_text)
        //{
        //    SelectElement select_element = new SelectElement(element);
        //    select_element.SelectByText(option_text);
        //}

        //public void SelectValueFromDropDown(IWebElement element, string option)
        //{
        //    SelectElement select_element = new SelectElement(element);
        //    select_element.SelectByValue(option);
        //}

        //public void SelectRandomOptionFromDropDown(IWebElement element, string option)
        //{
        //    SelectElement select_element = new SelectElement(element);
        //    var options = select_element.Options;
        //}

        //public void SelectIndexFromDropDown(IWebElement element, int option)
        //{
        //    SelectElement select_element = new SelectElement(element);
        //    select_element.SelectByIndex(option);
        //}

        //public void ClickDropDownElement(IWebDriver driver, IWebElement dropdown_element, string option)
        //{
        //List<WebElement> myElements = driver.FindElements(dropdown_element);
        //for (WebElement e : myElements)
        //{
        //    if (e.getText().equalsIgnoreCase("sometext"))
        //    {
        //        e.click();
        //    }
        //}
        //}


    }
}
