using PROG6212_POE.Models;
using PROG6212_POE.Services;

namespace PROG6212_POE.Tests
{
    public static class TestDataHelper
    {
        public static void ClearTestData()
        {
            DataService.ClearAllData();
        }

        public static void SeedTestUsers()
        {
            ClearTestData();

            // Add test users - UserIds must match what's in session (strings)
            DataService.AddUser(new User
            {
                UserId = 1, // This will be used as string "1" in session
                Name = "Test",
                Surname = "Lecturer",
                Email = "test.lecturer@university.com",
                HourlyRate = 350,
                Role = "Lecturer",
                Password = "password123"
            });

            DataService.AddUser(new User
            {
                UserId = 2, // This will be used as string "2" in session
                Name = "Test",
                Surname = "Coordinator",
                Email = "coordinator@university.com",
                HourlyRate = 0,
                Role = "Coordinator",
                Password = "password123"
            });

            DataService.AddUser(new User
            {
                UserId = 3, // This will be used as string "3" in session
                Name = "Test",
                Surname = "Manager",
                Email = "manager@university.com",
                HourlyRate = 0,
                Role = "Manager",
                Password = "password123"
            });

            DataService.AddUser(new User
            {
                UserId = 4, // This will be used as string "4" in session
                Name = "Test",
                Surname = "HR",
                Email = "hr@university.com",
                HourlyRate = 0,
                Role = "HR",
                Password = "password123"
            });
        }

        public static void SeedTestClaims()
        {
            DataService.AddClaim(new PROG6212_POE.Models.Claim
            {
                ClaimId = 101,
                LecturerId = 1, // Matches lecturer UserId 1
                Month = "January 2025",
                TotalHours = 120,
                StoredHourlyRate = 350,
                StoredTotalAmount = 120 * 350,
                Status = "Pending Verification",
                SubmittedDate = DateTime.Now.AddDays(-10)
            });

            DataService.AddClaim(new PROG6212_POE.Models.Claim
            {
                ClaimId = 102,
                LecturerId = 1, // Matches lecturer UserId 1
                Month = "February 2025",
                TotalHours = 150,
                StoredHourlyRate = 350,
                StoredTotalAmount = 150 * 350,
                Status = "Verified",
                SubmittedDate = DateTime.Now.AddDays(-5),
                VerifiedDate = DateTime.Now.AddDays(-2),
                VerifiedByCoordinatorId = 2 // Matches coordinator UserId 2
            });

            DataService.AddClaim(new PROG6212_POE.Models.Claim
            {
                ClaimId = 103,
                LecturerId = 1, // Matches lecturer UserId 1
                Month = "March 2025",
                TotalHours = 140,
                StoredHourlyRate = 350,
                StoredTotalAmount = 140 * 350,
                Status = "Approved",
                SubmittedDate = DateTime.Now.AddDays(-8),
                VerifiedDate = DateTime.Now.AddDays(-4),
                ApprovedDate = DateTime.Now.AddDays(-1),
                VerifiedByCoordinatorId = 2, // Matches coordinator UserId 2
                ApprovedByManagerId = 3 // Matches manager UserId 3
            });
        }
    }
}