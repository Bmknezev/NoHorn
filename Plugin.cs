using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using NoHorn.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHorn
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class NoHornBase : BaseUnityPlugin
    {
        private const string modGUID = "Poseidon.NoHorn";
        private const string modName = "No Loud Horn";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static NoHornBase Instance;

        internal ManualLogSource mls;



        void Awake()
        {
            if (Instance == null)
                Instance = this;

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The No Horn mod is online");

            harmony.PatchAll(typeof(NoHornBase));
            //harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll(typeof(ShipAlarmCordPatch));

        }


    }
}