using Microsoft.AspNetCore.Mvc;
using Vanity.API.Configuration.Interface.REST.Resource;

namespace Vanity.API.Configuration.Interface.REST;


[ApiController]
[Route("api/v1/config")]
public class ConfigurationController : ControllerBase
{
    private static List<ConfigurationResource> _configs = [new ConfigurationResource(1234,"WireGuard")];

    [HttpPut]
    public IActionResult UpdateConfig([FromBody] ConfigurationResource configRsrc)
    {
        ConfigurationResource config = _configs.Find((el) => el.getId() == configRsrc.getId());
        if (config == null)
        {
            return NotFound(false);
        }
        config.setConfig(configRsrc.getConfig());
        return Ok(true);
    }


    [HttpPost]
    public IActionResult CreateConfig([FromBody] ConfigurationResource configRsrc)
    {
        ConfigurationResource config = _configs.Find((el) => el.getId() == configRsrc.getId());
        if (config == null)
        {
            _configs.Add(new ConfigurationResource(configRsrc.getId(), configRsrc.getConfig()));
            return Ok(true);
        }
        
        return NotFound(false);
    }

    [HttpGet("{id}")]
    public IActionResult GetConfigById(long id)
    {
        ConfigurationResource config = _configs.Find((el) => el.getId() == id);
        if (config == null)
        {
            return NotFound(false);
        }
        
        return Ok(config);
    }
    
    
}