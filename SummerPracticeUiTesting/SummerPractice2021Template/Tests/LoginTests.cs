using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SummerPractice2021Template.Helpers;
using SummerPractice2021Template.PageObjects;

namespace SummerPractice2021Template.Tests
{
    [TestClass]
    public class LoginTests : Browser, IDisposable
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;


        public LoginTests() 
        {
            Driver.Navigate()
                .GoToUrl("https://www.phptravels.net/admin");
            loginPage = new LoginPage(Driver);
        }



        [TestMethod]
        [TestCategory("SummerPractice")]
        public void Login_With_Valid_Credentials()
        {
            loginPage.Login("admin@phptravels.com", "demoadmin");
            dashboardPage = new DashboardPage(Driver);
            dashboardPage.WaitForPageToLoad("[class='sidebar-header']");
            Assert.IsTrue(dashboardPage.AdminMenu.Displayed);
        }

        [TestMethod]
        public void Login_With_Invalid_Password()
        {
            loginPage.Login("admin@phptravels.com", "demoasdmin");
            loginPage.WaitForPageToLoad(".alert-danger");
            Assert.AreEqual("Invalid Login Credentials", loginPage.ErrInvalidCred.Text);
        }

        public void Dispose()
        {
            CloseBrowser();
        }
    }
}