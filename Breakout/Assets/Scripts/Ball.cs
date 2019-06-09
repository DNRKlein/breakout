﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config params
    [SerializeField] private Paddle paddle;

    //State
    private Vector2 paddleToBallVector;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        Debug.Log("Ball" + transform.position.x + ", " + transform.position.y);
        Debug.Log("Paddle" + paddle.transform.position.x + ", " + paddle.transform.position.y);
    }
}
