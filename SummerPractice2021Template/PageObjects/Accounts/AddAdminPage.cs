using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SummerPractice2021Template.PageObjects.Accounts
{
    public class AddAdminPage
    {
        public IWebDriver driver;

        public AddAdminPage( IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(5)));
        }

        #region Add admin

        [FindsBy(How = How.CssSelector, Using = "[name='fname']")]
        public IWebElement TxtFirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[name='lname']")]
        public IWebElement TxtLastName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[name='email']")]
        public IWebElement TxtEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[name='password']")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".select2-chosen")]
        public IWebElement TxtEnterCountry { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".select2-input")]
        public IWebElement TxtSearchCountry { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".select2-result-label")]
        public IList<IWebElement> LstCountryResults { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Submit']")]
        public IWebElement BtnSubmit { get; set; }

        #endregion

        public void WaitForPageToLoad(string selector)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(selector)));
        }

        public void AddCountry(string searchText, string selectText)
        {
            TxtEnterCountry.Click();
            var wait=new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(TxtEnterCountry));
            TxtSearchCountry.Click();
            TxtSearchCountry.SendKeys(searchText);

            foreach (var country in LstCountryResults)
            {
                if (country.Text.Contains(selectText))
                {
                    country.Click();
                    break;
                }
                
            }
        }
       
    }
}