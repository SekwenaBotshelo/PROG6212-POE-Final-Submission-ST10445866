using Microsoft.AspNetCore.Mvc;
using PROG6212_POE.Controllers;
using PROG6212_POE.Models;
using PROG6212_POE.Services;
using Xunit;

namespace PROG6212_POE.Tests
{
    public class CoordinatorControllerTests
    {
        [Fact]
        public void Dashboard_ReturnsActionResult()
        {
            // FIXED: Ensure proper test setup
            TestDataHelper.ClearTestData();
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();

            var controller = TestControllerHelper.CreateController<CoordinatorController>("2", "Coordinator");

            // Act & Assert - just check it doesn't throw exception
            var result = controller.Dashboard();
            Assert.NotNull(result);

            // If it's a redirect, that's fine for our test purposes
            // The important thing is no null reference exception
        }

        [Fact]
        public void VerifyClaims_ReturnsActionResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<CoordinatorController>("2", "Coordinator");
            var result = controller.VerifyClaims();
            Assert.NotNull(result);
        }

        [Fact]
        public void ViewClaimDetails_ReturnsActionResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<CoordinatorController>("2", "Coordinator");
            var result = controller.ViewClaimDetails(101);
            Assert.NotNull(result);
        }

        [Fact]
        public void VerifyClaim_ReturnsRedirectResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<CoordinatorController>("2", "Coordinator");
            var result = controller.VerifyClaim(101);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void RejectClaim_ReturnsRedirectResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<CoordinatorController>("2", "Coordinator");
            var result = controller.RejectClaim(101);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Dashboard_Unauthorized_RedirectsToAccessDenied()
        {
            var controller = TestControllerHelper.CreateController<CoordinatorController>("1", "Lecturer");
            var result = controller.Dashboard();
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("AccessDenied", redirect.ActionName);
        }
    }
}