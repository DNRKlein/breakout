using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadNextScene() {
        //Get the buildIndex of the current scene and load the next scene by upping the buildIndex by 1
        //This goes wrong if the scenes arent added in the right order in the buildindex
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadSceneByName(string name) {
        SceneManager.LoadScene(name);
    }

    public void Quit() {
        Application.Quit();
    }
}
