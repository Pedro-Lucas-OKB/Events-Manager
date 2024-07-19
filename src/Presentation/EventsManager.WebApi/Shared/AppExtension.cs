namespace EventsManager.WebApi.Shared;

public static class AppExtension
{
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        //app.MapSwagger().RequireAuthorization();
    }
}
