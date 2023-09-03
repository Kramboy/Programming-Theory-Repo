using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Lives { get; private set; }

    private void Start()
    {
        Lives = 3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Lives -= 1;
        }
    }
}
