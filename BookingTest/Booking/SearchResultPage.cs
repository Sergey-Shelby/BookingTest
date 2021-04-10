using BookingTest.Common;
using OpenQA.Selenium;

namespace BookingTest.Booking
{
	public class SearchResultPage
	{
		public string Filter => GetFilter();
		private IWebDriver _driver;
		private readonly By _checkFilter = By.XPath("//select[@name='group_children']//option[@value='1' and @selected='selected']");
		public SearchResultPage(IWebDriver driver)
		{
			this._driver = driver;
		}
		private string GetFilter()
		{
			return _driver.FindAndWaitElement(_checkFilter).Text;
		}
	}
}
