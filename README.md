# PROG6212-POE-Final-Submission-ST10445866

## Project Overview

A comprehensive web-based claim management system built with ASP.NET Core MVC that streamlines the monthly claim submission and approval process for educational institutions. The system features role-based access control, automated calculations, and secure document management.

## Student Information

- **Student Name:** Botshelo Koketso Sekwena
- **Student Number:** ST10445866
- **Module:** PROG6212 - Programming 2B
- **GitHub Rpository:** https://github.com/SekwenaBotshelo/PROG6212-POE-Final-Submission-ST10445866.git 

## Technology Stack

- **Framework:** ASP.NET Core MVC
- **Database:** Entity Framework Core (Code-First)
- **Testing:** xUnit Framework
- **Frontend:** Bootstrap 5, JavaScript
- **Authentication:** Session-based with role management

## Part 3 Enhancements

### HR Super User System
- Centralized user profile management
- No public registration - HR creates all accounts
- Complete CRUD operations for user management
- Automated report generation with LINQ queries

### Automated Data Flow
- Hourly rates automatically pulled from HR-managed user profiles
- Real-time total amount calculation
- Elimination of manual rate input errors
- Permanent audit trail of calculated values

### Enhanced Security & Validation
- Session-based authentication
- Role-based access control (HR, Lecturer, Coordinator, Manager)
- Business rule enforcement (180-hour monthly limit)
- Comprehensive input validation

### Entity Framework Integration
- Code-first database design
- Proper entity relationships (User → Claims → Documents)
- Data integrity through model validation
- Scalable architecture

### Comprehensive Testing
- **44/44 Unit Tests Passing**
- Full controller coverage
- Security and session management testing
- Business logic validation

## Feedback-Driven Improvements (From Part 2)

### Document Attachment Feature
- Added file upload option in claim submission form
- Support for multiple file types (PDF, Word, Images)
- Client and server-side file validation
- 10MB file size limit

### Document Display Fix
- Implemented button-based document viewing
- Clean UI unaffected by long filenames
- Documents open in new tabs for better user experience
- Professional document management interface

## User Roles & Workflows

### HR Manager
- Create and manage all user accounts
- Set hourly rates and roles
- Generate comprehensive reports
- System administration

### Lecturer
- Submit monthly claims with auto-calculated amounts
- Upload supporting documents
- Track claim status through approval workflow
- View personal claim history

### Programme Coordinator
- Verify submitted claims
- Update claim status
- Ensure claim accuracy and compliance

### Academic Manager
- Approve verified claims
- Final authorization before payment
- Overview of all claims and reporting

## Key Features

### Automated Calculations
// Real-time calculation from HR-managed data
var totalAmount = model.TotalHours * (double)lecturer.HourlyRate;

### Business Rule Enforcement
[Range(1, 180, ErrorMessage = "Maximum 180 hours per month")]
public double TotalHours { get; set; }


## **Security Implementation**
**Location:** Under "Key Features" section

### Security Implementation
// Role-based authorization
if (HttpContext.Session.GetString("UserRole") != "Lecturer")
    return RedirectToAction("AccessDenied", "Account");


## **Installation & Setup**

### Prerequisites
- .NET 9.0 SDK
- Visual Studio 2022 or VS Code
- Web browser with JavaScript enabled

### Running the Application
1. Clone the repository
2. Restore NuGet packages: `dotnet restore`
3. Build the solution: `dotnet build`
4. Run the application: `dotnet run`
5. Access via: `https://localhost:7116`

### Running Tests
dotnet test


## **Version Control**

## Version Control
- Regular, descriptive commits
- Feedback-driven development iterations
- Professional Git workflow management
- Comprehensive commit history documenting feature development

## Future Enhancements
- PDF report generation
- Email notification system
- Advanced analytics dashboard
- Mobile-responsive optimization
- API integration capabilities
- Advanced reporting features

## Conclusion

This Contract Monthly Claim System represents a production-ready enterprise solution that successfully implements all Part 3 requirements while addressing feedback from Part 2. The system demonstrates professional software engineering practices, comprehensive testing, and user-centered design.

## Referances
- Steve Smith. (2024, June 17). Overview of ASP.NET Core MVC. Retrieved from Microsoft Ignite: https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-9.0
- xUnit.net. (n.d.). About xUnit.net. Retrieved from xUnit.net: https://xunit.net/?tabs=cs
- Microsoft Ignite. (2025, January 29). ASP.NET Core security topics. Retrieved from Microsoft Ignite: https://learn.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-9.0
- Andrew Troelsen, Phil Japikse. (2022). Pro C# 10 with .NET 6. New York: Apress.
- Gregg Lindemulder, Matt Kosinski. (n.d.). What is role-based access control (RBAC)? . Retrieved from IBM: https://www.ibm.com/think/topics/rbac
- Microsoft Learn. (2025). Implement role-based access control. Retrieved from Microsoft Learn: https://learn.microsoft.com/en-us/entra/identity-platform/howto-implement-rbac-for-apps
- Microsoft Learn. (2025). Logging in C# and .NET. Retrieved from Microsoft Learn: https://learn.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line

