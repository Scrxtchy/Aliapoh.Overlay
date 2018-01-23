using Advanced_Combat_Tracker;
using Aliapoh.Overlay;
using Aliapoh.Overlay.Logger;
using Aliapoh.Overlay.OverlayManager;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Initializer
{
    public class PluginLoader : IDisposable
    {
        public static string PluginDirectory;
        public static string CurrentUserName = "YOU";

        public IActPluginV1 Plugin;
        public OverlayController OverlayController;
        public TabPage PluginTabPage;
        public Label PluginStatusLabel;

        public void Dispose()
        {
            // Setting Save
            SettingManager.GenerateSettingJSON();
            // dispose OverlayController
            OverlayController.Dispose();
            // unregister handlers
            ActGlobals.oFormActMain.BeforeLogLineRead -= OFormActMain_BeforeLogLineRead;
            ActGlobals.oFormActMain.OnLogLineRead -= OFormActMain_OnLogLineRead;
            ActGlobals.oFormActMain.OnCombatEnd -= OFormActMain_OnCombatEnd;
            ActGlobals.oFormActMain.OnCombatStart -= OFormActMain_OnCombatStart;
            // shutdown CEF
            Cef.Shutdown();
        }

        public PluginLoader(TabPage tp, Label lbl, string pluginDirectory, IActPluginV1 plugin)
        {
            PluginDirectory = pluginDirectory;
            PluginTabPage = tp;
            PluginStatusLabel = lbl;
            AttachBeforeLogLineRead();
            ActGlobals.oFormActMain.OnLogLineRead += OFormActMain_OnLogLineRead;
            ActGlobals.oFormActMain.OnCombatEnd += OFormActMain_OnCombatEnd;
            ActGlobals.oFormActMain.OnCombatStart += OFormActMain_OnCombatStart;
        }

        private void AttachBeforeLogLineRead()
        {
            try
            {
                var Fields = ActGlobals.oFormActMain.GetType().GetField("BeforeLogLineRead", (BindingFlags)(4 | 8 | 16 | 32 | 1024));
                var oDelegate = (Delegate)Fields.GetValue(ActGlobals.oFormActMain);
                if (oDelegate != null)
                {
                    var Handlers = oDelegate.GetInvocationList();
                    foreach (var h in Handlers) ActGlobals.oFormActMain.BeforeLogLineRead -= (LogLineEventDelegate)h;
                    ActGlobals.oFormActMain.BeforeLogLineRead += OFormActMain_BeforeLogLineRead;
                    foreach (var h in Handlers) ActGlobals.oFormActMain.BeforeLogLineRead += (LogLineEventDelegate)h;
                }
            }
            catch(Exception ex)
            {
                LOG.Logger.Log(LogLevel.Error, ex.Message);
            }
        }

        private void OFormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {

        }

        private void OFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {

        }

        private void OFormActMain_OnCombatStart(bool isImport, CombatToggleEventArgs encounterInfo)
        {

        }

        private void OFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {

        }

        private void InitializeComponent()
        {
            OverlayController = new OverlayController()
            {
                Dock = DockStyle.Fill
            };
            PluginTabPage.Controls.Add(OverlayController);
        }
    }
}