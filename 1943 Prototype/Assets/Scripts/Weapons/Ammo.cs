using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

}
