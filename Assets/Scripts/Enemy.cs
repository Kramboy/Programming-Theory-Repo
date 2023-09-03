using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event EventHandler OnEnemyKilled;

    private Rigidbody rb;
    private readonly int deadLayerIndex = 6;
    private float speed = 1;
    private bool collided;
    private Vector3 movement;

    private void Awake()
    {
        collided = false;
        movement = -transform.forward;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(!collided)
        transform.Translate(speed * Time.deltaTime * movement);
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
         speed = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            collided = true;
            Die();
        }
        if (collision.collider.CompareTag("Player"))
        {
            movement *= -1;
            speed *= 10;
            Destroy(gameObject, 2f);
        }
    }

    private void Die()
    {
        OnEnemyKilled?.Invoke(this, EventArgs.Empty);
        rb.constraints = RigidbodyConstraints.None;
        gameObject.layer = deadLayerIndex;
        rb.useGravity = true;
        Destroy(gameObject, 5f);
    }
}
