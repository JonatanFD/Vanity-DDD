using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Vanity.API.Security.Interface.REST
{
    [ApiController]
    [Route("api/v1/security")]
    public class Security : ControllerBase
    {
        private static List<Resource.SecurityResource> _stats = new List<Resource.SecurityResource> { new Resource.SecurityResource(1234, 100) };

        [HttpPut]
        public IActionResult UpdateConfig([FromBody] Resource.SecurityResource monitor)
        {
            Resource.SecurityResource stat = _stats.Find((el) => el.getId() == monitor.getId());
            if (stat == null)
            {
                return NotFound(false);
            }
            stat.setStat(monitor.getStat());
            return Ok(true);
        }

        [HttpPost]
        public IActionResult CreateMonitor([FromBody] Resource.SecurityResource _stat)
        {
            Resource.SecurityResource stat = _stats.Find((el) => el.getId() == _stat.getId());
            if (stat == null)
            {
                _stats.Add(new Resource.SecurityResource(_stat.getId(), _stat.getStat()));
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpGet("{id}")]
        public IActionResult GetMonitorById(long id)
        {
            Resource.SecurityResource config = _stats.Find((el) => el.getId() == id);
            if (config == null)
            {
                return NotFound(false);
            }

            return Ok(config);
        }
    }

    public class SecurityResource
    {
        public SecurityResource(long id, int stat)
        {
            Id = id;
            Stat = stat;
        }

        public long Id { get; }
        public int Stat { get; private set; }

        public long getId() => Id;
        public int getStat() => Stat;
        public void setStat(int stat) => Stat = stat;
    }
}
