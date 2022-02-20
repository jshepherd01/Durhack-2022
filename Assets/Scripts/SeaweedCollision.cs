using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedCollision : MonoBehaviour
{
    [SerializeField] private int heal;
    [SerializeField] private HealthController _healthController;

    private void OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.Heal(heal);
        }
    }
}
