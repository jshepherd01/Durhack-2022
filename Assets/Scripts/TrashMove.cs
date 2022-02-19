using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    private Vector3 StartPosition;
    private Rigidbody2D rb;

    void Start() {
        StartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnBecameInvisible() {
        transform.position = StartPosition;
        GetComponent<SpriteRenderer>().enabled = true;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0F;
    }
}
