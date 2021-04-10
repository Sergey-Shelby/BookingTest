using BookingTest.Common;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace BookingTest.Booking
{
	public class FlightSearchResult
	{
		public bool CheckPurchase => GetCheckPurchase();
		private IWebDriver _driver;
		private readonly By _checkPayment = By.XPath("//*[contains(text(), 'Br') or contains(text(), 'BYN')  or contains(text(), '₽')]");
		private readonly By _byTicketButton = By.XPath("//a[@aria-label='Купить']");
		public FlightSearchResult(IWebDriver driver)
		{
			_driver = driver;
		}
		public void ByTicket()
		{
			var byTicketButton = _driver.FindAndWaitElement(_byTicketButton, 10);
			byTicketButton.Click();
		}
		public bool GetCheckPurchase()
		{
			var checkPayment = _driver.FindAndWaitElement(_checkPayment);
			string[] arrayStringCheck = { "Br", "BYN", "₽" };
			return arrayStringCheck.Contains(checkPayment.Text);
		}
	}
}
