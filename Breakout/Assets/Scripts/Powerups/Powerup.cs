using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //When colliding with the paddle it needs to apply it's powerup to the paddle
    private void OnTriggerEnter2D(Collider2D collision) {
        if("Paddle".Equals(collision.gameObject.tag)) {
            applyPowerup(collision.gameObject);
            Destroy(gameObject);
        }
    }

    protected abstract void applyPowerup(GameObject gameObject);
}
