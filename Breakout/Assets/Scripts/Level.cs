using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    int breakableBlocks;
    LevelManager levelManager;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void AddBreakableBlockToTotal() {
        breakableBlocks++;
    }

    public void DecreaseBreakableBlocks() {
        breakableBlocks--;
        
        if(breakableBlocks <= 0) {
            levelManager.LoadNextScene();
        }
    }
}
