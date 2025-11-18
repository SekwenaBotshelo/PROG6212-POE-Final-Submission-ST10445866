using PROG6212_POE.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG6212_POE.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }

        // Foreign key to User (Lecturer who submitted the claim)
        [Required]
        public int LecturerId { get; set; }

        [Required(ErrorMessage = "Please enter total hours worked.")]
        [Range(1, 180, ErrorMessage = "Hours must be between 1 and 180.")]
        [Display(Name = "Hours Worked")]
        public double TotalHours { get; set; }

        // Store hourly rate at time of submission to calculate amount
        [Display(Name = "Hourly Rate")]
        public decimal StoredHourlyRate { get; set; }

        // Store calculated amount
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        public decimal StoredTotalAmount { get; set; }

        // NOTES IS OPTIONAL
        [Display(Name = "Additional Notes")]
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Month is required")]
        [Display(Name = "Claim Month")]
        public string Month { get; set; } = string.Empty;

        // Status workflow: Pending Verification → Verified → Approved → Paid
        public string Status { get; set; } = "Pending Verification";

        // Approval tracking
        [Display(Name = "Verified By")]
        public int? VerifiedByCoordinatorId { get; set; }

        [Display(Name = "Approved By")]
        public int? ApprovedByManagerId { get; set; }

        // Timestamps
        [Display(Name = "Submitted Date")]
        [DataType(DataType.DateTime)]
        public DateTime SubmittedDate { get; set; } = DateTime.Now;

        [Display(Name = "Verified Date")]
        [DataType(DataType.DateTime)]
        public DateTime? VerifiedDate { get; set; }

        [Display(Name = "Approved Date")]
        [DataType(DataType.DateTime)]
        public DateTime? ApprovedDate { get; set; }

        // File upload for supporting documents
        [Display(Name = "Supporting Document")]
        public string? DocumentPath { get; set; }

        [Display(Name = "Document Original Name")]
        public string? DocumentOriginalName { get; set; }

        // COMPUTED PROPERTIES
        [NotMapped]
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        public double TotalAmount => (double)StoredTotalAmount;

        [NotMapped]
        public string LecturerName => DataService.GetLecturerName(LecturerId);

        [NotMapped]
        public decimal HourlyRate => StoredHourlyRate;

        [NotMapped]
        public string SafeLecturerName => DataService.GetLecturerName(LecturerId);

        [NotMapped]
        public string SafeLecturerEmail
        {
            get
            {
                var lecturer = DataService.GetUserById(LecturerId);
                return lecturer?.Email ?? "Email Not Available";
            }
        }
    }
}