using System;
using System.ComponentModel;
using BepInEx;
using Utilla;
using UnityEngine;

namespace iiMenu.Patches
{
	[Description(PluginInfo.Description)]
	[ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    //[BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.11")]
    public class HarmonyPatches : BaseUnityPlugin
	{
		public static bool iinRoom;

		private void OnEnable()
		{
			Menu.ApplyHarmonyPatches();
        }

		private void OnDisable()
		{
			Menu.RemoveHarmonyPatches();
		}

		private void Start()
		{
			Console.Title = "ii's Stupid Menu // Build "+PluginInfo.Version;

            GameObject Loading = new GameObject();
            Loading.AddComponent<iiMenu.UI.Main>();
            Loading.AddComponent<iiMenu.Notifications.NotifiLib>();
            DontDestroyOnLoad(Loading);
        }

		[ModdedGamemodeJoin]
		void OnJoin()
        {
            iinRoom = true;
        }

		[ModdedGamemodeLeave]
		void OnLeave()
		{
			iinRoom = false;
		}
	}
}
