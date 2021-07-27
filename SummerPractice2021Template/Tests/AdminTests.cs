using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SummerPractice2021.Helpers;
using SummerPractice2021Template.Helpers;
using SummerPractice2021Template.PageObjects;
using SummerPractice2021Template.PageObjects.Acccounts;

namespace SummerPractice2021Template.Tests
{
    [TestClass]
    public class AdminTests: Browser, IDisposable
    {
        public LoginPage loginPage;
        public DashboardPage dashboardPage;
        public AddAdminPage addAdminPage;
        public AdminPage adminPage;

        public AdminTests()
        {
            Driver.Navigate().GoToUrl("https://www.phptravels.net/admin");

            loginPage = new LoginPage(Driver);
            loginPage.Login("admin@phptravels.com", "demoadmin");

            dashboardPage = new DashboardPage(Driver);
            dashboardPage.WaitForPageToLoad("[class='sidebar-header']");

            Driver.Navigate().GoToUrl("https://www.phptravels.net/admin/accounts/admins/add");
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void Add_Admin()
        {
            addAdminPage = new AddAdminPage(Driver);
            addAdminPage.WaitForPageToLoad("[class='sidebar-header']");

            addAdminPage.TxtFirstName.SendKeys("Nume"+ Utils.GetRandomString(4));
            var firstName = addAdminPage.TxtFirstName.GetAttribute("value"); //prin aceasta metoda putem extrage textul din interiorul unui input

            addAdminPage.TxtLastName.SendKeys("Last Name");

            //adresa de email trebuie sa fie unica
            //folosim metoda GetRandomString din clasa Utils, folderul Helpers
            addAdminPage.TxtEmail.SendKeys(Utils.GetRandomString(7) + "@gmail.com");

            addAdminPage.TxtPassword.SendKeys("Password");
            addAdminPage.AddCountry("rom", "Romania");
            //noi am creat doar un admin,insa nu i-am acordat drepturi de a adauga,edita sau sterge hoteluri
            //apelam metoda GiveHotelRights pentru a atribui drepturi userului creat
            addAdminPage.GiveHotelRights();

            addAdminPage.BtnSubmit.Click();

            adminPage = new AdminPage(Driver);
            adminPage.WaitForPageToLoad("[class='sidebar-header']");
            Assert.AreEqual(firstName, adminPage.GridAdminName.Text);//verificam daca numele adaugat de noi este prezent in grid ul de pe pagina :https://www.phptravels.net/admin/accounts/admins/
        }

        public void Dispose()
        {
            CloseBrowser();
        }
    }
}
