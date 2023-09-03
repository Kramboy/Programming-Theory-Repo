using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Weapon
{
    [SerializeField] private float speed;

    private Rigidbody rb;
    private bool collided;

    private void Awake()
    {
        collided = false;
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        if(!collided)
        Translate(speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collided = true;
        EnableRB();
    }

    private void EnableRB()
    {
        rb.useGravity = true;
    }
}
