using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor;

namespace Madyasiwi.Game {


    public class AppStateController : MonoBehaviour {

        [SerializeField]
        public static string someValue;


        [RuntimeInitializeOnLoadMethod]
        private static void Init() {
            // Instantiate self
            var prefab = Resources.Load("Prefabs/AppStateController");
            if (prefab != null) {
                var instance = Instantiate(prefab, null, true);
                instance.name = nameof(AppStateController);
                DontDestroyOnLoad(instance);
            }
        }
    }
}
