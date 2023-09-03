using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    protected virtual void Translate(float speed)
    {
        transform.Translate(speed * Time.deltaTime * transform.forward);
    }
}
