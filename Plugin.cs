using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalTestMod.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalTestMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "502944.TestMod";
        private const string modName = "TestMod";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static Plugin? instance;

        internal ManualLogSource? mls;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("------------------------------");
            mls.LogInfo("The test mod has awakened!");
            mls.LogInfo("------------------------------");

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
