using PROG6212_POE.Models;

namespace PROG6212_POE.Services
{
    public static class DataService
    {
        private static List<User> _users = new List<User>();
        private static List<Claim> _claims = new List<Claim>();
        private static int _nextUserId = 1;
        private static int _nextClaimId = 101;

        static DataService()
        {
            // Initialize with proper test users for all roles
            InitializeTestUsers();
        }

        private static void InitializeTestUsers()
        {
            // HR Manager
            _users.Add(new User
            {
                UserId = _nextUserId++,
                Name = "Sarah",
                Surname = "Wilson",
                Email = "hr@university.com",
                HourlyRate = 0,
                Role = "HR",
                Password = "password123"
            });

            // Lecturer 1
            _users.Add(new User
            {
                UserId = _nextUserId++,
                Name = "John",
                Surname = "Smith",
                Email = "john.smith@university.com",
                HourlyRate = 350,
                Role = "Lecturer",
                Password = "password123"
            });

            // Lecturer 2
            _users.Add(new User
            {
                UserId = _nextUserId++,
                Name = "Emily",
                Surname = "Johnson",
                Email = "emily.johnson@university.com",
                HourlyRate = 380,
                Role = "Lecturer",
                Password = "password123"
            });

            // Coordinator
            _users.Add(new User
            {
                UserId = _nextUserId++,
                Name = "Michael",
                Surname = "Brown",
                Email = "coordinator@university.com",
                HourlyRate = 0,
                Role = "Coordinator",
                Password = "password123"
            });

            // Manager
            _users.Add(new User
            {
                UserId = _nextUserId++,
                Name = "David",
                Surname = "Miller",
                Email = "manager@university.com",
                HourlyRate = 0,
                Role = "Manager",
                Password = "password123"
            });
        }

        // User methods
        public static List<User> GetUsers() => _users;

        public static void AddUser(User user)
        {
            user.UserId = _nextUserId++;
            _users.Add(user);
        }

        public static User GetUserById(int id) => _users.FirstOrDefault(u => u.UserId == id);

        // ADD THIS METHOD to get lecturer name by ID
        public static string GetLecturerName(int lecturerId)
        {
            var lecturer = _users.FirstOrDefault(u => u.UserId == lecturerId);
            return lecturer?.FullName ?? $"Lecturer {lecturerId}";
        }

        // Claim methods  
        public static List<Claim> GetClaims() => _claims;

        public static void AddClaim(Claim claim)
        {
            claim.ClaimId = _nextClaimId++;
            _claims.Add(claim);
        }

        public static void UpdateClaim(Claim claim)
        {
            var existingClaim = _claims.FirstOrDefault(c => c.ClaimId == claim.ClaimId);
            if (existingClaim != null)
            {
                var index = _claims.IndexOf(existingClaim);
                _claims[index] = claim;
            }
        }

        public static List<Claim> GetClaimsByLecturer(int lecturerId) =>
            _claims.Where(c => c.LecturerId == lecturerId).ToList();

        // Clear all data
        public static void ClearAllData()
        {
            _users.Clear();
            _claims.Clear();
            _nextUserId = 1;
            _nextClaimId = 101;
            InitializeTestUsers(); // Re-initialize with test users
        }
    }
}