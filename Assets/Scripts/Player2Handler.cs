﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Handler : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;
    private bool isGrounded;

    public GameManager manager;

    private void Awake()
    {
        rigidBody2d = transform.GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetMouseButton(1))
        {
            if((isGrounded) && Time.timeScale != 0)
            {
                SoundManager.Instance.Play(SoundManager.Sounds.Jump);
                rigidBody2d.velocity = new Vector3(0, -20, 0);
                isGrounded = false;
            }           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            SoundManager.Instance.Play(SoundManager.Sounds.Hit);
            manager.GameOver();
        }
    }
}
