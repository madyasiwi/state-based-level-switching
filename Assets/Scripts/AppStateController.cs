using UnityEngine;
using UnityEngine.SceneManagement;


namespace Madyasiwi.Game {


    public class AppStateController : MonoBehaviour {

        private static readonly string PREFAB_PATH = "Prefabs/AppStateController";


        [RuntimeInitializeOnLoadMethod]
        public static void Init() {
            SceneManager.sceneLoaded += (scene, mode) => {
                ValidateCurrentScene();
            };
            ValidateCurrentScene();
        }


        private static void ValidateCurrentScene() {
            var descriptor = GameObject.FindObjectOfType<SceneDescriptor>(true);
            if (descriptor == null) {
                return;
            }
            if (!descriptor.isManagedByAppState) {
                return;
            }
            Install();
        }


        public static void Install() {
            var instance = GameObject.FindObjectOfType<AppStateController>(true);
            if (instance != null) {
                // Already exists
                return;
            }
            var prefab = Resources.Load(PREFAB_PATH);
            if (prefab == null) {
                return;
            }
            var newInstance = Instantiate(prefab, null, true);
            newInstance.name = nameof(AppStateController);
            DontDestroyOnLoad(newInstance);
        }
    }
}
