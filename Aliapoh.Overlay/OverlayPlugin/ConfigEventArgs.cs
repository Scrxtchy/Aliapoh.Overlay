using Aliapoh.OverlayPlugin.Core;
using System;
using System.Windows.Forms;

namespace Aliapoh.OverlayPlugin
{
    public class StateChangedEventArgs<T> : EventArgs
    {
        public T NewState { get; private set; }
        public StateChangedEventArgs(T newState)
        {
            NewState = newState;
        }
    }

    public class VisibleStateChangedEventArgs : EventArgs
    {
        public bool IsVisible { get; private set; }
        public VisibleStateChangedEventArgs(bool isVisible)
        {
            IsVisible = isVisible;
        }
    }

    public class ThruStateChangedEventArgs : EventArgs
    {
        public bool IsClickThru { get; private set; }
        public ThruStateChangedEventArgs(bool isClickThru)
        {
            IsClickThru = isClickThru;
        }
    }

    public class UrlChangedEventArgs : EventArgs
    {
        public string NewUrl { get; private set; }
        public UrlChangedEventArgs(string url)
        {
            NewUrl = url;
        }
    }

    public class SortTypeChangedEventArgs : EventArgs
    {
        public MiniParseSortType NewSortType { get; private set; }
        public SortTypeChangedEventArgs(MiniParseSortType newSortType)
        {
            NewSortType = newSortType;
        }
    }

    public class SortKeyChangedEventArgs : EventArgs
    {
        public string NewSortKey { get; private set; }
        public SortKeyChangedEventArgs(string newSortKey)
        {
            NewSortKey = newSortKey;
        }
    }

    public class MaxFrameRateChangedEventArgs : EventArgs
    {
        public int NewFrameRate { get; private set; }
        public MaxFrameRateChangedEventArgs(int frameRate)
        {
            NewFrameRate = frameRate;
        }
    }

    public class GlobalHotkeyEnabledChangedEventArgs : EventArgs
    {
        public bool NewGlobalHotkeyEnabled { get; private set; }
        public GlobalHotkeyEnabledChangedEventArgs(bool globalHotkeyEnabled)
        {
            NewGlobalHotkeyEnabled = globalHotkeyEnabled;
        }
    }

    public class GlobalHotkeyChangedEventArgs : EventArgs
    {
        public Keys NewHotkey { get; private set; }
        public GlobalHotkeyChangedEventArgs(Keys hotkey)
        {
            NewHotkey = hotkey;
        }
    }
    public class GlobalHotkeyTypeChangedEventArgs : EventArgs
    {
        public GlobalHotkeyType NewHotkeyType { get; private set; }
        public GlobalHotkeyTypeChangedEventArgs(GlobalHotkeyType newHotkeyType)
        {
            NewHotkeyType = newHotkeyType;
        }
    }

    public class LockStateChangedEventArgs : EventArgs
    {
        public bool IsLocked { get; private set; }
        public LockStateChangedEventArgs(bool isLocked)
        {
            IsLocked = isLocked;
        }
    }
}
