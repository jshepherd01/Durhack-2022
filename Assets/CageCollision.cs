using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageCollision : MonoBehaviour
{
    public Sprite opened;

    private void OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            GetComponent<SpriteRenderer>().sprite = opened;
            // and end the demo
        }
    }
}
