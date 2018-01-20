using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Aliapoh.Overlay.OverlayManager
{
    public class SettingManager
    {
        public List<SettingObject> OverlaySettings { get; set; }
        public GlobalSettingObject GlobalSetting { get; set; }

        public void GenerateSettingJSON()
        {
            var o = new JObject()
            {
                { "PluginConfig", new JObject() }
            };
            if (GlobalSetting == null) return;
            foreach (FieldInfo fi in GlobalSetting.GetType().GetFields())
            {
                var val = fi.GetValue(GlobalSetting);
                ((JObject)o["PluginConfig"]).Add(fi.Name, val.ToString());
            }
            o["PluginConfig"]["Overlays"] = new JObject();
            if (OverlaySettings != null)
                foreach (SettingObject so in OverlaySettings)
                {
                    var obj = new JObject();
                    foreach (FieldInfo fi in so.GetType().GetFields())
                    {
                        obj.Add(fi.Name, fi.GetValue(so).ToString());
                    }
                    o["PluginConfig"]["Overlays"][so.Name] = obj;
                }

            Debug.WriteLine(o.ToString());
        }

        public void LoadSettingJSON()
        {
            if (File.Exists(Path.Combine(Program.APPDIR, "Setting.json")))
            {
                var o = JObject.Parse(File.ReadAllText(Path.Combine(Program.APPDIR, "Setting.json")));
                foreach (FieldInfo fi in GlobalSetting.GetType().GetFields())
                {
                    foreach(JProperty p in o["PluginConfig"])
                    {
                        if(fi.Name == p.Name)
                        {
                            if(fi.FieldType == typeof(string))
                                GlobalSetting.GetType().GetField(fi.Name).SetValue(GlobalSetting, p.Value<string>());
                            if (fi.FieldType == typeof(int))
                                GlobalSetting.GetType().GetField(fi.Name).SetValue(GlobalSetting, int.Parse(p.Value<string>()));
                            if (fi.FieldType == typeof(bool))
                                GlobalSetting.GetType().GetField(fi.Name).SetValue(GlobalSetting, p.Value<string>() == "True" ? true : false);
                        }
                    }
                }

                if (o["PluginConfig"]["Overlays"] != null)
                {
                    foreach (FieldInfo fi in GlobalSetting.GetType().GetFields())
                    {
                        foreach (JProperty p in o["PluginConfig"]["Overlays"])
                        {
                            var oc = new OverlayConfig(p.Name);
                            if (o["PluginConfig"]["Overlays"][p.Name] != null)
                            {

                            }
                        }
                    }
                }
            }
        }

        public void GenerateSettingACTStyle()
        {
            // not use. but I coded it
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
            xd.Save(Path.Combine(Program.APPDIR, "Setting.xml"));
        }

        public void LoadSettingACTStyle()
        {
            if(File.Exists(Path.Combine(Program.APPDIR, "Setting.xml")))
            {
                var xd = new XmlDocument();
                xd.Load(Path.Combine(Program.APPDIR, "Setting.xml"));

            }
        }
    }
}
