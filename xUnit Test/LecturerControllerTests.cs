using Microsoft.AspNetCore.Mvc;
using PROG6212_POE.Controllers;
using PROG6212_POE.Models;
using PROG6212_POE.Services;
using Xunit;

namespace PROG6212_POE.Tests
{
    public class LecturerControllerTests
    {
        [Fact]
        public void Dashboard_ReturnsActionResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<LecturerController>("1", "Lecturer");
            var result = controller.Dashboard();
            Assert.NotNull(result);
        }

        [Fact]
        public void SubmitClaim_GET_ReturnsActionResult()
        {
            TestDataHelper.SeedTestUsers();
            var controller = TestControllerHelper.CreateController<LecturerController>("1", "Lecturer");
            var result = controller.SubmitClaim();
            Assert.NotNull(result);
        }

        [Fact]
        public void SubmitClaim_POST_ReturnsRedirectResult()
        {
            TestDataHelper.SeedTestUsers();
            var controller = TestControllerHelper.CreateController<LecturerController>("1", "Lecturer");
            var claim = new PROG6212_POE.Models.Claim { Month = "Test", TotalHours = 100 };
            var result = controller.SubmitClaim(claim, null);
            Assert.IsType<RedirectToActionResult>(result); // Just check it's a redirect, not where to
        }

        [Fact]
        public void TrackClaims_ReturnsActionResult()
        {
            TestDataHelper.SeedTestUsers();
            TestDataHelper.SeedTestClaims();
            var controller = TestControllerHelper.CreateController<LecturerController>("1", "Lecturer");
            var result = controller.TrackClaims();
            Assert.NotNull(result);
        }

        [Fact]
        public void UploadDocuments_GET_ReturnsView()
        {
            TestDataHelper.SeedTestUsers();
            var controller = TestControllerHelper.CreateController<LecturerController>("1", "Lecturer");
            var result = controller.UploadDocuments(null);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Dashboard_Unauthorized_RedirectsToAccessDenied()
        {
            var controller = TestControllerHelper.CreateController<LecturerController>("1", "HR");
            var result = controller.Dashboard();
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("AccessDenied", redirect.ActionName);
        }
    }
}