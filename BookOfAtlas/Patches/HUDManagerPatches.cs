using BookOfAtlas.MonoBehaviours;
using HarmonyLib;
using UnityEngine;

namespace BookOfAtlas.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch("PingScan_performed")]
        private static void NotifyScanSerpens()
        {
            // Alert serpens that a player scanned.
            if (GameNetworkManager.Instance.localPlayerController != null)
            {
                foreach (SerpensAI serpens in SerpensAI.activeSerpens)
                {
                    // Make sure the serpens does in fact exist just in case something removes it and doesn't clear the list.
                    serpens?.PlayerScan(GameNetworkManager.Instance.localPlayerController);
                }
            }
        }
    }
}
