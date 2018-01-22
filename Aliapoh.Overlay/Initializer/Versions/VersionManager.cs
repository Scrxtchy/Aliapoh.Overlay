using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Aliapoh.Overlay.Logger;

namespace Aliapoh.Overlay.Initializer
{
    public static class VersionManager
    {
        public static void Initialize()
        {
            WebClient wc = new WebClient();
            var jsonstr = wc.DownloadString("https://github.com/laiglinne-ff/Aliapoh.Overlay/raw/aliapoh-versions/version.json");
            var json = JObject.Parse(jsonstr);
            var cur = new VersionStruct(Application.ProductVersion);
            var git = new VersionStruct(json["Stable"].Value<string>());

            LOG.Logger.Log(LogLevel.Warning, "Latest version: " + git.ToString());
            LOG.Logger.Log(LogLevel.Warning, "Current version: " + cur.ToString());

            if (cur.Diff(git) == -1)
                LOG.Logger.Log(LogLevel.Warning, "Patch required");
        }
    }
}
