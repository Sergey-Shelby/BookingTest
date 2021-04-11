using BookingTest.Booking;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace BookingTest
{
	public class Tests
	{
		private IWebDriver _driver;
		private string url = "https://www.booking.com";
		[SetUp]
		public void Setup()
		{
			_driver = new OpenQA.Selenium.Chrome.ChromeDriver();
			_driver.Navigate().GoToUrl(url);
			_driver.Manage().Window.Maximize();
		}

		[Test]
		public void ChangeLanguageTest()
		{
			MainPage mainPage = new MainPage(_driver);
			mainPage.ChangeLanguage();
			var actualLanguage = mainPage.SelectedLanguage;
			Assert.That(actualLanguage, Does.Contain("aktuelle Sprache ist Deutsch"), "Language change error.");
		}

		[Test]
		public void BuyAirlineTicketTest()
		{
			var startDate = new DateTime(2021, 6, 1);
			var finishDate = new DateTime(2021, 6, 8);
			MainPage mainPage = new MainPage(_driver);
			AviaMainPage aviaMainPage = mainPage.AviaButtonClick();
			aviaMainPage.ChangeAirport();
			aviaMainPage.ChangeDates(startDate, finishDate);
			FlightSearchResult flightsPage = aviaMainPage.FlightsClick();
			flightsPage.ByTicket();
			bool actualTicket = flightsPage.CheckPurchase;
			Assert.That(actualTicket, "Check purchase error.");
		}

		[Test]
		public void UserAuthTest()
		{
			MainPage mainPage = new MainPage(_driver);
			LoginPage loginPage = mainPage.SingInButtonClick();
			loginPage.UserAuthClick();
			var actualUser = mainPage.UserAuthText;
			Assert.That(actualUser, Does.Contain("Genius"), "Auth error.");
		}

		[Test]
		public void FilterTest()
		{
			MainPage mainPage = new MainPage(_driver);
			mainPage.ChangeCity();
			mainPage.ChangeDate();
			mainPage.ChangeNumberChildren();
			SearchResultPage searchResult = mainPage.SearchClick();
			var actualFilter = searchResult.Filter;
			Assert.That(actualFilter, Does.Contain("1 ребенок"), "Filter error.");
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
		}
	}
}