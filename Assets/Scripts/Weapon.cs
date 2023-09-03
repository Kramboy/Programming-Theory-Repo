using UnityEngine;

// INHERITANCE
public abstract class Weapon : MonoBehaviour
{
    protected virtual void Impulse(Rigidbody rigidbody, float forceMagnitude)
    {
        rigidbody.AddForce(transform.forward * forceMagnitude, ForceMode.Impulse);
    }
}
