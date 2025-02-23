﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;
    public AudioSource passos;
    bool isMoving;

    private Vector2 adjustOperation;

    public Animator playerMov;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //checo de o player esta se movendo e atribuo a booleana
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
            isMoving = true;
        else
            isMoving = false;
        //caso ele esteja se movendo
        if (isMoving)
        {
            //e o audio ainda n tiver tocando ele toca o audio
            if (!passos.isPlaying)
            {
                passos.Play();
            }
        }
        else
            passos.Stop();

    }
    void FixedUpdate() {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if (inputX != 0 && inputY != 0) {
         //   inputX *= 0.5f;
          //  inputY *= 0.5f;
        }
        playerMov.SetFloat("VelX", inputX);
        playerMov.SetFloat("VelY", inputY);

        adjustOperation = new Vector2(inputX * speed, inputY * speed);
        adjustOperation.Normalize();
        rb.velocity = adjustOperation*speed;
    }
}
