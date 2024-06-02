using Microsoft.AspNetCore.Mvc;
using Vanity.API.ServerConnection.Interface.REST.Resource;

namespace Vanity.API.ServerConnection.Interface.REST;

[ApiController]
[Route("api/v1/server")]
public class ServerConnection : ControllerBase
{
    private static List<ServerConnectionResource> _stats = [new ServerConnectionResource(1234,100)];

    [HttpPut]
    public IActionResult UpdateConfig([FromBody] ServerConnectionResource monitor)
    {
        ServerConnectionResource stat = _stats.Find((el) => el.getId() == monitor.getId());
        if (stat == null)
        {
            return NotFound(false);
        }
        stat.setStat(monitor.getStat());
        return Ok(true);
    }


    [HttpPost]
    public IActionResult CreateMonitor([FromBody] ServerConnectionResource _stat)
    {
        ServerConnectionResource stat = _stats.Find((el) => el.getId() == _stat.getId());
        if (stat == null)
        {
            _stats.Add(new ServerConnectionResource(stat.getId(), stat.getStat()));
            return Ok(true);
        }
        
        return NotFound(false);
    }

    [HttpGet("{id}")]
    public IActionResult GetMonitorById(long id)
    {
        ServerConnectionResource config = _stats.Find((el) => el.getId() == id);
        if (config == null)
        {
            return NotFound(false);
        }
        
        return Ok(config);
    }
    
    [HttpGet]
    public IActionResult GetMonitors(long id)
    {
        ServerConnectionResource config = _stats.Find((el) => el.getId() == id);
        if (config == null)
        {
            return NotFound(false);
        }
        
        return Ok(config);
    }
    
    [HttpDelete("{id}")]
    public IActionResult GetMonitoById(long id)
    {
        ServerConnectionResource config = _stats.Find((el) => el.getId() == id);
        if (config == null)
        {
            return NotFound(false);
        }
        
        return Ok(config);
    }

}