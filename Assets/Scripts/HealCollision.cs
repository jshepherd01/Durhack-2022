using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCollision : MonoBehaviour
{
    [SerializeField] private int heal;
    [SerializeField] private bool vanish;
    [SerializeField] private Sprite used;
    public HealthController _healthController;

    private void OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.Heal(heal);
            if (vanish) {
                GetComponent<SpriteRenderer>().enabled = false;
            } else {
                GetComponent<SpriteRenderer>().sprite = used;
            }
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
