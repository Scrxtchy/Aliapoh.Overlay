using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aliapoh.Overlay
{
    public static class LanguageLoader
    {
        public static JObject JSON { get; set; }
        public static void Initialize()
        {
            var lang = Encoding.UTF8.GetString(Properties.Resources.LanguageFile);
            JSON = JObject.Parse(lang);
        }
    }
}