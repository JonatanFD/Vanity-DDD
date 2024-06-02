using Microsoft.AspNetCore.Mvc;
using Vanity.API.Monitoring.Interface.REST.Resource;

namespace Vanity.API.Monitoring.Interface.REST;


[ApiController]
[Route("api/v1/monitoring")]
public class MonitoringController : ControllerBase
{
    private static List<MonitoringResource> _stats = [new MonitoringResource(1234,100)];

    [HttpPut]
    public IActionResult UpdateMonitor([FromBody] MonitoringResource monitor)
    {
        MonitoringResource stat = _stats.Find((el) => el.getId() == monitor.getId());
        if (stat == null)
        {
            return NotFound(false);
        }
        stat.setStat(monitor.getStat());
        return Ok(true);
    }


    [HttpPost]
    public IActionResult CreateMonitor([FromBody] MonitoringResource _stat)
    {
        MonitoringResource stat = _stats.Find((el) => el.getId() == _stat.getId());
        if (stat == null)
        {
            _stats.Add(new MonitoringResource(stat.getId(), stat.getStat()));
            return Ok(true);
        }
        
        return NotFound(false);
    }

    [HttpGet("{id}")]
    public IActionResult GetMonitorById(long id)
    {
        MonitoringResource config = _stats.Find((el) => el.getId() == id);
        if (config == null)
        {
            return NotFound(false);
        }
        
        return Ok(config);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteMonitor(long id)
    {
        MonitoringResource config = _stats.Find((el) => el.getId() == id);
        if (config == null)
        {
            return NotFound(false);
        }
        
        return Ok(config);
    }
}