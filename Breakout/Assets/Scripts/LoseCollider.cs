using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();    
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        levelManager.LoadSceneByName("GameOver");
    }
}
