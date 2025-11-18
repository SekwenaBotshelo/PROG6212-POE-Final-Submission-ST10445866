using PROG6212_POE.Models;
using PROG6212_POE.Services;

namespace PROG6212_POE.Data
{
    public static class DemoSeeder
    {
        public static void Seed()
        {
            // Clear existing data and re-initialize with test users
            DataService.ClearAllData();

            // Add demo claims for testing
            var claims = new List<Claim>
            {
                new Claim
                {
                    ClaimId = 1,
                    LecturerId = 2, // John Smith
                    Month = "January 2025",
                    TotalHours = 120,
                    StoredHourlyRate = 350,
                    StoredTotalAmount = 120 * 350,
                    Status = "Pending Verification",
                    SubmittedDate = DateTime.Now.AddDays(-10),
                    Notes = "Regular teaching hours for January"
                },
                new Claim
                {
                    ClaimId = 2,
                    LecturerId = 2, // John Smith
                    Month = "February 2025",
                    TotalHours = 150,
                    StoredHourlyRate = 350,
                    StoredTotalAmount = 150 * 350,
                    Status = "Verified",
                    SubmittedDate = DateTime.Now.AddDays(-5),
                    VerifiedDate = DateTime.Now.AddDays(-2),
                    VerifiedByCoordinatorId = 4 // Michael Brown (Coordinator)
                },
                new Claim
                {
                    ClaimId = 3,
                    LecturerId = 3, // Emily Johnson
                    Month = "January 2025",
                    TotalHours = 140,
                    StoredHourlyRate = 380,
                    StoredTotalAmount = 140 * 380,
                    Status = "Approved",
                    SubmittedDate = DateTime.Now.AddDays(-8),
                    VerifiedDate = DateTime.Now.AddDays(-4),
                    ApprovedDate = DateTime.Now.AddDays(-1),
                    VerifiedByCoordinatorId = 4, // Michael Brown (Coordinator)
                    ApprovedByManagerId = 5 // David Miller (Manager)
                },
                new Claim
                {
                    ClaimId = 4,
                    LecturerId = 3, // Emily Johnson
                    Month = "February 2025",
                    TotalHours = 160,
                    StoredHourlyRate = 380,
                    StoredTotalAmount = 160 * 380,
                    Status = "Pending Verification",
                    SubmittedDate = DateTime.Now.AddDays(-3),
                    Notes = "Including overtime for special projects"
                }
            };

            foreach (var claim in claims)
            {
                DataService.AddClaim(claim);
            }
        }
    }
}