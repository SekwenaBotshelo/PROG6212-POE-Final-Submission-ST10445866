using Microsoft.AspNetCore.Mvc;
using PROG6212_POE.Controllers;
using PROG6212_POE.Models;
using PROG6212_POE.Services;
using Xunit;

namespace PROG6212_POE.Tests
{
    public class ManagerControllerTests
    {
        [Fact]
        public void Dashboard_ReturnsActionResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<ManagerController>("3", "Manager");
            var result = controller.Dashboard();
            Assert.NotNull(result);
        }

        [Fact]
        public void ApproveClaims_ReturnsActionResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<ManagerController>("3", "Manager");
            var result = controller.ApproveClaims();
            Assert.NotNull(result);
        }

        [Fact]
        public void ViewClaimDetails_ReturnsActionResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<ManagerController>("3", "Manager");
            var result = controller.ViewClaimDetails(102);
            Assert.NotNull(result);
        }

        [Fact]
        public void ApproveClaim_ReturnsRedirectResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<ManagerController>("3", "Manager");
            var result = controller.ApproveClaim(102);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Reports_ReturnsActionResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<ManagerController>("3", "Manager");
            var result = controller.Reports();
            Assert.NotNull(result);
        }

        [Fact]
        public void Dashboard_Unauthorized_RedirectsToAccessDenied()
        {
            var controller = TestControllerHelper.CreateController<ManagerController>("1", "Lecturer");
            var result = controller.Dashboard();
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("AccessDenied", redirect.ActionName);
        }
    }
}