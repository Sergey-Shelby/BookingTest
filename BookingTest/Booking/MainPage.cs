using BookingTest.Common;
using OpenQA.Selenium;
using System;

namespace BookingTest.Booking
{
	public class MainPage
	{
		public string UserAuthText => GetUserAuth();
		public string SelectedLanguage => GetLanguage();
		private IWebDriver _driver;
		private readonly By _aviaMainButton = By.XPath("/html/body/header/nav[2]/ul/li[2]/a/span[2]");
		private readonly By _signInButton = By.XPath("/html/body/header/nav[1]/div[2]/div[6]/a");
		private readonly By _checkUser = By.XPath("//span[contains(text(),'Genius 1')]");
		private readonly By _language = By.XPath("//button[@data-tooltip-text='Wählen Sie Ihre Sprache']");
		private readonly By _changeLanguage = By.XPath("//button[@data-modal-id='language-selection']");
		private readonly By _changeDe = By.XPath("//a[@data-lang='de']");
		private readonly By _city = By.XPath("//*[@id='ss']");
		private readonly By _datePanel = By.XPath("//span[@class='sb-date-field__icon sb-date-field__icon-btn bk-svg-wrapper calendar-restructure-sb']");
		private readonly By _dateStart = By.XPath($"//td[@data-date='{DateTime.Now.AddDays(7).ToString("yyyy-MM-dd")}']");
		private readonly By _dateFinal = By.XPath($"//td[@data-date='{DateTime.Now.AddDays(9).ToString("yyyy-MM-dd")}']");
		private readonly By _selectChild = By.XPath("//span[@class='xp__guests__count']");
		private readonly By _plusChild = By.XPath("//button[@aria-describedby='group_children_desc'][2]");
		private readonly By _searchButton = By.XPath("//button[@class='sb-searchbox__button ']");
		public MainPage(IWebDriver driver)
		{
			this._driver = driver;
		}
		private string GetUserAuth()
		{
			return _driver.FindAndWaitElement(_checkUser).Text;
		}
		private string GetLanguage()
		{
			return _driver.FindAndWaitElement(_language).Text;
		}
		public SearchResultPage SearchClick()
		{
			var search = _driver.FindElement(_searchButton);
			search.Click();
			return new SearchResultPage(_driver);
		}
		public void ChangeCity(string city = "Москва")
		{
			var changeCity = _driver.FindElement(_city);
			changeCity.SendKeys(city);
		}
		public void ChangeDate()
		{
			var datePanel = _driver.FindElement(_datePanel);
			datePanel.Click();
			var datestart = _driver.FindAndWaitElement(_dateStart);
			datestart.Click();
			var changeDate = _driver.FindAndWaitElement(_dateFinal);
			changeDate.Click();
		}
		public void ChangeNumberChildren()
		{
			var numberChild = _driver.FindElement(_selectChild);
			numberChild.Click();
			var addChild = _driver.FindAndWaitElement(_plusChild);
			addChild.Click();
		}
		public void ChangeLanguage()
		{
			var changeLanguage = _driver.FindAndWaitElement(_changeLanguage);
			changeLanguage.Click();
			var changeDe = _driver.FindAndWaitElement(_changeDe);
			changeDe.Click();
		}
		public AviaMainPage AviaButtonClick()
		{
			_driver.FindAndWaitElement(_aviaMainButton).Click();
			return new AviaMainPage(_driver);
		}
		public LoginPage SingInButtonClick()
		{
			_driver.FindElement(_signInButton).Click();
			return new LoginPage(_driver);
		}
	}
}
