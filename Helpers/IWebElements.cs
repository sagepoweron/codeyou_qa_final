using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Helpers
{
    public static class IWebElements
	{
		public static void SelectTextFromDropDown(this IWebElement element, string option_text)
		{
			SelectElement select_element = new SelectElement(element);
			select_element.SelectByText(option_text);
		}

		public static void SelectValueFromDropDown(this IWebElement element, string option)
		{
			SelectElement select_element = new SelectElement(element);
			select_element.SelectByValue(option);
		}

		//public static void SelectRandomOptionFromDropDown(this IWebElement element, string option)
		//{
		//	SelectElement select_element = new SelectElement(element);
		//	var options = select_element.Options;
		//}

		public static void SelectIndexFromDropDown(this IWebElement element, int option)
		{
			SelectElement select_element = new SelectElement(element);
			select_element.SelectByIndex(option);
		}

		public static void ScrollAndClickButton(this IWebElement element, IWebDriver driver)
		{
			Actions act = new Actions(driver);
			//act.MoveToElement(element).Click();

			act.ScrollToElement(element).Perform();
			element.Click();
		}

		public static void ScrollAndClickButtonByJS(this IWebElement element, IWebDriver driver)
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
			js.ExecuteScript("arguments[0].click();", element);
		}
	}
}
