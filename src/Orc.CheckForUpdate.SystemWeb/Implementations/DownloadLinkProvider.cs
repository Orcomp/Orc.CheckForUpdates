namespace Orc.CheckForUpdate.Web.Implementations
{
    using Orc.CheckForUpdate.Web.Abstract;

    public class DownloadLinkProvider : IDownloadLinkProvider
    {
        public string RouteName
        {
            get
            {
                return "DownloadFile";
            }
        }

        public string ControllerName
        {
            get
            {
                return "Home";
            }
        }

        public string ActionName
        {
            get
            {
                return "Download";
            }
        }
    }
}
