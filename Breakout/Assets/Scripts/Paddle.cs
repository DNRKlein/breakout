using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float paddleMovement;
    private Rigidbody2D rigidBody2D;

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private TouchController touchController;
   
    private float minX = -1.0f;
    private float maxX = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        calculateMinAndMaxX();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
        paddleMovement = Input.GetAxisRaw("Horizontal");
#endif

#if UNITY_ANDROID || UNITY_IOS
        paddleMovement = touchController.getMovementTouchRaw();
#endif
    }

    //called on physics step (default 50 times per second)
    //im moving the paddle in fixedupdate because it has a rigidbody and rigidbody works with physics
    //and thus should be done on the physics step
    void FixedUpdate() {
        Move();
    }

    //the screen is from -4 to 4 in world space. the minX and maxX is calculated from the middle of the paddle
    //so minX can be at most -4 + half of the paddle. By using the localScale.x we hold in account the possible scale powerup
    public void calculateMinAndMaxX() {
        minX = -4 + (gameObject.transform.localScale.x / 2);
        maxX = 4 - (gameObject.transform.localScale.x / 2);
    }


    private void Move() {
        calculateMinAndMaxX();
        Vector2 position = rigidBody2D.position + new Vector2(paddleMovement * moveSpeed, 0) * Time.fixedDeltaTime;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        rigidBody2D.MovePosition(position);
    }
}
