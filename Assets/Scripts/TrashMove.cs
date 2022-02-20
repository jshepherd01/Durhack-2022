using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    private Vector3 StartPosition;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private Sprite normal;

    void Start() {
        StartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        normal = sr.sprite;
    }

    void Update() {
        if (transform.position.y < -5) {
            transform.position = StartPosition;
            sr.sprite = normal;
            if (bc != null) {
                GetComponent<BoxCollider2D>().enabled = true;
            }
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0.0F;
        }
    }
}
