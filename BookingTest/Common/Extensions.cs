using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BookingTest.Common
{
	public static class Extensions
	{
		public static IWebElement FindAndWaitElement(this IWebDriver driver, By by, int timeoutInSeconds = 1)
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
			return wait.Until(drv => drv.FindElement(by));
		}
	}
}
