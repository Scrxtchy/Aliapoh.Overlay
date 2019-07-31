using Aliapoh.Overlays.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Aliapoh.OverlayPlugin.Core
{
    [Serializable]
    public abstract class OverlayConfigBase : IOverlayConfig
    {
        public event EventHandler<VisibleStateChangedEventArgs> VisibleChanged;
        public event EventHandler<ThruStateChangedEventArgs> ClickThruChanged;
        public event EventHandler<UrlChangedEventArgs> UrlChanged;
        public event EventHandler<MaxFrameRateChangedEventArgs> MaxFrameRateChanged;
        public event EventHandler<GlobalHotkeyEnabledChangedEventArgs> GlobalHotkeyEnabledChanged;
        public event EventHandler<GlobalHotkeyChangedEventArgs> GlobalHotkeyChanged;
        public event EventHandler<GlobalHotkeyChangedEventArgs> GlobalHotkeyModifiersChanged;
        public event EventHandler<LockStateChangedEventArgs> LockChanged;
        public event EventHandler<GlobalHotkeyTypeChangedEventArgs> GlobalHotkeyTypeChanged;

        private GlobalHotkeyType globalHotkeyType;
        private Keys globalHotkeyModifiers;
        private Keys globalHotkey;
        private bool globalHotkeyEnabled;
        private bool isClickThru;
        private bool isLocked;
        private int maxFrameRate;
        private string url;

        [XmlElement("Name")]
        public string Name { get; set; }

        private bool isVisible;
        [XmlElement("IsVisible")]
        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    VisibleChanged?.Invoke(this, new VisibleStateChangedEventArgs(isVisible));
                }
            }
        }

        [XmlElement("IsClickThru")]
        public bool IsClickThru
        {
            get
            {
                return isClickThru;
            }
            set
            {
                if (isClickThru != value)
                {
                    isClickThru = value;
                    ClickThruChanged?.Invoke(this, new ThruStateChangedEventArgs(isClickThru));
                }
            }
        }

        [XmlElement("Position")]
        public Point Position { get; set; }

        [XmlElement("Size")]
        public Size Size { get; set; }

        [XmlElement("Url")]
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                if (url != value)
                {
                    url = value;
                    UrlChanged?.Invoke(this, new UrlChangedEventArgs(url));
                }
            }
        }
        
        [XmlElement("MaxFrameRate")]
        public int MaxFrameRate
        {
            get
            {
                return maxFrameRate;
            }
            set
            {
                if (maxFrameRate != value)
                {
                    maxFrameRate = value;
                    MaxFrameRateChanged?.Invoke(this, new MaxFrameRateChangedEventArgs(maxFrameRate));
                }
            }
        }

        [XmlElement("GlobalHotkeyEnabled")]
        public bool GlobalHotkeyEnabled
        {
            get
            {
                return globalHotkeyEnabled;
            }
            set
            {
                if (globalHotkeyEnabled != value)
                {
                    globalHotkeyEnabled = value;
                    GlobalHotkeyEnabledChanged?.Invoke(this, new GlobalHotkeyEnabledChangedEventArgs(globalHotkeyEnabled));
                }
            }
        }

        [XmlElement("GlobalHotkey")]
        public Keys GlobalHotkey
        {
            get
            {
                return globalHotkey;
            }
            set
            {
                if (globalHotkey != value)
                {
                    globalHotkey = value;
                    GlobalHotkeyChanged?.Invoke(this, new GlobalHotkeyChangedEventArgs(globalHotkey));
                }
            }
        }


        [XmlElement("GlobalHotkeyModifiers")]
        public Keys GlobalHotkeyModifiers
        {
            get
            {
                return globalHotkeyModifiers;
            }
            set
            {
                if (globalHotkeyModifiers != value)
                {
                    globalHotkeyModifiers = value;
                    GlobalHotkeyModifiersChanged?.Invoke(this, new GlobalHotkeyChangedEventArgs(globalHotkeyModifiers));
                }
            }
        }

        [XmlElement("GlobalHotkeyType")]
        public GlobalHotkeyType GlobalHotkeyType
        {
            get
            {
                return globalHotkeyType;
            }
            set
            {
                if (globalHotkeyType != value)
                {
                    globalHotkeyType = value;
                    GlobalHotkeyTypeChanged?.Invoke(this, new GlobalHotkeyTypeChangedEventArgs(globalHotkeyType));
                }
            }
        }

        [XmlElement("IsLocked")]
        public bool IsLocked
        {
            get
            {
                return isLocked;
            }
            set
            {
                if (isLocked != value)
                {
                    isLocked = value;
                    LockChanged?.Invoke(this, new LockStateChangedEventArgs(isLocked));
                }
            }
        }

        protected OverlayConfigBase(string name)
        {
            Name = name;
            IsVisible = true;
            IsClickThru = false;
            Position = new Point(20, 20);
            Size = new Size(300, 300);
            Url = "";
            MaxFrameRate = 30;
            globalHotkeyEnabled = false;
            GlobalHotkey = Keys.None;
            globalHotkeyModifiers = Keys.None;
            globalHotkeyType = GlobalHotkeyType.ToggleVisible;
        }

        [XmlIgnore]
        public abstract Type OverlayType { get; }
    }
}
