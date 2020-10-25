using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float paddleMovement;
    private Rigidbody2D rigidBody2D;

    [SerializeField]
    private float moveSpeed = 5.0f;
   
    private float minX = -1.0f;
    private float maxX = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        CalculateMinAndMaxX();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //called on physics step (default 50 times per second)
    //im moving the paddle in fixedupdate because it has a rigidbody and rigidbody works with physics
    //and thus should be done on the physics step
    void FixedUpdate() {
        Move();
    }

    public void StopMoving() {
        paddleMovement = 0;
    }

    public void MoveLeft() {
        paddleMovement = -1;
    }

    public void MoveRight() {
        paddleMovement = 1;
    }

    //the screen is from -4 to 4 in world space. the minX and maxX is calculated from the middle of the paddle
    //so minX can be at most -4 + half of the paddle. By using the localScale.x we hold in account the possible scale powerup
    public void CalculateMinAndMaxX() {
        minX = -4 + (gameObject.transform.localScale.x / 2);
        maxX = 4 - (gameObject.transform.localScale.x / 2);
    }
    
    private void Move() {
        CalculateMinAndMaxX();
        Vector2 position = rigidBody2D.position + new Vector2(paddleMovement * moveSpeed, 0) * Time.fixedDeltaTime;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        rigidBody2D.MovePosition(position);
    }
}
