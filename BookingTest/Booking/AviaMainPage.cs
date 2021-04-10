using BookingTest.Common;
using OpenQA.Selenium;
using System;

namespace BookingTest.Booking
{
	public class AviaMainPage
	{
		private IWebDriver _driver;
		private readonly By _textBoxCity = By.XPath("//*[@data-placeholder='Куда?']");
		private readonly By _textBoxCityAirport = By.XPath("//input[@placeholder='Куда?']");
		private readonly By _startDateButton = By.XPath("//*[contains(@id, 'dateRangeInput-display-start-inner')]");
		private readonly By _textStartDate = By.XPath("//*[contains(@id, 'depart-input')]");
		private readonly By _finishDateButton = By.XPath("//*[contains(@id, 'dateRangeInput-display-end-inner')]");
		private readonly By _textFinishDate = By.XPath("//*[contains(@id, 'return-input')]");
		private readonly By _searchFlightsButton = By.XPath("//button[contains(@id, '-submit') and contains(@class, 'theme-light')]");
		public AviaMainPage(IWebDriver driver)
		{
			_driver = driver;
		}
		public void ChangeAirport(string city = "Москва")
		{
			var aviaText = _driver.FindAndWaitElement(_textBoxCity, 3);
			aviaText.Click();
			var aviaTextVvod = _driver.FindAndWaitElement(_textBoxCityAirport, 3);
			aviaTextVvod.SendKeys(city);
			aviaTextVvod.SendKeys(Keys.Enter);
		}
		public void ChangeDates(DateTime dateStart, DateTime dateFinish)
		{
			var startDateButton = _driver.FindAndWaitElement(_startDateButton, 3);
			startDateButton.Click();
			var textStartDate = _driver.FindAndWaitElement(_textStartDate, 3);
			textStartDate.SendKeys(dateStart.ToString("dd.MM.yyyy"));
			textStartDate.SendKeys(Keys.Enter);
			var finishDateButton = _driver.FindAndWaitElement(_finishDateButton, 3);
			finishDateButton.Click();
			var textFinishDate = _driver.FindAndWaitElement(_textFinishDate, 3);
			textFinishDate.SendKeys(dateFinish.ToString("dd.MM.yyyy"));
			textFinishDate.SendKeys(Keys.Enter);
		}
		public FlightSearchResult FlightsClick()
		{
			var searchFlightsButton = _driver.FindElement(_searchFlightsButton);
			searchFlightsButton.Click();
			return new FlightSearchResult(_driver);
		}
	}
}
