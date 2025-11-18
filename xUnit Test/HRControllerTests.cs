using Microsoft.AspNetCore.Mvc;
using PROG6212_POE.Controllers;
using PROG6212_POE.Models;
using PROG6212_POE.Services;
using Xunit;

namespace PROG6212_POE.Tests
{
    public class HRControllerTests
    {
        [Fact]
        public void Dashboard_ReturnsViewWithUsers()
        {
            TestDataHelper.SeedTestUsers();
            var controller = TestControllerHelper.CreateController<HRController>("4", "HR");
            var result = controller.Dashboard();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateUser_GET_ReturnsView()
        {
            TestDataHelper.SeedTestUsers();
            var controller = TestControllerHelper.CreateController<HRController>("4", "HR");
            var result = controller.CreateUser();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateUser_POST_ValidUser_RedirectsToDashboard()
        {
            TestDataHelper.SeedTestUsers();
            var controller = TestControllerHelper.CreateController<HRController>("4", "HR");
            var user = new User { Name = "New", Surname = "User", Email = "new@test.com", Role = "Lecturer", Password = "pass" };
            var result = controller.CreateUser(user);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void ViewAllClaims_ReturnsViewWithClaims()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<HRController>("4", "HR");
            var result = controller.ViewAllClaims();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void GenerateReports_ReturnsViewWithApprovedClaims()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<HRController>("4", "HR");
            var result = controller.GenerateReports();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Dashboard_Unauthorized_RedirectsToAccessDenied()
        {
            var controller = TestControllerHelper.CreateController<HRController>("1", "Lecturer");
            var result = controller.Dashboard();
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("AccessDenied", redirect.ActionName);
        }
    }
}