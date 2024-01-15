using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using InfiniteSprint.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteSprint
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class InfiniteSprintMod : BaseUnityPlugin
    {
        private const string modGUID = "SteveModders.InfiniteSprintMod";
        private const string modName = "InfiniteSprint";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static InfiniteSprintMod instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (instance == null) { instance = this; }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Awake() for " + modName + " called!");

            harmony.PatchAll(typeof(InfiniteSprintMod));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
