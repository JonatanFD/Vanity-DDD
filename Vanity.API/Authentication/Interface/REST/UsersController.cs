using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vanity.API.Data;
using Vanity.API.Models;

namespace Vanity.API.Authentication.Interface.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly VanityContext _context;

        public UsersController(VanityContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        /// <summary>
        /// Autentica un usuario basado en su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="username">El nombre de usuario.</param>
        /// <param name="pass">La contraseña.</param>
        /// <returns>El usuario autenticado o un mensaje de error si no se encuentra el usuario.</returns>
        /// <response code="200">Retorna el usuario autenticado.</response>
        /// <response code="404">No se encontró el usuario en base de datos.</response>
        [HttpPost("Authentication")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> AuthenticationUser(string username, string pass)
        {
            var userFind = await _context.Users.FirstOrDefaultAsync(e => e.Username == username && e.Password == pass);

            if (userFind is null)
                return NotFound("No se encontró el usuario en base de datos");

            return Ok(userFind);
        }
    }
}
