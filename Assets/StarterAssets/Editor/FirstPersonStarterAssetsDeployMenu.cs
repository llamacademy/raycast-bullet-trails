using System.Linq;
using UnityEditor;
using UnityEngine;

namespace StarterAssets
{
    public partial class StarterAssetsDeployMenu : ScriptableObject
    {
        // prefab paths
        private const string FirstPersonPrefabPath = "/FirstPersonController/Prefabs/";

#if STARTER_ASSETS_PACKAGES_CHECKED
        /// <summary>
        /// Check the capsule, main camera, cinemachine virtual camera, camera target and references
        /// </summary>
        [MenuItem(MenuRoot + "/Reset First Person Controller", false)]
        static void ResetFirstPersonControllerCapsule()
        {
            var firstPersonControllers = FindObjectsOfType<FirstPersonController>();
            var player = firstPersonControllers.FirstOrDefault(controller => controller.CompareTag(PlayerTag));
            GameObject playerGameObject;
            
            // player
            if (player == null)
                HandleInstantiatingPrefab(StarterAssetsPath + FirstPersonPrefabPath,
                    PlayerCapsulePrefabName, out playerGameObject);
            else
                playerGameObject = player.gameObject;

            // cameras
            CheckCameras(FirstPersonPrefabPath, playerGameObject.transform);
        }
#endif
    }
}