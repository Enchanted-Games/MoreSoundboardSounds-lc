using System.IO;

using BepInEx;

using HarmonyLib;
using BepInEx.Logging;

using UnityEngine;
using MemeSoundboard;

namespace MoreSoundboardSounds
{
    public static class PluginInfo
    {
        public const string PLUGIN_ID = "MoreSoundboardSounds";
        public const string PLUGIN_NAME = "MoreSoundboardSounds";
        public const string PLUGIN_VERSION = "1.0.0";
        public const string PLUGIN_GUID = "games.enchanted.MoreSoundboardSounds";
    }

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; }

        public ManualLogSource PluginLogger;

        private void Awake()
        {
            Instance = this;

            PluginLogger = Logger;

            // Apply Harmony patches (if any exist)
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            // Plugin startup logic
            PluginLogger.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} ({PluginInfo.PLUGIN_GUID}) has been summoned!");
            LoadSounboardSounds();
        }

        private void LoadSounboardSounds()
        {
            string text = Path.Combine(Path.GetDirectoryName(((BaseUnityPlugin)this).Info.Location), "mss-sounds");
            Assets.LoadAssetBundle(text);
            AssetBundle bundle = Assets.GetBundle();

            string soundPrefix = "[mss] ";

            MemeSoundboardBase.AddNewSound(soundPrefix + "GET OUT", bundle.LoadAsset<AudioClip>("getout"));
            MemeSoundboardBase.AddNewSound(soundPrefix + "theres an impostor among us", bundle.LoadAsset<AudioClip>("impostor"));
            MemeSoundboardBase.AddNewSound(soundPrefix + "AHHH HAELP HAELP HAELP", bundle.LoadAsset<AudioClip>("haelp"));
            MemeSoundboardBase.AddNewSound(soundPrefix + "WAIT WAIT WAIT", bundle.LoadAsset<AudioClip>("wait_wait_wait_wat_da_hell"));
            MemeSoundboardBase.AddNewSound(soundPrefix + "keydrop.mp3", bundle.LoadAsset<AudioClip>("keydrop"));
            MemeSoundboardBase.AddNewSound(soundPrefix + "although for one of you...", bundle.LoadAsset<AudioClip>("although_for_one_of_you"));
            MemeSoundboardBase.AddNewSound(soundPrefix + "skidaddle", bundle.LoadAsset<AudioClip>("goofy_run"));
            MemeSoundboardBase.AddNewSound(soundPrefix + "YOU'LL NEVER SEE IT COMING", bundle.LoadAsset<AudioClip>("you_never_see_it_coming"));
            MemeSoundboardBase.AddNewSound(soundPrefix + "to be continued...", bundle.LoadAsset<AudioClip>("to_be_continued"));

            PluginLogger.LogInfo($"{PluginInfo.PLUGIN_NAME} ({PluginInfo.PLUGIN_GUID}) has successfully added sounds!");
        }
    }
}
