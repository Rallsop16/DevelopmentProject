using DevelopmentProject.Data;
using DevelopmentProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DevelopmentProject.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        //Get all the users from the db
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        //get a user by their id from the db
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int Id)
        {
            var result = await _context.Users.FindAsync(Id);
            if (result == null)
                return NotFound(result);

            return Ok(result);
        }

        //delete a user from the db
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUserAsync(int Id)
        {
            var result = await _context.Users.FindAsync(Id);
            if (result == null)
                return NotFound(result);

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //update a user from the db
        [HttpPut("{Id}")]
        public async Task<ActionResult<User>> UpdateUserAsync(int Id, User updatedUser)
        {
            var dbResult = await _context.Users.FindAsync(Id);
            if (dbResult == null)
                return NotFound("User not found");

            dbResult.FirstName = updatedUser.FirstName;
            dbResult.LastName = updatedUser.LastName;
            dbResult.Email = updatedUser.Email;
            dbResult.Password = updatedUser.Password;
            dbResult.Role = updatedUser.Role;



            await _context.SaveChangesAsync();

            return Ok(dbResult);
        }

        //creates a user in the db
        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync(User newUser)
        {
            _context.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(newUser);
        }
    }
}


