using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Aliapoh.Overlay.OverlayManager
{
    public static class SettingManager
    {
        public static readonly string SettingFile = "Aliapoh.Overlay.Config.json";
        public static List<SettingObject> OverlaySettings;
        public static GlobalSettingObject GlobalSetting;

        public static void GenerateSettingJSON()
        {
            GenerateSettingJSON(GlobalSetting);
        }

        public static void GenerateSettingJSON(GlobalSettingObject gso)
        {
            var o = new JObject()
            {
                { "PluginConfig", new JObject() }
            };
            if (gso == null) return;
            foreach (FieldInfo fi in gso.GetType().GetFields())
            {
                var val = fi.GetValue(gso);
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
            File.WriteAllText(Path.Combine(Loader.APPDIR, SettingFile), o.ToString());
        }

        public static void LoadSettingJSON()
        {
            if (!File.Exists(Path.Combine(Loader.APPDIR, SettingFile)))
            {
                GenerateSettingJSON(DefaultSetting.GlobalSettingObject);
                GlobalSetting = DefaultSetting.GlobalSettingObject;
                LoadSettingJSON();
            }
            else
            {
                var o = JObject.Parse(File.ReadAllText(Path.Combine(Loader.APPDIR, SettingFile)));
                if (GlobalSetting == null)
                    GlobalSetting = new GlobalSettingObject();
                foreach (FieldInfo fi in GlobalSetting.GetType().GetFields())
                {
                    foreach(JProperty p in o["PluginConfig"])
                    {
                        if(fi.Name == p.Name)
                        {
                            if(fi.FieldType == typeof(string))
                                GlobalSetting.GetType().GetField(fi.Name).SetValue(GlobalSetting, p.Value.ToString());
                            else if (fi.FieldType == typeof(int))
                                GlobalSetting.GetType().GetField(fi.Name).SetValue(GlobalSetting, int.Parse(p.Value.ToString()));
                            else if (fi.FieldType == typeof(bool))
                                GlobalSetting.GetType().GetField(fi.Name).SetValue(GlobalSetting, p.Value.ToString() == "True" ? true : false);
                        }
                    }
                }

                if (o["PluginConfig"]["Overlays"] != null)
                {
                    foreach (JProperty p in o["PluginConfig"]["Overlays"])
                    {
                        if (o["PluginConfig"]["Overlays"][p.Name] != null)
                        {
                            var so = new SettingObject();
                            foreach (FieldInfo fi in so.GetType().GetFields())
                            {
                                foreach(JProperty jo in o["PluginConfig"]["Overlays"][p.Name])
                                {
                                    if (fi.Name == jo.Name)
                                    {
                                        if (fi.FieldType == typeof(string))
                                            so.GetType().GetField(fi.Name).SetValue(so, jo.Value.ToString());
                                        else if (fi.FieldType == typeof(int))
                                            so.GetType().GetField(fi.Name).SetValue(so, int.Parse(jo.Value.ToString()));
                                        else if (fi.FieldType == typeof(bool))
                                            so.GetType().GetField(fi.Name).SetValue(so, jo.Value.ToString() == "True" ? true : false);
                                    }
                                }
                            }
                            OverlayController.OverlayConfigs.Add(p.Name, new OverlayTabPage(so.CreateOverlayConfig()));
                        }
                    }
                }
            }
            // LoadSettingJSON
        }
    }
}
