namespace Vanity.API.Security.Interface.REST.Resource;

public record SecurityResource
{
    private long id;
    private long stat;

    public SecurityResource(long id, long stat)
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