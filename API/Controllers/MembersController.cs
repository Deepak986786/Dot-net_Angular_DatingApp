using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class MembersController : BaseApiController
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }
        //[AllowAnonymous] to allow anonymous access to all users on this endpoint
        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetMembers()
        {
            var members = await _context.Users.ToListAsync();
            return members;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMemberById(string Id)
        {
            var member = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == Id);
            return Ok(member);
        }
    }
}
