using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player player;
    private Rigidbody rb;
    private NavMeshAgent agent;
    private readonly int deadLayerIndex = 6;
    private bool collided;
    private float speed = 1f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        collided = false;
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<Player>();
    }

    private void Start()
    {
        agent.speed = speed;
    }

    private void Update()
    {
        if (!collided)
            agent.SetDestination(player.transform.position);
        if (transform.position.z < -10) Destroy(gameObject);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
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
            agent.SetDestination((transform.position - player.transform.position).normalized);
            agent.speed *= 10;
            Destroy(gameObject, 2f);
        }
    }

    private void Die()
    {
        Destroy(agent);
        rb.constraints = RigidbodyConstraints.None;
        gameObject.layer = deadLayerIndex;
        rb.useGravity = true;
        Destroy(gameObject, 5f);
    }
}
