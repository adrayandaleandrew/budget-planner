// Controllers/UserController.cs

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Here you would typically save the user to your database
        // Replace with your actual database logic (e.g., Entity Framework Core)
        // Example: using (var dbContext = new YourDbContext())
        // {
        //     dbContext.Users.Add(user);
        //     dbContext.SaveChanges();
        // }

        // For demo purposes, returning a success message
        return Ok(new { message = "Registration successful" });
    }
}
