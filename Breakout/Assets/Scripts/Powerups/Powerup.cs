using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{

    private bool applied = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //When colliding with the paddle it needs to apply it's powerup to the paddle
    //when it didnt collide with the paddle but collides with the loseCollider it needs to be destroyed
    //this prevents the gameObject living forever because it isnt being destroyed from the coroutine
    private void OnTriggerEnter2D(Collider2D collision) {
        if("Paddle".Equals(collision.gameObject.tag)) {
            applied = true;
            StartCoroutine(applyPowerupForSecondsCoroutine(collision.gameObject));
        } else if("LoseCollider".Equals(collision.gameObject.tag) && !applied) {
            Destroy(gameObject);
        }
    }

    //Coroutine to apply the powerup, wait for the amount of seconds the powerup is allowed to be applied
    //and then undo the powerup. Destroy is added to this coroutine because adding it to onTriggerEnter after starting the coroutine
    //will make the coroutine start and while we wait for x seconds control is given back so it starts to destroy the gameObject
    IEnumerator applyPowerupForSecondsCoroutine(GameObject gameObjectToApply) {
        Debug.Log("Applying powerup");
        applyPowerup(gameObjectToApply);
        yield return new WaitForSeconds(getPowerupTime());
        Debug.Log("Undoing powerup");
        undoPowerup(gameObjectToApply);
        Debug.Log("Destroying powerup gameobject");

        Destroy(gameObject);
    }

    protected abstract void applyPowerup(GameObject gameObject);

    protected abstract void undoPowerup(GameObject gameObject);

    protected abstract float getPowerupTime();
}
