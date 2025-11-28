using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetMembers()
        {
            var members = await _context.Users.ToListAsync();
            return members;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMemberById(string Id)
        {
            var member = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            return Ok(member);
        }
    }
}
