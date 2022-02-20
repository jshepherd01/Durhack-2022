using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCollision : MonoBehaviour {
    [SerializeField] private int damage;
    [SerializeField] private HealthController _healthController;
    [SerializeField] public MovementController _movementController;
    private int bobTime = 240;
    private int count = 0;
    private float direction = 0.0005f;

    public MovementController player;

    private void Start() {
        player = GameObject.Find("TurtleObject").GetComponent<MovementController>();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.DoDamage(damage);
            GameObject playerObj = Collision.gameObject.transform.Find("TurtleSprite").gameObject;
            StartCoroutine(playerObj.GetComponent<PlayerColourController>().ApplyTempColor(Color.red));
            player.speed.x *= 0.3F;
            player.speed.y *= 0.3F;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(2f);
            player.speed.x /= 0.3F;
            player.speed.y /= 0.3F;
            Destroy(this.gameObject);
        }
    }

    private void Update() {
        if(count < bobTime) {
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + direction);
            count++;
        } else {
            direction *= -1;
            count = 0;
        }

    }
}
