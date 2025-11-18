using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Moq;
using PROG6212_POE.Controllers;
using PROG6212_POE.Models;
using Xunit;

namespace PROG6212_POE.Tests
{
    public class HomeControllerTests
    {
        private HomeController GetController()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockLogger.Object);

            var httpContext = new DefaultHttpContext();
            httpContext.Session = new MockHttpSession();
            controller.ControllerContext = new ControllerContext() { HttpContext = httpContext };
            controller.TempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            return controller;
        }

        [Fact] public void Index_ReturnsView() => Assert.IsType<ViewResult>(GetController().Index());
        [Fact] public void Privacy_ReturnsView() => Assert.IsType<ViewResult>(GetController().Privacy());
        [Fact] public void About_ReturnsView() => Assert.IsType<ViewResult>(GetController().About());
        [Fact] public void Contact_ReturnsView() => Assert.IsType<ViewResult>(GetController().Contact());
        [Fact] public void Error_ReturnsView() => Assert.IsType<ViewResult>(GetController().Error());

        [Fact]
        public void DashboardSearch_ValidInput_RedirectsToDashboard()
        {
            var result = GetController().DashboardSearch("lecturer");
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Dashboard", redirect.ActionName);
        }
    }
}