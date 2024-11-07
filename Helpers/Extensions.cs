using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace FinalProject.Helpers
{
    public static class Extensions
	{
		public static void ScrollAndClickButton(this IWebElement element, IWebDriver driver)
		{
            new Actions(driver)
				.ScrollToElement(element)
				.Click().Perform();
		}

		public static void ScrollAndClickButtonByJS(this IWebElement element, IWebDriver driver)
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
			js.ExecuteScript("arguments[0].click();", element);
		}

        public static void WaitUntil(this IWebDriver driver, Func<bool> condition)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => condition);
        }

        public static void Pause(this IWebDriver driver, int seconds)
        {
            new Actions(driver)
                .Pause(TimeSpan.FromSeconds(seconds))
                .Perform();
        }

        //site doesn't use select elements
        //public static void SelectTextFromDropDown(this IWebElement element, string option_text)
        //{
        //	SelectElement select_element = new SelectElement(element);
        //	select_element.SelectByText(option_text);
        //}

        //public static void SelectValueFromDropDown(this IWebElement element, string option)
        //{
        //	SelectElement select_element = new SelectElement(element);
        //	select_element.SelectByValue(option);
        //}

        //public static void SelectRandomOptionFromDropDown(this IWebElement element, string option)
        //{
        //	SelectElement select_element = new SelectElement(element);
        //	var options = select_element.Options;
        //}

        //public static void SelectIndexFromDropDown(this IWebElement element, int option)
        //{
        //	SelectElement select_element = new SelectElement(element);
        //	select_element.SelectByIndex(option);
        //}
    }
}
