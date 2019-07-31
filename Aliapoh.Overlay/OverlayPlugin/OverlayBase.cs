using Aliapoh.OverlayPlugin.Core;
using Aliapoh.Overlays;
using Aliapoh.Overlays.Common;
using Aliapoh.Overlays.GlobalHook;
using Aliapoh.Overlays.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.OverlayPlugin
{
    public abstract class OverlayBase<TConfig> : IOverlay where TConfig : OverlayConfigBase
    {
        private KeyboardHook hook = new KeyboardHook();
        protected System.Timers.Timer timer;
        protected System.Timers.Timer xivWindowTimer;

        public event EventHandler<LogEventArgs> OnLog;

        public string Name { get; private set; }

        public OverlayForm Overlay { get; private set; }

        public TConfig Config { get; private set; }

        public IPluginConfig PluginConfig { get; set; }

        protected OverlayBase(TConfig config, string name)
        {
            Config = config;
            Name = name;

            InitializeOverlay();
            InitializeTimer();
            InitializeConfigHandlers();
        }

        public void Start()
        {
            timer.Start();
            xivWindowTimer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            xivWindowTimer.Stop();
        }

        protected virtual void InitializeOverlay()
        {
            try
            {
                // FIXME: is this *really* correct way to get version of current assembly?
                Overlay = new OverlayForm(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), Name, "about:blank", Config.MaxFrameRate);

                // グローバルホットキーを設定
                if (Config.GlobalHotkeyEnabled)
                {
                    var modifierKeys = GetModifierKey(Config.GlobalHotkeyModifiers);
                    var key = Config.GlobalHotkey;
                    var hotkeyType = Config.GlobalHotkeyType;
                    if (key != Keys.None)
                    {
                        switch (hotkeyType)
                        {
                            case GlobalHotkeyType.ToggleVisible:
                                hook.KeyPressed += (o, e) => Config.IsVisible = !Config.IsVisible;
                                break;
                            case GlobalHotkeyType.ToggleClickthru:
                                hook.KeyPressed += (o, e) => Config.IsClickThru = !Config.IsClickThru;
                                break;
                            case GlobalHotkeyType.ToggleLock:
                                hook.KeyPressed += (o, e) => Config.IsLocked = !Config.IsLocked;
                                break;
                            default:
                                hook.KeyPressed += (o, e) => Config.IsVisible = !Config.IsVisible;
                                break;
                        }

                        hook.RegisterHotKey(modifierKeys, key);
                    }
                }

                // 画面外にウィンドウがある場合は、初期表示位置をシステムに設定させる
                if (!Util.IsOnScreen(Overlay))
                {
                    Overlay.StartPosition = FormStartPosition.WindowsDefaultLocation;
                }
                else
                {
                    Overlay.Location = Config.Position;
                }

                Overlay.Text = Name;
                Overlay.Size = Config.Size;
                Overlay.IsClickThru = Config.IsClickThru;

                // イベントハンドラを設定
                Overlay.Browser.LoadError += (o, e) =>
                {
                    Log(LogLevel.Error, "BrowserError: {0}, {1}, {2}", e.ErrorCode, e.ErrorText, e.FailedUrl);
                };
                Overlay.Browser.FrameLoadEnd += (o, e) =>
                {
                    Log(LogLevel.Debug, "BrowserLoad: {0}: {1}", e.HttpStatusCode, e.Url);
                    NotifyOverlayState();
                };
                Overlay.Browser.ConsoleMessage += (o, e) =>
                {
                    Log(LogLevel.Info, "BrowserConsole: {0} (Source: {1}, Line: {2})", e.Message, e.Source, e.Line);
                };
                Config.UrlChanged += (o, e) =>
                {
                    Navigate(e.NewUrl);
                };

                if (CheckUrl(Config.Url))
                {
                    Navigate(Config.Url);
                }
                else
                {
                    Navigate("about:blank");
                }

                Overlay.Show();
                Overlay.Visible = Config.IsVisible;
                Overlay.Locked = Config.IsLocked;
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "InitializeOverlay: {0}", Name, ex);
            }
        }

        private ModifierKeys GetModifierKey(Keys modifier)
        {
            ModifierKeys modifiers = new ModifierKeys();
            if ((modifier & Keys.Shift) == Keys.Shift)
            {
                modifiers |= ModifierKeys.Shift;
            }
            if ((modifier & Keys.Control) == Keys.Control)
            {
                modifiers |= ModifierKeys.Control;
            }
            if ((modifier & Keys.Alt) == Keys.Alt)
            {
                modifiers |= ModifierKeys.Alt;
            }
            if ((modifier & Keys.LWin) == Keys.LWin || (modifier & Keys.RWin) == Keys.RWin)
            {
                modifiers |= ModifierKeys.Win;
            }
            return modifiers;
        }

        private bool CheckUrl(string url)
        {
            try
            {
                var uri = new System.Uri(url);

                if (uri.Scheme == "file")
                {
                    if (!File.Exists(uri.LocalPath))
                    {
                        Log(LogLevel.Warning,
                            "InitializeOverlay: Local file {0} does not exist!",
                            uri.LocalPath);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // URL パースエラー
                Log(LogLevel.Error,
                    "InitializeOverlay: URI parse error! Please reconfigure the URL. (Config.Url = {0}): {1}",
                    Config.Url,
                    ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// タイマーを初期化します。
        /// </summary>
        protected virtual void InitializeTimer()
        {
            timer = new System.Timers.Timer
            {
                Interval = 1000
            };
            timer.Elapsed += (o, e) =>
            {
                try
                {
                    Update();
                }
                catch (Exception ex)
                {
                    Log(LogLevel.Error, "Update: {0}", ex.ToString());
                }
            };

            xivWindowTimer = new System.Timers.Timer
            {
                Interval = 1000
            };
            xivWindowTimer.Elapsed += (o, e) =>
            {
                try
                {
                    if (Config.IsVisible && PluginConfig.HideOverlaysWhenNotActive)
                    {
                        var hWndFg = NativeMethods.GetForegroundWindow();
                        if (hWndFg == IntPtr.Zero)
                        {
                            return;
                        }
                        NativeMethods.GetWindowThreadProcessId(hWndFg, out uint pid);
                        var exePath = Process.GetProcessById((int)pid).MainModule.FileName;

                        if (Path.GetFileName(exePath.ToString()) == "ffxiv.exe" ||
                            Path.GetFileName(exePath.ToString()) == "ffxiv_dx11.exe" ||
                            exePath.ToString() == Process.GetCurrentProcess().MainModule.FileName)
                        {
                            Overlay.Visible = true;
                        }
                        else
                        {
                            Overlay.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log(LogLevel.Error, "XivWindowWatcher: {0}", ex.ToString());
                }
            };
        }

        /// <summary>
        /// 設定クラスのイベントハンドラを設定します。
        /// </summary>
        protected virtual void InitializeConfigHandlers()
        {
            Config.VisibleChanged += (o, e) =>
            {
                Overlay.Visible = e.IsVisible;
            };

            Config.ClickThruChanged += (o, e) =>
            {
                Overlay.IsClickThru = e.IsClickThru;
            };
            Config.LockChanged += (o, e) =>
            {
                Overlay.Locked = e.IsLocked;
                NotifyOverlayState();
            };
        }

        /// <summary>
        /// オーバーレイを更新します。
        /// </summary>
        protected abstract void Update();

        /// <summary>
        /// オーバーレイのインスタンスを破棄します。
        /// </summary>
        public virtual void Dispose()
        {
            try
            {
                if (timer != null)
                {
                    timer.Stop();
                }
                if (xivWindowTimer != null)
                {
                    xivWindowTimer.Stop();
                }
                if (Overlay != null)
                {
                    Overlay.Close();
                    Overlay.Dispose();
                }
                if (hook != null)
                {
                    hook.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "Dispose: {0}", ex);
            }
        }

        public virtual void Navigate(string url)
        {
            Overlay.Url = url;
        }

        protected void Log(LogLevel level, string message)
        {
            OnLog?.Invoke(this, new LogEventArgs(level, string.Format("{0}: {1}", Name, message)));
        }

        protected void Log(LogLevel level, string format, params object[] args)
        {
            Log(level, string.Format(format, args));
        }


        public void SavePositionAndSize()
        {
            Config.Position = Overlay.Location;
            Config.Size = Overlay.Size;
        }

        private void NotifyOverlayState()
        {
            var updateScript = string.Format(
                "document.dispatchEvent(new CustomEvent('onOverlayStateUpdate', {{ detail: {{ isLocked: {0} }} }}));",
                Config.IsLocked ? "true" : "false");

            if (Overlay != null &&
                Overlay.Browser != null)
            {
                Overlay.ExecuteScript(updateScript);
            }
        }

        public void SendMessage(string message)
        {
            var script = string.Format(
                "document.dispatchEvent(new CustomEvent('onBroadcastMessageReceive', {{ detail: {{ message: \"{0}\" }} }}));",
                Util.CreateJsonSafeString(message));

            if (Overlay != null &&
                Overlay.Browser != null)
            {
                Overlay.ExecuteScript(script);
            }
        }

        public virtual void OverlayMessage(string message)
        {
        }
    }
}
