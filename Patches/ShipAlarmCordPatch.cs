using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHorn.Patches
{
    [HarmonyPatch(typeof(ShipAlarmCord))]
    internal class ShipAlarmCordPatch
    {
        private static Random random = new Random();
        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        static void hornCheckPatch(ref bool ___localClientHoldingCord)
        {
            if (___localClientHoldingCord)
            {

                if (random.Next(0,1000) == 2)
                {
                    PlayerControllerB player = StartOfRound.Instance.localPlayerController;
                    player.DamagePlayer(100, hasDamageSFX: true, callRPC: true, CauseOfDeath.Unknown);
                }
            }

        }
        /*
        [HarmonyPatch("HoldCordDown")]
        [HarmonyPrefix]
        public static bool Prefix()
        {
            PlayerControllerB player = StartOfRound.Instance.localPlayerController;
            player.DamagePlayer(100, hasDamageSFX: true, callRPC: true, CauseOfDeath.Unknown);
            return false;
        }
        */
    }
}
