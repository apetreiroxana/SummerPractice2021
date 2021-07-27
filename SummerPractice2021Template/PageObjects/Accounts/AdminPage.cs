using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SummerPractice2021.PageObjects.Accounts
{
    public class AdminPage: BasePageObjectModel
    {
        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.XPath, Using = "//tbody//tr[1]//td[3]")]
        public IWebElement GridAdmins { get; set; }
    }
}
