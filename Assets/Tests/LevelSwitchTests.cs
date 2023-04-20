using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Madyasiwi.Game;


public class LevelSwitchTests {


    [UnityTest, Order(100)]
    public IEnumerator AutoSwitchTest() {
        // Set to the default value
        Variables.Application.Set("isResourceLoaded", false);
        // Wait for application variable to be "flushed"
        yield return null;
        SceneManager.LoadSceneAsync("Level");
        yield return new WaitForSeconds(.5f);
        Assert.AreEqual("Loading", SceneManager.GetActiveScene().name);
    }


    [UnityTest, Order(200)]
    public IEnumerator PreloadTest() {
        // Mark resource as loaded
        Variables.Application.Set("isResourceLoaded", true);
        // Wait for application variable to be "flushed"
        yield return null;
        SceneManager.LoadSceneAsync("Level");
        yield return new WaitForSeconds(.5f);
        Assert.AreEqual("Level", SceneManager.GetActiveScene().name);
    }


    [UnityTest, Order(300)]
    public IEnumerator LoadingTest() {
        // Set to the default value
        Variables.Application.Set("isResourceLoaded", false);
        // Wait for application variable to be "flushed"
        yield return null;
        SceneManager.LoadSceneAsync("Loading");
        yield return new WaitForSeconds(.5f);
        Assert.AreEqual("Loading", SceneManager.GetActiveScene().name);
    }
}

