using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Madyasiwi.Game;


public class LevelSwitchTests {


    [SetUp]
    public void SetUp() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        var varName = "isResourceLoaded";
        Variables.Application.Set(varName, true);
        Variables.Application.Serialize();
    }


    [TearDown]
    public void TearDown() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log($"Scene {scene.name} loaded");
    }


    [UnityTest]
    public IEnumerator LevelSwitchPreloadTest() {
        bool sceneLoaded = false;
        SceneManager.sceneLoaded += (scene, mode) => {
            sceneLoaded = true;
        };
        var sceneName = "Level";
        SceneManager.LoadScene(sceneName);
        while (!sceneLoaded) {
            yield return null;
        }
        Assert.AreEqual("Level", SceneManager.GetActiveScene().name);
    }


    [UnityTest]
    public IEnumerator LevelSwitchTest2() {
        bool sceneLoaded = false;
        SceneManager.sceneLoaded += (scene, mode) => {
            sceneLoaded = true;
        };
        var sceneName = "Level";
        SceneManager.LoadScene(sceneName);
        while (!sceneLoaded) {
            yield return null;
        }
        Assert.AreEqual("Loading", SceneManager.GetActiveScene().name);
    }
}

