﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //References
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

 private void Update()
    { 
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //Flip animation lefright
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(9, 9, 9);
        }
        else if(horizontalInput < - 0.01f)
        {
            transform.localScale = new Vector3(-9, 9, 9);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //Set animator parameters

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground");
        grounded = true;
    }
}