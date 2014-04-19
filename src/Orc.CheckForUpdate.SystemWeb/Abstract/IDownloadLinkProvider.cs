namespace Orc.CheckForUpdate.Web.Abstract
{
    public interface IDownloadLinkProvider
    {
        string RouteName { get; }

        string ControllerName { get; }

        string ActionName { get; } 
    }
}