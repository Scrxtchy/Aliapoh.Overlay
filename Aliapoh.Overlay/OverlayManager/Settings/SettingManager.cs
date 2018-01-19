using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Diagnostics;

namespace Aliapoh.Overlay.OverlayManager
{
    public class SettingManager
    {
        public List<SettingObject> OverlaySettings { get; set; }
        public GlobalSettingObject GlobalSetting { get; set; }

        public void GenerateSettingACTStyle()
        {
            var xd = new XmlDocument();
            var plugin = xd.CreateElement("PluginConfig");
            plugin.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            plugin.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");

            if (GlobalSetting == null) return;

            foreach(FieldInfo fi in GlobalSetting.GetType().GetFields())
            {
                var el = xd.CreateElement(fi.Name);
                el.InnerText = fi.GetValue(GlobalSetting).ToString();
                plugin.AppendChild(el);
            }

            var overlays = xd.CreateElement("Overlays");

            if(OverlaySettings != null)
                foreach(SettingObject so in OverlaySettings)
                {
                    var overlay = xd.CreateElement("Overlay");
                    overlay.SetAttribute("Name", so.Name);
                    foreach (FieldInfo fi in so.GetType().GetFields())
                    {
                        var el = xd.CreateElement(fi.Name);
                        el.InnerText = fi.GetValue(so).ToString();
                        overlay.AppendChild(el);
                    }
                    overlays.AppendChild(overlay);
                }

            xd.AppendChild(plugin);
            Debug.WriteLine(xd.OuterXml);
        }
    }
}
