using System;
using BepInEx;
using BepInEx.Logging;
using RoR2;

namespace more_purple_rain;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
	internal static new ManualLogSource Logger;

	const string PURPLE_RAIN_SONG_NAME = "muSong14";

	private void Awake() {
		// Plugin startup logic
		Logger = base.Logger;
		MusicController.pickTrackHook += (MusicController controller, ref MusicTrackDef newTrack) => {
			var mainTrack = SceneCatalog.mostRecentSceneDef.mainTrack;
			if (mainTrack.cachedName == PURPLE_RAIN_SONG_NAME && newTrack.cachedName != PURPLE_RAIN_SONG_NAME) {
				Logger.LogDebug("Continuing Sky Meadows main track...");
				newTrack = mainTrack;
			}
		};
	}
}
