using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicCollision : MonoBehaviour {
    [SerializeField] private int damage;
    public HealthController _healthController;

    public MovementController player;
    public Rigidbody2D playerBody;

    private void Start() {
        Debug.Log("Things are happening");
        player = GameObject.Find("TurtleObject").GetComponent<MovementController>();
        playerBody = GameObject.Find("TurtleObject").GetComponent<Rigidbody2D>();
        Debug.Log(player.speed.ToString());
    }

    private IEnumerator OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.DoDamage(damage);
            Vector2 prevPlayer = player.speed;
            player.speed = new Vector2(0, 0);
            player.rebound();
            yield return new WaitForSeconds(1f);
            player.speed = prevPlayer;
        }
    }
}
