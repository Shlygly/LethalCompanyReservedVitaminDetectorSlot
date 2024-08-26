using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ReservedItemSlotCore.Data;

namespace ReservedVitaminDetectorSlot
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency(ReservedItemSlotCore.PluginInfo.PLUGIN_GUID, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(JuicesMod.MyPluginInfo.PLUGIN_GUID, BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;
        internal static Harmony? Harmony { get; set; }

        private void Awake()
        {
            Logger = base.Logger;
            Instance = this;

            ReservedItemSlotData vitaminDetectorSlotData = ReservedItemSlotData.CreateReservedItemSlotData("vitamin_detector_item_slod");
            ReservedItemData vitaminDetectorData = new ReservedItemData(JuicesMod.Plugin.instance.VitaminDetector.itemName);
            vitaminDetectorSlotData.AddItemToReservedItemSlot(vitaminDetectorData);

            Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
        }
    }
}
