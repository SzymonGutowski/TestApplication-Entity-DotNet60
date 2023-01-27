using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private static List<Users> users = new List<Users>
            {

            };
        private readonly DataContext _context;

        public TestController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest("Please provide a correct id");
            }
            else
            {
                return Ok(user);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Users>>> GiveUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Users>>> UpdateUser(Users request)
        {
            var DbUser = await _context.Users.FindAsync(request.Id);

            if (DbUser == null)
            {
                return BadRequest("Please provide a correct id");
            }
            else
            {
                DbUser.Name = request.Name;
                DbUser.LastName = request.LastName;
                DbUser.Character = request.Character;
                DbUser.Age = request.Age;
                await _context.SaveChangesAsync();

                return Ok(await _context.Users.ToListAsync());
            }

        }
        [HttpDelete]
        public async Task<ActionResult<List<Users>>> DeleteUser(int id)
        {
            var DbUser = await _context.Users.FindAsync(id);
            if (DbUser == null)
            {
                return BadRequest("Please provide a correct id");
            }
            else
            {
                _context.Users.Remove(DbUser);
                await _context.SaveChangesAsync();
                return Ok(await _context.Users.ToListAsync());
            }

        }
    }


}

