using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool vanish;
    public HealthController _healthController;

    private void OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.DoDamage(damage);
            if (vanish) {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
