﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to solve ambiguous class references you can do this:
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    //Config params
    [SerializeField] private Paddle paddle;
    [SerializeField] private float verticalSpeed = 10f;
    [SerializeField] AudioClip[] audioClips;

    //State
    private Vector2 paddleToBallVector;

    //components
    private Rigidbody2D rigidbody2D;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        LockBallToPaddle();
    }

    //We're giving the ball a velocity which makes sense to me, since you just want it to move on it's own and not move it
    //by constantly setting its transform.position
    public void Launch() {
        float x = Random.Range(-3f, 3f);
        rigidbody2D.velocity = new Vector2(x, verticalSpeed);     
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    //collision because ball has rigidbody
    private void OnCollisionEnter2D(Collision2D collision) {
        //this plays the audioclip set at the audiosource in the editor
        PlayRandomHitSound();
    }

    private void PlayRandomHitSound() {
        AudioClip clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.PlayOneShot(clip);
    }
}
