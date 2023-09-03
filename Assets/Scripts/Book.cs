using UnityEngine;

public class Book : Weapon
{
    [SerializeField] private float speed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }
    private void Start()
    {
        rb.AddForce(transform.forward * 1000f, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = true;
        if (!collision.collider.CompareTag("Weapon") && collision.rigidbody != null)
        {
            rb.AddForce(-rb.velocity * 100, ForceMode.Impulse);
            collision.rigidbody.AddForce(rb.velocity, ForceMode.Impulse);
            EnableRB();
        }
    }

    private void EnableRB()
    {
        gameObject.layer = LayerMask.NameToLayer("Dead");
    }
}
