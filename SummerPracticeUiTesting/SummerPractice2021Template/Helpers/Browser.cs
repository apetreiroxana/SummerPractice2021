using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SummerPractice2021Template.Helpers
{
    public abstract class Browser
    {
        protected IWebDriver Driver;

        protected Browser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        protected void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
           
        }
    }
}