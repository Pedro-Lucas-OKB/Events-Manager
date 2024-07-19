using System.Net;

namespace EventsManager.Application;

public class Configuration
{
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 30;
    public const int DefaultStatusCode = (int)HttpStatusCode.OK;

    public static string BackendUrl { get; set; } = "http://localhost:5220";
    public static string FrontendUrl { get; set; } = "";
}
