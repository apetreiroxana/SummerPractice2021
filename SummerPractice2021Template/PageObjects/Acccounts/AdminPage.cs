using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SummerPractice2021Template.PageObjects.Acccounts
{
   
    public class AdminPage:BasePageObjectModel
    {
        
        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(20)));
        }
        [FindsBy(How=How.XPath, Using = "//tbody//tr[1]//td[3]")]
        public IWebElement GridAdminName { get; set; }

 

    }
}
