using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    private Vector3 StartPosition;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Sprite normal;

    void Start() {
        StartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        normal = sr.sprite;
    }

    void OnBecameInvisible() {
        transform.position = StartPosition;
        sr.sprite = normal;
        GetComponent<BoxCollider2D>().enabled = true;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0F;
    }
}
