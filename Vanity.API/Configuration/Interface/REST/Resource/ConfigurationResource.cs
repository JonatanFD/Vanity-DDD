namespace Vanity.API.Configuration.Interface.REST.Resource;

public record ConfigurationResource
{
    private long id;
    private string config;

    public ConfigurationResource(long id, string config)
    {
        this.id = id;
        this.config = config;
    }

    public long getId()
    {
        return id;
    }

    public string getConfig()
    {
        return config;
    }

    public void setConfig(string _config)
    {
        this.config = _config;
    }
}