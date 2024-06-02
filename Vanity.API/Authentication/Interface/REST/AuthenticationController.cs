using Microsoft.AspNetCore.Http.HttpResults;
using Vanity.API.Authentication.Interface.REST.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Vanity.API.Authentication.Interface.REST;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController : ControllerBase
{
    private static AuthenticationResource _auth = new AuthenticationResource(12345);
    
    [HttpGet("{id}")]
    public IActionResult GetAuthenticationById(long id)
    {
        if (id == _auth.Id)
        {
            return Ok(true);
        }
        return NotFound(false);
    }
}