using System.ComponentModel.DataAnnotations;

namespace LMS.WebAPI.Models;

public class RegisterDto
{
    [Required]
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    [Required]
    public required string LastName { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
    public required string Password { get; set; }
    [Required]
    public required string Role { get; set; }
}
