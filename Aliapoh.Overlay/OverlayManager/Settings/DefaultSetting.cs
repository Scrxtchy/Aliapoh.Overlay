using System.Windows.Forms;

namespace Aliapoh.Overlay
{
    public static class DefaultSetting
    {
        public static readonly GlobalSettingObject GlobalSettingObject = new GlobalSettingObject()
        {
            VersionAutoCheck = false,
            AutoHide = false,
            AutoClipping = false,
            ScreenshotSavePath = Application.ExecutablePath + "\\Screenshots",
            BackgroundImagePath = "",
            DetectProcessName = "ffxiv.exe, ffxiv_dx11.exe",
            BackgroundFillMode = 0,
            ScreenshotMargin = 0
        };

        public static readonly SettingObject SettingObject = new SettingObject()
        {
            Url = "about:blank",
            Show = true,
            Clickthru = false,
            Locked = false,
            UseGlobalHotkey = false,
            BeforeLogLineRead = false,
            Framerate = 30,
            Updaterate = 1000,
            Width = 400,
            Height = 300,
            Left = 15,
            Top = 15
        };
    }
}