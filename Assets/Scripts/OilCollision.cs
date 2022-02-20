using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilCollision : MonoBehaviour {

    [SerializeField] private int damage;
    public HealthController _healthController;

    public MovementController player;
    public Rigidbody2D playerBody;
    public Vector2 defaultSpeed;

    private void Start() {
        player = GameObject.Find("TurtleObject").GetComponent<MovementController>();
        playerBody = GameObject.Find("TurtleObject").GetComponent<Rigidbody2D>();
        defaultSpeed = player.speed;
    }

    

    private void OnTriggerStay2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            Debug.Log("awesome");
            _healthController.DoDamage(damage);
            player.speed = 0.5f * defaultSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            player.speed = defaultSpeed;
        }
    }
}
