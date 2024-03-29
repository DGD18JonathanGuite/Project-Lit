﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        rb.AddForce(movement * speed);
    }
}
