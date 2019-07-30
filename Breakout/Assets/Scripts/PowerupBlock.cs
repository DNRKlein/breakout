using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBlock : MonoBehaviour
{
    Level level;
    [SerializeField] private AudioClip destroyAudioClip;
    [SerializeField] private GameObject powerup;
     
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        level.AddBreakableBlockToTotal();
    }

    //This is a collision because the ball has a rigidbody and the block is not a trigger
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Equals("Ball")) {
            //we use PlayClipAtPoint which creates a temporary AudioSource, since we cannot define an AudioSource
            //on the Block. The Block will be destroyed and with it the AudioSource, therefore we need a temporary AudioSource,
            //which is destroyed after playing the clip once
            AudioSource.PlayClipAtPoint(destroyAudioClip, Camera.main.transform.position);

            level.DecreaseBreakableBlocks();

            //Launches the powerup which will fall with gravity and instantiate it at the position of the block
            Debug.Log("Instantiate :" + powerup.name);
            //instantiate the powerup at the position of this block
            Instantiate(powerup, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

}
