using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SummerPractice2021Template.PageObjects
{
    public class DashboardPage: BasePageObjectModel
    {
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.Id, Using = "sidebar")]
        public IWebElement AdminMenu { get; set; }

    }
}
