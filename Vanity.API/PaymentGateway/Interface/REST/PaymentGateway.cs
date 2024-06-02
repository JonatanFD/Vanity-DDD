using Microsoft.AspNetCore.Mvc;
using Vanity.API.PaymentGateway.Interface.REST.Resource;

namespace Vanity.API.PaymentGateway.Interface.REST;


[ApiController]
[Route("api/v1/payment")]
public class PaymentGateway : ControllerBase
{
    private static List<PaymentGatewayResource> _stats = [new PaymentGatewayResource(1234,100)];

    [HttpPut]
    public IActionResult UpdatePayment([FromBody] PaymentGatewayResource monitor)
    {
        PaymentGatewayResource stat = _stats.Find((el) => el.getId() == monitor.getId());
        if (stat == null)
        {
            return NotFound(false);
        }
        stat.setStat(monitor.getStat());
        return Ok(true);
    }


    [HttpPost]
    public IActionResult CreatePayment([FromBody] PaymentGatewayResource _stat)
    {
        PaymentGatewayResource stat = _stats.Find((el) => el.getId() == _stat.getId());
        if (stat == null)
        {
            _stats.Add(new PaymentGatewayResource(stat.getId(), stat.getStat()));
            return Ok(true);
        }
        
        return NotFound(false);
    }

    [HttpGet("{id}")]
    public IActionResult GetPaymentById(long id)
    {
        PaymentGatewayResource config = _stats.Find((el) => el.getId() == id);
        if (config == null)
        {
            return NotFound(false);
        }
        
        return Ok(config);
    }

}