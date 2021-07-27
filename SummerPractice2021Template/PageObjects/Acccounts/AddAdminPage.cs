using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SummerPractice2021Template.PageObjects.Acccounts
{
    public class AddAdminPage:BasePageObjectModel
    {
        
        public AddAdminPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(20)));
        }
        //Elemente identificate pentru completarea formularului de add admin
        #region Add admin
        [FindsBy(How = How.Name, Using = "fname")]
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


        //Elemente identificate pentru a atribui drepturi unui user creat
        #region Main settings
        [FindsBy(How = How.CssSelector, Using = "input[value$='addHotels']")]
        public IWebElement ChkAddHotels { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value$='editHotels']")]
        public IWebElement ChkEditHotels { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value$='deleteHotels']")]
        public IWebElement ChkDeleteHotels { get; set; }
        #endregion

        public void AddCountry(string searchCountry, string selectCountry)
        {
            TxtEnterCountry.Click();
            var wait=new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(TxtEnterCountry));

            TxtSearchCountry.Click();
            TxtSearchCountry.SendKeys(searchCountry);

            foreach (var country in LstCountryResults)
            {
                if (country.Text.Contains(selectCountry))
                {
                    country.Click();
                    break;
                }
                
            }

        }

        //Metoda de atribuire de drepturi unui user asupra unui hotel
        public void GiveHotelRights()
        {
            ChkAddHotels.Click();
            ChkEditHotels.Click();
            ChkDeleteHotels.Click();
        }

    }
}
