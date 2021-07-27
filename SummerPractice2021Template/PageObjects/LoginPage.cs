using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SummerPractice2021Template.PageObjects
{
    public class LoginPage: BasePageObjectModel
    {

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(10)));
        }

        #region Login section

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement TxtUsername { get; set; }


        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]
        public IWebElement BtnLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert-danger")]
        public IWebElement ErrInvalidCred { get; set; }
        #endregion

        public void Login(string username, string password)
        {
            TxtUsername.SendKeys(username);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
        }
    }
}