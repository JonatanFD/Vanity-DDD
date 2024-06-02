using Microsoft.AspNetCore.Mvc;
using Vanity.API.Security.Interface.REST.Resource;

namespace Vanity.API.Security.Interface.REST;


[ApiController]
[Route("api/v1/security")]
public class Security : ControllerBase
{
    private static List<SecurityResource> _stats = [new SecurityResource(1234,100)];

    [HttpPut]
    public IActionResult UpdateConfig([FromBody] SecurityResource monitor)
    {
        SecurityResource stat = _stats.Find((el) => el.getId() == monitor.getId());
        if (stat == null)
        {
            return NotFound(false);
        }
        stat.setStat(monitor.getStat());
        return Ok(true);
    }


    [HttpPost]
    public IActionResult CreateMonitor([FromBody] SecurityResource _stat)
    {
        SecurityResource stat = _stats.Find((el) => el.getId() == _stat.getId());
        if (stat == null)
        {
            _stats.Add(new SecurityResource(stat.getId(), stat.getStat()));
            return Ok(true);
        }
        
        return NotFound(false);
    }

    [HttpGet("{id}")]
    public IActionResult GetMonitoById(long id)
    {
        SecurityResource config = _stats.Find((el) => el.getId() == id);
        if (config == null)
        {
            return NotFound(false);
        }
        
        return Ok(config);
    }

}