using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OofOuchOwie : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private HealthController _healthController;

    private void OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.DoDamage(Damage);
        }
    }
}
