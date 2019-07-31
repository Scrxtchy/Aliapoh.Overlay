using Aliapoh.Overlays.Logger;
using System;

namespace Aliapoh.Overlays.Common
{
    public interface IOverlay : IDisposable
    {
        string Name { get; }
        IPluginConfig PluginConfig { get; set; }
        event EventHandler<LogEventArgs> OnLog;
        void Start();
        void Stop();
        void Navigate(string url);
        void SavePositionAndSize();
        void SendMessage(string message);
        void OverlayMessage(string message);
    }
}
