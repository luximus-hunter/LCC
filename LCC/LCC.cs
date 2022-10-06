using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using LCC.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace LCC
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class LCC : BaseUnityPlugin
    {
        private const string ModId = "lxms.rounds.lcc";
        private const string ModName = "Lux' Custom Cards";
        public const string ModInitials = "LCC";
        public const string Version = "0.0.1";
        
        public static LCC instance { get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            Harmony harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;

            CustomCard.BuildCard<MyCardName>();
        }
    }
}
