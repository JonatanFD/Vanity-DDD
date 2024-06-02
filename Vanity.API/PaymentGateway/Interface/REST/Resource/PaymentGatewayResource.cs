namespace Vanity.API.PaymentGateway.Interface.REST.Resource;

public record PaymentGatewayResource
{
    private long id;
    private long stat;

    public PaymentGatewayResource(long id, long stat)
    {
        this.id = id;
        this.stat = stat;
    }

    public long getId()
    {
        return id;
    }

    public long getStat()
    {
        return stat;
    }

    public void setStat(long _stat)
    {
        this.stat = _stat;
    }
}