using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicCollision : MonoBehaviour {
    [SerializeField] private int damage;
    [SerializeField] private HealthController _healthController;
    [SerializeField] public MovementController _movementController;

    public MovementController player, camera;
    public Rigidbody2D playerBody, cameraBody;

    private void Start() {
        player = GameObject.Find("TurtleObject").GetComponent<MovementController>();
        playerBody = GameObject.Find("TurtleObject").GetComponent<Rigidbody2D>();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.DoDamage(damage);
            Vector2 prevPlayer = player.speed;
            player.speed = new Vector2(0, 0);
            playerBody.velocity = new Vector2(-1, -1);
            Debug.Log(playerBody.velocity.x.ToString());
            yield return new WaitForSeconds(1f);
            playerBody.velocity = new Vector2(0, 0);
            player.speed = prevPlayer;
        }
    }
}
