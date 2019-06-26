using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int currentHealth = 1;
    [SerializeField] private AudioClip destroyAudioClip;
    private Sprite fullBlockSprite;
    private Sprite damagedBlockSprite;

    //reference to our level script
    Level level;

    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //assets loaded via this way need to be in a folder called Resources. That folder can be anywhere within the assets folder
        //and can be a subfolder, so for instance Sprites/Resources is valid, I think the uppercase R is important
        //Haven't tried yet if it really is important
        fullBlockSprite = Resources.Load<Sprite>("Sprites/block");
        damagedBlockSprite = Resources.Load<Sprite>("Sprites/brokenblock");
        DetermineSprite();

        //finds the level script in the scene
        level = FindObjectOfType<Level>();
        level.AddBreakableBlockToTotal();
    }

    //This is a collision because the ball has a rigidbody and the block is not a trigger
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Equals("Ball")) {
            currentHealth--;
            if(currentHealth <= 0) {
                //we use PlayClipAtPoint which creates a temporary AudioSource, since we cannot define an AudioSource
                //on the Block. The Block will be destroyed and with it the AudioSource, therefore we need a temporary AudioSource,
                //which is destroyed after playing the clip once
                AudioSource.PlayClipAtPoint(destroyAudioClip, Camera.main.transform.position);

                level.DecreaseBreakableBlocks();
                Destroy(gameObject);
            }
            DetermineSprite();
        }
    }

    //determines which sprite needs to be rendered based on the currentHealth
    private void DetermineSprite() {
        if(currentHealth == 2) {
            spriteRenderer.sprite = fullBlockSprite;
        }
        else if(currentHealth == 1) {
            spriteRenderer.sprite = damagedBlockSprite;
        }
    }
}
