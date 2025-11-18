using PROG6212_POE.Models;
using PROG6212_POE.Data;

namespace PROG6212_POE.Services
{
    public static class DataService
    {
        private static List<User> _users = new List<User>
        {
            new User { UserId = 1, Name = "HR", Surname = "Manager", Email = "hr@university.com", Password = "password123", Role = "HR", HourlyRate = 0 },
            new User { UserId = 2, Name = "John", Surname = "Smith", Email = "lecturer@university.com", Password = "password123", Role = "Lecturer", HourlyRate = 200 },
            new User { UserId = 3, Name = "Programme", Surname = "Coordinator", Email = "coordinator@university.com", Password = "password123", Role = "Coordinator", HourlyRate = 0 },
            new User { UserId = 4, Name = "Academic", Surname = "Manager", Email = "manager@university.com", Password = "password123", Role = "Manager", HourlyRate = 0 }
        };

        private static List<Claim> _claims = new List<Claim>();
        private static int _nextClaimId = 1;

        public static List<User> GetUsers() => _users;

        public static User? GetUserById(int id) => _users.FirstOrDefault(u => u.UserId == id);

        public static List<Claim> GetClaims() => _claims;

        public static List<Claim> GetClaimsByLecturer(int lecturerId) =>
            _claims.Where(c => c.LecturerId == lecturerId).ToList();

        public static void AddUser(User user)
        {
            user.UserId = _users.Max(u => u.UserId) + 1;
            _users.Add(user);
        }

        public static void AddClaim(Claim claim)
        {
            claim.ClaimId = _nextClaimId++;
            _claims.Add(claim);
        }

        public static void UpdateClaim(Claim updatedClaim)
        {
            var existingClaim = _claims.FirstOrDefault(c => c.ClaimId == updatedClaim.ClaimId);
            if (existingClaim != null)
            {
                // Update properties
                existingClaim.TotalHours = updatedClaim.TotalHours;
                existingClaim.StoredHourlyRate = updatedClaim.StoredHourlyRate;
                existingClaim.StoredTotalAmount = updatedClaim.StoredTotalAmount;
                existingClaim.Notes = updatedClaim.Notes;
                existingClaim.Month = updatedClaim.Month;
                existingClaim.Status = updatedClaim.Status;
                existingClaim.VerifiedByCoordinatorId = updatedClaim.VerifiedByCoordinatorId;
                existingClaim.ApprovedByManagerId = updatedClaim.ApprovedByManagerId;
                existingClaim.SubmittedDate = updatedClaim.SubmittedDate;
                existingClaim.VerifiedDate = updatedClaim.VerifiedDate;
                existingClaim.ApprovedDate = updatedClaim.ApprovedDate;
                existingClaim.DocumentPath = updatedClaim.DocumentPath;
                existingClaim.DocumentOriginalName = updatedClaim.DocumentOriginalName;
            }
        }
    }
}