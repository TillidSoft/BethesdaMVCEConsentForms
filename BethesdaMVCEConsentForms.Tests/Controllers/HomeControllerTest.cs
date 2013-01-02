using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BethesdaMVCEConsentForms;
using BethesdaMVCEConsentForms.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BethesdaMVCEConsentForms.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);
        }
    }
}