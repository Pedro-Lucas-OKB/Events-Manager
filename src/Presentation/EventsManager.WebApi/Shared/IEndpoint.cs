namespace EventsManager.WebApi.Shared;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}
