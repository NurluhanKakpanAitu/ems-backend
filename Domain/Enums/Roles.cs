using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum Roles
{
    [Display(Name = "Admin")]
    Admin,
    [Display(Name = "User")]
    User,
    [Display(Name = "Backend Developer")]
    BackendDeveloper,
    [Display(Name = "Frontend Developer")]
    FrontendDeveloper,
    [Display(Name = "Full Stack Developer")]
    FullStackDeveloper,
    [Display(Name = "DevOps")]
    DevOps,
    [Display(Name = "Manager")]
    Manager,
}