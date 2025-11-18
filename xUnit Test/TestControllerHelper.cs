using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PROG6212_POE.Controllers;
using System.Security.Claims;

namespace PROG6212_POE.Tests
{
    public static class TestControllerHelper
    {
        public static T CreateController<T>(string userId = "1", string userRole = "Lecturer", string userName = "Test User") where T : Controller, new()
        {
            var controller = new T();

            // Create mock HTTP context with session
            var httpContext = new DefaultHttpContext();
            var session = new MockHttpSession();

            // Set session values
            if (!string.IsNullOrEmpty(userId))
                session.SetString("UserId", userId);
            if (!string.IsNullOrEmpty(userRole))
                session.SetString("UserRole", userRole);
            if (!string.IsNullOrEmpty(userName))
                session.SetString("UserName", userName);

            httpContext.Session = session;

            // Set user identity for authentication
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, userRole),
                new Claim(ClaimTypes.Name, userName)
            };
            var identity = new ClaimsIdentity(claims, "TestAuth");
            var principal = new ClaimsPrincipal(identity);
            httpContext.User = principal;

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            controller.TempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            return controller;
        }
    }
}