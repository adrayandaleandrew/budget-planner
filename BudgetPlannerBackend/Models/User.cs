// Models/User.cs

using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; } = string.Empty; // Initialize with empty string

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = string.Empty; // Initialize with empty string

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty; // Initialize with empty string
}
