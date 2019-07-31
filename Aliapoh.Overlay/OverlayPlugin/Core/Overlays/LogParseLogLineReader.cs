using Advanced_Combat_Tracker;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Aliapoh.OverlayPlugin.Core.Overlays
{
    partial class LogParseOverlay : OverlayBase<LogParseOverlayConfig>
    {
        // Part of FFXIV_ACT_Plugin (v 1.7.2.14)
        public enum MessageType
        {
            Unknown = -1,
            LogLine = 0,
            ChangeZone = 1,
            ChangePrimaryPlayer = 2,
            AddCombatant = 3,
            RemoveCombatant = 4,
            AddBuff = 5,
            RemoveBuff = 6,
            FlyingText = 7,
            OutgoingAbility = 8,
            IncomingAbility = 10,
            PartyList = 11,
            PlayerStats = 12,
            CombatantHP = 13,
            NetworkStartsCasting = 20,
            NetworkAbility = 21,
            NetworkAOEAbility = 22,
            NetworkCancelAbility = 23,
            NetworkDoT = 24,
            NetworkDeath = 25,
            NetworkBuff = 26,
            NetworkTargetIcon = 27,
            NetworkRaidMarker = 28,
            NetworkTargetMarker = 29,
            NetworkBuffRemove = 30,
            Debug = 251,
            PacketDump = 252,
            Version = 253,
            Error = 254,
            Timer = 255
        }

        private void LogLineReader(bool isImported, LogLineEventArgs e)
        {
            if (isImported)
            {
                return;
            }
            try
            {
                string[] chunk = e.logLine.Split(new[] { '|' });

                if (chunk.Length < 3) // DataErr0r
                {
                    return;
                }

                if (Overlay != null &&
                Overlay != null &&
                Overlay.Browser != null)
                {
                    JObject message = new JObject();
                    message["opcode"] = Convert.ToInt32(chunk[0]);
                    message["timestamp"] = chunk[1];
                    message["payload"] = JArray.FromObject(chunk.Skip(2));
                    Overlay.ExecuteScript(
                        "document.dispatchEvent(new CustomEvent('onLogLine', { detail: " + message.ToString() + " } ));"
                    );
                }
            }
            catch { }
        }
    }
}
