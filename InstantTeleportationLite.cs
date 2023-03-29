// InstantTeleportationLite, Valheim mod that changes how teleportation works
// Copyright (C) 2022 BurgersMcFly
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace InstantTeleportationLite
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class InstantTeleportationLite : BaseUnityPlugin
    {
        const string pluginGUID = "InstantTeleportationLite";
        const string pluginName = "Instant TeleportationLite";
        const string pluginVersion = "1.0.1";
        public static readonly Harmony harmony = new Harmony("InstantTeleportationLite");
        private static bool playerIsTeleporting = false;
        void Awake()
        {
            harmony.PatchAll();

        }
        void OnDestroy()
        {
            harmony.UnpatchSelf();
        }

        [HarmonyPatch(typeof(Player), "UpdateTeleport")]
        public static class TeleportationTweaks

        {
            private static void Prefix(ref bool ___m_teleporting, ref float dt, ref bool ___m_distantTeleport, ref float ___m_teleportCooldown)

            {

                playerIsTeleporting = ___m_teleporting;
                if (___m_teleporting && !___m_distantTeleport)
                {
                    dt = 16f;
                }

                if (!___m_teleporting && !___m_distantTeleport)
                {
                    ___m_teleportCooldown = 16f;
                }
            }
        }
    }
}

