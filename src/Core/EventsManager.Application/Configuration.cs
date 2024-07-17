using System.Net;

namespace EventsManager.Application;

public class Configuration
{
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 30;
    public const int DefaultStatusCode = (int)HttpStatusCode.OK;

    public static string BackendUrl { get; set; } = "";
    public static string FrontendUrl { get; set; } = "";
}
