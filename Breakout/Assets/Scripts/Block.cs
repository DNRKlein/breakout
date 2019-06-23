using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private int health = 1;

    //This is a collision because the ball has a rigidbody and the block is not a trigger
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Equals("Ball")) {
            Destroy(gameObject);
        }
    }
}
