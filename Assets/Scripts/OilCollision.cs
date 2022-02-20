using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilCollision : MonoBehaviour {

    [SerializeField] private int damage;
    public HealthController _healthController;

    public MovementController player;
    public Rigidbody2D playerBody;
    public Vector2 defaultSpeed;
    public int decrement = 15;

    private void Start() {
        player = GameObject.Find("TurtleObject").GetComponent<MovementController>();
        playerBody = GameObject.Find("TurtleObject").GetComponent<Rigidbody2D>();
        defaultSpeed = player.speed;
    }

    private void OnTriggerStay2D(Collider2D Collision) {
        
        if (Collision.CompareTag("Player")) {
            if(decrement == 0){
                _healthController.DoDamage(damage);
                GameObject playerObj = Collision.gameObject.transform.Find("TurtleSprite").gameObject;
                StartCoroutine(playerObj.GetComponent<PlayerColourController>().ApplyTempColor(Color.red, 0.1f));
                decrement = 15;
            }
            player.speed = 0.5f * defaultSpeed;
            decrement--;
        }
    }

    private void OnTriggerExit2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            player.speed = defaultSpeed;
        }
    }
}
