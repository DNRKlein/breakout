using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float paddleMovement;
    private Rigidbody2D rigidBody2D;

    [SerializeField]
    private float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        paddleMovement = Input.GetAxisRaw("Horizontal");
    }

    //called on physics step (default 50 times per second)
    void FixedUpdate() {
        rigidBody2D.MovePosition(rigidBody2D.position + new Vector2(paddleMovement*moveSpeed,0) * Time.fixedDeltaTime);
    }
}
