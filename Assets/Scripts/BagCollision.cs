using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCollision : MonoBehaviour {
    [SerializeField] private int damage;
    [SerializeField] private HealthController _healthController;
    [SerializeField] public MovementController _movementController;

    public MovementController player;

    private void Start() {
        player = GameObject.Find("TurtleObject").GetComponent<MovementController>();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.DoDamage(damage);
            player.speed.x *= 0.3F;
            player.speed.y *= 0.3F;
            yield return new WaitForSeconds(1f);
            player.speed.x /= 0.3F;
            player.speed.y /= 0.3F;
        }
    }
}
