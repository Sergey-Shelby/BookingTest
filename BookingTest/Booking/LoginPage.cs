using BookingTest.Common;
using OpenQA.Selenium;

namespace BookingTest.Booking
{
	public class LoginPage
	{
		private IWebDriver _driver;
		private readonly By _emailEnter = By.XPath("//*[@id='username']");
		private readonly By _emailButton = By.XPath("//button[@class='bui-button bui-button--large bui-button--wide']");
		private readonly By _passwordEnter = By.XPath("//*[@id='password']");
		private readonly By _passwordButton = By.XPath("//button[@class='bui-button bui-button--large bui-button--wide']");
		private const string Email = "booking-test@bk.ru";
		private const string Password = "fghfgdfsdcce1W";
		public LoginPage(IWebDriver driver)
		{
			this._driver = driver;
		}

		public void UserAuthClick()
		{
			_driver.FindElement(_emailEnter).SendKeys(Email);
			_driver.FindAndWaitElement(_emailButton).Click();
			_driver.FindAndWaitElement(_passwordEnter).SendKeys(Password);
			_driver.FindAndWaitElement(_passwordButton).Click();
		}
	}
}
